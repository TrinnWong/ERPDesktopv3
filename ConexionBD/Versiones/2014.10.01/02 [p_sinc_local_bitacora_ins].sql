

-- [p_sinc_local_bitacora_ins] 'doc_ventas,doc_gastos'
CREATE PROC [dbo].[p_sinc_local_bitacora_ins]
@TableName VARCHAR(max),
@id INT=0,
@scope VARCHAR(500)
AS
begin

	
	CREATE TABLE #TMP_TABLES (
			TABLE_NAME NVARCHAR(500)
	);

	INSERT INTO #TMP_TABLES (TABLE_NAME)
	SELECT value
	FROM STRING_SPLIT(@TableName, ',');



	IF EXISTS (SELECT 1 FROM #TMP_TABLES WHERE TABLE_NAME = 'doc_gastos')
	BEGIN
		INSERT INTO [dbo].[sinc_local_bitacora](
		RecordSyncId,TableName,CreadoEl,Scope
		)
		select GastoId,'doc_gastos',GETDATE(),@scope
		from doc_gastos G
		WHERE NOT EXISTS (
			SELECT 1 FROM [sinc_local_bitacora] S1 WHERE S1.RecordSyncId = G.GastoId AND s1.TableName = 'doc_gastos'
		) AND @id IN (0,G.GastoId)

	END

	

end
GO


