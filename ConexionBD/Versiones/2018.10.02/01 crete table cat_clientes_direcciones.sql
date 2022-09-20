if not exists (
	select 1
	from sysobjects
	where name = 'cat_clientes_direcciones'
)
begin
CREATE TABLE [dbo].[cat_clientes_direcciones](
	[ClienteDireccionId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[TipoDireccionId] [tinyint] NOT NULL,
	[Calle] [varchar](50) NULL,
	[NumeroInterior] [varchar](10) NULL,
	[NumeroExterior] [varchar](10) NULL,
	[Colonia] [varchar](50) NULL,
	[Ciudad] [varchar](100) NULL,
	[EstadoId] [int] NULL,
	[PaisId] [int] NULL,
	[CodigoPostal] [varchar](5) NULL,
	[CreadoEl] [datetime] NULL,
 CONSTRAINT [PK_cat_clientes_direcciones] PRIMARY KEY CLUSTERED 
(
	[ClienteDireccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[cat_clientes_direcciones]  WITH CHECK ADD  CONSTRAINT [FK_cat_clientes_direcciones_cat_clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[cat_clientes] ([ClienteId])


ALTER TABLE [dbo].[cat_clientes_direcciones] CHECK CONSTRAINT [FK_cat_clientes_direcciones_cat_clientes]


ALTER TABLE [dbo].[cat_clientes_direcciones]  WITH CHECK ADD  CONSTRAINT [FK_cat_clientes_direcciones_cat_tipos_direcciones] FOREIGN KEY([TipoDireccionId])
REFERENCES [dbo].[cat_tipos_direcciones] ([TipoDireccionId])


ALTER TABLE [dbo].[cat_clientes_direcciones] CHECK CONSTRAINT [FK_cat_clientes_direcciones_cat_tipos_direcciones]
END
GO


