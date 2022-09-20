if not exists (
	select 1
	from sysobjects
	where name = 'cat_equipos_computo'
)
BEGIN

CREATE TABLE [dbo].[cat_equipos_computo](
	[EquipoComputoId] [int] NOT NULL,
	[HardwareID] [varchar](250) NOT NULL,
	[IPPublica] [varchar](50) NOT NULL,
	[PCName] [varchar](250) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
	[ModificadoEl] [datetime] NULL,
 CONSTRAINT [PK_cat_equipos_computo] PRIMARY KEY CLUSTERED 
(
	[EquipoComputoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO


