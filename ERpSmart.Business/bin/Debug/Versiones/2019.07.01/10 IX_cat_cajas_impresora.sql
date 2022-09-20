if not exists (
sELECT * 
FROM sys.indexes 
WHERE name='IX_cat_cajas_impresora' 
)
begin


/****** Object:  Index [IX_cat_cajas_impresora]    Script Date: 7/26/2019 12:38:43 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_cat_cajas_impresora] ON [dbo].[cat_cajas_impresora]
(
	[CajaId] ASC,
	[ImpresoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
end


