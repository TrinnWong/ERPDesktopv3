IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_empleados_productos_descuentos_grd'
)
DROP PROC p_empleados_productos_descuentos_grd
GO
create proc p_empleados_productos_descuentos_grd
@pEmpleadoId INT
as

	SELECT 
			PD.Id,
			ClaveProducto = P.Clave,
			Producto = P.DescripcionCorta,
			MontoDescuento = PD.MontoDescuento,
			Precio = PP.Precio,
			PrecioDescuento = PP.Precio - ISNULL(PD.MontoDescuento,0),
			p.ProductoId
	FROM  doc_empleados_productos_descuentos PD
	INNER JOIN cat_productos P ON P.ProductoId = PD.ProductoId
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
										PP.IdPrecio = 1--Publico en General
	--WHERE EmpleadoId = @pEmpleadoId 