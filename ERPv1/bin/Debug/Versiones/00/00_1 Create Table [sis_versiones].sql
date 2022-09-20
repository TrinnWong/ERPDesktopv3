if not exists(
	select 1
	from sysobjects
	where name = 'sis_versiones'
)
begin

CREATE TABLE [dbo].[sis_versiones](
	[VersionId] [smallint] NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[Completado] [bit] NOT NULL,
	[Intentos] [tinyint] NOT NULL,
 CONSTRAINT [PK_sis_versiones] PRIMARY KEY CLUSTERED 
(
	[VersionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



end

GO

SET ANSI_PADDING OFF
GO


