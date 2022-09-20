if not exists (
select 1
from sysobjects
where name = 'cat_configuracion_restaurante'
)
begin

CREATE TABLE [dbo].[cat_configuracion_restaurante](
	[Id] [int] NOT NULL,
	[SolicitarFolioComanda] [bit] NOT NULL,
 CONSTRAINT [PK_cat_configuracion_restaurante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO


