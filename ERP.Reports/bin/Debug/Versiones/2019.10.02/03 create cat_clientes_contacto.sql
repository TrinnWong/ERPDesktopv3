if not exists(
	select 1
	from sysobjects
	where name = 'cat_clientes_contacto'
)
begin

CREATE TABLE [dbo].[cat_clientes_contacto](
	[ClienteId] [int] NOT NULL,
	[Email] [varchar](100) NULL,
	[Email2] [varchar](100) NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_clientes_contacto] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_clientes_contacto]  WITH CHECK ADD  CONSTRAINT [FK_cat_clientes_contacto_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[cat_clientes_contacto] CHECK CONSTRAINT [FK_cat_clientes_contacto_cat_clientes]
END
GO


