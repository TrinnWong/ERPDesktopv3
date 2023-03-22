IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_produccion_solicitud_requerido'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion_solicitud_requerido](
	[Id] [int] IDENTITY (1,1) NOT NULL,
	[ProduccionSolicitudDetalleId] [int] NOT NULL,
	[ProductoRequeridoId] [int] NOT NULL,
	[UnidadRequeridaId] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_produccion_solicitud_requerido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_requerido_cat_productos] FOREIGN KEY([ProductoRequeridoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido] CHECK CONSTRAINT [FK_doc_produccion_solicitud_requerido_cat_productos]


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_requerido_cat_unidadesmed] FOREIGN KEY([UnidadRequeridaId])
REFERENCES [dbo].[cat_unidadesmed] ([Clave])


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido] CHECK CONSTRAINT [FK_doc_produccion_solicitud_requerido_cat_unidadesmed]


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_requerido_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido] CHECK CONSTRAINT [FK_doc_produccion_solicitud_requerido_cat_usuarios]


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_requerido_doc_produccion_solicitud_detalle] FOREIGN KEY([ProduccionSolicitudDetalleId])
REFERENCES [dbo].[doc_produccion_solicitud_detalle] ([Id])


ALTER TABLE [dbo].[doc_produccion_solicitud_requerido] CHECK CONSTRAINT [FK_doc_produccion_solicitud_requerido_doc_produccion_solicitud_detalle]




END

