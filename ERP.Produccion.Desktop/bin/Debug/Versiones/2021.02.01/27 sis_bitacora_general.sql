if not exists (
	select 1
	from sysobjects
	where name = 'sis_bitacora_general'
)
BEGIN

CREATE TABLE [dbo].[sis_bitacora_general](
	[BitacoraId] [int] NOT NULL,
	[SucursalId] [int] NULL,
	[Detalle] [varchar](500) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NULL,
 CONSTRAINT [PK_sis_bitacora_general] PRIMARY KEY CLUSTERED 
(
	[BitacoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[sis_bitacora_general]  WITH CHECK ADD  CONSTRAINT [FK_sis_bitacora_general_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[sis_bitacora_general] CHECK CONSTRAINT [FK_sis_bitacora_general_cat_sucursales]


ALTER TABLE [dbo].[sis_bitacora_general]  WITH CHECK ADD  CONSTRAINT [FK_sis_bitacora_general_cat_sucursales1] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[sis_bitacora_general] CHECK CONSTRAINT [FK_sis_bitacora_general_cat_sucursales1]


END
