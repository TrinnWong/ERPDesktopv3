if exists (
	select 1
	from sysobjects
	where name = 'p_doc_clientes_licencia_sel'
)
drop proc p_doc_clientes_licencia_sel
go
create proc p_doc_clientes_licencia_sel
@pKeyClient varchar(100),
@pTipoProducto varchar(20),
@pVersion varchar(20)
as

	select cl.ClienteLicenciaId,
		cl.ClienteId,
		cl.ProductoId,
		cl.FechaVigencia,
		cl.Vigente,
		cl.CreadoEl,
		cl.ModificadoEl
	from doc_clientes_licencias cl
	inner join cat_clientes c on c.ClienteId = cl.clienteId
	--where cl.productoId = @pProductoId and
	--c.KeyClient = @pKeyClient