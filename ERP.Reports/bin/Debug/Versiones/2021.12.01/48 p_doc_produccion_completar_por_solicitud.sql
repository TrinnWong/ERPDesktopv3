IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_produccion_completar_por_solicitud'
)
DROP PROC p_doc_produccion_completar_por_solicitud
GO
CREATE PROC p_doc_produccion_completar_por_solicitud
@pProduccionSolicitudId INT,
@pUsuarioId INT
AS

	declare @produccionId INT

	UPDATE doc_produccion
	SET EstatusProduccionId = 3,
		Completado = 1,
		FechaHoraFin = GETDATE()
	WHERE ProduccionSolicitudId = @pProduccionSolicitudId
	
	INSERT INTO doc_produccion_salida(ProduccionId,ProductoId,Cantidad,UnidadId,CreadoEl)
	SELECT PS.ProduccionId,PSD.ProductoId,SUM(PSA.Cantidad),MAX(PSA.UnidadId),GETDATE()
	FROM doc_produccion_solicitud PS
	INNER JOIN doc_produccion_solicitud_detalle PSD ON PSD.ProduccionSolicitudId = PS.ProduccionSolicitudId
	INNER JOIN doc_produccion_solicitud_aceptacion PSA ON PSA.ProduccionSolicitudDetalleId = PSD.Id 
	INNER JOIN doc_produccion P ON P.ProduccionSolicitudId = PS.ProduccionSolicitudId AND
								P.ProductoId = PSD.ProductoId
	WHERE PS.ProduccionSolicitudId = @pProduccionSolicitudId
	group by PS.ProduccionId,PSD.ProductoId


