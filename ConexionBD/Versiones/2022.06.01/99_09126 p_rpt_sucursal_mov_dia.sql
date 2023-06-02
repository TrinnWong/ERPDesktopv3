
-- p_rpt_sucursal_mov_dia 0,'20230501','20230515',1
ALTER proc p_rpt_sucursal_mov_dia
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME,
@pUsuarioId INT
AS


	CREATE TABLE #TMP_RESULT(
		Id INT IDENTITY(1,1),
		Fecha DATETIME,
		SucursalId INT,
		Sucursal VARCHAR(250),
		VentasMostradorTortilla MONEY,
		VentasMostradorMasa	MONEY,
		VentasMostradorOtros MONEY,
		VentasRepartoTortilla MONEY,
		VentasRepartoMasa  MONEY,
		Gastos		MONEY,
		Retiros		MONEY,
		RetirosCorte MONEY,
		RetirosTotal MONEY,
		Maiz		DECIMAL(14,3),
		Maseca		DECIMAL(14,3)
	)

	INSERT INTO #TMP_RESULT(Fecha,SucursalId,Sucursal,VentasMostradorTortilla,VentasMostradorMasa,VentasMostradorOtros,
	VentasRepartoTortilla,VentasRepartoMasa,Gastos,Retiros,RetirosCorte,RetirosTotal,Maiz,Maseca)
	SELECT CAST(DATEADD(DAY,number,@pDel) AS DATE), S.Clave,S.NombreSucursal,0,0,0,0,0,
	0,0,0,0,0,0
	FROM master..spt_values D
	INNER JOIN cat_sucursales S ON @pSucursalId IN (0,S.Clave)
	INNER JOIN cat_usuarios_sucursales US ON US.UsuarioId = @pUsuarioId AND
										US.SucursalId = S.Clave
	WHERE D.type = 'P'
	AND DATEADD(DAY,number,@pDel) <= @pAl

	--VENTAS MOSTRADOR
	SELECT V.SucursalId,
		Fecha = CAST(V.Fecha AS date),
		VentasMostradorTortilla = SUM(CASE WHEN VD.ProductoId = 1 THEN VD.Total ELSE 0 END),
		VentasMostradorMasa = SUM(CASE WHEN VD.ProductoId = 2 THEN VD.Total ELSE 0 END),
		VentasMostradorOtros = SUM(CASE WHEN VD.ProductoId NOT IN (1,2) THEN VD.Total ELSE 0 END)
	INTO #TMP_VENTAS_MOSTRADOR
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND 
							CAST(V.Fecha AS date) BETWEEN CAST(@pDel AS date) AND CAST(@pAl AS date)
	WHERE V.Activo = 1  and
	V.ClienteId IS NULL
	GROUP BY V.SucursalId,CAST(V.Fecha AS date)
	ORDER BY V.SucursalId,CAST(V.Fecha AS date)


	--repartos
	SELECT V.SucursalId,
		Fecha = CAST(V.Fecha AS date),
		VentasRepartoTortilla = SUM(CASE WHEN VD.ProductoId = 1 THEN VD.Total ELSE 0 END),
		VentasMostradorMasa = SUM(CASE WHEN VD.ProductoId = 2 THEN VD.Total ELSE 0 END),
		VentasRepartoMasa = SUM(CASE WHEN VD.ProductoId NOT IN (1,2) THEN VD.Total ELSE 0 END)
	INTO #TMP_VENTAS_REPARTOS
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
						CAST(V.Fecha AS DATE) BETWEEN CAST(@pDel AS DATE) AND CAST(@pAl AS DATE)
	WHERE V.Activo = 1  and
	V.ClienteId IS NOT NULL
	GROUP BY V.SucursalId,CAST(V.Fecha AS date)
	ORDER BY V.SucursalId,CAST(V.Fecha AS date)


	--Gastos
	SELECT 
		Fecha = CAST(G.CreadoEl AS date),
		G.SucursalId,		
		Gastos = SUM(G.Monto)
	INTO #TMP_GASTOS
	FROM doc_gastos G
	WHERE @pSucursalId IN (0, G.SucursalId ) AND
	G.Activo = 1 
	GROUP BY  CAST(G.CreadoEl AS date),G.SucursalId
	ORDER BY G.SucursalId,CAST(G.CreadoEl AS date)

	--Retiros
	SELECT R.SucursalId,
		Fecha = Cast(R.FechaRetiro as date),
		Retiros = SUM(R.MontoRetiro)
	INTO #TMP_RETIROS
	FROM doc_retiros R
	WHERE @pSucursalId IN (0,R.SucursalId) AND
	CAST(R.FechaRetiro AS date) BETWEEN CAST(@pDel AS date) AND CAST(@pAl AS date)
	GROUP BY R.SucursalId, R.FechaRetiro

	--Retiro Final
	SELECT SucursalId = C.Sucursal,
		Fecha = cast(CC.CreadoEl as date),
		Retiros = SUM(CCD.Total)
	INTO #TMP_RETIROS_CC
	FROM doc_corte_caja_denominaciones CCD
	INNER JOIN doc_corte_caja CC ON CC.CorteCajaId = CCD.CorteCajaId AND 
									CAST(CC.CreadoEl AS date) BETWEEN CAST(@pDel AS date) AND CAST(@pAl AS date)
	INNER JOIN cat_cajas C ON C.Clave = CC.CajaId AND @pSucursalId IN (0,C.Sucursal)
	GROUP BY C.Sucursal, cast(CC.CreadoEl as date)

	--ACTUALIZAR TEMPORAL VENTAS MOSTRADOR
	UPDATE #TMP_RESULT
	SET VentasMostradorTortilla = ISNULL(VM.VentasMostradorTortilla,0),
		VentasMostradorMasa = ISNULL(VM.VentasMostradorMasa,0),
		VentasMostradorOtros = ISNULL(VM.VentasMostradorOtros,0)
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_VENTAS_MOSTRADOR VM ON VM.SucursalId = T1.SucursalId AND
										CAST(VM.Fecha AS date) = CAST(T1.Fecha AS date)


	--ACTUALIZAR TEMPORAL REPARTOS
	UPDATE #TMP_RESULT
	SET VentasRepartoTortilla  = ISNULL(VM.VentasRepartoTortilla,0),
		VentasRepartoMasa = ISNULL(VM.VentasRepartoMasa,0)
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_VENTAS_REPARTOS VM ON VM.SucursalId = T1.SucursalId AND
										CAST(VM.Fecha AS date) = CAST(T1.Fecha AS date)


	--ACTUALIZAR GASTOS
	UPDATE #TMP_RESULT
	SET Gastos = G.Gastos
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_GASTOS G ON G.SucursalId = T1.SucursalId AND
										CAST(G.Fecha AS date) = CAST(T1.Fecha AS date)

	--ACTUALIZAR RETIROS
	UPDATE #TMP_RESULT
	SET Retiros = R.Retiros
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_RETIROS R ON R.SucursalId = T1.SucursalId AND
										CAST(R.Fecha AS date) = CAST(T1.Fecha AS date)

	--ACTUALIZAR RETIROS CORTE
	UPDATE #TMP_RESULT
	SET RetirosCorte = R.Retiros
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_RETIROS_CC R ON R.SucursalId = T1.SucursalId AND
										CAST(R.Fecha AS date) = CAST(T1.Fecha AS date)

	--ACTUALIZAR RETIROS TOTAL
	UPDATE #TMP_RESULT
	SET RetirosTotal = Retiros + RetirosCorte

	--ACTUALZIAR CONSUMO MAIZ  MASECA
	--ACTUALIZAR RETIROS CORTE
	UPDATE #TMP_RESULT
	SET Maiz = M.MaizSacos,
		Maseca = m.MasecaSacos
	FROM #TMP_RESULT T1
	INNER JOIN doc_maiz_maseca_rendimiento M ON M.SucursalId = T1.SucursalId AND
											CAST(M.CreadoEl AS DATE) = cast(T1.Fecha as date)


	SELECT *
	FROM #TMP_RESULT
	ORDER BY Fecha,Sucursal

