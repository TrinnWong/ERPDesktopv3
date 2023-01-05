IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_productos_existencias_diario_upd'
)

DROP PROC p_doc_productos_existencias_diario_upd
GO


-- p_doc_productos_existencias_diario_upd 3,1,''
CREATE PROC p_doc_productos_existencias_diario_upd
@pSucursalId INT,
@pCreadoPor INT,
@pError VARCHAR(250) OUT
as


	SET @pError = ''

	BEGIN TRAN

	BEGIN TRY


		DECLARE @FechaExistenciaMov DATETIME


		--MARCAR MOVIMIENTOS DE INVENTARIO PARA YA NO TOMARSE EN CUENTA
		update doc_inv_movimiento
		set FechaCorteExistencia = [dbo].[fn_GetDateTimeServer]()
		where SucursalId = @pSucursalId AND
		FechaCorteExistencia IS NULL

		SELECT *
		INTO #TMP_EXISTENCIAS_SUCURSAL
		FROM cat_productos_existencias PE
		WHERE PE.SucursalId = @pSucursalId

		SET @FechaExistenciaMov = [dbo].[fn_GetDateTimeServer]()

		
		--ACTUALIZAR EXISTENCIAS QUE YA TENGAN REGISTRO DEL DÍA

		UPDATE doc_productos_existencias_diario
		SET [Existencia] = TMP.ExistenciaTeorica,
			FechaCorteExistencia = @FechaExistenciaMov
		FROM doc_productos_existencias_diario PE
		INNER JOIN #TMP_EXISTENCIAS_SUCURSAL TMP ON TMP.ProductoId = PE.ProductoId AND
												TMP.SucursalId = PE.SucursalId AND
												CONVERT(VARCHAR,PE.FechaCorteExistencia,112) = CONVERT(VARCHAR,@FechaExistenciaMov,112)


		INSERT INTO doc_productos_existencias_diario(SucursalId,ProductoId,FechaCorteExistencia,Existencia,CreadoEl,CreadoPor)
		SELECT TMP.SucursalId,TMP.ProductoId,@FechaExistenciaMov,TMP.ExistenciaTeorica,GETDATE(),@pCreadoPor
		FROM #TMP_EXISTENCIAS_SUCURSAL TMP 
		WHERE NOT EXISTS (
			SELECT 1
			FROM doc_productos_existencias_diario S1
			WHERE S1.SucursalId = TMP.SucursalId AND
			S1.ProductoId = TMP.ProductoId AND
			CONVERT(VARCHAR,S1.FechaCorteExistencia,112) = CONVERT(VARCHAR,@FechaExistenciaMov,112)
		)

		COMMIT TRAN

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SET @pError = ERROR_MESSAGE()
	END CATCH
