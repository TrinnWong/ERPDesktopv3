IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS 
	WHERE name = 'doc_produccion_solicitud'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion_solicitud](
	[ProduccionSolicitudId] [int] IDENTITY(1,1) NOT NULL,
	[DeSucursalId] [int] NOT NULL,
	[ParaSucursalId] [int] NOT NULL,
	[Completada] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_doc_produccion_solicitud] PRIMARY KEY CLUSTERED 
(
	[ProduccionSolicitudId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_solicitud]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_cat_sucursales] FOREIGN KEY([DeSucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_produccion_solicitud] CHECK CONSTRAINT [FK_doc_produccion_solicitud_cat_sucursales]


ALTER TABLE [dbo].[doc_produccion_solicitud]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_cat_sucursales1] FOREIGN KEY([ParaSucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_produccion_solicitud] CHECK CONSTRAINT [FK_doc_produccion_solicitud_cat_sucursales1]


ALTER TABLE [dbo].[doc_produccion_solicitud]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_produccion_solicitud] CHECK CONSTRAINT [FK_doc_produccion_solicitud_cat_usuarios]


END


