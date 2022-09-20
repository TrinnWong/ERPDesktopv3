if exists (
	select 1
	from sysobjects
	where name = 'p_productos_imagenes_sel'
)
drop proc p_productos_imagenes_sel
go
create proc p_productos_imagenes_sel
@pProductoId int
as
	select ProductoImageId,
			ProductoId,
			FileName,
			Principal
	from cat_productos_imagenes
	where ProductoId = @pProductoId