if exists (
	select 1
	from sysobjects
	where name = 'p_productos_importacion_bitacora_sel'
)
drop proc p_productos_importacion_bitacora_sel
go
create proc p_productos_importacion_bitacora_sel
as

	select UUID,
		  Fecha = convert(varchar,CreadoEl,103),
		  Producto = sum(cantidad)
	from [dbo].[doc_productos_importacion_bitacora]
	group by UUID,convert(varchar,CreadoEl,103)
	order by convert(varchar,CreadoEl,103) desc
