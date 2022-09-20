if not exists (
	select 1
	from sysobjects
	where name = 'cat_paqueterias'
)
begin

CREATE TABLE [dbo].[cat_paqueterias](
	[PaqueteriaId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_cat_paqueterias] PRIMARY KEY CLUSTERED 
(
	[PaqueteriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
go


