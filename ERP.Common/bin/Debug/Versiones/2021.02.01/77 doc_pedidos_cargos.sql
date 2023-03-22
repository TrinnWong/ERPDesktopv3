IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_pedidos_cargos'
)
BEGIN

CREATE TABLE [dbo].[doc_pedidos_cargos](
	[PedidoCargoId] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[CargoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NULL,
 CONSTRAINT [PK_doc_pedidos_cargos] PRIMARY KEY CLUSTERED 
(
	[PedidoCargoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cargos_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_pedidos_cargos] CHECK CONSTRAINT [FK_doc_pedidos_cargos_cat_usuarios]

ALTER TABLE [dbo].[doc_pedidos_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cargos_doc_cargos] FOREIGN KEY([CargoId])
REFERENCES [dbo].[doc_cargos] ([CargoId])


ALTER TABLE [dbo].[doc_pedidos_cargos] CHECK CONSTRAINT [FK_doc_pedidos_cargos_doc_cargos]


ALTER TABLE [dbo].[doc_pedidos_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_cargos_doc_pedidos_orden] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[doc_pedidos_orden] ([PedidoId])


ALTER TABLE [dbo].[doc_pedidos_cargos] CHECK CONSTRAINT [FK_doc_pedidos_cargos_doc_pedidos_orden]

END

