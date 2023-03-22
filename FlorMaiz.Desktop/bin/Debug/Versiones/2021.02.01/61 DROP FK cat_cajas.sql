if exists (
	select 1
	from sysobjects
	where name = 'FK__cat_cajas__Sucur__17036CC0'
)
BEGIN

ALTER TABLE dbo.cat_cajas   
DROP CONSTRAINT FK__cat_cajas__Sucur__17036CC0;   

END
GO  