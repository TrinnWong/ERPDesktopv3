IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS 
	WHERE NAME = 'doc_productos_sobrantes_registro'
)
BEGIN


CREATE TABLE [dbo].[doc_productos_sobrantes_registro](
	[Id] [int] NOT NULL,
	[SucursalId] [int] NULL,
	[ProductoId] [int] NULL,
	[CantidadSobrante] [float] NULL,
	[CreadoEl] [datetime] NULL,
	[CreadoPor] [int] NULL,
 CONSTRAINT [PK_doc_productos_sobrantes_registro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_productos_sobrantes_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_registro_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_productos_sobrantes_registro] CHECK CONSTRAINT [FK_doc_productos_sobrantes_registro_cat_productos]


ALTER TABLE [dbo].[doc_productos_sobrantes_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_registro_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_productos_sobrantes_registro] CHECK CONSTRAINT [FK_doc_productos_sobrantes_registro_cat_sucursales]


ALTER TABLE [dbo].[doc_productos_sobrantes_registro]  WITH CHECK ADD  CONSTRAINT [FK_doc_productos_sobrantes_registro_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_productos_sobrantes_registro] CHECK CONSTRAINT [FK_doc_productos_sobrantes_registro_cat_usuarios]


END


