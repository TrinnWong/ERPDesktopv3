
if EXISTS (
	select 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_gastos_del'
)
DROP PROC p_doc_gastos_del
go

CREATE PROCEDURE [dbo].[p_doc_gastos_del]
    @GastoId INT
AS
BEGIN
    DELETE FROM [dbo].[doc_gastos]
    WHERE [GastoId] = @GastoId
END
