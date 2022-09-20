if not exists (
	select 1
	from sysobjects
	where name = 'cat_rec_configuracion_rangos'
)
begin

CREATE TABLE [dbo].[cat_rec_configuracion_rangos](
	[Id] [smallint] NOT NULL,
	[RangoInicial] [money] NOT NULL,
	[RangoFinal] [money] NOT NULL,
	[PorcDeclarar] [decimal](5, 2) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_rec_configuracion_rangos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

End
GO


