
if not exists (
	SELECT * 
FROM sys.indexes 
WHERE name='IX_cat_productos_base' AND object_id = OBJECT_ID('cat_productos_base')
)
begin
/****** Object:  Index [IX_cat_productos_base]    Script Date: 30/04/2019 04:52:37 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_cat_productos_base] ON [dbo].[cat_productos_base]
(
	[ProductoId] ASC,
	[ProductoBaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO




