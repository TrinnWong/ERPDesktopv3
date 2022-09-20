IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'doc_requisiciones'
)
BEGIN

CREATE TABLE [dbo].[doc_requisiciones](
	[RequisicionId] [int] NOT NULL,
	[Folio] [varchar](50) NOT NULL,
	[Version] [smallint] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaRequerida] [datetime] NOT NULL,
	[RequisicionPadreId] [int] NOT NULL,
	[TipoRequisicionId] [smallint] NOT NULL,
	[EstatusId] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_requisiciones] PRIMARY KEY CLUSTERED 
(
	[RequisicionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_requisiciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_cat_estatus] FOREIGN KEY([EstatusId])
REFERENCES [dbo].[cat_estatus] ([EstatusId])


ALTER TABLE [dbo].[doc_requisiciones] CHECK CONSTRAINT [FK_doc_requisiciones_cat_estatus]


ALTER TABLE [dbo].[doc_requisiciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_cat_proveedores] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[cat_proveedores] ([ProveedorId])


ALTER TABLE [dbo].[doc_requisiciones] CHECK CONSTRAINT [FK_doc_requisiciones_cat_proveedores]


ALTER TABLE [dbo].[doc_requisiciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_cat_tipos_requisiciones] FOREIGN KEY([TipoRequisicionId])
REFERENCES [dbo].[cat_tipos_requisiciones] ([TipoRequisicionId])


ALTER TABLE [dbo].[doc_requisiciones] CHECK CONSTRAINT [FK_doc_requisiciones_cat_tipos_requisiciones]


ALTER TABLE [dbo].[doc_requisiciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_requisiciones] CHECK CONSTRAINT [FK_doc_requisiciones_cat_usuarios]


ALTER TABLE [dbo].[doc_requisiciones]  WITH CHECK ADD  CONSTRAINT [FK_doc_requisiciones_doc_requisiciones] FOREIGN KEY([RequisicionPadreId])
REFERENCES [dbo].[doc_requisiciones] ([RequisicionId])


ALTER TABLE [dbo].[doc_requisiciones] CHECK CONSTRAINT [FK_doc_requisiciones_doc_requisiciones]


END
