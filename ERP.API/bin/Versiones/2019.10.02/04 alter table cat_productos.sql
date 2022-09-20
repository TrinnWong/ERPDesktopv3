if not exists (
	select 1
	from sysobjects
	where name = 'cat_productos_licencias'
)
begin

CREATE TABLE [dbo].[cat_productos_licencias](
	[ProductoId] [int] NOT NULL,
	[TiempoLicencia] [smallint] NOT NULL,
	[UnidadLicencia] [varchar](1) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_productos_licencias] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_productos_licencias]  WITH CHECK ADD  CONSTRAINT [FK_cat_productos_licencias_cat_productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[cat_productos] ([ProductoId])


ALTER TABLE [dbo].[cat_productos_licencias] CHECK CONSTRAINT [FK_cat_productos_licencias_cat_productos]
END
GO


