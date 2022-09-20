if  exists (
	select 1
	from sysobjects
	where name = 'p_productos_importacion_validar'
)
drop proc p_productos_importacion_validar
go

-- p_productos_importacion_validar 1,1,''
create proc p_productos_importacion_validar
@pSucursald int,
@pProductoId int
as

	declare @respuesta as bit

	if exists (select 1
	from doc_inv_movimiento m
	inner join doc_inv_movimiento_detalle md on md.MovimientoId = m.MovimientoId
	where SucursalId = @pSucursald and
	md.ProductoId = @pProductoId and
	m.Activo = 1 and
	m.TipoMovimientoId in (1,7) and
	convert(varchar,m.FechaMovimiento,112) = convert(varchar,GETDATE(),112))
	begin
		set @respuesta = 1
	end
	Else
	Begin
		set @respuesta = 0
		
	End

	select Respuesta = @respuesta

	
