if not exists (
	select 1
	from sysobjects
	where name = 'sis_correos_tipos'
)
begin

CREATE TABLE [dbo].[sis_correos_tipos](
	[TipoCorreoId] [smallint] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Html] [text] NOT NULL,
	[CreadoEl] [varchar](250) NOT NULL,
 CONSTRAINT [PK_sis_correos_tipos] PRIMARY KEY CLUSTERED 
(
	[TipoCorreoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END
GO


