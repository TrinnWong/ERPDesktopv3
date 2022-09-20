IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS WHERE NAME = 'p_doc_sobrantes_ajustes_inventario'
)
DROP PROC p_doc_sobrantes_ajustes_inventario
GO

-- p_doc_sobrantes_ajustes_inventario 10,'20220704',''
CREATE PROC p_doc_sobrantes_ajustes_inventario
@pSucursalId INT,
@pFecha DATETIME,
@pError VARCHAR(250) OUT
AS

	DECLARE @MovimientoId INT,
		@MovimientoDetalleId INT,
		@FolioMovimiento VARCHAR(200)

	BEGIN TRY

	BEGIN TRAN

	SELECT psc.ProductoSobranteId,Descripcion1=P1.Descripcion,PSC.ProductoConvertirId ,Descripcion2=p2.Descripcion,CantidadSobrante = SUM(ps.CantidadSobrante),
		TipoMovimientoInventario1 = CASE WHEN P1.Descripcion LIKE '%DESPERDICIO%' THEN 25 /*Desperdicio de Inventario*/ ELSE 6 /*Ajuste Por Salida*/ END,
		TipoMovimientoInventario2 = CASE WHEN PSC.Convertir = 1  THEN   5 /*Ajuste Por Entrada*/ END
	INTO #TMP_SOBRANTES_CONFIG
	FROM doc_productos_sobrantes_registro PS
	INNER JOIN doc_productos_sobrantes_config PSC ON PSC.ProductoSobranteId = PS.ProductoId 
	INNER JOIN cat_productos P1 ON P1.ProductoId = PSC.ProductoSobranteId
	INNER JOIN cat_productos P2 ON P2.ProductoId = PSC.ProductoConvertirId
	LEFT JOIN doc_productos_sobrantes_regitro_inventario PSI ON PSI.SobranteRegsitroId = PS.Id
	WHERE SucursalId = @pSucursalId AND
	PSI.Id IS NULL AND
	CONVERT(VARCHAR,PS.CreadoEl,112) = CONVERT(VARCHAR,@pFecha,112)
	GROUP BY psc.ProductoSobranteId,P1.Descripcion,PSC.ProductoConvertirId ,p2.Descripcion,PSC.Convertir

	


	/****DESPERDICIO DE INVENTARIO ENTRADA****/
	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
	FROM doc_inv_movimiento

	SELECT @FolioMovimiento = count(*) + 1
	FROM doc_inv_movimiento
	WHERE TipoMovimientoId = 5 AND
	SucursalId = @pSucursalId

	INSERT INTO doc_inv_movimiento(
		MovimientoId,SucursalId,FolioMovimiento,TipoMovimientoId,FechaMovimiento,HoraMovimiento,
		Comentarios,ImporteTotal,Activo,CreadoPor,CreadoEl,
		Autorizado,FechaAutoriza,SucursalDestinoId,AutorizadoPor,FechaCancelacion,
		ProductoCompraId,Consecutivo,SucursalOrigenId,VentaId,MovimientoRefId,
		Cancelado,TipoMermaId
	)
	SELECT TOP 1 @MovimientoId,@pSucursalId,@FolioMovimiento,5 /*DESPERDICIO*/,dbo.fn_GetDateTimeServer(),dbo.fn_GetDateTimeServer(),
	'Ajuste generado de manera automática',0,1,1,dbo.fn_GetDateTimeServer(),
	1,dbo.fn_GetDateTimeServer(),NULL,1,NULL,
	NULL,@FolioMovimiento,NULL,NULL,NULL,NULL,NULL
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1 LIKE '%DESPERDICIO%'

	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0) + 1
	FROM doc_inv_movimiento_detalle

	INSERT INTO doc_inv_movimiento_detalle(	MovimientoDetalleId,MovimientoId,ProductoId,Consecutivo,Cantidad,PrecioUnitario,Importe,
	Disponible,CreadoPor,CreadoEl,CostoUltimaCompra,CostoPromedio,ValCostoUltimaCompra,ValCostoPromedio,ValorMovimiento,Flete,Comisiones,
	SubTotal,PrecioNeto
	)
	SELECT  ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC) +@MovimientoDetalleId,@MovimientoId,ProductoSobranteId,ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC),CantidadSobrante,0,0,
	0,1,dbo.fn_GetDateTimeServer(),0,0,0,0,0,0,0,0,0
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1  LIKE '%DESPERDICIO%'

	/****DESPERDICIO DE INVENTARIO SALIDA****/
	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
	FROM doc_inv_movimiento

	SELECT @FolioMovimiento = count(*) + 1
	FROM doc_inv_movimiento
	WHERE TipoMovimientoId = 25 AND
	SucursalId = @pSucursalId

	INSERT INTO doc_inv_movimiento(
		MovimientoId,SucursalId,FolioMovimiento,TipoMovimientoId,FechaMovimiento,HoraMovimiento,
		Comentarios,ImporteTotal,Activo,CreadoPor,CreadoEl,
		Autorizado,FechaAutoriza,SucursalDestinoId,AutorizadoPor,FechaCancelacion,
		ProductoCompraId,Consecutivo,SucursalOrigenId,VentaId,MovimientoRefId,
		Cancelado,TipoMermaId
	)
	SELECT TOP 1 @MovimientoId,@pSucursalId,@FolioMovimiento,25 /*DESPERDICIO*/,dbo.fn_GetDateTimeServer(),dbo.fn_GetDateTimeServer(),
	'Ajuste generado de manera automática en Corte de Caja',0,1,1,dbo.fn_GetDateTimeServer(),
	1,dbo.fn_GetDateTimeServer(),NULL,1,NULL,
	NULL,@FolioMovimiento,NULL,NULL,NULL,NULL,NULL
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1 LIKE '%DESPERDICIO%'

	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0) + 1
	FROM doc_inv_movimiento_detalle

	INSERT INTO doc_inv_movimiento_detalle(	MovimientoDetalleId,MovimientoId,ProductoId,Consecutivo,Cantidad,PrecioUnitario,Importe,
	Disponible,CreadoPor,CreadoEl,CostoUltimaCompra,CostoPromedio,ValCostoUltimaCompra,ValCostoPromedio,ValorMovimiento,Flete,Comisiones,
	SubTotal,PrecioNeto
	)
	SELECT  ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC) +@MovimientoDetalleId,@MovimientoId,ProductoSobranteId,ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC),CantidadSobrante,0,0,
	0,1,dbo.fn_GetDateTimeServer(),0,0,0,0,0,0,0,0,0
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1  LIKE '%DESPERDICIO%'


	/***********ENTRADA DE PRODUCTOS SOBRANTES ANTES DE CONVERTIRLO EN OTRO PRODUCTO**********************/
	
	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
	FROM doc_inv_movimiento

	SELECT @FolioMovimiento = count(*) + 1
	FROM doc_inv_movimiento
	WHERE TipoMovimientoId = 5 AND
	SucursalId = @pSucursalId

	INSERT INTO doc_inv_movimiento(
		MovimientoId,SucursalId,FolioMovimiento,TipoMovimientoId,FechaMovimiento,HoraMovimiento,
		Comentarios,ImporteTotal,Activo,CreadoPor,CreadoEl,
		Autorizado,FechaAutoriza,SucursalDestinoId,AutorizadoPor,FechaCancelacion,
		ProductoCompraId,Consecutivo,SucursalOrigenId,VentaId,MovimientoRefId,
		Cancelado,TipoMermaId
	)
	SELECT TOP 1 @MovimientoId,@pSucursalId,@FolioMovimiento,5,dbo.fn_GetDateTimeServer(),dbo.fn_GetDateTimeServer(),
	'Ajuste generado de manera automática en Corte de Caja',0,1,1,dbo.fn_GetDateTimeServer(),
	1,dbo.fn_GetDateTimeServer(),NULL,1,NULL,
	NULL,@FolioMovimiento,NULL,NULL,NULL,NULL,NULL
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1 NOT LIKE '%DESPERDICIO%' AND TipoMovimientoInventario1 IS NOT NULL


	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0) + 1
	FROM doc_inv_movimiento_detalle

	INSERT INTO doc_inv_movimiento_detalle(	MovimientoDetalleId,MovimientoId,ProductoId,Consecutivo,Cantidad,PrecioUnitario,Importe,
	Disponible,CreadoPor,CreadoEl,CostoUltimaCompra,CostoPromedio,ValCostoUltimaCompra,ValCostoPromedio,ValorMovimiento,Flete,Comisiones,
	SubTotal,PrecioNeto
	)
	SELECT  ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC) +@MovimientoDetalleId,@MovimientoId,ProductoSobranteId,ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC),CantidadSobrante,0,0,
	0,1,dbo.fn_GetDateTimeServer(),0,0,0,0,0,0,0,0,0
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1  NOT LIKE '%DESPERDICIO%' AND TipoMovimientoInventario1 IS NOT NULL AND CantidadSobrante <> 0

	/***********SALIDA DE PRODUCTOS SOBRANTES PARA CONVERTIRLO EN OTRO PRODUCTO**********************/
	
	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
	FROM doc_inv_movimiento

	SELECT @FolioMovimiento = count(*) + 1
	FROM doc_inv_movimiento
	WHERE TipoMovimientoId = 6 AND
	SucursalId = @pSucursalId

	INSERT INTO doc_inv_movimiento(
		MovimientoId,SucursalId,FolioMovimiento,TipoMovimientoId,FechaMovimiento,HoraMovimiento,
		Comentarios,ImporteTotal,Activo,CreadoPor,CreadoEl,
		Autorizado,FechaAutoriza,SucursalDestinoId,AutorizadoPor,FechaCancelacion,
		ProductoCompraId,Consecutivo,SucursalOrigenId,VentaId,MovimientoRefId,
		Cancelado,TipoMermaId
	)
	SELECT TOP 1 @MovimientoId,@pSucursalId,@FolioMovimiento,TipoMovimientoInventario1 /*DESPERDICIO*/,dbo.fn_GetDateTimeServer(),dbo.fn_GetDateTimeServer(),
	'Ajuste generado de manera automática en Corte de Caja',0,1,1,dbo.fn_GetDateTimeServer(),
	1,dbo.fn_GetDateTimeServer(),NULL,1,NULL,
	NULL,@FolioMovimiento,NULL,NULL,NULL,NULL,NULL
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1 NOT LIKE '%DESPERDICIO%' AND TipoMovimientoInventario1 IS NOT NULL


	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0) + 1
	FROM doc_inv_movimiento_detalle

	INSERT INTO doc_inv_movimiento_detalle(	MovimientoDetalleId,MovimientoId,ProductoId,Consecutivo,Cantidad,PrecioUnitario,Importe,
	Disponible,CreadoPor,CreadoEl,CostoUltimaCompra,CostoPromedio,ValCostoUltimaCompra,ValCostoPromedio,ValorMovimiento,Flete,Comisiones,
	SubTotal,PrecioNeto
	)
	SELECT  ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC) +@MovimientoDetalleId,@MovimientoId,ProductoSobranteId,ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC),CantidadSobrante,0,0,
	0,1,dbo.fn_GetDateTimeServer(),0,0,0,0,0,0,0,0,0
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1  NOT LIKE '%DESPERDICIO%' AND TipoMovimientoInventario1 IS NOT NULL AND CantidadSobrante <> 0


	/***********ENTRADA DE PRODUCTOS SOBRANTES CONVERTIDOS A UN NUEVO PRODUCTO**********************/

	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
	FROM doc_inv_movimiento

	SELECT @FolioMovimiento = count(*) + 1
	FROM doc_inv_movimiento
	WHERE TipoMovimientoId = 5 AND
	SucursalId = @pSucursalId

	INSERT INTO doc_inv_movimiento(
		MovimientoId,SucursalId,FolioMovimiento,TipoMovimientoId,FechaMovimiento,HoraMovimiento,
		Comentarios,ImporteTotal,Activo,CreadoPor,CreadoEl,
		Autorizado,FechaAutoriza,SucursalDestinoId,AutorizadoPor,FechaCancelacion,
		ProductoCompraId,Consecutivo,SucursalOrigenId,VentaId,MovimientoRefId,
		Cancelado,TipoMermaId
	)
	SELECT TOP 1 @MovimientoId,@pSucursalId,@FolioMovimiento,TipoMovimientoInventario2 ,dbo.fn_GetDateTimeServer(),dbo.fn_GetDateTimeServer(),
	'Ajuste generado de manera automática en Corte de Caja',0,1,1,dbo.fn_GetDateTimeServer(),
	1,dbo.fn_GetDateTimeServer(),NULL,1,NULL,
	NULL,@FolioMovimiento,NULL,NULL,NULL,NULL,NULL
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1 NOT LIKE '%DESPERDICIO%' AND TipoMovimientoInventario1 IS NOT NULL


	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0) + 1
	FROM doc_inv_movimiento_detalle

	INSERT INTO doc_inv_movimiento_detalle(	MovimientoDetalleId,MovimientoId,ProductoId,Consecutivo,Cantidad,PrecioUnitario,Importe,
	Disponible,CreadoPor,CreadoEl,CostoUltimaCompra,CostoPromedio,ValCostoUltimaCompra,ValCostoPromedio,ValorMovimiento,Flete,Comisiones,
	SubTotal,PrecioNeto
	)
	SELECT  ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC) +@MovimientoDetalleId,@MovimientoId,ProductoConvertirId,ROW_NUMBER() OVER(ORDER BY ProductoSobranteId ASC),CantidadSobrante,0,0,
	0,1,dbo.fn_GetDateTimeServer(),0,0,0,0,0,0,0,0,0
	FROM #TMP_SOBRANTES_CONFIG
	WHERE Descripcion1  NOT LIKE '%DESPERDICIO%' AND TipoMovimientoInventario1 IS NOT NULL AND CantidadSobrante <> 0



	DROP TABLE #TMP_SOBRANTES_CONFIG

	COMMIT TRAN

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SET @pError = ERROR_MESSAGE()
	END CATCH