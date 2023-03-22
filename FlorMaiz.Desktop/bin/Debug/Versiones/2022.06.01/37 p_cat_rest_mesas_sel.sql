IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_cat_rest_mesas_sel'
)
DROP PROC p_cat_rest_mesas_sel
GO

CREATE PROC p_cat_rest_mesas_sel
@pSucursalId INT
AS

	SELECT MesaId,
		SucursalId,
		Nombre,
		Descripcion,
		Activo,
		CreadoEl,
		CreadoPor,
		ModificadoEl,
		ModificadoPor
	FROM cat_rest_mesas
	WHERE SucursalId = @pSucursalId AND
	Activo = 1