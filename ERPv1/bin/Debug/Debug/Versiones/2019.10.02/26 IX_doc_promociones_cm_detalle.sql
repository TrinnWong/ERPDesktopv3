if not exists (
	SELECT * 
FROM sys.indexes 
WHERE name='IX_doc_promociones_cm_detalle' 
AND object_id = OBJECT_ID('doc_promociones_cm_detalle')
)
begin

/****** Object:  Index [IX_doc_promociones_cm_detalle]    Script Date: 11/26/2019 3:37:06 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_doc_promociones_cm_detalle] ON [dbo].[doc_promociones_cm_detalle]
(
	[ProductoId] ASC,
	[PromocionCMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

end
GO


