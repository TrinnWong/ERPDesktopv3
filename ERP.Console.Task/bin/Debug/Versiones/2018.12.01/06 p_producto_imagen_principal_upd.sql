IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_producto_imagen_principal_upd'
)
DROP PROC p_producto_imagen_principal_upd
GO
create proc p_producto_imagen_principal_upd
@pProductoImagenId int
as

	declare @pProductoId int

	select @pProductoId = ProductoId
	from cat_productos_imagenes
	where ProductoImageId = @pProductoImagenId

	update cat_productos_imagenes
	set Principal = 0
	where ProductoId = @pProductoId

	update cat_productos_imagenes
	set Principal = 1
	where ProductoImageId = @pProductoImagenId



