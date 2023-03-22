if not exists (
	select 1
	from sysobjects
	where name = 'sis_notificaciones'
)
begin
CREATE TABLE [dbo].[sis_notificaciones](
	[NotificacionId] [int] NOT NULL,
	[Para] [varchar](500) NOT NULL,
	[Asunto] [varchar](250) NOT NULL,
	[Mensaje] [text] NOT NULL,
	[FechaProgramadaEnvio] [datetime] NOT NULL,
	[Enviada] [bit] NOT NULL,
	[FechaEnvio] [datetime] NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[ModificadoPor] [int] NULL,
	[ModificadoEl] [datetime] NULL,
	[De] [varchar](100) NULL,
 CONSTRAINT [PK_sis_notificaciones] PRIMARY KEY CLUSTERED 
(
	[NotificacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END
GO


