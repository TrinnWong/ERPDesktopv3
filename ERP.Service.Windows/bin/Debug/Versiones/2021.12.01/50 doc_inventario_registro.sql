IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_inventario_registro'
)
BEGIN

CREATE TABLE [dbo].[doc_inventario_registro](
	[RegistroInventarioId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CantidadReal] [decimal](14, 4) NOT NULL,
	[CantidadTeorica] [decimal](14, 4) NOT NULL,
	[Diferencia] [decimal](14, 4) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_inventario_registro] PRIMARY KEY CLUSTERED 
(
	[RegistroInventarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_inventario_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_inventario_registro_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_inventario_registro] CHECK CONSTRAINT [FK_doc_inventario_registro_cat_productos]


ALTER TABLE [dbo].[doc_inventario_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_inventario_registro_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_inventario_registro] CHECK CONSTRAINT [FK_doc_inventario_registro_cat_sucursales]


ALTER TABLE [dbo].[doc_inventario_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_inventario_registro_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_inventario_registro] CHECK CONSTRAINT [FK_doc_inventario_registro_cat_usuarios]


END
