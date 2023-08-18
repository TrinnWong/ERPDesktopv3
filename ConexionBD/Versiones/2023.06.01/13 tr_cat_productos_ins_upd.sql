IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'tr_cat_productos_ins_upd'
)
DROP TRIGGER tr_cat_productos_ins_upd
GO

CREATE TRIGGER [dbo].[tr_cat_productos_ins_upd] ON cat_productos
AFTER INSERT,UPDATE
AS
BEGIN

	IF EXISTS(
		SELECT 1
		FROM inserted
		WHERE Empresa IS NULL OR Sucursal IS NULL
	)
	BEGIN

		update cat_productos
		SET Empresa = CASE WHEN P.Empresa IS NULL THEN 1 ELSE P.Empresa END,
			Sucursal = CASE WHEN P.Sucursal IS NULL THEN 1 ELSE P.Sucursal END
		FROM cat_productos P
		INNER JOIN inserted I ON I.ProductoId = p.ProductoId
	END
END


	



