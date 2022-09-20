IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'FormaPagoId'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table doc_web_carrito
	add FormaPagoId tinyint null


END
go

