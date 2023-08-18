IF NOT EXISTS (

	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'sinc_doc_inv_movimiento'
)
BEGIN

CREATE TABLE [sinc_doc_inv_movimiento](
	[MovimientoId] [int] NULL,
	[MovimientoId_Externa] [int] NULL,
	[CreadoEl] [datetime] NULL
) ON [PRIMARY]

END


