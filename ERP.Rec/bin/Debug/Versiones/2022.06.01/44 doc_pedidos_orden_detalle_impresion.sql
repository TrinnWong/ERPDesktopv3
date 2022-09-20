IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_pedidos_orden_detalle_impresion'
)
BEGIN

CREATE TABLE [dbo].[doc_pedidos_orden_detalle_impresion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PedidoDetalleId] [int] NOT NULL,
	[Impreso] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_pedidos_orden_detalle_impresion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_pedidos_orden_detalle_impresion]  WITH CHECK ADD  CONSTRAINT [FK_doc_pedidos_orden_detalle_impresion_doc_pedidos_orden_detalle] FOREIGN KEY([PedidoDetalleId])
REFERENCES [dbo].[doc_pedidos_orden_detalle] ([PedidoDetalleId])


ALTER TABLE [dbo].[doc_pedidos_orden_detalle_impresion] CHECK CONSTRAINT [FK_doc_pedidos_orden_detalle_impresion_doc_pedidos_orden_detalle]

END
GO


