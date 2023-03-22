if not exists (
	select 1
	from sysobjects
	where name = 'doc_promociones_cm'
)
begin


CREATE TABLE [dbo].[doc_promociones_cm](
	[PromocionCMId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[NombrePromocion] [varchar](150) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FechaVigencia] [datetime] NOT NULL,
	[HoraVigencia] [time](7) NOT NULL,
	[Lunes] [bit] NULL,
	[Martes] [bit] NULL,
	[Miercoles] [bit] NULL,
	[Jueves] [bit] NULL,
	[Viernes] [bit] NULL,
	[Sabado] [bit] NULL,
	[Domingo] [bit] NULL,
	[CreadoPor] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_doc_promociones_cm] PRIMARY KEY CLUSTERED 
(
	[PromocionCMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[doc_promociones_cm]  WITH CHECK ADD  CONSTRAINT [FK_doc_promociones_cm_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[doc_promociones_cm] CHECK CONSTRAINT [FK_doc_promociones_cm_cat_sucursales]


ALTER TABLE [dbo].[doc_promociones_cm]  WITH CHECK ADD  CONSTRAINT [FK_doc_promociones_cm_cat_usuarios] FOREIGN KEY([CreadoPor])
REFERENCES [dbo].[cat_usuarios] ([IdUsuario])


ALTER TABLE [dbo].[doc_promociones_cm] CHECK CONSTRAINT [FK_doc_promociones_cm_cat_usuarios]


End
GO


