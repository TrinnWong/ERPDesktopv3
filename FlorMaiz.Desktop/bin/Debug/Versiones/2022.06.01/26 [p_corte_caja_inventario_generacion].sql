IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_corte_caja_inventario_generacion'
)
DROP PROC p_corte_caja_inventario_generacion
GO

-- p_corte_caja_inventario_generacion 10,'20220718','20220718'
CREATE PROC [dbo].[p_corte_caja_inventario_generacion]
@pSucursalId INT,
@pFechaIni DATETIME,
@pFechaFin DATETIME
as

	DECLARE @TotalRetiros MONEY,
		@MasaUsadaEnTortilla DECIMAL(14,3),
		@MasaTotal DECIMAL(14,3)

	CREATE TABLE #TMP_RESULTADO
	(
		Fila int identity(1,1),
		TipoMovimiento VARCHAR(450),
		Concepto VARCHAR(450),
		Abono BIT,
		Cantidad decimal(14,3),
		PrecioUnitario MONEY,
		Monto MONEY,
		TotalAnalisisCorteCaja MONEY NULL,
		TotalDescuentos MONEY NULL,
		TotalEntregadoSucursal  MONEY NULL,
		Diferencia MONEY NULL

	)

	CREATE TABLE #TMP_MOVS_INVENTARIO_EXCLUIR(
		MovimientoId INT,
		MovimientoDetalleId INT
	)

	INSERT INTO #TMP_MOVS_INVENTARIO_EXCLUIR(MovimientoId,MovimientoDetalleId)
	SELECT IMD.MovimientoId,IMD.MovimientoDetalleId
	FROM doc_productos_sobrantes_regitro_inventario PSR
	INNER JOIN doc_inv_movimiento_detalle IMD ON IMD.MovimientoDetalleId = PSR.MovimientoDetalleId
	INNER JOIN doc_inv_movimiento IM ON IM.MovimientoId = IMD.MovimientoId
	WHERE IM.SucursalId = @pSucursalId AND
	convert(varchar,IM.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)
	GROUP BY IMD.MovimientoId,IMD.MovimientoDetalleId
	

	SELECT @TotalRetiros = sum(R.MontoRetiro)
	FROM doc_retiros R
	WHERE R.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,R.FechaRetiro,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)

	/***********************************************ENTRADAS********************************************/
	--MASA 
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1-ENTRADAS MASA Y TORTILLA',P.Descripcion,1,SUM(IMD.Cantidad),0,0
	FROM doc_inv_movimiento IM
	INNER JOIN doc_inv_movimiento_detalle IMD ON IMD.MovimientoId = IM.MovimientoId AND
								IM.Activo = 1
	INNER JOIN cat_productos P ON P.ProductoId = IMD.ProductoId AND P.Descripcion = 'MASA'	
	INNER JOIN cat_tipos_movimiento_inventario TMI ON TMI.TipoMovimientoInventarioId = IM.TipoMovimientoId AND 
													TMI.EsEntrada = 1 
	
	WHERE IM.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,IM.FechaMovimiento,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND 
	IMD.MovimientoDetalleId IN (SELECT MovimientoDetalleId FROM #TMP_MOVS_INVENTARIO_EXCLUIR)
	GROUP BY P.Descripcion

	--MASA FRIA
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1-ENTRADAS MASA Y TORTILLA',p.Descripcion +' '+ (CAST(SUM(psr.CantidadSobrante) AS VARCHAR)),1,(SUM(psr.CantidadSobrante)/40*33),pp.Precio,(SUM(psr.CantidadSobrante)/40*33) * pp.Precio
	FROM doc_productos_sobrantes_registro PSR
	INNER JOIN cat_productos P ON P.ProductoId = PSR.ProductoId AND p.Descripcion like '%MASA FRIA%'
	INNER JOIN cat_productos PM ON PM.Descripcion = 'TORTILLA'
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = pm.ProductoId and pp.IdPrecio = 1
	WHERE CONVERT(VARCHAR,PSR.CreadoEl,112) BETWEEN CONVERT(VARCHAR,DATEADD(DAY,-1,@pFechaIni),112) AND CONVERT(VARCHAR,DATEADD(DAY,-1,@pFechaFin),112)
	GROUP BY p.Descripcion,pp.Precio

	SELECT @MasaTotal = SUM(Cantidad)
	FROM #TMP_RESULTADO
	WHERE TipoMovimiento = '1-ENTRADAS MASA Y TORTILLA'

	--VENTA MASA Y TORTILLA
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1.1-VENTA MASA Y TORTILLA',
			P.CLAVE + '-'+P.Descripcion + CASE WHEN ISNULL(MIN(v.ClienteId),0) > 0 THEN '-(PEDIDO MAYOREO CONTADO)' ELSE '-(VENTA MOSTRADOR)' END,
			1,
			SUM(VD.Cantidad),
			VD.PrecioUnitario,
			SUM(VD.Total)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId AND P.ProdVtaBascula = 1 AND
								P.ProductoId = 1 --TORTILLA
	LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId
	WHERE V.SucursalId = @pSucursalId AND
	V.Activo = 1 AND
	CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	PO.VentaId IS NULL AND
	VD.PrecioUnitario > 0
	GROUP BY P.CLAVE,P.Descripcion,VD.PrecioUnitario,v.ClienteId
	order by p.CLAVE


	----PEDIDO MAYOREO
	--INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	--SELECT '1.1-VENTA MASA Y TORTILLA',
	--		P.CLAVE + '-'+P.Descripcion  + '-(VENTA MAYOREO)',
	--		1,
	--		SUM(VD.Cantidad),
	--		VD.PrecioUnitario,
	--		SUM(VD.Total)
	--FROM doc_ventas_detalle VD
	--INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId and vd.ProductoId = 1
	--INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId 
	--LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId
	--WHERE V.SucursalId = @pSucursalId AND
	--V.Activo = 1 AND
	--CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	--PO.VentaId IS NOT NULL
	--GROUP BY P.CLAVE,P.Descripcion,VD.PrecioUnitario
	--order by p.CLAVE


	--PEDIDO MAYOREO POR PAGAR
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1.1-VENTA MASA Y TORTILLA',p.CLave + '-' +p.Descripcion + '-(VENTA MAYOREO POR PAGAR)',1,SUM(POD.Cantidad),POD.PrecioUnitario,SUM(POD.Cantidad) * POD.PrecioUnitario
	FROM doc_pedidos_orden PO
	INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId 	 AND
										PO.Activo = 1 AND
										PO.SucursalId = @pSucursalId and
										pod.ProductoId = 1
	INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	WHERE CONVERT(VARCHAR,PO.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)
	GROUP BY p.Descripcion,POD.PrecioUnitario,p.CLave	

	SELECT @MasaUsadaEnTortilla = SUM(Cantidad) * 1.21
	FROM #TMP_RESULTADO
	WHERE TipoMovimiento = '1.1-VENTA MASA Y TORTILLA'

	

	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1.1-VENTA MASA Y TORTILLA',P.Descripcion,1,(@MasaTotal - @MasaUsadaEnTortilla),PP.Precio,PP.Precio * (@MasaTotal - @MasaUsadaEnTortilla)
	FROM cat_productos P
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
							PP.IdPrecio = 1
	WHERE P.ProductoId = 2

	--TORTILLA ENTRADA POR TRASPASO
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1.2-ENTRADA POR TRASPASO',p.clave + P.Descripcion ,1,SUM(IMD.Cantidad),PP.Precio,PP.Precio * SUM(IMD.Cantidad)
	FROM doc_inv_movimiento IM
	INNER JOIN doc_inv_movimiento_detalle IMD ON IMD.MovimientoId = IM.MovimientoId
	INNER JOIN cat_productos P ON P.ProductoId = IMD.ProductoId AND P.ProdVtaBascula = 1 AND P.ProductoId = 1 --SOLO TORTILLA
	INNER JOIN cat_tipos_movimiento_inventario TMI ON TMI.TipoMovimientoInventarioId = IM.TipoMovimientoId AND
												TMI.TipoMovimientoInventarioId in (3,5)
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId and pp.IdPrecio = 1
	WHERE IM.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,IM.CreadoEl,112) BETWEEN   CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)AND 
	IMD.MovimientoDetalleId IN (SELECT MovimientoDetalleId FROM #TMP_MOVS_INVENTARIO_EXCLUIR)
	group by PP.Precio,P.Descripcion,p.clave

	

	--VENTAS REGISTRADAS
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1.3-ENTRADAS POR PRODUCTO',
			P.CLAVE + '-'+P.Descripcion,
			1,
			SUM(VD.Cantidad),
			VD.PrecioUnitario,
			SUM(VD.Total)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId AND P.ProdVtaBascula = 0
	LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId
	WHERE V.SucursalId = @pSucursalId AND
	V.Activo = 1 AND
	CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	PO.VentaId IS NULL
	GROUP BY P.CLAVE,P.Descripcion,VD.PrecioUnitario
	order by p.CLAVE

	
	/********************SOBRANTES DE PRODUCTOS MOSTRADOR*************************/
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '1.4-FALTANTES PRODUCTO MOSTRADOR',P.Clave +'-'+ P.Descripcion,1,PSR.CantidadInventario - PSR.CantidadSobrante,PP.Precio, (PSR.CantidadInventario - PSR.CantidadSobrante) * pp.Precio
	FROM doc_productos_sobrantes_registro PSR
	INNER JOIN cat_productos P ON P.ProductoId = PSR.ProductoId AND
							P.ProdVtaBascula = 0
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
					PP.IdPrecio = 1
	WHERE PSR.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,PSR.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	ISNULL(PSR.CantidadSobrante,0) < ISNULL(PSR.CantidadInventario,0)
	
	

	/**********************DESCUENTOS***********************************************/
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2-SOBRANTES/DESPERDICIO',p.Descripcion,0,sum(PSR.CantidadSobrante),pp.Precio,PSR.CantidadSobrante* pp.Precio
	FROM doc_productos_sobrantes_registro PSR
	INNER JOIN cat_productos P ON P.ProductoId = PSR.ProductoId AND p.ProdVtaBascula = 1 AND PSR.SucursalId = @pSucursalId
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = p.ProductoId and pp.IdPrecio = 1
	WHERE CONVERT(VARCHAR,PSR.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)
	GROUP BY p.Descripcion,pp.Precio,PSR.CantidadSobrante

	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2.1-GASTOS',G.Obervaciones,0,1,g.Monto,g.Monto
	FROM doc_gastos G
	WHERE CONVERT(VARCHAR,G.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	G.SucursalId = @pSucursalId and
	G.Activo = 1


	--PEDIDO MAYOREO
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2.2-PEDIDOS MAYOREO',
			P.CLAVE + '-'+P.Descripcion,
			0,
			SUM(VD.Cantidad),
			VD.PrecioUnitario,
			SUM(VD.Total)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId 
	LEFT JOIN doc_pedidos_orden PO ON PO.VentaId = V.VentaId
	WHERE V.SucursalId = @pSucursalId AND
	V.Activo = 1 AND
	CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	PO.VentaId IS NOT NULL
	GROUP BY P.CLAVE,P.Descripcion,VD.PrecioUnitario
	order by p.CLAVE


	--PEDIDO MAYOREO POR PAGAR
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2.3-PEDIDOS MAYOREO POR PAGAR',p.Descripcion,0,SUM(POD.Cantidad),POD.PrecioUnitario,SUM(POD.Cantidad) * POD.PrecioUnitario
	FROM doc_pedidos_orden PO
	INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId 	 AND
										PO.Activo = 1 AND
										PO.SucursalId = @pSucursalId 
	INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	WHERE CONVERT(VARCHAR,PO.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)
	GROUP BY p.Descripcion,POD.PrecioUnitario


	--TRASPASOS
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2.4-TRASPASO/SALIDA',P.Descripcion,0,SUM(IMD.Cantidad),PP.Precio,PP.Precio * SUM(IMD.Cantidad)
	FROM doc_inv_movimiento IM
	INNER JOIN doc_inv_movimiento_detalle IMD ON IMD.MovimientoId = IM.MovimientoId
	INNER JOIN cat_productos P ON P.ProductoId = IMD.ProductoId AND P.ProdVtaBascula = 1 AND P.Descripcion NOT LIKE '%MASA%FRIA%' AND
												P.ProductoId = 2
	INNER JOIN cat_tipos_movimiento_inventario TMI ON TMI.TipoMovimientoInventarioId = IM.TipoMovimientoId AND
												TMI.TipoMovimientoInventarioId in (4,6)
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
										PP.IdPrecio = 1
	WHERE IM.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,IM.CreadoEl,112) BETWEEN   CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)AND 
	IMD.MovimientoDetalleId IN (SELECT MovimientoDetalleId FROM #TMP_MOVS_INVENTARIO_EXCLUIR)
	group by PP.Precio,P.Descripcion

	--CORTESIA
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2.5-CORTESIA/CONSUMO EMPLEADO',P.Descripcion + ' Folio:'+v.Folio,0,VD.Cantidad,PP.Precio,VD.Cantidad * PP.Precio
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
											ISNULL(VD.Total,0) = 0
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId AND P.ProdVtaBascula = 1
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
										PP.IdPrecio = 1
	WHERE CONVERT(VARCHAR,V.FechaCreacion,112) BETWEEN  CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	V.SucursalId = @pSucursalId and
	v.Activo = 1
	order by P.Descripcion
	


	/********************SOBRANTES DE PRODUCTOS MOSTRADOR*************************/
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT '2.6-SOBRANTES PRODUCTO MOSTRADOR',P.Clave +'-'+ P.Descripcion,0,PSR.CantidadSobrante - PSR.CantidadInventario,PP.Precio, (PSR.CantidadSobrante - PSR.CantidadInventario) * pp.Precio
	FROM doc_productos_sobrantes_registro PSR
	INNER JOIN cat_productos P ON P.ProductoId = PSR.ProductoId AND
							P.ProdVtaBascula = 0
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
					PP.IdPrecio = 1
	WHERE PSR.SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,PSR.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112) AND
	ISNULL(PSR.CantidadSobrante,0) > ISNULL(PSR.CantidadInventario,0)

	update #TMP_RESULTADO
	set Monto = Monto * -1
	where Abono = 0

	
	UPDATE #TMP_RESULTADO
	SET TotalEntregadoSucursal = ISNULL(@TotalRetiros,0),
		TotalAnalisisCorteCaja = ISNULL((SELECT SUM(Monto) FROM #TMP_RESULTADO WHERE Abono = 1),0),
		TotalDescuentos = ISNULL((SELECT SUM(Monto)*-1 FROM #TMP_RESULTADO WHERE Abono = 0),0)

	UPDATE #TMP_RESULTADO
	SET Diferencia = TotalEntregadoSucursal - TotalAnalisisCorteCaja + TotalDescuentos

	--RESULTADOS
	INSERT INTO #TMP_RESULTADO(TipoMovimiento,Concepto,Abono,Cantidad,PrecioUnitario,Monto)
	SELECT TOP 1 '3-BALANCE FINAL','Total Análisis Corte Caja',0,1,TotalAnalisisCorteCaja,TotalAnalisisCorteCaja
	FROM #TMP_RESULTADO
	union
	SELECT TOP 1 '3-BALANCE FINAL','Total Descuentos',0,1,TotalDescuentos,TotalDescuentos
	FROM #TMP_RESULTADO
	union
	SELECT TOP 1 '3-BALANCE FINAL','Total Entregado En Sucursal',0,1,TotalEntregadoSucursal,TotalEntregadoSucursal
	FROM #TMP_RESULTADO
	union
	SELECT TOP 1 '3-BALANCE FINAL','Diferencia',0,1,Diferencia,Diferencia
	FROM #TMP_RESULTADO
		


	SELECT Fila ,
		TipoMovimiento,
		Concepto,
		Abono,
		Cantidad,
		PrecioUnitario,
		Monto,
		TotalAnalisisCorteCaja = ISNULL(TotalAnalisisCorteCaja,0),
		TotalDescuentos = ISNULL(TotalDescuentos,0),
		TotalEntregadoSucursal = ISNULL(TotalEntregadoSucursal,0),
		Diferencia = ISNULL(Diferencia,0)
	FROM #TMP_RESULTADO
	order by Fila