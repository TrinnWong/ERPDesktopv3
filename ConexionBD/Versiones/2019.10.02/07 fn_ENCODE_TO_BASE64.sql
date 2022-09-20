if exists (

	select 1
	from sysobjects
	where name = 'fn_ENCODE_TO_BASE64'
)
drop function fn_ENCODE_TO_BASE64
go

CREATE FUNCTION [dbo].[fn_ENCODE_TO_BASE64]
(
    @STRING VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
    RETURN (
        SELECT
            CAST(N'' AS XML).value(
                  'xs:base64Binary(xs:hexBinary(sql:column("bin")))'
                , 'VARCHAR(MAX)'
            )   Base64Encoding
        FROM (
            SELECT CAST(@STRING AS VARBINARY(MAX)) AS bin
        ) AS bin_sql_server_temp
    )
END
GO