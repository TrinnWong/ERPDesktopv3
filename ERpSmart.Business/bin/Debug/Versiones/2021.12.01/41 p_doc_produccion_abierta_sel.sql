IF EXISTS (
	SELECT 1
	FROM sysobjects
	WHERE name = 'p_doc_produccion_abierta_sel'
)
DROP PROC p_doc_produccion_abierta_sel
go

CREATE PROC p_doc_produccion_abierta_sel
@pSucursalId int,
@pProductoId int,
@pFecha	int
as

	SELECT * 
	FROM doc_produccion p
	WHERE p.SucursalId = @pSucursalId AND
	p.ProductoId = @pProductoId AND
	p.Activo = 1 AND
	p.FechaHoraFin IS NULL AND
	ISNULL(p.Completado,0) = 0
