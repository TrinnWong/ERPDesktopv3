IF EXISTS (
	SELECT 1
	FROM sysobjects
	WHERE name = 'p_doc_solicitud_produccion_requerido_grd'
)
BEGIN
	DROP PROC p_doc_solicitud_produccion_requerido_grd

END
GO

-- p_doc_solicitud_produccion_requerido_grd 9
CREATE proc p_doc_solicitud_produccion_requerido_grd
@pProduccionSolicitudId INT
AS

	SELECT ProductoId = ps.ProductoRequeridoId,
		Clave = p.clave,
		Producto = p.Descripcion,
		UnidadId = u.DescripcionCorta,
		Cantidad  = SUM(ps.Cantidad)
	FROM doc_produccion_solicitud_requerido ps
	INNER JOIN doc_produccion_solicitud_detalle pd on pd.Id = ps.ProduccionSolicitudDetalleId
	INNER JOIN cat_productos p on p.ProductoId = ps.ProductoRequeridoId
	INNER JOIN cat_unidadesmed u on u.Clave = ps.UnidadRequeridaId
	WHERE pd.ProduccionSolicitudId = @pProduccionSolicitudId 
	GROUP BY ps.ProductoRequeridoId,p.clave,p.Descripcion,u.DescripcionCorta

	