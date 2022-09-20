if not exists (
	select 1
	from sysobjects
	where name = 'doc_promociones_cm_detalle'
)
begin

CREATE TABLE [dbo].[doc_promociones_cm_detalle](
	[PromocionCMDetId] [int] NOT NULL,
	[PromocionCMId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CantidadCompraMinima] [decimal](10, 2) NOT NULL,
	[CantidadCobro] [decimal](10, 2) NOT NULL,
	[CreadoEL] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_promociones_cm_detalle] PRIMARY KEY CLUSTERED 
(
	[PromocionCMDetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_promociones_cm_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_promociones_cm_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_promociones_cm_detalle] CHECK CONSTRAINT [FK_doc_promociones_cm_detalle_cat_productos]


ALTER TABLE [dbo].[doc_promociones_cm_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_promociones_cm_detalle_doc_promociones_cm] FOREIGN KEY([PromocionCMId])
REFERENCES [dbo].[doc_promociones_cm] ([PromocionCMId])


ALTER TABLE [dbo].[doc_promociones_cm_detalle] CHECK CONSTRAINT [FK_doc_promociones_cm_detalle_doc_promociones_cm]

end
GO


