if exists (

	select 1
	from sysobjects
	where name = 'fn_DECODE_FROM_BASE64'
)
drop function fn_DECODE_FROM_BASE64
go

-- select dbo.fn_str_FROM_BASE64('MTAw')
CREATE FUNCTION [dbo].[fn_DECODE_FROM_BASE64]
(
    @BASE64_STRING VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
    RETURN (
        SELECT 
            CAST(
                CAST(N'' AS XML).value('xs:base64Binary(sql:variable("@BASE64_STRING"))', 'VARBINARY(MAX)') 
            AS VARCHAR(MAX)
            )   UTF8Encoding
    )
END