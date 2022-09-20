IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_cocimiento_habilitar'
)
DROP PROC p_doc_cocimiento_habilitar
GO
CREATE PROC p_doc_cocimiento_habilitar
@pSucursalId INT
AS

	DECLARE @cocimientoGrupoId INT


	SELECT C.*
	into #tmpCocimientos
	FROM doc_cocimientos C
	INNER JOIN doc_produccion P ON P.ProduccionId = C.ProduccionId AND
							P.SucursalId = @pSucursalId 
	WHERE NOT EXISTS (
		SELECT 1
		FROM doc_cocimientos_grupos_detalle st1
		WHERE st1.CocimientoId = C.CocimientoId
	)

	IF EXISTS (
		SELECT 1
		FROM #tmpCocimientos)
	BEGIN

		INSERT INTO doc_cocimientos_grupos(SucursalId,CreadoEl,CreadoPor)
		VALUES(@pSucursalId,GETDATE(),1)

		SET @cocimientoGrupoId = SCOPE_IDENTITY()

		UPDATE doc_cocimientos
		SET FechaHabilitado = GETDATE()
		FROM doc_cocimientos C
		INNER JOIN #tmpCocimientos TMP ON TMP.CocimientoId = C.CocimientoId
	

		INSERT INTO doc_cocimientos_grupos_detalle(CocimientoGrupoId,CocimientoId,CreadoEl)
		SELECT @cocimientoGrupoId,CocimientoId,GETDATE()	
		FROM #tmpCocimientos
		
		SELECT CG.*,MovimientoInventarioId = M.MovimientoId
		INTO #tmpCocimientosSobrante
		FROM doc_cocimientos_grupos CG
		INNER JOIN doc_cocimientos_grupos_movs_inventario I ON I.CocimientoGrupoId = CG.Id
		INNER JOIN doc_inv_movimiento M ON M.MovimientoId = I.MovimientoInventarioId
		INNER JOIN doc_inv_movimiento_detalle ID ON ID.MovimientoId = M.MovimientoId 
		INNER JOIN cat_productos P ON P.ProductoId = ID.ProductoId AND
									P.Descripcion LIKE '%NIXTRAMAL%SOBRANTE%'
		WHERE CG.SucursalId = @pSucursalId AND
		CONVERT(VARCHAR,CG.CreadoEl,112) < CONVERT(VARCHAR,GETDATE(),112)

		INSERT INTO doc_cocimientos_grupos_movs_inventario(
		CocimientoGrupoId,MovimientoInventarioId,CreadoEl
		)
		SELECT DISTINCT @cocimientoGrupoId,TMP.MovimientoInventarioId,GETDATE()
		FROM #tmpCocimientosSobrante TMP





	END