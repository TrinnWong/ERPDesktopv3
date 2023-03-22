

UPDATE cat_productos
SET Estatus = 0,
	ProdParaVenta = 0
FROM cat_productos P
INNER JOIN cat_familias F ON F.Clave = p.ClaveFamilia
WHERE F.Descripcion = 'TACO INDIVIDUAL'