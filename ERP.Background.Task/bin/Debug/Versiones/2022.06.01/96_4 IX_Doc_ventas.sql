IF NOT EXISTS (
	SELECT * 
	FROM sys.indexes 
	WHERE name='IX_Doc_ventas'
)
BEGIN

	/****** Object:  Index [IX_doc_ventas]    Script Date: 11/29/2022 5:14:02 PM ******/
	CREATE NONCLUSTERED INDEX [IX_doc_ventas] ON [dbo].[doc_ventas]
	(
		[VentaId] ASC,
		[Activo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

END
GO


