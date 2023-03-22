if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_productos_importacion'
)
drop proc p_rpt_productos_importacion
go

-- exec p_rpt_productos_importacion '41129728-6e9b-4040-a092-a6da356794b6' 
create proc p_rpt_productos_importacion
@pUUID uniqueidentifier
as

	select UUID,
		p.Clave,
		p.Descripcion,
		b.Cantidad,
		Movimiento = mov.Descripcion,
		Fecha = convert(varchar,b.CreadoEl,103)
	from doc_productos_importacion_bitacora  b
	inner join cat_tipos_movimiento_inventario mov on mov.TipoMovimientoInventarioId = b.TipoMovimientoInventarioId
	inner join cat_productos p on p.ProductoId = b.productoId
	where UUID  = @pUUID