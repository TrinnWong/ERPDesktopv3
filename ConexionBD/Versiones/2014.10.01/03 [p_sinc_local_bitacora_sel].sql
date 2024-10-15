
CREATE PROC [dbo].[p_sinc_local_bitacora_sel]
@TableName VARCHAR(max)
as

	CREATE TABLE #TMP_TABLES (
			TABLE_NAME NVARCHAR(500)
	);

	INSERT INTO #TMP_TABLES (TABLE_NAME)
	SELECT value
	FROM STRING_SPLIT(@TableName, ',');

	SELECT Id,RecordSyncId,TableName,CreadoEl
	FROM [sinc_local_bitacora] B
	INNER JOIN #TMP_TABLES  TMP  ON TMP.TABLE_NAME = B.TableName
GO


