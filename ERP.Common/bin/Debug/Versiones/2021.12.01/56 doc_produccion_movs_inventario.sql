IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_produccion_movs_inventario'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion_movs_inventario](
	[ProduccionId] [int] NOT NULL,
	[MovimientoInventarioId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_produccion_movs_inventario] PRIMARY KEY CLUSTERED 
(
	[ProduccionId] ASC,
	[MovimientoInventarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_movs_inventario]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_movs_inventario_doc_inv_movimiento] FOREIGN KEY([MovimientoInventarioId])
REFERENCES [dbo].[doc_inv_movimiento] ([MovimientoId])


ALTER TABLE [dbo].[doc_produccion_movs_inventario] CHECK CONSTRAINT [FK_doc_produccion_movs_inventario_doc_inv_movimiento]


ALTER TABLE [dbo].[doc_produccion_movs_inventario]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_movs_inventario_doc_produccion] FOREIGN KEY([ProduccionId])
REFERENCES [dbo].[doc_produccion] ([ProduccionId])


ALTER TABLE [dbo].[doc_produccion_movs_inventario] CHECK CONSTRAINT [FK_doc_produccion_movs_inventario_doc_produccion]


END
