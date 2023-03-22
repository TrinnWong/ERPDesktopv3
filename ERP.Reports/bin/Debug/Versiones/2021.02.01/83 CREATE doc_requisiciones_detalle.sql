IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_requisiciones_detalle'
)
BEGIN

CREATE TABLE [dbo].[doc_requisiciones_detalle](
	[RequisicionDetalleId] [int] NOT NULL,
	[RequisicionId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](18, 4) NOT NULL,
	[Precio] [decimal](14, 2) NOT NULL,
	[Total] [decimal](14, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_requisiciones_detalle] PRIMARY KEY CLUSTERED 
(
	[RequisicionDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_requisiciones_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_requisiciones_detalle] CHECK CONSTRAINT [FK_doc_requisiciones_detalle_cat_productos]


ALTER TABLE [dbo].[doc_requisiciones_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_detalle_doc_requisiciones] FOREIGN KEY([RequisicionId])
REFERENCES [dbo].[doc_requisiciones] ([RequisicionId])


ALTER TABLE [dbo].[doc_requisiciones_detalle] CHECK CONSTRAINT [FK_doc_requisiciones_detalle_doc_requisiciones]


END


