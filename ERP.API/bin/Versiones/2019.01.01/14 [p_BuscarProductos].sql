


-- p_BuscarProductos '1',1
alter PROC [dbo].[p_BuscarProductos]
@pText VARCHAR(100),
@pBuscarSoloPorClave bit
AS

SELECT PRO.Clave,
		Descripcion = pro.Descripcion +' '+ isnull(pro.Talla,''),
		Unidad = u.Descripcion ,
		Precio = isnull(precio.Precio,0),
		ID = pro.ProductoId,
		impuestos = CASE WHEN  SUM(imp2.Porcentaje)  > 0 
					THEN (SUM(imp2.Porcentaje) / 100) * ISNULL(precio.Precio,0)
					ELSE 0
				END,
		porcImpuestos = SUM(imp2.Porcentaje),
		Foto = (SELECT foto FROM cat_productos t1 WHERE t1.ProductoId = pro.ProductoId),
		pro.Estatus

FROM dbo.cat_productos pro
left JOIN dbo.cat_productos_precios precio ON 
						precio.IdProducto = pro.ProductoId AND
                        precio.IdPrecio = 1 --publico gral
LEFT JOIN dbo.cat_productos_impuestos imp ON imp.ProductoId = pro.ProductoId
LEFT JOIN dbo.cat_impuestos imp2 ON imp2.Clave = imp.ImpuestoId
left JOIN dbo.cat_unidadesmed u ON u.Clave = pro.ClaveUnidadMedida
WHERE (pro.Descripcion LIKE '%'+RTRIM(@pText)+'%' AND @pBuscarSoloPorClave = 0)
OR
(pro.DescripcionCorta LIKE '%'+RTRIM(@pText)+'%' AND @pBuscarSoloPorClave = 0)
OR
(pro.Clave like '%'+RTRIM(@pText)+'%' AND @pBuscarSoloPorClave = 0)
OR
(pro.Clave = RTRIM(@pText) AND @pBuscarSoloPorClave = 1)
GROUP BY PRO.Clave,
		pro.Descripcion,
		u.Descripcion,
		precio.Precio,
		pro.ProductoId,
		pro.Estatus,
		pro.Talla
ORDER BY pro.Descripcion












