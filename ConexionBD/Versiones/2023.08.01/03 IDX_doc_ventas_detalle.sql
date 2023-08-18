IF NOT EXISTS (

SELECT 1
FROM sys.indexes 
WHERE name='IDX_doc_ventas_detalle' AND object_id = OBJECT_ID('doc_ventas_detalle')

)
BEGIN

	/****** Object:  Index [IDX_doc_ventas_detalle]    Script Date: 17/08/2023 12:01:39 p. m. ******/
	CREATE NONCLUSTERED INDEX [IDX_doc_ventas_detalle] ON [dbo].[doc_ventas_detalle]
	(
		[VentaId] ASC,
		[ProductoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

END
GO


