IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'sis_preferencias'
)
BEGIN

CREATE TABLE [dbo].[sis_preferencias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Preferencia] [varchar](150) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[ParaEmpresa] [bit] NOT NULL,
	[ParaUsuario] [bit] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_sis_preferencias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END


