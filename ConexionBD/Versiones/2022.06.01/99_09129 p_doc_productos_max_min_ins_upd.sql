IF EXISTS (
SELECT 1 FROM SYSOBJECTS WHERE NAME = 'p_doc_productos_max_min_ins_upd'
)
DROP PROC p_doc_productos_max_min_ins_upd
GO
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_doc_productos_max_min_grd 1,1
CREATE PROC p_doc_productos_max_min_ins_upd
@pSucursalId INT,
@pProductoId INT,
@pMaximo DECIMAL(14,2),
@pMinimo DECIMAL(14,2)
AS

	IF NOT EXISTS (
		SELECT 1
		FROM doc_productos_max_min 
		WHERE ProductoId = @pProductoId AND
		SucursalId = @pSucursalId
	)
	BEGIN

		INSERT INTO doc_productos_max_min(
			SucursalId,ProductoId,Maximo,Minimo,CreadoEl
		)
		VALUES(@pSucursalId,@pProductoId,@pMaximo,@pMinimo,GETDATE())
	END
	ELSE
	BEGIN

		UPDATE doc_productos_max_min
		SET Maximo = @pMaximo,
		Minimo = @pMinimo
		WHERE ProductoId = @pProductoId AND
		SucursalId = @pSucursalId
	END

