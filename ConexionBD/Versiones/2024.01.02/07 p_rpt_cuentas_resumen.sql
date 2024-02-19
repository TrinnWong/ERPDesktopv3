--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_cuentas_resumen 2,'20231214','20231214',0,0,0,1
ALTER PROC p_rpt_cuentas_resumen
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME,
@pMaizInventario DECIMAL(14,3)=0,
@pMasecaInventario DECIMAL(14,3)=0,
@pTotalRepartoRecuperacion DECIMAL(14,3)=0,
@pUsuarioId INT
AS

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	DECLARE @PrecioSacoMaiz MONEY=0,
			@PrecioSacoMaseca MONEY=0,
			@PrecioTortilla MONEY = 0,
			@RecuperacionTotal MONEY=0,
			@Gastos MONEY=0,
			@UtilidadSucursal DECIMAL(14,3),
			@UtilidadEmpresa DECIMAL(14,3)


	CREATE TABLE #TMP_RESULT
	(
		Id INT IDENTITY(1,1),
		Sucursal VARCHAR(200),
		MaizSacosEntrada DECIMAL(14,3) default 0,
		MasecaSacosEntrada DECIMAL(14,3) default 0,
		MaizInvFinal  DECIMAL(14,3) default 0,
		MasecaInvFinal  DECIMAL(14,3) default 0,
		MaizSacosPagar DECIMAL(14,3) default 0,
		MasecaSacosPagar DECIMAL(14,3) default 0,
		MaizSacoRendimiento DECIMAL(14,3) default 0,
		MasecaSacoRendimiento DECIMAL(14,3) default 0,
		MaizSacoRendimientoTortilla DECIMAL(14,3) default 0,
		MasecaSacoRendimientoTortilla DECIMAL(14,3) default 0,
		TortillaPrecioKilo MONEY default 0,--Precio por Kilo
		MaizTotalProduccion MONEY default 0,--Total Prod. Maiz y maseca
		MasecaTotalProduccion MONEY default 0, --Total Prod. Maiz y maseca
		TortillaVentaTotal MONEY default 0, --Total venta tortilla
		RepartoRecuperacionTotal MONEY default 0,--Recuperacion 2 Pesos Vtas reparto
		TortillaVentaTotal2 MONEY default 0, --Total venta tortilla
		PagosMaseca MONEY default 0,--Pagos a Maseca
		PagosMaiz MONEY default 0,--Consumo de Maiz
		Gastos MONEY default 0,
		Utilidad MONEY default 0,
		Utilidad60 MONEY default 0,
		ConsumoMaiz MONEY default 0,
		TotalPago MONEY default 0,
		Utilidad40 MONEY default 0,
		MaizSacoCosto MONEY default 0,
		MasecaSacoCosto MONEY default 0
		
	)

	SELECT @UtilidadSucursal = CAST(ISNULL([dbo].[fnGetPreferenciaValor]('UtilidadSucursal',@pSucursalId),0) AS DECIMAL(14,2));
	SET @UtilidadEmpresa = 100 - @UtilidadSucursal;


	SELECT @PrecioSacoMaiz = MAX(PP.Precio)
	FROM cat_productos P
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId
	WHERE P.Clave = 'MP001'

	SELECT @PrecioSacoMaseca = MAX(PP.Precio)
	FROM cat_productos P
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId
	WHERE P.Clave = 'MP002'


	--SUCURSAL
	INSERT INTO #TMP_RESULT(Sucursal)
	SELECT NombreSucursal
	FROM cat_sucursales S
	INNER JOIN cat_usuarios_sucursales US  ON US.UsuarioId = @pUsuarioId AND
										US.SucursalId = S.Clave
	where Clave = @pSucursalId

	UPDATE #TMP_RESULT
	SET MaizSacoCosto = @PrecioSacoMaiz,
	MasecaSacoCosto = @PrecioSacoMaseca

	--*************SACOS ENTRADA****************
	SELECT	MaizSacos = ISNULL(SUM(T1.MaizSacos),0) ,
		MasecaSacos = ISNULL(SUM(T1.MasecaSacos),0),
		SucursalId = T1.SucursalId
	INTO #TMP_MAIZ_MASECA_ENTRADA
	FROM doc_maiz_maseca_entrada T1
	WHERE SucursalId = @pSucursalId AND
	CAST(T1.Fecha AS DATE) BETWEEN  CAST(@pDel AS DATE) AND CAST(@pAl AS DATE)
	GROUP BY T1.SucursalId

	UPDATE #TMP_RESULT
	SET MaizSacosEntrada = MaizSacos,
		MasecaSacosEntrada = MasecaSacos
	FROM #TMP_RESULT TMP
	INNER JOIN #TMP_MAIZ_MASECA_ENTRADA TMP2 ON TMP2.SucursalId = @pSucursalId

	--*******************MAIZ/MASECA INV FINAL***********************
	UPDATE #TMP_RESULT
	SET MaizInvFinal = @pMaizInventario,
		MasecaInvFinal = @pMasecaInventario

	--****************Sacos Maiz/maseca a pagar**********************
	UPDATE #TMP_RESULT
	SET MaizSacosPagar = MaizSacosEntrada - MaizInvFinal  ,
		MasecaSacosPagar = MasecaSacosEntrada - MasecaInvFinal

	--***************Rendimineto por saco*************************
	UPDATE  #TMP_RESULT
	SET MaizSacoRendimiento = CAST(isnull(PS.Valor,0) AS DECIMAL(14,2))
	FROM #TMP_RESULT TMP
	INNER JOIN sis_preferencias_sucursales PS ON PS.SucursalId = @pSucursalId
	INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId AND
								P.Preferencia IN ('PROD-EquivalenciaMaizSacoTortillaKg')

	UPDATE  #TMP_RESULT
	SET MasecaSacoRendimiento = CAST(isnull(PS.Valor,0) AS DECIMAL(14,2))
	FROM #TMP_RESULT TMP
	INNER JOIN sis_preferencias_sucursales PS ON PS.SucursalId = @pSucursalId
	INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId AND
								P.Preferencia IN ('PROD-EquivalenciaMasecaSacoTortillaKg')

	--***************Rend. Kilos tortilla****************
	UPDATE #TMP_RESULT
	SET MaizSacoRendimientoTortilla = MaizSacoRendimiento * MaizSacosPagar,
		MasecaSacoRendimientoTortilla = MasecaSacoRendimiento * MasecaSacosPagar

	--*****************Precio por Kilo*****************************
	UPDATE #TMP_RESULT
	SET TortillaPrecioKilo = (SELECT ISNULL(MAX(S1.PrecioUnitario),0) FROM doc_ventas_detalle S1 WHERE S1.ProductoId = 1 AND CAST(S1.FechaCreacion AS DATE) BETWEEN CAST(@pDel AS DATE) AND  CAST(@pAl AS DATE) )


	--**********Total Prod. Maiz y maseca***************
	update  #TMP_RESULT
	SET MaizTotalProduccion = TortillaPrecioKilo * MaizSacoRendimientoTortilla,
		MasecaTotalProduccion = TortillaPrecioKilo * MasecaSacoRendimientoTortilla

	--***********Total venta tortilla*************
	UPDATE #TMP_RESULT
	SET TortillaVentaTotal = MaizTotalProduccion + MasecaTotalProduccion

	--************Recuperacion 2 Pesos Vtas reparto****************	
	SELECT @RecuperacionTotal = ISNULL(SUM(VD.Cantidad),0) * 2
	FROM DOC_VENTAS_DETALLE VD 
	INNER JOIN DOC_VENTAS V ON V.VentaId = VD.VentaId AND
								V.Activo = 1 AND
								V.SucursalId = @pSucursalId AND
								CAST(V.Fecha AS DATE) BETWEEN CAST(@pDel AS DATE) and CAST(@pAl AS DATE) AND
								VD.ProductoId IN (1,2) AND FechaCancelacion IS NULL AND
								V.ClienteId IS NOT NULL
	--INNER JOIN DOC_PEDIDOS_ORDEN PO  ON PO.VentaId = V.VentaId
	
	UPDATE #TMP_RESULT
	SET RepartoRecuperacionTotaL = CASE  WHEN @pTotalRepartoRecuperacion > 0 THEN @pTotalRepartoRecuperacion ELSE  @RecuperacionTotal END

	--*************Total venta tortilla***************
	UPDATE #TMP_RESULT
	SET TortillaVentaTotal2 = TortillaVentaTotal - RepartoRecuperacionTotaL


	--Pagos a Maseca
	UPDATE #TMP_RESULT
	SET PagosMaseca = MasecaSacosPagar * @PrecioSacoMaseca,
		PagosMaiz = MaizSacosPagar * @PrecioSacoMaiz


	--Gatos en general
	SELECT @Gastos = ISNULL(SUM(G.Monto),0)
	FROM doc_gastos G
	INNER JOIN cat_gastos_deducibles GD ON GD.GastoConceptoId = G.GastoConceptoId
	WHERE G.SucursalId = @pSucursalId AND
	G.Activo = 1 AND
	CAST(G.CreadoEl AS DATE) BETWEEN CAST(@pDel AS DATE) AND CAST(@pAl AS DATE)

	UPDATE #TMP_RESULT
	SET Gastos = @Gastos

	--Utilidad Tortilleria
	UPDATE #TMP_RESULT
	SET Utilidad = CASE WHEN ( TortillaVentaTotal2 - PagosMaiz - PagosMaseca - Gastos) < 0 THEN 0 ELSE ( TortillaVentaTotal2 - PagosMaiz - PagosMaseca - Gastos) END

	--Utilidad Tortilleria
	UPDATE #TMP_RESULT
	SET Utilidad60 =Utilidad * (@UtilidadEmpresa/100)

	--Utilidad Tortilleria
	UPDATE #TMP_RESULT
	SET ConsumoMaiz = PagosMaiz

	--Total a paga a Don Juan
	UPDATE #TMP_RESULT
	SET TotalPago = PagosMaiz + Utilidad60


	--Utilidad Encargado 40%
	UPDATE #TMP_RESULT
	SET Utilidad40 = Utilidad * (@UtilidadSucursal/100)

	SELECT * FROM #TMP_RESULT
	
	

