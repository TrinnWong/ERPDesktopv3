if not exists (
select 1
from sysobjects 
where name = 'cat_rest_mesas'
)
begin

CREATE TABLE [dbo].[cat_rest_mesas](
	[MesaId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[ModificadoEl] [datetime] NULL,
	[ModificadoPor] [int] NULL,
 CONSTRAINT [PK_cat_rest_mesas] PRIMARY KEY CLUSTERED 
(
	[MesaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[cat_rest_mesas]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_mesas_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_rest_mesas] CHECK CONSTRAINT [FK_cat_rest_mesas_cat_sucursales]

ALTER TABLE [dbo].[cat_rest_mesas]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_mesas_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])

ALTER TABLE [dbo].[cat_rest_mesas] CHECK CONSTRAINT [FK_cat_rest_mesas_cat_usuarios]


ALTER TABLE [dbo].[cat_rest_mesas]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_mesas_cat_usuarios1] FOREIGN KEY([ModificadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[cat_rest_mesas] CHECK CONSTRAINT [FK_cat_rest_mesas_cat_usuarios1]
END
GO


