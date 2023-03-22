
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Impuestos'
          AND Object_ID = Object_ID('doc_web_carrito_detalle'))
BEGIN
	alter table doc_web_carrito_detalle
	add Impuestos money null

END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Subtotal'
          AND Object_ID = Object_ID('doc_web_carrito_detalle'))
BEGIN
	alter table doc_web_carrito_detalle
	add Subtotal money null

END
go
