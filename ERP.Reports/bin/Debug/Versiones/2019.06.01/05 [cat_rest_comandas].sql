if not exists (
	select 1
	from sysobjects
	where name = 'cat_rest_comandas'
)
begin
CREATE TABLE [dbo].[cat_rest_comandas](
	[ComandaId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[Folio] [int] NOT NULL,
	[Disponible] [bit] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_rest_comandas] PRIMARY KEY CLUSTERED 
(
	[ComandaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_rest_comandas]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_comandas_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_rest_comandas] CHECK CONSTRAINT [FK_cat_rest_comandas_cat_sucursales]


ALTER TABLE [dbo].[cat_rest_comandas]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_comandas_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_rest_comandas] CHECK CONSTRAINT [FK_cat_rest_comandas_cat_usuarios]
END
GO


