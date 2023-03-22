
-- p_productos_sobrantes_grd 6,'20230110'
ALTER PROC [dbo].[p_productos_sobrantes_grd]
@SucursalId INT,
@Fecha DATETIME
AS



SELECT PSR.ProductoId,
		PSR.SucursalId,
		CantidadSobrante = cast(SUM(PSR.CantidadSobrante) as decimal(14,3)),
		PSR.Cerrado
INTO #TMP_ProdcutoSobrante
FROM doc_productos_sobrantes_registro PSR
WHERE PSR.SucursalId = @SucursalId AND
CONVERT(VARCHAR,PSR.CreadoEl,112) = CONVERT(VARCHAR,@Fecha,112)
GROUP BY PSR.ProductoId,
		PSR.SucursalId,
		PSR.Cerrado

INSERT INTO #TMP_ProdcutoSobrante(ProductoId,SucursalId,CantidadSobrante,Cerrado)
SELECT psc.ProductoSobranteId,@SucursalId,0,0
FROM doc_productos_sobrantes_config PSC 
INNER JOIN cat_sucursales S ON S.Empresa = PSC.EmpresaId AND
							S.Clave = @SucursalId
AND NOT EXISTS (
	SELECT 1
	FROM #TMP_ProdcutoSobrante S1
	WHERE S1.ProductoId = PSC.ProductoSobranteId
)


		
SELECT 
	p.ProductoId,
	P.Clave,
	P.Descripcion,
	Existencia = ISNULL(MAX(PE.ExistenciaTeorica),0),
	Fecha = @Fecha,
	CantidadSobrante = ISNULL(PSR.CantidadSobrante,0),
	RequiereBascula = P.ProdVtaBascula

FROM cat_productos P
left JOIN cat_productos_existencias PE ON PE.ProductoId = P.ProductoId AND PE.SucursalId = @SucursalId
LEFT JOIN doc_inv_movimiento_detalle IMD ON IMD.ProductoId = P.ProductoId
LEFT JOIN doc_inv_movimiento IM ON IM.MovimientoId = IMD.MovimientoId AND
								CONVERT(VARCHAR,IM.FechaMovimiento,112) = CONVERT(VARCHAR,@Fecha,112)
LEFT JOIN #TMP_ProdcutoSobrante PSR ON PSR.ProductoId = P.ProductoId AND
												PSR.SucursalId = @SucursalId 
LEFT JOIN doc_productos_sobrantes_config PSC  ON PSC.ProductoSobranteId = P.ProductoId
WHERE (
			(
					PE.SucursalId = @SucursalId  AND
					(
						(IM.MovimientoId IS NOT NULL OR ISNULL(PE.ExistenciaTeorica,0) > 0) OR
						PSC.ProductoSobranteId IS NOT NULL	

					) 
			) 
			OR
			(
				PSR.SucursalId =@SucursalId 
			)
)
AND ISNULL(PSR.Cerrado,0) = 0
AND P.Descripcion NOT LIKE '%FRIA%'


GROUP BY 
	P.ProductoId,
	P.Clave,
	P.Descripcion,
	PSR.CantidadSobrante,
	 P.ProdVtaBascula,
	 P.Orden
ORDER BY P.ProdVtaBascula DESC,P.ORDEN ,P.Descripcion

DROP TABLE #TMP_ProdcutoSobrante


