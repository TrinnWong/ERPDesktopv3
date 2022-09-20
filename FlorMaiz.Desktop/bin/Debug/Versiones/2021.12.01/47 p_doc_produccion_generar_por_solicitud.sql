IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_produccion_generar_por_solicitud'
)
DROP PROC p_doc_produccion_generar_por_solicitud
GO
-- p_doc_produccion_generar_por_solicitud 12,1
CREATE PROC p_doc_produccion_generar_por_solicitud
@pProduccionSolicitudId INT,
@pUsuarioId INT
AS

	declare @produccionId INT

	SELECT @produccionId = ISNULL(MAX(ProduccionId),0) 
	FROM doc_produccion 

	INSERT INTO doc_produccion(
	ProduccionId,	SucursalId,	FechaHoraInicio,	FechaHoraFin,	CreadoPor,	CreadoEl,
	Completado,		Activo,		EstatusProduccionId,ProductoId,		ProduccionSolicitudId)
	SELECT @produccionId + ROW_NUMBER() OVER(ORDER BY PS.ProduccionSolicitudId ASC) ,PS.ParaSucursalId, GETDATE(),			NULL,			@pUsuarioId,GETDATE(),
	0,				1,			2,					PSD.ProductoId,	@pProduccionSolicitudId		
	FROM doc_produccion_solicitud PS 
	INNER JOIN doc_produccion_solicitud_detalle PSD ON PSD.ProduccionSolicitudId = PS.ProduccionSolicitudId
	--INNER JOIN doc_produccion_solicitud_requerido PSR ON PSR.ProduccionSolicitudDetalleId = PSD.Id
	WHERE PS.ProduccionSolicitudId = @pProduccionSolicitudId
	GROUP BY PS.ProduccionSolicitudId,
	PSD.ProductoId,
	PS.ParaSucursalId
	
	INSERT INTO doc_produccion_entrada(ProduccionId,ProductoId,Cantidad,UnidadId,CreadoEl)
	SELECT P.ProduccionId,IR.ProductoRequeridoId,SUM(IR.Cantidad),MAX(IR.UnidadRequeridaId),GETDATE()
	FROM doc_produccion_solicitud PS
	INNER JOIN doc_produccion_solicitud_detalle PSD ON PSD.ProduccionSolicitudId = PS.ProduccionSolicitudId
	INNER JOIN doc_produccion_solicitud_requerido IR ON IR.ProduccionSolicitudDetalleId = PSD.Id
	inner join doc_produccion p on p.ProduccionSolicitudId = PS.ProduccionSolicitudId AND
								PSD.ProductoId = p.ProductoId
	WHERE PS.ProduccionSolicitudId = @pProduccionSolicitudId
	group by P.ProduccionId,IR.ProductoRequeridoId


