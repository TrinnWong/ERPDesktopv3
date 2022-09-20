IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_produccion_solicitud_ajuste_unidad'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProduccionSolicitudDetalleId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[UnidadId] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_produccion_solicitud_ajuste_unidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad] CHECK CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_cat_productos]


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_cat_unidadesmed] FOREIGN KEY([UnidadId])
REFERENCES [dbo].[cat_unidadesmed] ([Clave])


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad] CHECK CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_cat_unidadesmed]


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad] CHECK CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_cat_usuarios]


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_doc_produccion_solicitud_detalle] FOREIGN KEY([ProduccionSolicitudDetalleId])
REFERENCES [dbo].[doc_produccion_solicitud_detalle] ([Id])


ALTER TABLE [dbo].[doc_produccion_solicitud_ajuste_unidad] CHECK CONSTRAINT [FK_doc_produccion_solicitud_ajuste_unidad_doc_produccion_solicitud_detalle]


END
