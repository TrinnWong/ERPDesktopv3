IF  EXISTS(
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_produccion_rendimiento'
)
drop proc p_rpt_produccion_rendimiento
GO

-- p_rpt_produccion_rendimiento 0,'20220101','20220228'
CREATE PROC [dbo].[p_rpt_produccion_rendimiento]
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
AS

	DECLARE @IndicadorProduccionEstimada DECIMAL(10,2),
			@IndicadorGlobalProduccionEstimada DECIMAL(10,2)

	--venta tortilla
	SELECT Cantidad = SUM(VD.Cantidad)
	into #tmpVentaTortilla
	FROM doc_ventas V
	INNER JOIN doc_ventas_detalle VD ON VD.VentaId = V.VentaId
	INNER JOIN cat_productos p on p.ProductoId = VD.ProductoId AND
									UPPER(p.Descripcion) = 'TORTILLA'
	WHERE V.Activo = 1 AND
	v.FechaCancelacion IS NULL AND
	@pSucursalId IN (0,V.SucursalId) AND
	CONVERT(VARCHAR,V.Fecha,112) BETWEEN CONVERT(VARCHAR,@pDel,112) and CONVERT(VARCHAR,@pAl,112)
	


	--PRODUCTOS PRODUCCIÓN
	SELECT 
		  
		   ProductoTerminadoId=P.ProductoId,
		   ProductoTerminado = isnull(P.DescripcionCorta,P.Descripcion),
		   ProductoMateriaPrimaId = MP.ProductoId,
		   ProductoMateriaPrima = MP.DescripcionCorta,
		   Unidad = UNID.DescripcionCorta,
		   CantidadRealInsumo = ISNULL(SUM(PE.Cantidad),0),		  
		   CantidadEstimadaInsumo = ISNULL(max(PB.Cantidad),0) * ISNULL(SUM(PS.Cantidad),0),		   
		   CantidadRealProductoTerminado = ISNULL(SUM(PS.Cantidad),0),
		   CantidadEstimadaProductoTerminado = CAST(0 AS DECIMAL(14,2)),
		   IndicadorRendimiento = CAST(0 AS DECIMAL(14,2)),
		   IndicadorGlobalRendimiento = CAST(0 AS DECIMAL(14,2)),
		   IndicadorProduccionEstimada = CAST(0 AS DECIMAL(14,2)),
		   IndicadorGlobalProduccionEstimada = CAST(0 AS DECIMAL(14,2))
	INTO #tmpResult
	FROM doc_produccion prod	
	INNER JOIN cat_productos P ON P.ProductoId = prod.ProductoId
	INNER JOIN cat_productos_base PB ON PB.ProductoId = P.ProductoId 
	INNER JOIN cat_productos MP ON MP.ProductoId = PB.ProductoBaseId
	INNER JOIN cat_unidadesmed UNID ON UNID.Clave = PB.UnidadCocinaId
	LEFT JOIN doc_produccion_entrada PE ON PE.ProduccionId = prod.ProduccionId AND 
											PE.ProductoId = MP.ProductoId
	LEFT JOIN doc_produccion_salida PS ON PS.ProduccionId = prod.ProduccionId AND
										PS.ProductoId = P.ProductoId
	WHERE prod.Completado = 1 AND
	@pSucursalId IN (0,prod.SucursalId) AND
	CONVERT(VARCHAR,prod.FechaHoraFin,112) BETWEEN CONVERT(VARCHAR,@pDel,112) and CONVERT(VARCHAR,@pAl,112)
	GROUP BY P.ProductoId,
	P.DescripcionCorta,
	P.Descripcion,
	MP.ProductoId,
	MP.DescripcionCorta,
	UNID.DescripcionCorta

	UNION
	
	--TORTILLA
	SELECT 
		   ProductoTerminadoId=P.ProductoId,
		   ProductoTerminado = isnull(P.DescripcionCorta,P.Descripcion),
		   ProductoMateriaPrimaId = MP.ProductoId,
		   ProductoMateriaPrima = MP.DescripcionCorta,
		   Unidad = UNID.DescripcionCorta,
		   CantidadRealInsumo = isnull(SUM(IMD.Cantidad),0),		  
		   CantidadEstimadaInsumo = isnull(max(PB.Cantidad),0) *MAX(Vt.Cantidad),
		   CantidadRealProductoTerminado = MAX(vt.Cantidad),
		   CantidadEstimadaProductoTerminado = CAST(0 AS DECIMAL(14,2)),
		   IndicadorRendimiento = CAST(0 AS DECIMAL(14,2)),
		   IndicadorGlobalRendimiento = CAST(0 AS DECIMAL(14,2)),
		   IndicadorProduccionEstimada = CAST(0 AS DECIMAL(14,2)),
		   IndicadorGlobalProduccionEstimada = CAST(0 AS DECIMAL(14,2))
	FROM cat_productos P
	INNER JOIN cat_productos_base PB ON PB.ProductoId = P.ProductoId 
	INNER JOIN cat_productos MP ON MP.ProductoId = PB.ProductoBaseId
	INNER JOIN cat_unidadesmed UNID ON UNID.Clave = PB.UnidadCocinaId
	INNER JOIN doc_inv_movimiento IM ON IM.Activo = 1 AND
									IM.TipoMovimientoId = 22-- Producto Terminado
	INNER JOIN doc_inv_movimiento_detalle IMD on IMD.MovimientoId = IM.MovimientoId AND
									IMD.ProductoId = PB.ProductoBaseId
	INNER JOIN #tmpVentaTortilla vt on vt.Cantidad = vt.Cantidad
	where UPPER(P.DescripcionCorta) = 'TORTILLA' AND
	CONVERT(VARCHAR,IM.CreadoEl,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112)
	group by P.ProductoId,
	P.DescripcionCorta,
	MP.ProductoId,
	MP.DescripcionCorta,
	UNID.DescripcionCorta,
	P.Descripcion

	UPDATE #tmpResult
	SET IndicadorRendimiento = (((CantidadRealInsumo * 100) / CantidadEstimadaInsumo)-100)/100

	

	UPDATE #tmpResult
	SET IndicadorGlobalRendimiento = (SELECT SUM(IndicadorRendimiento)/COUNT(*) from #tmpResult WHERE ProductoTerminado = 'MASA')

	--CANTIDAD ESTIMADA PRODUCTO TERMINADO
	--Update #tmpResult
	SELECT CantidadEstimadaProductoTerminado = max(CantidadRealInsumo) / MAX(PB.Cantidad),T.ProductoTerminadoId
	INTO #TMPCantidadEstimada
	FROM #tmpResult T
	INNER JOIN cat_productos_base PB ON PB.ProductoId = T.ProductoTerminadoId AND
								PB.ProductoMateriaPrimaId = (SELECT MIN(ProductoMateriaPrimaId) FROM cat_productos_base S1 WHERE S1.ProductoId = PB.ProductoId)
	WHERE T.ProductoMateriaPrimaId = PB.ProductoBaseId
	GROUP BY T.ProductoTerminadoId

	UPDATE #tmpResult
	SET CantidadEstimadaProductoTerminado = T2.CantidadEstimadaProductoTerminado
	FROM #tmpResult T1
	INNER JOIN #TMPCantidadEstimada T2 ON T2.ProductoTerminadoId = T1.ProductoTerminadoId

	
	SELECT ProductoTerminadoId , IndicadorProduccionEstimada = (((MAX(CantidadEstimadaInsumo)*100) / MAX(CantidadRealInsumo))-100)/100
	INTO #TMPIndicadorProduccionEstimada
	FROM #tmpResult TMP
	GROUP BY ProductoTerminadoId

	UPDATE #tmpResult
	SET IndicadorProduccionEstimada = TMPI.IndicadorProduccionEstimada + 1
	FROM #tmpResult TMP
	INNER JOIN #TMPIndicadorProduccionEstimada TMPI ON TMPI.ProductoTerminadoId = TMP.ProductoTerminadoId

	SELECT @IndicadorGlobalProduccionEstimada  = SUM(IndicadorProduccionEstimada)/COUNT(*)
	FROM #tmpResult TMP
	WHERE TMP.ProductoTerminado = 'MASA'
	

	UPDATE #tmpResult
	SET IndicadorGlobalProduccionEstimada = @IndicadorGlobalProduccionEstimada

	SELECT * FROM #tmpResult