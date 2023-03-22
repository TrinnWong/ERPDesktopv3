if exists (
	select 1
	from sysobjects
	where name = 'fn_GetDateTimeServer'
)
drop function fn_GetDateTimeServer
go
CREATE FUNCTION fn_GetDateTimeServer()
RETURNS DateTime
AS
BEGIN
	
	return getdate()

END
GO

