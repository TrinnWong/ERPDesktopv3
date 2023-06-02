
-- p_productos_sobrantes_grd 6,'20230404'
ALTER PROC [dbo].[p_productos_sobrantes_grd]
@SucursalId INT,
@Fecha DATETIME
AS

DECLARE @ExcluirBascula BIT=0,
	@SoloProductosGranel BIT=0

CREATE TABLE #TMP_EXCLUIR_CLAVES( Clave VARCHAR(200))

INSERT INTO #TMP_EXCLUIR_CLAVES(Clave)
SELECT PS.Valor
FROM sis_preferencias_sucursales PS
INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId
WHERE P.Preferencia IN( 'MAIZ-SACO-CLAVE', 'MASECA-SACO-CLAVE') AND
PS.SucursalId = @SucursalId
UNION
SELECT PS.Valor
FROM sis_preferencias_empresa PS
INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId
WHERE P.Preferencia IN( 'MAIZ-SACO-CLAVE', 'MASECA-SACO-CLAVE') 


SELECT  @SoloProductosGranel = dbo.fnPreferenciaAplicaSiNo('SOB-SoloProdBascula',@SucursalId)


/********EXCLUIR BASCULA*******************/

SELECT @ExcluirBascula = CASE WHEN PS.PreferenciaId IS NOT NULL THEN 1 ELSE 0  END
FROM sis_preferencias_sucursales PS
INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId AND
						P.Preferencia = 'SOBRANTE-QuitarBasculaEnCaptura'
WHERE SucursalId = @SucursalId 

IF ISNULL(@ExcluirBascula,0) = 0
BEGIN
	SELECT @ExcluirBascula = CASE WHEN PS.PreferenciaId IS NOT NULL THEN 1 ELSE 0  END
	FROM sis_preferencias_empresa PS
	INNER JOIN sis_preferencias P ON P.Id = PS.PreferenciaId AND
							P.Preferencia = 'SOBRANTE-QuitarBasculaEnCaptura'
	INNER JOIN cat_sucursales S ON S.Clave = @SucursalId
	INNER JOIN cat_empresas E ON E.Clave = S.Empresa 
END

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
	RequiereBascula =CAST( CASE WHEN @ExcluirBascula = 1 THEN 0 ELSE P.ProdVtaBascula END AS bit)

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
AND P.CLAVE NOT IN (SELECT Clave FROM #TMP_EXCLUIR_CLAVES)
AND ((@SoloProductosGranel = 1 AND P.ProdVtaBascula = 1) OR  @SoloProductosGranel = 0)

GROUP BY 
	P.ProductoId,
	P.Clave,
	P.Descripcion,
	PSR.CantidadSobrante,
	 P.ProdVtaBascula,
	 P.Orden
ORDER BY P.ProdVtaBascula DESC,P.ORDEN ,P.Descripcion

DROP TABLE #TMP_ProdcutoSobrante



