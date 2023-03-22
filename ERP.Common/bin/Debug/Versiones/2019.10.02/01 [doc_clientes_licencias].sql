if not exists (

	select 1
	from sysobjects
	where name = 'doc_clientes_licencias'
)
begin


CREATE TABLE [dbo].[doc_clientes_licencias](
	[ClienteLicenciaId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[FechaVigencia] DateTime NOT NULL,
	[Vigente] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[ModificadoEl] [datetime] NULL,
 CONSTRAINT [PK_doc_clientes_licencias] PRIMARY KEY CLUSTERED 
(
	[ClienteLicenciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_clientes_licencias]  WITH CHECK ADD  CONSTRAINT [FK_doc_clientes_licencias_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[doc_clientes_licencias] CHECK CONSTRAINT [FK_doc_clientes_licencias_cat_clientes]


ALTER TABLE [dbo].[doc_clientes_licencias]  WITH CHECK ADD  CONSTRAINT [FK_doc_clientes_licencias_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[doc_clientes_licencias] CHECK CONSTRAINT [FK_doc_clientes_licencias_cat_productos]
END
GO


