IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'sinc_doc_ventas'
)
BEGIN

CREATE TABLE sinc_doc_ventas(
	VentaId INT,
	VentaId_Externa INT,
	CreadoEl DATETIME
)

END

