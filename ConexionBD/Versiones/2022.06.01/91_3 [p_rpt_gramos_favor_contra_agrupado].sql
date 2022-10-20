-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_gramos_favor_contra_agrupado 9,'20221019','20221019'
ALTER PROC [dbo].[p_rpt_gramos_favor_contra_agrupado]
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
AS

	CREATE TABLE #TMP_RESULT(
		Tipo VARCHAR(100),
		VentaDetalleId INT,
		NombreSucursal VARCHAR(500),
		GramosFavorContra FLOAT,
		Producto VARCHAR(500),
		FolioVenta VARCHAR(100),
		Importe MONEY
	)


	INSERT INTO #TMP_RESULT
	--GRAMOS A FAVOR
	SELECT 	
		'GRAMOS A FAVOR',
		VD.VentaDetalleId,
		S.NombreSucursal,
		GramosFavorContra = Cantidad - Total/PrecioUnitario,
		Producto = P.DescripcionCorta,
		FolioVenta = V.Serie + V.Folio,
		Importe = VD.PrecioUnitario * (Cantidad - Total/PrecioUnitario)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND v.Activo = 1 AND
														@pSucursalId IN (v.SucursalId,0 ) 
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId AND p.ProdVtaBascula = 1
	INNER JOIN cat_sucursales S ON S.Clave = V.SucursalId
	WHERE (PrecioUnitario * Cantidad) <> Total AND
	PrecioUnitario > 0 AND
	CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)

	UNION 

	--GRAMOS EN CONTRA

	SELECT 	
		'GRAMOS EN CONTRA',
		VD.VentaDetalleId,
		S.NombreSucursal,
		GramosFavorContra = (Total % 1) - 1,
		Producto = P.DescripcionCorta,
		FolioVenta = V.Serie + V.Folio,
		Importe = VD.PrecioUnitario * ((Total % 1) - 1)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId and v.Activo = 1 AND @pSucursalId IN (V.SucursalId,0 )  
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId AND p.ProdVtaBascula = 1
	INNER JOIN cat_sucursales S ON S.Clave = V.SucursalId
	WHERE (Cantidad % 1 BETWEEN .875 AND .999  AND VD.Total = VD.PrecioUnitario) AND
	PrecioUnitario > 0 AND	
	CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)

	SELECT Tipo,
		Total = SUM(Importe)
	FROM #TMP_RESULT
	GROUP BY Tipo

