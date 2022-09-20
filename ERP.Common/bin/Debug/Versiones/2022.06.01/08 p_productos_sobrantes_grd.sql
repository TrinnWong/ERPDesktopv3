if  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_productos_sobrantes_grd'
)
DROP PROC p_productos_sobrantes_grd
GO

-- p_productos_sobrantes_grd 10,'20221101'
CREATE PROC p_productos_sobrantes_grd
@SucursalId INT,
@Fecha DATETIME
AS



SELECT PSR.ProductoId,
		PSR.SucursalId,
		CantidadSobrante = cast(SUM(PSR.CantidadSobrante) as decimal(14,3))
INTO #TMP_ProdcutoSobrante
FROM doc_productos_sobrantes_registro PSR
WHERE PSR.SucursalId = @SucursalId AND
CONVERT(VARCHAR,PSR.CreadoEl,112) = CONVERT(VARCHAR,@Fecha,112)
GROUP BY PSR.ProductoId,
		PSR.SucursalId
		
SELECT 
	p.ProductoId,
	P.Clave,
	P.Descripcion,
	Existencia = MAX(PE.ExistenciaTeorica),
	Fecha = @Fecha,
	CantidadSobrante = ISNULL(PSR.CantidadSobrante,0),
	RequiereBascula = P.ProdVtaBascula

FROM cat_productos P
left JOIN cat_productos_existencias PE ON PE.ProductoId = P.ProductoId
LEFT JOIN doc_inv_movimiento_detalle IMD ON IMD.ProductoId = P.ProductoId
LEFT JOIN doc_inv_movimiento IM ON IM.MovimientoId = IMD.MovimientoId AND
								CONVERT(VARCHAR,IM.FechaMovimiento,112) = CONVERT(VARCHAR,@Fecha,112)
LEFT JOIN #TMP_ProdcutoSobrante PSR ON PSR.ProductoId = P.ProductoId AND
												PSR.SucursalId = @SucursalId 
LEFT JOIN doc_productos_sobrantes_config PSC  ON PSC.ProductoSobranteId = P.ProductoId
WHERE PE.SucursalId = @SucursalId AND
(
	(IM.MovimientoId IS NOT NULL OR ISNULL(PE.ExistenciaTeorica,0) > 0) OR
	PSC.ProductoSobranteId IS NOT NULL
	

)
GROUP BY 
	P.ProductoId,
	P.Clave,
	P.Descripcion,
	PSR.CantidadSobrante,
	 P.ProdVtaBascula
ORDER BY P.ProdVtaBascula DESC,P.Descripcion

DROP TABLE #TMP_ProdcutoSobrante




