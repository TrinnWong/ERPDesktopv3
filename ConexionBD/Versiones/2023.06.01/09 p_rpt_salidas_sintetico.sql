IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_salidas_sintetico'
)
DROP PROC p_rpt_salidas_sintetico
GO

-- p_rpt_salidas_sintetico 0,'20210901','20211001'
CREATE proc p_rpt_salidas_sintetico
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
as
BEGIN	

	DECLARE @TituloReporte varchar(250)

	SET @TituloReporte = 'SALIDAS DE INVENTARIO DEL DIA '+CONVERT(VARCHAR,@pDel,103) + ' AL '+CONVERT(VARCHAR,@pAl,103)

	SELECT imd.* ,i.TipoMovimientoId,tm.EsEntrada,SucursalId = i.SucursalId,i.FechaMovimiento,SucursalDestinoId = i.SucursalDestinoId
	INTO #tmpMovimientosinventario
	FROM doc_inv_movimiento i
	INNER JOIN doc_inv_movimiento_detalle imd on imd.MovimientoId = i.MovimientoId
	INNER JOIN cat_tipos_movimiento_inventario tm on tm.TipoMovimientoInventarioId = i.TipoMovimientoId 
	WHERE CONVERT(VARCHAR,i.FechaMovimiento,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112) AND
	i.Activo = 1 AND @pSucursalId IN (0,i.SucursalId) AND
	tm.EsEntrada = 0

	SELECT ProductoId,
		MinMovimientoDetalleId = MIN(i.MovimientoDetalleId),
		MaxMovimientoDetalleId = MAX(i.MovimientoDetalleId),
		MaxCostoPromedio = MAX(i.CostoPromedio)
	INTO #tmpMovimientoMaxMin
	FROM #tmpMovimientosinventario i	 
	group by ProductoId

	SELECT 
			Id = CAST(ROW_NUMBER() OVER(ORDER BY S.NombreSucursal ASC) AS INT),
			TituloReporte = @TituloReporte,
			SucursalOrigen = ISNULL(S.NombreSucursal,'TODAS') ,
			SucursalDestino = ISNULL(SD.NombreSucursal,''),
			ClaveProducto = p.Clave,
			Producto = p.Descripcion,			
			Cantidad = SUM(I.Cantidad)
	FROM #tmpMovimientosinventario I
	INNER JOIN cat_productos p on p.ProductoId = I.ProductoId
	INNER JOIN #tmpMovimientoMaxMin MinM on MinM.ProductoId = I.ProductoId 
	
	INNER JOIN cat_sucursales S ON I.SucursalId = S.Clave
	LEFT JOIN cat_sucursales SD ON I.SucursalDestinoId = SD.Clave
	GROUP BY  p.Clave, p.Descripcion,S.NombreSucursal,SD.NombreSucursal
	ORDER BY S.NombreSucursal,SD.NombreSucursal,p.Descripcion,p.Clave



END