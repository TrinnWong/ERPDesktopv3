IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'cat_sucursales_departamentos'
)
BEGIN

CREATE TABLE [dbo].[cat_sucursales_departamentos](
	[SucursalId] [int] NOT NULL,
	[DepartamentoId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
 CONSTRAINT [PK_cat_sucursales_departamentos] PRIMARY KEY CLUSTERED 
(
	[SucursalId] ASC,
	[DepartamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_sucursales_departamentos]  WITH CHECK ADD  CONSTRAINT [FK_cat_sucursales_departamentos_cat_departamentos] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[cat_departamentos] ([DepartamentoId])


ALTER TABLE [dbo].[cat_sucursales_departamentos] CHECK CONSTRAINT [FK_cat_sucursales_departamentos_cat_departamentos]


ALTER TABLE [dbo].[cat_sucursales_departamentos]  WITH CHECK ADD  CONSTRAINT [FK_cat_sucursales_departamentos_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_sucursales_departamentos] CHECK CONSTRAINT [FK_cat_sucursales_departamentos_cat_sucursales]

END

