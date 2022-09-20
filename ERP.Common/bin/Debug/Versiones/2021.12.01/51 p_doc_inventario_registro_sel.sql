IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_inventario_registro_sel'
)
DROP PROC p_doc_inventario_registro_sel
GO
-- p_doc_inventario_registro_sel 2,'20220201'
-- drop proc p_doc_inventario_registro_sel
CREATE PROC p_doc_inventario_registro_sel
@pSucursalId INT,
@pFecha DATETIME
as
BEGIN

	SELECT 
			I.RegistroInventarioId,
			I.SucursalId,
			P.ProductoId,
			P.DescripcionCorta,
			CantidadReal = ISNULL(I.CantidadReal,0),
			Unidad = U.DescripcionCorta,
			CantidadTeorica = ISNULL(I.CantidadTeorica,PE.ExistenciaTeorica),
			I.Diferencia,
			I.CreadoEl,
			I.CreadoPor
	FROM cat_productos_existencias PE
	INNER JOIN cat_productos P ON P.ProductoId = PE.ProductoId
	INNER JOIN cat_unidadesmed U on U.Clave = P.ClaveUnidadMedida
	LEFT JOIN doc_inventario_registro I ON I.ProductoId = P.ProductoId AND
									CONVERT(VARCHAR,I.CreadoEl,112) = CONVERT(VARCHAR,@pFecha,112)
	WHERE P.Estatus = 1 AND
	P.Inventariable = 1 and
	PE.SucursalId = @pSucursalId

END