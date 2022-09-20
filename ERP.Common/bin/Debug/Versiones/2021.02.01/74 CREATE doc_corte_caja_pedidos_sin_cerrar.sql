IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name ='doc_corte_caja_pedidos_sin_cerrar'
)
BEGIN

CREATE TABLE [dbo].[doc_corte_caja_pedidos_sin_cerrar](
	[CorteCajaId] [int] NOT NULL,
	[PedidoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_corte_caja_pedidos_sin_cerrar] PRIMARY KEY CLUSTERED 
(
	[CorteCajaId] ASC,
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_corte_caja_pedidos_sin_cerrar]  WITH CHECK ADD  CONSTRAINT [FK_doc_corte_caja_pedidos_sin_cerrar_doc_corte_caja] FOREIGN KEY([CorteCajaId])
REFERENCES [dbo].[doc_corte_caja] ([CorteCajaId])


ALTER TABLE [dbo].[doc_corte_caja_pedidos_sin_cerrar] CHECK CONSTRAINT [FK_doc_corte_caja_pedidos_sin_cerrar_doc_corte_caja]


ALTER TABLE [dbo].[doc_corte_caja_pedidos_sin_cerrar]  WITH CHECK ADD  CONSTRAINT [FK_doc_corte_caja_pedidos_sin_cerrar_doc_pedidos_orden] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_corte_caja_pedidos_sin_cerrar] CHECK CONSTRAINT [FK_doc_corte_caja_pedidos_sin_cerrar_doc_pedidos_orden]

END

