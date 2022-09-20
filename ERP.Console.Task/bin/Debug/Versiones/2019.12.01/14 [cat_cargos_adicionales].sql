if not exists (
	select 1
	from sysobjects 
	where name = 'cat_cargos_adicionales'
)
begin

CREATE TABLE [dbo].[cat_cargos_adicionales](
	[CargoAdicionalId] [smallint] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_cargos_adicionales] PRIMARY KEY CLUSTERED 
(
	[CargoAdicionalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

end
GO


