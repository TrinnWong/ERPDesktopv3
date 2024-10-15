

CREATE PROC [dbo].[p_sinc_local_bitacora_del]
@TableName VARCHAR(max),
@scope VARCHAR(500)
AS
begin

	
	DELETE [sinc_local_bitacora]
	WHERE TableName = @TableName AND
	Scope = @scope

	

end
GO


