if not exists (
	select 1
	from sysobjects
	where name = 'doc_web_carrito_detalle'
)
begin


CREATE TABLE [dbo].[doc_web_carrito_detalle](
	[IdDetalle] [int] NOT NULL,
	[uUID] [varchar](50) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](10, 2) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[PrecioUnitario] [money] NOT NULL,
	[Importe] [money] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_web_carrito_detalle] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[doc_web_carrito_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_web_carrito_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_web_carrito_detalle] CHECK CONSTRAINT [FK_doc_web_carrito_detalle_cat_productos]


ALTER TABLE [dbo].[doc_web_carrito_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_web_carrito_detalle_doc_web_carrito] FOREIGN KEY([uUID])
REFERENCES [dbo].[doc_web_carrito] ([uUID])



ALTER TABLE [dbo].[doc_web_carrito_detalle] CHECK CONSTRAINT [FK_doc_web_carrito_detalle_doc_web_carrito]

END


