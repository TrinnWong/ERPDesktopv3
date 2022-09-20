if not exists (
	select 1
	from sysobjects
	where name = 'cat_rest_platillo_adicionales_sfam'
)
begin

CREATE TABLE [dbo].[cat_rest_platillo_adicionales_sfam](
	[PlatilloAdicionalId] [int] NOT NULL,
	[SubfamiliaId] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_rest_platillo_adicionales_sfam] PRIMARY KEY CLUSTERED 
(
	[PlatilloAdicionalId] ASC,
	[SubfamiliaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[cat_rest_platillo_adicionales_sfam]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_platillo_adicionales_sfam_cat_rest_platillo_adicionales] FOREIGN KEY([PlatilloAdicionalId])
REFERENCES [dbo].[cat_rest_platillo_adicionales] ([Id])


ALTER TABLE [dbo].[cat_rest_platillo_adicionales_sfam] CHECK CONSTRAINT [FK_cat_rest_platillo_adicionales_sfam_cat_rest_platillo_adicionales]


ALTER TABLE [dbo].[cat_rest_platillo_adicionales_sfam]  WITH CHECK ADD  CONSTRAINT [FK_cat_rest_platillo_adicionales_sfam_cat_subfamilias] FOREIGN KEY([SubfamiliaId])
REFERENCES [dbo].[cat_subfamilias] ([Clave])


ALTER TABLE [dbo].[cat_rest_platillo_adicionales_sfam] CHECK CONSTRAINT [FK_cat_rest_platillo_adicionales_sfam_cat_subfamilias]

END

