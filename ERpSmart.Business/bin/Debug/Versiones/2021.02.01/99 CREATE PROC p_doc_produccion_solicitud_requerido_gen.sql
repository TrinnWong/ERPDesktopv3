IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_produccion_solicitud_requerido_gen'
)
DROP PROC p_doc_produccion_solicitud_requerido_gen
go
CREATE PROC p_doc_produccion_solicitud_requerido_gen
@pProduccionSolicitudId INT,
@pCreadoPor INT
AS
BEGIN


	DELETE [doc_produccion_solicitud_requerido]
	FROM [doc_produccion_solicitud_requerido] R
	INNER JOIN doc_produccion_solicitud_detalle SD ON SD.Id = R.ProduccionSolicitudDetalleId
	WHERE SD.ProduccionSolicitudId = @pProduccionSolicitudId

	INSERT INTO [doc_produccion_solicitud_requerido](
		ProduccionSolicitudDetalleId,		ProductoRequeridoId,		UnidadRequeridaId,
		Cantidad,							CreadoEl,							CreadoPor
	)
	SELECT SD.Id,							PB.ProductoBaseId,		  UnidadRequeridaId =PB.UnidadCocinaId,
		  CantidadRequerida = ISNULL(SD.Cantidad,0) * ISNULL(PB.Cantidad,0),GETDATE(),@pCreadoPor
	FROM doc_produccion_solicitud_detalle SD
	INNER JOIN cat_productos_base PB on PB.ProductoId = SD.ProductoId
	INNER JOIN cat_productos P ON P.ProductoId = SD.ProductoId
	WHERE SD.ProduccionSolicitudId = @pProduccionSolicitudId
END