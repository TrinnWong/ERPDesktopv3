if not exists (
	select 1
	from sysobjects
	where name = 'doc_cargos'
)
begin

CREATE TABLE [dbo].[doc_cargos](
	[CargoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Total] [money] NOT NULL,
	[CredoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_doc_cargos] PRIMARY KEY CLUSTERED 
(
	[CargoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cargos_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[doc_cargos] CHECK CONSTRAINT [FK_doc_cargos_cat_clientes]


ALTER TABLE [dbo].[doc_cargos]  WITH CHECK ADD  CONSTRAINT [FK_doc_cargos_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_cargos] CHECK CONSTRAINT [FK_doc_cargos_cat_productos]
end
GO

