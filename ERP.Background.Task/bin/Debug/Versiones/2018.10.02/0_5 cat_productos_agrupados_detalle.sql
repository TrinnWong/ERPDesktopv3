
if not exists(
	select 1
	from sysobjects
	where name = 'cat_productos_agrupados_detalle'
)
begin
CREATE TABLE [dbo].[cat_productos_agrupados_detalle](
	[ProductoAgrupadoId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_productos_agrupados_detalle] PRIMARY KEY CLUSTERED 
(
	[ProductoAgrupadoId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[cat_productos_agrupados_detalle]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_agrupados_detalle_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_agrupados_detalle] CHECK CONSTRAINT [FK_cat_productos_agrupados_detalle_cat_productos]


ALTER TABLE [dbo].[cat_productos_agrupados_detalle]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_agrupados_detalle_cat_productos_agrupados] FOREIGN KEY([ProductoAgrupadoId])
REFERENCES [dbo].[cat_productos_agrupados] ([ProductoAgrupadoId])



ALTER TABLE [dbo].[cat_productos_agrupados_detalle] CHECK CONSTRAINT [FK_cat_productos_agrupados_detalle_cat_productos_agrupados]
END
GO


