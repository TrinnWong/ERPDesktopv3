------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- p_rpt_sucursal_mov_dia 0,'20230628','20230628',1
ALTER proc p_rpt_sucursal_mov_dia
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME,
@pUsuarioId INT,
@pTipo INT=1 --1 AGRUPAR POR DIA, 2 AGRUPAR SOLO POR SUCURSAL
AS


	CREATE TABLE #TMP_RESULT(
		Id INT IDENTITY(1,1),
		Fecha DATETIME,
		SucursalId INT,
		Sucursal VARCHAR(250),
		VentasMostradorTortilla MONEY,
		VentasMostradorMasa	MONEY,
		TotalVentaMostradorTortillaMasa MONEY NULL, --
		VentasRepartoTortilla MONEY,
		VentasRepartoMasa  MONEY,
		TotalRepartoMasaTortilla MONEY NULL,
		TotalGlobalMostradorRepartoTortillaMasa MONEY NULL,
		VentasMostradorOtros MONEY,		
		TotalGlobalVenta MONEY NULL,
		KilosVentaMostradorTortilla DECIMAL(14,3) NULL,--
		KilosVentaMostradorMasa DECIMAL(14,3) NULL,--
		KilosRepartoTortilla DECIMAL(14,3) NULL,--
		KilosRepartoMasa DECIMAL(14,3) NULL,--
		TotalKilosVentaRepartoTortilla DECIMAL(14,3) NULL,
		TotalKilosVentaRepartoMasa DECIMAL(14,3) NULL,
		DevolucionRepartoKilosTortilla DECIMAL(14,3) NULL,
		DevolucionRepartoKilosMasa  DECIMAL(14,3) NULL,
		TotalDevolucionesRepato DECIMAL(14,3) NULL,
		SobranteKilosTortilla DECIMAL(14,3) NULL,	
		SobranteKilosMasa DECIMAL(14,3) NULL,		
		Gastos		MONEY,
		GastosAdmon MONEY NULL,
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
		VentasMostradorOtros = SUM(CASE WHEN VD.ProductoId NOT IN (1,2) THEN VD.Total ELSE 0 END),
		KilosVentaMostradorTortilla = SUM(CASE WHEN VD.ProductoId = 1 THEN VD.Cantidad ELSE 0 END),--
		KilosVentaMostradorMasa = SUM(CASE WHEN VD.ProductoId = 2 THEN VD.Cantidad ELSE 0 END)
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
		--VentasMostradorMasa = SUM(CASE WHEN VD.ProductoId = 2 THEN VD.Total ELSE 0 END),
		VentasRepartoMasa = SUM(CASE WHEN VD.ProductoId = 2 THEN VD.Total ELSE 0 END),
		KilosRepartoTortilla = SUM(CASE WHEN VD.ProductoId = 1 THEN VD.Cantidad ELSE 0 END),--
		KilosRepartoMasa= SUM(CASE WHEN VD.ProductoId = 2 THEN VD.Cantidad ELSE 0 END)
	INTO #TMP_VENTAS_REPARTOS
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
						CAST(V.Fecha AS DATE) BETWEEN CAST(@pDel AS DATE) AND CAST(@pAl AS DATE)
	WHERE V.Activo = 1  and
	V.ClienteId IS NOT NULL AND
	@pSucursalId IN(0,V.SucursalId)
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
	G.Activo = 1  AND
	G.CajaId IS NOT NULL
	GROUP BY  CAST(G.CreadoEl AS date),G.SucursalId
	ORDER BY G.SucursalId,CAST(G.CreadoEl AS date)


	--Gastos
	SELECT 
		Fecha = CAST(G.CreadoEl AS date),
		G.SucursalId,		
		Gastos = SUM(G.Monto)
	INTO #TMP_GASTOS_ADMON
	FROM doc_gastos G
	WHERE @pSucursalId IN (0, G.SucursalId ) AND
	G.Activo = 1  AND
	G.CajaId IS NULL
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


	--REPARTO DEVOLUCIONES
	SELECT
		SucursalId = PO.SucursalId,
		Fecha = CAST(PO.CreadoEl AS DATE),
		DevolucionTortilla = SUM(CASE WHEN POD.ProductoId = 1 THEN POD.CantidadDevolucion ELSE 0 END),
		DevolucionMasa = SUM(CASE WHEN POD.ProductoId = 2 THEN POD.CantidadDevolucion ELSE 0 END),
		TotalRepartoDevolucion = SUM(POD.CantidadDevolucion * POD.PrecioUnitario)
	INTO #TMP_REPARTOS_DEVS
	FROM doc_pedidos_orden_detalle POD 
	INNER JOIN doc_pedidos_orden PO ON PO.PedidoId = POD.PedidoId
	INNER JOIN doc_ventas V ON V.VentaId = PO.VentaId AND
							@pSucursalId IN (V.SucursalId,0) AND
							CAST(PO.CreadoEl AS DATE) BETWEEN CAST(@pDel AS DATE) AND CAST(@pAl AS DATE) and							
							V.FechaCancelacion IS NULL
	GROUP BY PO.SucursalId,CAST(PO.CreadoEl AS DATE)

	--SOBRANTES TORTILLA
	SELECT PS.SucursalId,
		Fecha = CAST(PS.CreadoEl AS DATE) ,
		KilosSobrante = ISNULL(SUM(PS.CantidadSobrante),0)
	INTO #TMP_SOBRANTE_TORTILLA
	FROM doc_productos_sobrantes_registro PS 
	WHERE PS.ProductoId = 1	
	GROUP BY PS.SucursalId,CAST(PS.CreadoEl AS DATE) 

	--SOBRANTES MASA
	SELECT PS.SucursalId,
		Fecha = CAST(PS.CreadoEl AS DATE) ,
		KilosSobrante = ISNULL(SUM(PS.CantidadSobrante),0)
	INTO #TMP_SOBRANTE_MASA
	FROM doc_productos_sobrantes_registro PS 
	INNER JOIN cat_productos P ON P.ProductoId = PS.ProductoId
	WHERE P.Descripcion LIKE '%MASA%'
	GROUP BY PS.SucursalId,CAST(PS.CreadoEl AS DATE) 


	--ACTUALIZAR TEMPORAL VENTAS MOSTRADOR
	UPDATE #TMP_RESULT
	SET VentasMostradorTortilla = ISNULL(VM.VentasMostradorTortilla,0),
		VentasMostradorMasa = ISNULL(VM.VentasMostradorMasa,0),
		VentasMostradorOtros = ISNULL(VM.VentasMostradorOtros,0),
		KilosVentaMostradorTortilla =  ISNULL(VM.KilosVentaMostradorTortilla,0),
		KilosVentaMostradorMasa = ISNULL(VM.KilosVentaMostradorMasa,0)
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_VENTAS_MOSTRADOR VM ON VM.SucursalId = T1.SucursalId AND
										CAST(VM.Fecha AS date) = CAST(T1.Fecha AS date)

	--ACTUALIZAR TEMPORAL REPARTOS
	UPDATE #TMP_RESULT
	SET VentasRepartoTortilla  = ISNULL(VM.VentasRepartoTortilla,0),
		VentasRepartoMasa = ISNULL(VM.VentasRepartoMasa,0),
		KilosRepartoTortilla = ISNULL(VM.KilosRepartoTortilla,0),
		KilosRepartoMasa =  ISNULL(VM.KilosRepartoMasa,0)
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_VENTAS_REPARTOS VM ON VM.SucursalId = T1.SucursalId AND
										CAST(VM.Fecha AS date) = CAST(T1.Fecha AS date)

	--ACTUALIZAR TEMPORAL DEVS REPARTO
	UPDATE #TMP_RESULT
	SET DevolucionRepartoKilosMasa = ISNULL(D.DevolucionMasa,0),
		DevolucionRepartoKilosTortilla = ISNULL(D.DevolucionTortilla,0),
		TotalDevolucionesRepato = ISNULL(TotalRepartoDevolucion,0)
	FROM #TMP_RESULT T1
	LEFT JOIN #TMP_REPARTOS_DEVS D ON D.SucursalId = T1.SucursalId AND
									D.Fecha = T1.Fecha	

	--ACTUALIZAR TEMPORAL SOBRANTE TORTILLA
	UPDATE #TMP_RESULT
	SET SobranteKilosTortilla = ISNULL(S.KilosSobrante,0)
	FROM #TMP_RESULT T
	LEFT JOIN #TMP_SOBRANTE_TORTILLA S ON S.SucursalId = T.SucursalId AND
											S.Fecha = T.Fecha

	--ACTUALIZAR TEMPORAL SOBRANTE MASA
	UPDATE #TMP_RESULT
	SET SobranteKilosMasa = ISNULL(S.KilosSobrante,0)
	FROM #TMP_RESULT T
	LEFT JOIN #TMP_SOBRANTE_MASA S ON S.SucursalId = T.SucursalId AND
											S.Fecha = T.Fecha


	--ACTUALIZAR GASTOS
	UPDATE #TMP_RESULT
	SET Gastos = G.Gastos
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_GASTOS G ON G.SucursalId = T1.SucursalId AND
										CAST(G.Fecha AS date) = CAST(T1.Fecha AS date)

	--ACTUALIZAR GASTOS
	UPDATE #TMP_RESULT
	SET GastosAdmon = ISNULL(G.Gastos,0)
	FROM #TMP_RESULT T1
	INNER JOIN #TMP_GASTOS_ADMON G ON G.SucursalId = T1.SucursalId AND
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

	UPDATE #TMP_RESULT
	SET TotalVentaMostradorTortillaMasa = ISNULL(VentasMostradorTortilla,0) + ISNULL(VentasMostradorMasa,0),
		TotalRepartoMasaTortilla = ISNULL(VentasRepartoTortilla,0) + ISNULL(VentasRepartoMasa,0),
		TotalGlobalMostradorRepartoTortillaMasa = ISNULL(VentasMostradorTortilla,0) + ISNULL(VentasMostradorMasa,0) + ISNULL(VentasRepartoTortilla,0) + ISNULL(VentasRepartoMasa,0)

	/*
	TotalKilosVentaRepartoTortilla DECIMAL(14,3) NULL,
		TotalKilosVentaRepartoMasa DECIMAL(14,3) NULL,
	*/
	UPDATE #TMP_RESULT
	SET TotalGlobalVenta = ISNULL(TotalGlobalMostradorRepartoTortillaMasa,0) + ISNULL(VentasMostradorOtros,0),
	TotalKilosVentaRepartoTortilla = ISNULL(KilosVentaMostradorTortilla,0) + ISNULL(KilosRepartoTortilla,0),
	TotalKilosVentaRepartoMasa = ISNULL(KilosVentaMostradorMasa,0) + ISNULL(KilosRepartoMasa,0)


	IF(@pTipo = 2)
	BEGIN
		SELECT Id,
		   Fecha,
		   T.SucursalId,
		   Sucursal,
		   ISNULL(VentasMostradorTortilla, 0) AS VentasMostradorTortilla,
		   ISNULL(VentasMostradorMasa, 0) AS VentasMostradorMasa,
		   ISNULL(TotalVentaMostradorTortillaMasa, 0) AS TotalVentaMostradorTortillaMasa,
		   ISNULL(VentasRepartoTortilla, 0) AS VentasRepartoTortilla,
		   ISNULL(VentasRepartoMasa, 0) AS VentasRepartoMasa,
		   ISNULL(TotalRepartoMasaTortilla, 0) AS TotalRepartoMasaTortilla,
		   ISNULL(TotalGlobalMostradorRepartoTortillaMasa, 0) AS TotalGlobalMostradorRepartoTortillaMasa,
		   ISNULL(VentasMostradorOtros, 0) AS VentasMostradorOtros,
		   ISNULL(TotalGlobalVenta, 0) AS TotalGlobalVenta,
		   ISNULL(KilosVentaMostradorTortilla, 0) AS KilosVentaMostradorTortilla,
		   ISNULL(KilosVentaMostradorMasa, 0) AS KilosVentaMostradorMasa,
		   ISNULL(KilosRepartoTortilla, 0) AS KilosRepartoTortilla,
		   ISNULL(KilosRepartoMasa, 0) AS KilosRepartoMasa,
		   ISNULL(TotalKilosVentaRepartoTortilla, 0) AS TotalKilosVentaRepartoTortilla,
		   ISNULL(TotalKilosVentaRepartoMasa, 0) AS TotalKilosVentaRepartoMasa,
		   ISNULL(DevolucionRepartoKilosTortilla, 0) AS DevolucionRepartoKilosTortilla,
		   ISNULL(DevolucionRepartoKilosMasa, 0) AS DevolucionRepartoKilosMasa,
		   ISNULL(TotalDevolucionesRepato, 0) AS TotalDevolucionesRepato,
		   ISNULL(SobranteKilosTortilla, 0) AS SobranteKilosTortilla,
		   ISNULL(SobranteKilosMasa, 0) AS SobranteKilosMasa,
		   Gastos,
		   ISNULL(GastosAdmon, 0) AS GastosAdmon,
		   Retiros,
		   RetirosCorte,
		   RetirosTotal,
		   Maiz,
		   Maseca
		FROM #TMP_RESULT T
		INNER JOIN cat_usuarios_sucursales US ON US.UsuarioId = @pUsuarioId AND
											US.SucursalId = T.SucursalId
		ORDER BY Fecha, Sucursal
	END

	IF(@pTipo = 1)
	BEGIN
		SELECT Id = MAX(Id),
		   Fecha = MAX(Fecha),
		   T.SucursalId,
		   Sucursal,
		  SUM(ISNULL(VentasMostradorTortilla, 0)) AS VentasMostradorTortilla,
		   SUM(ISNULL(VentasMostradorMasa, 0)) AS VentasMostradorMasa,
		   SUM(ISNULL(TotalVentaMostradorTortillaMasa, 0)) AS TotalVentaMostradorTortillaMasa,
		   SUM(ISNULL(VentasRepartoTortilla, 0)) AS VentasRepartoTortilla,
		   SUM(ISNULL(VentasRepartoMasa, 0)) AS VentasRepartoMasa,
		   SUM(ISNULL(TotalRepartoMasaTortilla, 0)) AS TotalRepartoMasaTortilla,
		   SUM(ISNULL(TotalGlobalMostradorRepartoTortillaMasa, 0)) AS TotalGlobalMostradorRepartoTortillaMasa,
		   SUM(ISNULL(VentasMostradorOtros, 0)) AS VentasMostradorOtros,
		   SUM(ISNULL(TotalGlobalVenta, 0)) AS TotalGlobalVenta,
		   SUM(ISNULL(KilosVentaMostradorTortilla, 0)) AS KilosVentaMostradorTortilla,
		   SUM(ISNULL(KilosVentaMostradorMasa, 0)) AS KilosVentaMostradorMasa,
		   SUM(ISNULL(KilosRepartoTortilla, 0)) AS KilosRepartoTortilla,
		   SUM(ISNULL(KilosRepartoMasa, 0)) AS KilosRepartoMasa,
		   SUM(ISNULL(TotalKilosVentaRepartoTortilla, 0)) AS TotalKilosVentaRepartoTortilla,
		   SUM(ISNULL(TotalKilosVentaRepartoMasa, 0)) AS TotalKilosVentaRepartoMasa,
		   SUM(ISNULL(DevolucionRepartoKilosTortilla, 0)) AS DevolucionRepartoKilosTortilla,
		   SUM(ISNULL(DevolucionRepartoKilosMasa, 0)) AS DevolucionRepartoKilosMasa,
		   SUM(ISNULL(TotalDevolucionesRepato, 0)) AS TotalDevolucionesRepato,
		   SUM(ISNULL(SobranteKilosTortilla, 0)) AS SobranteKilosTortilla,
		   SUM(ISNULL(SobranteKilosMasa, 0)) AS SobranteKilosMasa,
		   SUM(Gastos) AS Gastos,
		   SUM(ISNULL(GastosAdmon, 0)) AS GastosAdmon,
		   SUM(Retiros) AS Retiros,
		   SUM(RetirosCorte) AS RetirosCorte,
		   SUM(RetirosTotal) AS RetirosTotal,
		   SUM(Maiz) AS Maiz,
		   SUM(Maseca) AS Maseca
		FROM #TMP_RESULT T
		INNER JOIN cat_usuarios_sucursales US ON US.UsuarioId = @pUsuarioId AND
											US.SucursalId = T.SucursalId
		GROUP BY T.SucursalId,Sucursal
		ORDER BY Fecha, Sucursal
	END



