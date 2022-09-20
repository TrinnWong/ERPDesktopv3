if  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_productos_sobrantes_registro_sel'
)
DROP PROC p_doc_productos_sobrantes_registro_sel
GO
CREATE PROC p_doc_productos_sobrantes_registro_sel
@pSucursalId int,
@pFecha DateTime
AS
	SELECT Id,
		SucursalId,
		ProductoId,
		CantidadSobrante,
		CreadoEl,
		CreadoPor
	FROM doc_productos_sobrantes_registro
	WHERE SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,CreadoEl,112) = CONVERT(VARCHAR,@pFecha,112)