if not exists (
	select 1
	from sysobjects
	where name ='doc_cargo_adicional_config'
)
begin



CREATE TABLE [dbo].[doc_cargo_adicional_config](
	[CargoAdicionalId] [smallint] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[PorcentajeVenta] [decimal](5, 2) NULL,
	[MontoFijo] [money] NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [nchar](10) NULL,
 CONSTRAINT [PK_doc_cargo_adicional_config] PRIMARY KEY CLUSTERED 
(
	[CargoAdicionalId] ASC,
	[SucursalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_cargo_adicional_config]  WITH CHECK ADD  CONSTRAINT [FK_doc_cargo_adicional_config_cat_cargos_adicionales] FOREIGN KEY([CargoAdicionalId])
REFERENCES [dbo].[cat_cargos_adicionales] ([CargoAdicionalId])


ALTER TABLE [dbo].[doc_cargo_adicional_config] CHECK CONSTRAINT [FK_doc_cargo_adicional_config_cat_cargos_adicionales]


ALTER TABLE [dbo].[doc_cargo_adicional_config]  WITH CHECK ADD  CONSTRAINT [FK_doc_cargo_adicional_config_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])

ALTER TABLE [dbo].[doc_cargo_adicional_config] CHECK CONSTRAINT [FK_doc_cargo_adicional_config_cat_sucursales]






end
GO


