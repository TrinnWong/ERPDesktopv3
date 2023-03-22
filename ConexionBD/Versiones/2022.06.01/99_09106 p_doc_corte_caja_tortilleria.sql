IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_corte_caja_tortilleria'
)
DROP PROC p_doc_corte_caja_tortilleria
GO

-- p_doc_corte_caja_tortilleria 6,'20230315','20230315',1
CREATE PROC p_doc_corte_caja_tortilleria
@pSucursalId INT,
@pFechaIni DATETIME,
@pFechaFin DATETIME,
@pUsuarioId INT
AS

	DECLARE @SacosMaiz FLOAT,
		@SacosMaseca FLOAT,
		@KilosTortillaTotal FLOAT,
		@PrecioTortilla FLOAT,
		@MasaProdFinal FLOAT,
		@TotalEntradas FLOAT,
		@TotalRetiros FLOAT,
		@SobranteMasaDiaAnterior FLOAT,
		@GramosMermaMayoreoKilo FLOAT=.07

	 CREATE TABLE #TMP_TIPOS(
		TipoId INT,
		Tipo VARCHAR(250)
	 )
	 
	 CREATE TABLE #TMP_RESULTADO      
	 (      
	  Fila int identity(1,1),      
	  TipoId INT,      
	  Concepto VARCHAR(450),      
	  Abono BIT,      
	  Cantidad decimal(14,3),      
	  PrecioUnitario MONEY,      
	  Total  decimal(14,3),
	  Clave  varchar(50) NULL,
	  Mostrar BIT NULL DEFAULT 1,
	  TotalEntradas DECIMAL(14,3) NULL,
	  TotalDescuentos DECIMAL(14,3) NULL,
	  TotalRetiros DECIMAL(14,3) NULL,
	  TotalDiferencia DECIMAL(14,3) NULL,
	  TotalRequerido DECIMAL(14,3) NULL,
	  TotalRegistradoSistema DECIMAL(14,3) NULL
	 )      

	 SELECT VD.ProductoId,Fecha = CAST(V.Fecha AS date),Precio = MAX(VD.PrecioUnitario)
	 INTO #TMP_PRECIOS_HIS
	 FROM doc_ventas_detalle VD
	 INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	 WHERE V.SucursalId = @pSucursalId AND
	 V.ClienteId IS NULL AND
	 CAST(V.Fecha AS date) BETWEEN CAST(@pFechaIni AS DATE)AND CAST(@pFechaFin AS date) 
	 GROUP BY VD.ProductoId,CAST(V.Fecha AS date)


	 SELECT @SobranteMasaDiaAnterior = SUM(PS.CantidadSobrante)
	 FROM doc_productos_sobrantes_registro PS
	 INNER JOIN cat_productos P ON P.ProductoId = PS.ProductoId AND
								P.Clave IN('2','S001')
	 WHERE CAST(PS.CerradoEl AS date) BETWEEN DATEADD(DAY,-1,CAST(@pFechaIni AS DATE)) AND DATEADD(DAY,-1,CAST(@pFechaFin AS date)) AND
	 PS.SucursalId = @pSucursalId AND
	 PS.Cerrado = 1

	 
	 INSERT INTO #TMP_TIPOS
	 SELECT 1,'1. PRODUCCIÓN'
	 UNION
	 SELECT 2,'2. VENTAS MASA'
	 UNION
	 SELECT 3,'3. ENTRADAS POR TRASPASO'
	 UNION
	 SELECT 4,'4. PRODUCCIÓN TORTILLA'
	 UNION
	 SELECT  5,'5. ENTRADAS POR VENTA DE PRODUCTO'
	 UNION
	 SELECT  6,'6. DESCUENTO SOBRANTES'
	 UNION
	 SELECT  7,'7. DESCUENTO VENTAS MAYOREO'
	 UNION
	 SELECT  8,'8. DESCUENTO POR GRAMOS EN CONTRA'
	 UNION
	 SELECT  9,'8. GASTOS CAJA CHICA'
	 UNION
	 SELECT 10,'9. SALIDAS POR TRASPASO'

	  SELECT @SacosMaiz = ISNULL(SUM(T1.MaizSacos),0),
			@SacosMaseca = ISNULL(SUM(T1.MasecaSacos),0),
			@KilosTortillaTotal = ISNULL(SUM(T1.TortillaTotalRendimiento),0)
	  FROM doc_maiz_maseca_rendimiento T1
	  WHERE CAST(T1.Fecha AS date) BETWEEN DATEADD(DAY,-1,CAST(@pFechaIni AS date)) AND DATEADD(DAY,-1,CAST(@pFechaFin AS DATE))
	  AND T1.SucursalId = @pSucursalId
	  GROUP BY T1.SucursalId

	  SET @MasaProdFinal = ISNULL(@KilosTortillaTotal,0) / .800

	  /************PRODUCCIÓN ESTIMADA************/
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  VALUES(1,'Total Sacos Maiz',1,ISNULL(@SacosMaiz,0),0,0,'MAIZS')

	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  VALUES(1,'Total Sacos Maseca',1,ISNULL(@SacosMaseca,0),0,0,'MASECAS')

	   INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 1,'Masa - Sobrante día anterior',1,ISNULL(@SobranteMasaDiaAnterior,0),0, 0,'MASA_DIA_ANT'

	  SET @MasaProdFinal = ISNULL(@MasaProdFinal,0) + ISNULL(@SobranteMasaDiaAnterior,0)

	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 1,'Masa - Kg Estimados Producción',1,ISNULL(@MasaProdFinal,0),0, 0,'MASA_PROD'

	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave,Mostrar)
	  SELECT 1,'Kg Estimados Prod Tortilla',1,(ISNULL(@MasaProdFinal,0)*.8),P.Precio, P.Precio * (ISNULL(@MasaProdFinal,0)*.8),'TORTPROD',0
	  FROM #TMP_PRECIOS_HIS P WHERE P.ProductoId = 1

	  
	  /***********VENTA MAYOREO*************/
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 2,'Tortilla - Venta Mayoreo Pagado Atrasado' ,0,SUM(VD.Cantidad),VD.PrecioUnitario,SUM(VD.Cantidad) * VD.PrecioUnitario,'VTORT_MAY_ATRAS'
	  FROM doc_ventas_detalle VD
	  INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	  INNER JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId AND
									CAST(PO.CreadoEl AS date) < CAST(V.Fecha AS date)
	  WHERE VD.ProductoId = 1 AND--TORTILLA
	  CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	  V.SucursalId = @pSucursalId  AND
	  V.ClienteId IS NOT NULL AND
	  V.Activo = 1
	  GROUP BY VD.ProductoId,VD.PrecioUnitario

	   IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'VTORT_MAY_ATRAS') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 2,'Tortilla - Venta Mayoreo Pagado Atrasado' ,0,0,0,0,'VTORT_MAY_ATRAS'

	  /***************************************************************/

	  --INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  --SELECT 2,'Masa - Ventas Mostrador',1,SUM(VD.Cantidad),VD.PrecioUnitario,SUM(VD.Cantidad) * VD.PrecioUnitario,'VMASA_MOSTRADOR'
	  --FROM doc_ventas_detalle VD
	  --INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	  --WHERE VD.ProductoId = 2 AND--MASA
	  --CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	  --V.SucursalId = @pSucursalId  AND
	  --V.ClienteId IS NULL AND
	  --V.Activo = 1
	  --GROUP BY VD.ProductoId,VD.PrecioUnitario

	 
	 

	  /*********************************************************************************/
	 -- INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	 -- SELECT 2,'Masa - Venta Mayoreo Pagado el Mismo día' ,1,
		--SUM(POD.CantidadOriginal),pod.PrecioUnitario,SUM(POD.CantidadOriginal) * pod.PrecioUnitario,'VMASA_MAY_DIA'
	 -- FROM doc_pedidos_orden_detalle POD
	 -- INNER JOIN doc_pedidos_orden PO ON PO.PedidoId = POD.PedidoId 
	 -- INNER JOIN doc_ventas V ON V.VentaId = PO.VentaId AND
		--					V.Activo = 1 AND
		--					CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) 
	 --  INNER JOIN #TMP_PRECIOS_HIS PRE ON PRE.ProductoId = POD.ProductoId
	 -- WHERE PO.SucursalId = @pSucursalId AND
	 -- CAST(PO.CreadoEl AS date) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	 -- PO.VentaId IS NOT NULL AND
	 -- --PO.Activo = 1 AND
	 -- POD.ProductoId = 2
	 -- GROUP BY pod.PrecioUnitario

	 -- SELECT 2,'Masa - Venta Mayoreo Pagado el Mismo día' ,1,
		--SUM(VD.Cantidad),VD.PrecioUnitario,SUM(VD.Cantidad) * VD.PrecioUnitario,'VMASA_MAY_DIA'
	 -- FROM doc_ventas_detalle VD
	 -- INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	 -- INNER JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId 
	 -- INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId
	 -- WHERE VD.ProductoId = 2 AND--MASA
	 -- CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	 -- V.SucursalId = @pSucursalId  AND
	 -- V.ClienteId IS NOT NULL AND
	 -- V.Activo = 1 AND
	 -- (CAST(PO.CreadoEl AS date) = CAST(V.Fecha AS date) OR PO.CreadoEl IS NULL)
	 -- GROUP BY VD.ProductoId,VD.PrecioUnitario

	  --IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'VMASA_MAY_DIA') 
	  --INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  --SELECT 2,'Masa - Venta Mayoreo Pagado el Mismo día' ,0,0,0,0,'VMASA_MAY_DIA'
	 
	  /**************************DEVOLUCIONES DE MASA*********************************************************/


	  /************************************************************************************/

	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 2,'Masa - Venta Mayoreo Pagado Atrasado' ,0,SUM(VD.Cantidad),VD.PrecioUnitario,SUM(VD.Cantidad) * VD.PrecioUnitario,'VMASA_MAY_ATRAS'
	  FROM doc_ventas_detalle VD
	  INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	  INNER JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId AND
									CAST(PO.CreadoEl AS date) < CAST(V.Fecha AS date)
	  WHERE VD.ProductoId = 2 AND--MASA
	  CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	  V.SucursalId = @pSucursalId  AND
	  V.ClienteId IS NOT NULL AND
	  V.Activo = 1
	  GROUP BY VD.ProductoId,VD.PrecioUnitario

	   IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'VMASA_MAY_ATRAS') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 2,'Masa - Venta Mayoreo Pagado Atrasado' ,0,0,0,0,'VMASA_MAY_ATRAS'




	  /***********ENTRADAS POR TRASPASO*************/
	   INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 3,'Tortilla - Traspaso Entrada',1,ISNULL(SUM(MD.Cantidad),0),P.Precio,P.Precio * ISNULL(SUM(MD.Cantidad),0),'TORT_E_TRAS'
	  FROM doc_inv_movimiento M
	  INNER JOIN doc_inv_movimiento_Detalle MD ON MD.MovimientoId = M.MovimientoId AND
										MD.ProductoId = 1 AND--TORTILLA
										M.SucursalId = @pSucursalId AND
										  CAST(M.FechaMovimiento AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE) AND
										  M.Activo = 1
	 INNER JOIN #TMP_PRECIOS_HIS P ON P.ProductoId = MD.ProductoId AND CAST(P.Fecha AS DATE) = CAST(M.FechaMovimiento AS date)
	 INNER JOIN cat_tipos_movimiento_inventario TM ON TM.TipoMovimientoInventarioId = M.TipoMovimientoId AND
											EsEntrada = 1 AND
											TM.TipoMovimientoInventarioId = 3
	  GROUP BY P.Precio


	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 3,'Masa - Traspaso Entrada',1,ISNULL(SUM(MD.Cantidad),0),P.Precio,P.Precio * ISNULL(SUM(MD.Cantidad),0),'MASA_E_TRAS'
	  FROM doc_inv_movimiento M
	  INNER JOIN doc_inv_movimiento_Detalle MD ON MD.MovimientoId = M.MovimientoId AND
										MD.ProductoId = 2 AND--TORTILLA
										M.SucursalId = @pSucursalId AND
										  CAST(M.FechaMovimiento AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE) AND
										  M.Activo = 1
	 INNER JOIN #TMP_PRECIOS_HIS P ON P.ProductoId = MD.ProductoId AND CAST(P.Fecha AS DATE) = CAST(M.FechaMovimiento AS date)
	 INNER JOIN cat_tipos_movimiento_inventario TM ON TM.TipoMovimientoInventarioId = M.TipoMovimientoId AND
											EsEntrada = 1 AND
											TM.TipoMovimientoInventarioId = 3
	 GROUP BY P.Precio

	 SELECT @MasaProdFinal = ISNULL(Cantidad,0)
	 FROM #TMP_RESULTADO WHERE CLAVE IN( 'MASA_PROD')

	 --SELECT @MasaProdFinal = @MasaProdFinal - SUM(Cantidad)
	 --FROM #TMP_RESULTADO WHERE CLAVE IN(  'VMASA_MAY_DIA','VMASA_MOSTRADOR')

	 

	 INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	 SELECT 1,'Tortilla - Kg Producción Estimado',1,ISNULL(@MasaProdFinal,0) * .8 ,ISNULL(MAX(Precio),0),ISNULL(MAX(Precio),0)*ISNULL(@MasaProdFinal,0) * .8 ,'TORT_PROD_F'
	 FROM #TMP_PRECIOS_HIS P 
	 WHERE P.ProductoId = 1 

	 
	 /****************************************************************************/
	INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	SELECT 5,P.Descripcion,1,SUM(VD.Cantidad),VD.PrecioUnitario,VD.PrecioUnitario * SUM(VD.Cantidad),'PROD_VENTA'
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
							V.SucursalId = @pSucursalId AND
							CAST(V.Fecha AS date) BETWEEN CAST(@pFechaIni  AS DATE) AND CAST(@pFechaFin AS date) and
							VD.ProductoId NOT IN(1,2) AND
							V.Activo = 1
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
	GROUP BY P.Descripcion,VD.PrecioUnitario

	 SELECT @TotalEntradas = SUM(Total)
	 FROM #TMP_RESULTADO
	 WHERE Clave IN( 'VTORT_MAY_ATRAS','VMASA_MOSTRADOR','VMASA_MAY_DIA','VMASA_MAY_ATRAS','TORT_E_TRAS','TORT_PROD_F','PROD_VENTA')


	 /*****************SOBRANTES****************************************************/
	 INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	 SELECT 6,P.Descripcion,0,PS.CantidadSobrante,MAX(PRE.Precio),PS.CantidadSobrante * MAX(PRE.Precio),'TORT_SOBRANTE'
	 from doc_productos_sobrantes_registro PS
	 INNER JOIN cat_productos P ON P.ProductoId = PS.ProductoId AND
									P.Descripcion LIKE '%DESPERDICIO%TORTILLA%' AND
									CAST(PS.CerradoEl AS DATE) BETWEEN CAST(@pFechaIni AS date) AND  CAST(@pFechaFin AS date)
	 INNER JOIN #TMP_PRECIOS_HIS PRE ON PRE.ProductoId = 1 
	 WHERE PS.SucursalId = @pSucursalId
	 GROUP BY P.Descripcion,PS.CantidadSobrante

	  IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'TORT_SOBRANTE') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 6,'DESPERDICIO TORTILLA' ,0,0,0,0,'TORT_SOBRANTE'

	  /*************************************************************************/


	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	 SELECT 6,P.Descripcion,0,PS.CantidadSobrante,MAX(PRE.Precio),PS.CantidadSobrante * MAX(PRE.Precio),'MASA_SOBRANTE'
	 from doc_productos_sobrantes_registro PS
	 INNER JOIN cat_productos P ON P.ProductoId = PS.ProductoId AND
									P.Clave IN ('S001','S002','S003') AND
									CAST(PS.CreadoEl AS DATE) BETWEEN CAST(@pFechaIni AS date) AND  CAST(@pFechaFin AS date)
	 INNER JOIN #TMP_PRECIOS_HIS PRE ON PRE.ProductoId = 2
	 WHERE PS.SucursalId = @pSucursalId
	 GROUP BY P.Descripcion,PS.CantidadSobrante

	  IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'MASA_SOBRANTE') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 6,'DESPERDICIO/SOBRANTE MASA' ,0,0,0,0,'MASA_SOBRANTE'


	  /********************SOBRANTE MASA Y TORTILLA******************************/

	 INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	 SELECT 6,P.Descripcion,0,PS.CantidadSobrante,MAX(PRE.Precio),PS.CantidadSobrante * MAX(PRE.Precio),'TORTILLA_MASA_SOBRANTE'
	 from doc_productos_sobrantes_registro PS
	 INNER JOIN cat_productos P ON P.ProductoId = PS.ProductoId AND
									P.ProductoId IN (1,2) AND
									CAST(PS.CreadoEl AS DATE) BETWEEN CAST(@pFechaIni AS date) AND  CAST(@pFechaFin AS date)
	 INNER JOIN #TMP_PRECIOS_HIS PRE ON PRE.ProductoId = P.ProductoId
	 WHERE PS.SucursalId = @pSucursalId
	 GROUP BY P.Descripcion,PS.CantidadSobrante

	  


	  /*********************7. DESCUENTO VENTAS MAYOREO*******************************************************************/

	  /********************7. DESCUENTO VENTAS MAYOREO- Tortilla - Ajuste Monto por precio Preferencial Mayoreo********************************/
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 7,'Tortilla - Ajuste Monto por precio Preferencial Mayoreo' ,0,
	  SUM(VD.Cantidad),
	  (ISNULL(P.Precio,0) - ISNULL(VD.PrecioUnitario,0)),
	  SUM(VD.Cantidad) * (ISNULL(P.Precio,0) - ISNULL(VD.PrecioUnitario,0)),
	  
	  'VTORT_MAY_DIA'
	  FROM doc_ventas_detalle VD
	  INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	  LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId 
	  INNER JOIN #TMP_PRECIOS_HIS P ON P.ProductoId = VD.ProductoId AND CAST(P.Fecha AS date) = CAST(V.Fecha AS DATE)
	  WHERE VD.ProductoId = 1 AND--TORTILLA
	  CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	  V.SucursalId = @pSucursalId  AND
	  V.ClienteId IS NOT NULL AND
	  V.Activo = 1 AND
	  (CAST(PO.CreadoEl AS date) = CAST(V.Fecha AS date) OR PO.CreadoEl IS NULL)
	  GROUP BY VD.ProductoId,VD.PrecioUnitario,P.Precio

	  /***************************************************************************************/
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 7,'Masa - Ajuste Monto por precio Preferencial Mayoreo' ,0,
	  SUM(VD.Cantidad),
	  (ISNULL(P.Precio,0) - ISNULL(VD.PrecioUnitario,0)),
	  SUM(VD.Cantidad) * (ISNULL(P.Precio,0) - ISNULL(VD.PrecioUnitario,0)),
	  
	  'VMASA_MAY_DIA'
	  FROM doc_ventas_detalle VD
	  INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	  LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId 
	  INNER JOIN #TMP_PRECIOS_HIS P ON P.ProductoId = VD.ProductoId AND CAST(P.Fecha AS date) = CAST(V.Fecha AS DATE)
	  WHERE VD.ProductoId = 2 AND--TORTILLA
	  CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	  V.SucursalId = @pSucursalId  AND
	  V.ClienteId IS NOT NULL AND
	  V.Activo = 1 AND
	  (CAST(PO.CreadoEl AS date) = CAST(V.Fecha AS date) OR PO.CreadoEl IS NULL)
	  GROUP BY VD.ProductoId,VD.PrecioUnitario,P.Precio

	  IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'VTORT_MAY_DIA') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 7,'Tortilla - Ajuste Monto por precio Preferencial Mayoreo' ,0,0,0,0,'VMASA_MAY_DIA'

	  /******************7. DESCUENTO VENTAS MAYOREO. Pedido Tortilla Por Pagar********************************************************************/
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 7,P.Descripcion + ' - Pedido Por Pagar',0,SUM(POD.Cantidad),POD.PrecioUnitario, POD.PrecioUnitario * SUM(POD.Cantidad),'POR_PAGAR'
	  FROM doc_pedidos_orden PO
	  INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId  AND POD.ProductoId IN(1,2)
	  INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	  WHERE PO.SucursalId = @pSucursalId AND
	  PO.VentaId IS NULL AND
	  CAST(PO.CreadoEl AS DATE) BETWEEN CAST(@pFechaIni  AS DATE)AND CAST(@pFechaFin AS date) AND
	  ISNULL(PO.Cancelada,0) = 0
	  GROUP BY P.Descripcion ,POD.PrecioUnitario

	   IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'POR_PAGAR') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 7,'Pedidos por Pagar' ,0,0,0,0,'POR_PAGAR'


	  /******************7. DESCUENTO VENTAS MAYOREO. Devoluciones de Masa y Tortilla en Pedidos****************/
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 7,P.Descripcion + '(Devolución Mayoreo)',0,SUM(POD.CantidadDevolucion),PH.Precio,SUM(POD.CantidadDevolucion) * PH.Precio,'MAYOREO_DEVOLUCION'
	  FROM doc_pedidos_orden PO
	  INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId AND
												CAST(PO.CreadoEl AS DATE) BETWEEN CAST(@pFechaIni AS date) AND CAST(@pFechaFin AS date) AND
												PO.VentaId IS NOT NULL AND
												PO.SucursalId = @pSucursalId
	 INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId 
	 INNER JOIN #TMP_PRECIOS_HIS PH ON PH.ProductoId = POD.ProductoId
	 GROUP BY P.Descripcion,PH.Precio




	  /******************8. DESCUENTO POR GRAMOS EN CONTRA**********************************************/
	 create table #GramosFavorEnContra (ProductoId int, PrecioProducto decimal(16,6), ClaveTipoGramos smallint, PrecioPorGramo decimal(16,6), GramosPesados decimal(16,6),   
         Total decimal(16,6), GramosVendidos_EnBase_Al_Total decimal(16,6), ResultadoGramos decimal(16,6), ImporteGramos decimal(16,6))     
  
		insert into #GramosFavorEnContra(ProductoId, PrecioProducto, PrecioPorGramo, GramosPesados, Total, GramosVendidos_EnBase_Al_Total)     
		select ProductoId,   PrecioProducto= PrecioUnitario,    
		PrecioPorgramo= (PrecioUnitario/1000),   GramosPesados=(Cantidad*1000),  Total,   GramosVendidos_EnBase_Al_Total= (Total/(PrecioUnitario/1000))    
		from      
		 doc_ventas t1   
		inner join     
		 doc_ventas_detalle t2 on t2.VentaId= t1.VentaId    
		where    
		 isnull(t1.clienteid,0)=0 and   t1.SucursalId=@pSucursalId and     
		 cast(t1.FechaCreacion as date)  between  cast(@pFechaIni as date) and cast(@pFechaFin as date) and   
		 PrecioUnitario>0     		 
		update #GramosFavorEnContra set ResultadoGramos= ((GramosPesados)-(Total/(PrecioPorgramo)))    
  
		update #GramosFavorEnContra set ClaveTipoGramos= 1 /*A favor*/, ImporteGramos= PrecioPorGramo*ResultadoGramos   
		where ResultadoGramos>0    
  
		update #GramosFavorEnContra set ClaveTipoGramos= 2 /*En contra*/, ImporteGramos= PrecioPorGramo*ResultadoGramos where ResultadoGramos<0    
  
		delete #GramosFavorEnContra where ISNULL(ResultadoGramos, 0)= 0    

		 INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)	 
		 SELECT  8,'Gramos en Contra - Gramos que se dieron de mas',		      
		  Abono= 0,   
		  Cantidad= ((sum(ResultadoGramos))/1000.00000),  
		  PrecioUnitario= PrecioProducto,   
		  Total= sum(ImporteGramos)    ,'GRAMOS_CONTRA'
		from #GramosFavorEnContra t1 inner join   
		 cat_productos t2 on t2.ProductoId= t1.ProductoId     
		where t1.ClaveTipoGramos= 1
		group  by ClaveTipoGramos, t1.ProductoId, PrecioProducto  order by t1.ProductoId   
		

		/********************************************************/
		INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 8,'Tortilla - Gramos en Contra Por Ventas Mayoreo' ,0,
	  SUM(VD.Cantidad) * @GramosMermaMayoreoKilo,
	  (ISNULL(P.Precio,0) - ISNULL(VD.PrecioUnitario,0)),
	  (SUM(VD.Cantidad) * @GramosMermaMayoreoKilo) * (ISNULL(P.Precio,0) - ISNULL(VD.PrecioUnitario,0)),
	  
	  'VTORT_MAY_DIA_MERMA'
	  FROM doc_ventas_detalle VD
	  INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	  LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId 
	  INNER JOIN #TMP_PRECIOS_HIS P ON P.ProductoId = VD.ProductoId AND CAST(P.Fecha AS date) = CAST(V.Fecha AS DATE)
	  WHERE VD.ProductoId = 1 AND--TORTILLA
	  CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date) AND
	  V.SucursalId = @pSucursalId  AND
	  V.ClienteId IS NOT NULL AND
	  V.Activo = 1 AND
	  (CAST(PO.CreadoEl AS date) = CAST(V.Fecha AS date) OR PO.CreadoEl IS NULL)
	  GROUP BY VD.ProductoId,VD.PrecioUnitario,P.Precio



	/**************************9. GASTOS CAJA CHICA**********************************************************/
	INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)	
	SELECT 9,G.Obervaciones,0,1,G.Monto,G.Monto,'GASTOS_CCHICA'
	FROM doc_gastos G
	INNER JOIN cat_cajas C ON C.Clave = G.CajaId
	WHERE G.SucursalId = @pSucursalId AND
	ISNULL(G.Activo,0) = 1 AND
	CAST(G.CreadoEl AS date) BETWEEN CAST(@pFechaIni AS DATE)AND CAST(@pFechaFin AS date)

	 IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'GASTOS_CCHICA') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 9,'Gastos Caja Chica' ,0,0,0,0,'GASTOS_CCHICA'


	/*************************10.SALIDAS POR TRASPASO**********************************************************/
	 INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 10,PROD.Descripcion + '-' + TM.Descripcion,0,ISNULL(SUM(MD.Cantidad),0),P.Precio,P.Precio * ISNULL(SUM(MD.Cantidad),0),'TORT_S_TRAS'
	  FROM doc_inv_movimiento M
	  INNER JOIN doc_inv_movimiento_Detalle MD ON MD.MovimientoId = M.MovimientoId AND
										MD.ProductoId IN( 1,2) AND--TORTILLA
										M.SucursalId = @pSucursalId AND
										  CAST(M.FechaMovimiento AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE) AND
										  M.Activo = 1 AND
										  M.TipoMovimientoId IN (4)
	 INNER JOIN #TMP_PRECIOS_HIS P ON P.ProductoId = MD.ProductoId AND CAST(P.Fecha AS DATE) = CAST(M.FechaMovimiento AS date)
	 INNER JOIN cat_tipos_movimiento_inventario TM ON TM.TipoMovimientoInventarioId = M.TipoMovimientoId AND
											EsEntrada = 0
	 INNER JOIN cat_productos PROD ON PROD.ProductoId = MD.ProductoId
	  GROUP BY P.Precio,PROD.Descripcion,TM.Descripcion

	  IF NOT EXISTS (SELECT 1 FROM #TMP_RESULTADO WHERE Clave = 'TORT_S_TRAS') 
	  INSERT INTO #TMP_RESULTADO(TipoId,Concepto,Abono,Cantidad,PrecioUnitario,Total,Clave)
	  SELECT 10,'SALIDAS DE MASA Y TORTILLA' ,0,0,0,0,'TORT_S_TRAS'


	  /********************************************************/

	  UPDATE #TMP_RESULTADO
	  SET TotalEntradas =  @TotalEntradas

	  UPDATE #TMP_RESULTADO
	  SET TotalDescuentos = (SELECT SUM(Total) FROM #TMP_RESULTADO WHERE Abono = 0)

	  SELECT @TotalRetiros = SUM(MontoRetiro)
	  FROM doc_retiros 
	  where SucursalId = @pSucursalId AND
	  CAST(FechaRetiro AS date) BETWEEN CAST(@pFechaIni AS date) AND CAST(@pFechaFin AS date)

	  SELECT @TotalRetiros = ISNULL(@TotalRetiros,0) + ISNULL(SUM(CCD.Total),0)
	  FROM doc_corte_caja_denominaciones CCD 
	  INNER JOIN doc_corte_caja CC ON CC.CorteCajaId = CCD.CorteCajaId 
	  INNER JOIN cat_cajas C ON C.Clave = CC.CajaId AND
								C.Sucursal = @pSucursalId AND	
								CAST(CCD.CreadoEl AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS date)

										
	  

	  UPDATE #TMP_RESULTADO
	  SET TotalRetiros = ISNULL(@TotalRetiros,0)

	  UPDATE #TMP_RESULTADO
	  SET TotalDiferencia = TotalRetiros - (ISNULL(TotalEntradas,0) - ISNULL(TotalDescuentos,0))

	  update #TMP_RESULTADO
		SET TotalRequerido = ISNULL(TotalEntradas,0) - ISNULL(TotalDescuentos,0)

	  UPDATE #TMP_RESULTADO
	  SET TotalRegistradoSistema = (SELECT ISNULL(SUM(V.TotalVenta),0) FROM doc_ventas V WHERE CAST(V.Fecha AS date) BETWEEN CAST(@pFechaIni AS date) AND CAST(@pFechaFin AS date) AND V.Activo = 1 AND V.SucursalId = @pSucursalId)
	  
	  update #TMP_RESULTADO
	  set Total = Total * -1
	  Where Abono = 0

	  SELECT Tipo = T.Tipo ,R.* FROM #TMP_RESULTADO R
	  INNER JOIN #TMP_TIPOS T  ON T.TipoId = R.TipoId
	  WHERE Mostrar = 1
	  Order by T.Tipo,R.Fila


