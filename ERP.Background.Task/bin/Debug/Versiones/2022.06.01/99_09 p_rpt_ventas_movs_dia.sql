if  exists (
	select 1
	from sysobjects
	where name = 'p_rpt_ventas_movs_dia'
)
drop proc p_rpt_ventas_movs_dia
go
-- p_rpt_ventas_movs_dia 4,'20230211','20230211'
create proc p_rpt_ventas_movs_dia
@pSucursalId INT,
@pFechaIni DATETIME,
@pFechaFin DATETIME
AS


	declare @ValorPreferencia VARCHAR(500),
			@UsarOtros BIT=0
	
	--Obtener productos que se quieren agrupar
	SELECT @ValorPreferencia = ISNULL(pe.Valor,'')
	FROM sis_preferencias_empresa PE
	INNER JOIN cat_sucursales S ON S.Clave = @pSucursalId
	INNER JOIN sis_preferencias P ON P.Id = PE.PreferenciaId AND P.Preferencia = 'CorteCajaSubReporteVentasProd'
	WHERE PE.EmpresaId = S.Empresa


	SELECT ProductoId = splitdata
	INTO #TMP_IdProdcutos
	FROM [dbo].[fnSplitString](@ValorPreferencia,',')

	

	CREATE TABLE #TMP_RESULT(
		Id Int IDENTITY(1,1),
		TipoId INT ,		
		Fecha DATETIME NULL,
		Detalle VARCHAR(250) NULL,
		Detalle2 VARCHAR(250) NULL,
		Cantidad FLOAT NULL,
		Valor	FLOAT,
		Abono BIT

	)
	CREATE TABLE #TMP_TIPOS(
		TipoId INT,
		Descripcion VARCHAR(250)
	)

	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(1,'VENTAS TOTALES')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(2,'RESUMEN DIARIO')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(3,'VENTAS POR PRODUCTO')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(4,'PEDIDOS PAGADOS')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(5,'PEDIDOS PENDIENTES DE PAGAR')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(6,'GASTOS')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(7,'RETIROS')
	INSERT INTO #TMP_TIPOS(TipoId,Descripcion)
	VALUES(8,'RETIRO FINAL')

	/************************VENTAS TOTALES*******************************/
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Valor,Abono)
	SELECT  1,
			'VENTAS',
			Sum(VD.Total),
			1
	FROM doc_ventas_detalle VD
	iNNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
							V.SucursalId = @pSucursalId AND
							CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE)
	
	WHERE V.Activo = 1 
	
	
	/**************************RESUMEN VENTAS*****************************/
	--RESUMEN
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Valor,Abono)
	SELECT  2,
			CASE WHEN MAX(TMP.ProductoId) = MAX(VD.ProductoId) THEN MAX(P.Descripcion) ELSE 'OTROS PRODUCTOS' END,
			Sum(VD.Total),
			1
	FROM doc_ventas_detalle VD
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
							V.SucursalId = @pSucursalId AND
							CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE)
	LEFT JOIN #TMP_IdProdcutos TMP ON TMP.ProductoId = VD.ProductoId
	WHERE V.Activo = 1 
	GROUP BY (CASE WHEN TMP.ProductoId IS NULL THEN 99999999 ELSE TMP.ProductoId END)
	ORDER BY (CASE WHEN TMP.ProductoId IS NULL THEN 99999999 ELSE TMP.ProductoId END) 


	/*************************VENTAS POR PRODUCTO*******************************/
	--RESUMEN
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Detalle2,Cantidad,Valor,Abono)
	SELECT  3,
			P.Descripcion,
			p.ProductoId,
			SUM(VD.Cantidad),
			Sum(VD.Total),
			1
	FROM doc_ventas_detalle VD
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
							V.SucursalId = @pSucursalId AND
							CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE)
	LEFT JOIN #TMP_IdProdcutos TMP ON TMP.ProductoId = VD.ProductoId
	WHERE V.Activo = 1 
	GROUP BY P.Descripcion,p.ProductoId
	ORDER BY p.ProductoId

	--GASTOS
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Valor,Abono)
	SELECT 6,'Gastos',SUM(G.Monto),0
	FROM doc_gastos G
	WHERE G.SucursalId = @pSucursalId AND
	G.Activo = 1 AND
	CAST(G.CreadoEl AS DATE) BETWEEN CAST(@pFechaIni AS DATE)AND CAST(@pFechaFin AS DATE)

	--RETIROS
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Valor,Abono)
	SELECT 7,'Retiros',SUM(R.MontoRetiro),0 
	FROM doc_retiros R
	WHERE R.SucursalId = @pSucursalId AND
	CAST(R.FechaRetiro AS DATE)  BETWEEN CAST(@pFechaIni AS DATE) AND  CAST(@pFechaFin AS DATE)

	--RETIRO FINAL
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Valor,Abono)
	SELECT 8,'Retiro Final',ISNULL(SUM(CCD.Total),0),0
	FROM doc_corte_caja_denominaciones CCD
	INNER JOIN doc_corte_caja CC ON CC.CorteCajaId = CCD.CorteCajaId AND
								CAST(CC.FechaCorte AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE)
	INNER JOIN cat_cajas C ON C.Clave = CC.CajaId AND
								C.Sucursal = @pSucursalId 
								
	--DIFERENCIA
	--INSERT INTO #TMP_RESULT(TipoId,Detalle,Valor,Abono)
	--SELECT 2,'Ventas - Gastos - Retiros - Retiro Final = ',(SUM(CASE WHEN Abono = 1 THEN Valor ELSE (Valor*-1) END))*-1,0
	--FROM #TMP_RESULT WHERE TipoId = 2


	/**********************PEDIDOS PAGADOS******************************/
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Detalle2,Cantidad,Valor,Abono)
	select 4,ISNULL(C.Nombre,'SIN NOMBRE') , P.DescripcionCorta,SUM(VD.Cantidad), SUM(VD.Total),1
	from doc_ventas V
	INNER JOIN cat_clientes C ON C.ClienteId = V.ClienteId
	INNER JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId AND
											V.SucursalId = @pSucursalId AND
											V.Activo = 1 AND 
											CAST(V.FechaCreacion AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE) 
	INNER JOIN doc_ventas_detalle VD ON VD.VentaId = V.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
	GROUP BY C.Nombre, P.DescripcionCorta

	/**********************PEDIDOS PENDIENTES DE PAGAR******************************/
	INSERT INTO #TMP_RESULT(TipoId,Detalle,Detalle2,Fecha,Cantidad,Valor,Abono)
	SELECT 5, ISNULL(C.Nombre,'SIN NOMBRE'),P.DescripcionCorta,PO.CreadoEl,SUM(POD.Cantidad),SUM(POD.Total),0
	FROM doc_pedidos_orden PO
	INNER JOIN cat_clientes C ON C.ClienteId = PO.ClienteId 
	INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId AND									 
									 PO.Activo = 1 AND
									 PO.VentaId IS NULL AND
									 PO.SucursalId = @pSucursalId
	INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	GROUP BY C.Nombre, P.DescripcionCorta,PO.CreadoEl
	ORDER BY C.Nombre


	SELECT TMP.Id,
			TIPO.TipoId,
			TIPO.Descripcion,
			TMP.Detalle,
			Detalle2=ISNULL(TMP.Detalle2,''),
			tmp.Fecha,
			Cantidad = ISNULL(TMP.Cantidad,0),	
			Total = ISNULL(TMP.Valor,0),
			TMP.Abono
	FROM #TMP_RESULT TMP
	INNER JOIN #TMP_TIPOS TIPO ON TIPO.TipoId = TMP.TipoId
