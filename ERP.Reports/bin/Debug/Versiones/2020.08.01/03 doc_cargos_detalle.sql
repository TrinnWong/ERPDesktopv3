if not exists (
	select 1
	from sysobjects
	where name = 'doc_cargos_detalle'
)
BEGIN
CREATE TABLE [dbo].[doc_cargos_detalle](
	[CargoDetalleId] [int] NOT NULL,
	[CargoId] [int] NOT NULL,
	[FechaCargo] [datetime] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[Subtotal] [money] NOT NULL,
	[Impuestos] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_doc_cargos_detalle] PRIMARY KEY CLUSTERED 
(
	[CargoDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_cargos_detalle]  WITH CHECK ADD  CONSTRAINT [FK_doc_cargos_detalle_doc_cargos] FOREIGN KEY([CargoId])
REFERENCES [dbo].[doc_cargos] ([CargoId])


ALTER TABLE [dbo].[doc_cargos_detalle] CHECK CONSTRAINT [FK_doc_cargos_detalle_doc_cargos]
END


