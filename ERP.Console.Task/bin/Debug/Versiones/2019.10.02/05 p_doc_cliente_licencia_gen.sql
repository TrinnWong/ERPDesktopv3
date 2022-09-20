if exists (
	select 1
	from sysobjects
	where name = 'p_doc_cliente_licencia_gen'
)
drop proc p_doc_cliente_licencia_gen
go
create proc p_doc_cliente_licencia_gen
@pVentaId int
as 

	declare @ClienteLicenciaId int

	select @ClienteLicenciaId = isnull(max(ClienteLicenciaId),0) +1
	from doc_clientes_licencias
	
	insert into doc_clientes_licencias(
		ClienteLicenciaId,		ClienteId,		ProductoId,		FechaVigencia,
		Vigente,				CreadoEl,		ModificadoEl
	)
	select ROW_NUMBER() OVER(ORDER BY v.VentaId ASC),v.ClienteId,vd.ProductoId,
	case when pl.UnidadLicencia = 'd' then dateadd(dd,pl.TiempoLicencia,getdate())
		when pl.UnidadLicencia = 'm' then dateadd(mm,pl.TiempoLicencia,getdate())
		when pl.UnidadLicencia = 'y' then dateadd(yy,pl.TiempoLicencia,getdate())
	end,1,getdate(),getdate()
	from doc_ventas v
	inner join doc_ventas_detalle vd on vd.VentaId = v.VentaId
	inner join cat_productos_licencias pl on pl.ProductoId = vd.ProductoId
	where v.VentaId = @pVentaId and
	v.ClienteId is not null 

	if @@ROWCOUNT <= 0
		RAISERROR (15600,-1,-1, 'No fue posible generar la licencia del usuario');

	
