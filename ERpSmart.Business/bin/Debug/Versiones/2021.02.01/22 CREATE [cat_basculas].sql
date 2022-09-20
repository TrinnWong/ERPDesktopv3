if not exists (
	select 1
	from sysobjects
	where name = 'cat_basculas'
)
BEGIN

CREATE TABLE [dbo].[cat_basculas](
	[BasculaId] [int] NOT NULL,
	[EmpresaId] [int] NOT NULL,
	[Alias] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Serie] [varchar](50) NOT NULL,
	[SucursalAsignadaId] [int] NULL,
	[Activo] Bit NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
	[ModificadoPor] [int] NULL,
 CONSTRAINT [PK_cat_basculas] PRIMARY KEY CLUSTERED 
(
	[BasculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_basculas]  WITH CHECK ADD  CONSTRAINT [FK_cat_basculas_cat_empresas] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[cat_empresas] ([Clave])


ALTER TABLE [dbo].[cat_basculas] CHECK CONSTRAINT [FK_cat_basculas_cat_empresas]


ALTER TABLE [dbo].[cat_basculas]  WITH CHECK ADD  CONSTRAINT [FK_cat_basculas_cat_sucursales] FOREIGN KEY([SucursalAsignadaId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_basculas] CHECK CONSTRAINT [FK_cat_basculas_cat_sucursales]


ALTER TABLE [dbo].[cat_basculas]  WITH CHECK ADD  CONSTRAINT [FK_cat_basculas_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_basculas] CHECK CONSTRAINT [FK_cat_basculas_cat_usuarios]


ALTER TABLE [dbo].[cat_basculas]  WITH CHECK ADD  CONSTRAINT [FK_cat_basculas_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_basculas] CHECK CONSTRAINT [FK_cat_basculas_cat_usuarios1]


END


