IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_inventario_producto'
)
DROP PROC p_rpt_inventario_producto
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_inventario_producto 1,'20210927','20211003'
CREATE proc p_rpt_inventario_producto
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
as
BEGIN	

	


	DECLARE @TituloReporte varchar(250),
		@Sucursal varchar(250)
	
	SET @TituloReporte = 'INVENTARIO DEL '+CONVERT(VARCHAR,@pDel,103) + ' AL '+CONVERT(VARCHAR,@pAl,103)

	SELECT @Sucursal = NombreSucursal
	FROM cat_sucursales
	where Clave = @pSucursalId

	SELECT imd.* ,i.TipoMovimientoId,tm.EsEntrada,SucursalId = i.SucursalId
	INTO #tmpMovimientosinventario
	FROM doc_inv_movimiento i
	INNER JOIN doc_inv_movimiento_detalle imd on imd.MovimientoId = i.MovimientoId
	INNER JOIN cat_tipos_movimiento_inventario tm on tm.TipoMovimientoInventarioId = i.TipoMovimientoId 
	WHERE CONVERT(VARCHAR,i.FechaMovimiento,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112) AND
	i.Activo = 1 AND @pSucursalId IN (0,i.SucursalId) AND i.SucursalId is not null

	

	SELECT p.ProductoId, 
			ExistenciaInicial = MAX(ISNULL(imd.Disponible,0))
	into #tmpExistenciaInicial
	FROM cat_Productos p
	INNER JOIN doc_inv_movimiento_detalle imd on imd.ProductoId = p.ProductoId 
	INNER JOIN doc_inv_movimiento m on m.MovimientoId = imd.MovimientoId AND
								m.MovimientoId = (
													SELECT top 1 sm.MovimientoId
													FROM doc_inv_movimiento sm 
													INNER JOIN doc_inv_movimiento_detalle smd on smd.MovimientoId = sm.MovimientoId 
													WHERE smd.ProductoId = p.ProductoId  AND 
													CONVERT(VARCHAR,sm.FechaMovimiento,112) < CONVERT(VARCHAR,@pDel,112) AND
													sm.Activo = 1 AND
													sm.SucursalId = @pSucursalId
 
													ORDER BY sm.FechaMovimiento  DESC
												)
	INNER JOIN cat_tipos_movimiento_inventario tm on tm.TipoMovimientoInventarioId = m.TipoMovimientoId 
	WHERE m.SucursalId = @pSucursalId
	GROUP BY p.ProductoId


	

	SELECT ProductoId,
		MinMovimientoDetalleId = MIN(i.MovimientoDetalleId),
		MaxMovimientoDetalleId = MAX(i.MovimientoDetalleId)
	INTO #tmpMovimientoMaxMin
	FROM #tmpMovimientosinventario i	 
	group by ProductoId

	

	SELECT 
			
			ProductoId = p.ProductoId,
			TituloReporte = @TituloReporte,
			Sucursal = ISNULL(@Sucursal,'TODAS') ,
			ClaveProducto = p.Clave,
			Producto = p.Descripcion,
			InvInicial = ISNULL(ei.ExistenciaInicial,0),
			Compras =CAST(0 as decimal(14,3)),
			SalidasTraspasos = CAST(0 as  decimal(14,3)),
			InvFinal = CAST(0 as  decimal(14,3))
	INTO #tmpResult
	FROM  cat_productos p 
	LEFT JOIN #tmpMovimientoMaxMin MinM on MinM.ProductoId = p.ProductoId 
	LEFT JOIN #tmpMovimientosinventario II ON II.MovimientoDetalleId = MinM.MinMovimientoDetalleId	
	LEFT JOIN #tmpExistenciaInicial ei on ei.ProductoId = p.ProductoId
	GROUP BY   p.ProductoId,p.Clave, p.Descripcion,II.Disponible,ei.ExistenciaInicial
	ORDER BY p.Descripcion,p.Clave

	update #tmpResult
	set Compras = (SELECT ISNULL(SUM( TMP.Cantidad),0) FROM #tmpMovimientosinventario TMP WHERE TMP.ProductoId = r.ProductoId AND TMP.EsEntrada = 1),
		SalidasTraspasos = (SELECT ISNULL(SUM( TMP.Cantidad),0) FROM #tmpMovimientosinventario TMP WHERE TMP.ProductoId = r.ProductoId AND TMP.EsEntrada = 0)
	from #tmpResult r

	update #tmpResult
	set InvFinal = ISNULL(InvInicial,0) + ISNULL(Compras,0) - ISNULL(SalidasTraspasos,0)
	from #tmpResult r

	

	SELECT Id = CAST(ROW_NUMBER() OVER(ORDER BY Producto ASC) AS INT),*
	FROM #tmpResult
	ORDER BY Producto
	
	



END

