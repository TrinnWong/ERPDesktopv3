IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_cat_subfamilias_sel'
)
DROP PROC p_cat_subfamilias_sel
GO

-- p_cat_subfamilias_sel 1
CREATE PROC p_cat_subfamilias_sel
@pSoloParaVenta BIT=0
AS

	SELECT F.Clave,
			F.Descripcion
	FROM cat_subfamilias F
	INNER JOIN cat_productos P ON F.Clave = P.ClaveSubFamilia
	WHERE @pSoloParaVenta = 0 OR (@pSoloParaVenta = 1 AND P.ProdParaVenta = 1)
	GROUP BY F.Clave,
			F.Descripcion
	ORDER BY F.Descripcion