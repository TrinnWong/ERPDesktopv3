-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_ventas_gastos_sucursal 0,'20221101','20221220',0
ALTER PROC p_rpt_ventas_gastos_sucursal
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME,
@pUsuarioId INT=0

AS

	DECLARE @ProductoId1 INT= 1,
			@ProductoId2 INT = 2

	CREATE TABLE #TMP_RESULTADO(
		SucursalId INT,
		Sucursal VARCHAR(500),
		VentasProducto1 MONEY,
		VentasProducto2 MONEY,
		NombreProducto1 VARCHAR(500),
		NombreProducto2 VARCHAR(500),
		VentasOtros MONEY,
		VentasTotal MONEY,
		Gastos MONEY,
		Utilidad MONEY
	)


	--PRODUCTO 1
	SELECT V.SucursalId,
			VentasProducto1 = ISNULL(SUM(VD.Total),0)
	INTO #TMP_VENTAS_PRODUCTO1
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND	
							VD.ProductoId = @ProductoId1 AND
							CONVERT(VARCHAR,VD.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	WHERE @pSucursalId in (0,v.SucursalId) AND
	V.Activo = 1
	GROUP BY V.SucursalId

	--PRODUCTO 2
	SELECT V.SucursalId,
			VentasProducto1 = ISNULL(SUM(VD.Total),0)
	INTO #TMP_VENTAS_PRODUCTO2
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND	
							VD.ProductoId = @ProductoId2 AND
							CONVERT(VARCHAR,VD.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	WHERE @pSucursalId in (0,v.SucursalId) AND
	V.Activo = 1
	GROUP BY V.SucursalId


	--VENTAS OTROS
	SELECT V.SucursalId,
			VentasOtros = ISNULL(SUM(VD.Total),0)
	INTO #TMP_VENTAS_OTROS
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND	
							VD.ProductoId NOT IN (@ProductoId1,@ProductoId2) AND
							CONVERT(VARCHAR,VD.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	WHERE @pSucursalId in (0,v.SucursalId) AND
	V.Activo = 1
	GROUP BY V.SucursalId

	--GASTOS
	SELECT G.SucursalId,
		Gastos = ISNULL(SUM(G.Monto),0)
	INTO #TMP_GASTOS
	FROM doc_gastos G
	WHERE G.Activo = 1 AND
	CONVERT(VARCHAR,g.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	GROUP BY G.SucursalId

	INSERT INTO #TMP_RESULTADO(
		SucursalId ,		Sucursal ,		VentasProducto1 ,		VentasProducto2 ,
		NombreProducto1 ,	NombreProducto2 ,VentasOtros ,			VentasTotal ,
		Gastos ,			Utilidad 
	)
	SELECT S.Clave,			S.NombreSucursal,ISNULL(MAX(VP1.VentasProducto1),0), ISNULL(MAX(VP2.VentasProducto1),0),
	MAX(P1.Descripcion),	MAX(P2.Descripcion),ISNULL(MAX(VO.VentasOtros),0), ISNULL(MAX(VP1.VentasProducto1),0) + ISNULL(MAX(VP2.VentasProducto1),0) + ISNULL(MAX(VO.VentasOtros),0),
	ISNULL(MAX(G.Gastos),0),			0
	FROM cat_sucursales S
	LEFT JOIN #TMP_VENTAS_PRODUCTO1 VP1 ON VP1.SucursalId = S.Clave
	LEFT JOIN #TMP_VENTAS_PRODUCTO2 VP2 ON VP2.SucursalId = S.Clave
	LEFT JOIN #TMP_VENTAS_OTROS VO ON VO.SucursalId = S.Clave
	LEFT JOIN #TMP_GASTOS G ON G.SucursalId = S.Clave
	LEFT JOIN cat_productos P1 ON P1.ProductoId = @ProductoId1
	LEFT JOIN cat_productos P2 ON P2.ProductoId = @ProductoId2
	group by S.Clave,			S.NombreSucursal

	update #TMP_RESULTADO
	set VentasTotal = isnull(VentasProducto1,0) + isnull(VentasProducto2,0) + isnull(VentasOtros,0)

	update #TMP_RESULTADO
	set Utilidad = VentasTotal - Gastos

	SELECT distinct	TMP.* 
	FROM #TMP_RESULTADO TMP
	INNER JOIN cat_usuarios_sucursales US ON @pUsuarioId IN (0,US.UsuarioId) AND
										US.SucursalId = TMP.SucursalId
	WHERE Utilidad <> 0
	ORDER BY VentasTotal DESC

