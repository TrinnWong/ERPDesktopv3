
IF NOT EXISTS (
	select 1
	from sysobjects
	where name = 'doc_produccion'
)
BEGIN

CREATE TABLE [dbo].[doc_produccion](
	[ProduccionId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[FechaHoraInicio] [datetime] NOT NULL,
	[FechaHoraFin] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[Completado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_doc_produccion] PRIMARY KEY CLUSTERED 
(
	[ProduccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_produccion]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_produccion] CHECK CONSTRAINT [FK_doc_produccion_cat_sucursales]


ALTER TABLE [dbo].[doc_produccion]  WITH CHECK ADD  CONSTRAINT [FK_doc_produccion_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_produccion] CHECK CONSTRAINT [FK_doc_produccion_cat_usuarios]

END


