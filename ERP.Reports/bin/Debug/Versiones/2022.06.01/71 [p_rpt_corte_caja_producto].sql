
-- p_rpt_corte_caja_producto 0,'20220922','20220922'
ALTER PROC [dbo].[p_rpt_corte_caja_producto]
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
AS

	
	--EXISTENCIAS
	SELECT imd.ProductoId,
		MinId = MIN(IMD.MovimientoDetalleId),
		MaxId = MAX(IMD.MovimientoDetalleId)
	INTO #TMP_EXISTENCIAS
	FROM doc_inv_movimiento_detalle IMD
	INNER JOIN doc_inv_movimiento IM on IM.MovimientoId = IMD.MovimientoId and im.Activo = 1 AND
					@pSucursalId IN(0, IM.SucursalId)
	WHERE CONVERT(VARCHAR,IM.FechaMovimiento,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112) 
	GROUP BY imd.ProductoId
	
	SELECT 
		Id =ROW_NUMBER() OVER(ORDER BY P.ProductoId ASC) ,
		CajaId = 1,
		Caja = 'caja',
		P.ProductoId,
		Producto = P.Descripcion,
		ExistenciaInicial = ISNULL(IMD.Disponible,0),
		ExistenciaFinal = ISNULL(FMD.Disponible,0),
		CantidadVenta = ISNULL(SUM(vd.Cantidad),0),
		ImporteVenta = ISNULL(SUM(Vd.Total),0)
	FROM doc_ventas_detalle vd 
	INNER JOIN doc_ventas v on v.VentaId = vd.VentaId
	INNER JOIN cat_cajas C ON C.Clave = v.CajaId
	INNER JOIN cat_productos P ON P.ProductoId = vd.ProductoId
	LEFT JOIN #TMP_EXISTENCIAS TMP ON TMP.ProductoId = vd.ProductoId
	LEFT JOIN doc_inv_movimiento_detalle IMD ON IMD.MovimientoDetalleId = TMP.MinId
	LEFT JOIN doc_inv_movimiento_detalle FMD ON FMD.MovimientoDetalleId = TMP.MaxId
	WHERE CONVERT(VARCHAR,vd.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pDel,112) AND CONVERT(VARCHAR,@pAl,112) AND
	V.Activo = 1 and
	@pSucursalId in (v.SucursalId,0)
	GROUP BY 
		P.ProductoId,
		P.Descripcion,
		IMD.Disponible,
		FMD.Disponible
	order by ISNULL(SUM(Vd.Total),0)DESC,P.ProductoId

	

	