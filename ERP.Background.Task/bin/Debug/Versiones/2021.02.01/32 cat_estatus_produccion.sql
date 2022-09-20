if not exists (
	select 1
	from sysobjects 
	where name = 'cat_estatus_produccion'
)
BEGIN

CREATE TABLE [dbo].[cat_estatus_produccion](
	[EstatusProduccionId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cat_estatus_produccion] PRIMARY KEY CLUSTERED 
(
	[EstatusProduccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO cat_estatus_produccion(EstatusProduccionId,Nombre)
VALUES(1,'Registrada')

INSERT INTO cat_estatus_produccion(EstatusProduccionId,Nombre)
VALUES(2,'En Producción')

INSERT INTO cat_estatus_produccion(EstatusProduccionId,Nombre)
VALUES(3,'Producción Terminada')


END
GO


