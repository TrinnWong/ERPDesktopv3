IF NOT EXISTS (

SELECT 1
FROM sys.indexes 
WHERE name='IDX_doc_movimiento' AND object_id = OBJECT_ID('doc_inv_movimiento')

)
BEGIN

/****** Object:  Index [IDX_doc_movimiento]    Script Date: 08/05/2023 09:33:37 p. m. ******/
CREATE NONCLUSTERED INDEX [IDX_doc_movimiento] ON [dbo].[doc_inv_movimiento]
(
	[MovimientoId] ASC,
	[Autorizado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

END


