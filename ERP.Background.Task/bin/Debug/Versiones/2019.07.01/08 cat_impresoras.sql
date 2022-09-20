if not exists (
	select 1
	from sysobjects
	where name = 'cat_impresoras'
)
begin

CREATE TABLE [dbo].[cat_impresoras](
	[ImpresoraId] [smallint] NOT NULL,
	[SucursalId] [int] NOT NULL,
	[NombreRed] [varchar](250) NOT NULL,
	[NombreImpresora] [varchar](150) NOT NULL,
	[Activa] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_impresoras] PRIMARY KEY CLUSTERED 
(
	[ImpresoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_impresoras]  WITH CHECK ADD  CONSTRAINT [FK_cat_impresoras_cat_sucursales] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[cat_sucursales] ([Clave])


ALTER TABLE [dbo].[cat_impresoras] CHECK CONSTRAINT [FK_cat_impresoras_cat_sucursales]
END


go


