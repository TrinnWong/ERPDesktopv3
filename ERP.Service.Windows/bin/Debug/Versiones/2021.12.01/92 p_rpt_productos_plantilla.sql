CREATE PROC p_rpt_productos_plantilla
AS
SELECT PRODUCTO = P.Descripcion,
	LINEA = L.Descripcion,
	FAMILIA = F.Descripcion,
	EXISTENCIA_INICIAL = 0,
	PRECIO_VENTA = PP.Precio,
	CODIGO = P.Clave,
	SUBFAMILIA = SF.Descripcion,
	IVA = CASE WHEN PI.ImpuestoId IS NOT NULL THEN 16 ELSE 0 END,
	UNIDAD = UM.DescripcionCorta,
	MARCA = M.Descripcion,
	P.MateriaPrima,
	ParaVenta = p.ProdParaVenta,
	DescripcionCorta= p.DescripcionCorta,
	CostoPromedio = 0,
	Activo = p.Estatus,
	P.ProductoTerminado,
	P.Inventariable,
	P.ProdVtaBascula,
	p.Seriado,
	UnidadInventario = UM.DescripcionCorta,	
	UnidadVenta = UM.DescripcionCorta,
	p.MinimoInventario,
	p.MaximoInventario,
	P.ContenidoCaja,
	P.CodigoBarras
FROM cat_productos P
INNER JOIN cat_lineas L ON L.Clave = P.ClaveLinea
INNER JOIN cat_familias F ON F.Clave = P.ClaveFamilia
INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
							PP.IdPrecio = 1
INNER JOIN cat_subfamilias SF ON SF.Clave = P.ClaveSubFamilia
INNER JOIN cat_unidadesmed UM ON UM.Clave = P.ClaveUnidadMedida
LEFT JOIN cat_marcas M ON M.Clave = P.ClaveMarca
LEFT JOIN cat_productos_impuestos PI ON PI.ProductoId = P.ProductoId AND
								PI.ImpuestoId = 1

