IF NOT EXISTS (
SELECT 1
FROM SYSOBJECTS
WHERE NAME  = 'doc_rango_gramos_venta'
)
BEGIN

	CREATE TABLE [dbo].[doc_rango_gramos_venta](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[RangoIniVenta] [decimal](14, 3) NOT NULL,
		[RangoFinVenta] [decimal](14, 3) NOT NULL,
		[EstablecerValor] [decimal](14, 3) NOT NULL,
	 CONSTRAINT [PK_doc_rango_gramos_venta] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


END


