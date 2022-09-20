IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'doc_productos_importacion_bitacora'
)
BEGIN
CREATE TABLE [dbo].[doc_productos_importacion_bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UUID] [uniqueidentifier] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[TipoMovimientoInventarioId] [int] NOT NULL,
	[Cantidad] [decimal](14, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_productos_importacion_bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[doc_productos_importacion_bitacora]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_importacion_bitacora_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_importacion_bitacora] CHECK CONSTRAINT [FK_doc_productos_importacion_bitacora_cat_productos]


ALTER TABLE [dbo].[doc_productos_importacion_bitacora]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_importacion_bitacora_cat_tipos_movimiento_inventario] FOREIGN KEY([TipoMovimientoInventarioId])
REFERENCES [dbo].[cat_tipos_movimiento_inventario] ([TipoMovimientoInventarioId])


ALTER TABLE [dbo].[doc_productos_importacion_bitacora] CHECK CONSTRAINT [FK_doc_productos_importacion_bitacora_cat_tipos_movimiento_inventario]


ALTER TABLE [dbo].[doc_productos_importacion_bitacora]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_importacion_bitacora_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_productos_importacion_bitacora] CHECK CONSTRAINT [FK_doc_productos_importacion_bitacora_cat_usuarios]

END


