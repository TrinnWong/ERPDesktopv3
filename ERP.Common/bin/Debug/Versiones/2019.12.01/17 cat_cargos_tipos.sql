
if not exists (	
	select 1
	from sysobjects
	where name = 'cat_cargos_tipos'
)
begin

CREATE TABLE [dbo].[cat_cargos_tipos](
	[CargoTipoId] [tinyint] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_cargos_tipos] PRIMARY KEY CLUSTERED 
(
	[CargoTipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

end
GO


