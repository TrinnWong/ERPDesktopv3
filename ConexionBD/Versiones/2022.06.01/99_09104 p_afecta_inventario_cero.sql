IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_afecta_inventario_cero'
)
DROP PROC p_afecta_inventario_cero
GO
-- p_afecta_inventario_cero 9,1
create proc p_afecta_inventario_cero
@pSucursalId INT,
@pUsuarioId INT
AS


	DECLARE @Id INT

	SELECT @Id = MAX(Id)
	FROM doc_inventario_captura

	INSERT INTO doc_inventario_captura(Id,SucursalId,ProductoId,Cantidad,CreadoPor,CreadoEl,Cerrado)
	SELECT @Id+ ROW_NUMBER() OVER(ORDER BY PE.ProductoId ASC) ,PE.SucursalId,PE.ProductoId,0,@pUsuarioId,GETDATE(),0
	FROM cat_productos_existencias PE
	WHERE PE.SucursalId = @pSucursalId


	EXEC [dbo].[p_inventario_cierre] @pSucursalId,@pUsuarioId