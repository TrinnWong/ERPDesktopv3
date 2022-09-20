IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_cat_rest_platillo_adicionales_sel'
)
DROP PROC p_cat_rest_platillo_adicionales_sel
GO

-- p_cat_rest_platillo_adicionales_sel 1
CREATE PROC p_cat_rest_platillo_adicionales_sel
@pProductoId INT
AS

	SELECT DISTINCT pa.*
	FROM cat_productos P
	INNER JOIN cat_rest_platillo_adicionales_sfam PAF ON PAF.SubfamiliaId = P.ClaveSubFamilia
	INNER JOIN cat_rest_platillo_adicionales PA ON PA.Id = PAF.PlatilloAdicionalId

	UNION 
	
	SELECT PA.*
	FROM cat_rest_platillo_adicionales PA 
	WHERE PA.MostrarSiempre = 1