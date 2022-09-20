
if not exists(
	select 1
	from sysobjects
	where name = 'cat_empresas_config_inventario'
)
BEGIN
CREATE TABLE [dbo].[cat_empresas_config_inventario](
	[EmpresaId] [int] NOT NULL,
	[EnableTraspasoAutomatico] [bit] NOT NULL,
 CONSTRAINT [PK_cat_empresa_config_inventario] PRIMARY KEY CLUSTERED 
(
	[EmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_empresas_config_inventario]  WITH CHECK ADD  CONSTRAINT [FK_cat_empresas_config_inventario_cat_empresas] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[cat_empresas] ([Clave])


ALTER TABLE [dbo].[cat_empresas_config_inventario] CHECK CONSTRAINT [FK_cat_empresas_config_inventario_cat_empresas]


ALTER TABLE [dbo].[cat_empresas_config_inventario]  WITH CHECK ADD  CONSTRAINT [FK_cat_empresas_config_inventario_cat_empresas_config_inventario] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[cat_empresas_config_inventario] ([EmpresaId])


ALTER TABLE [dbo].[cat_empresas_config_inventario] CHECK CONSTRAINT [FK_cat_empresas_config_inventario_cat_empresas_config_inventario]


END
GO


