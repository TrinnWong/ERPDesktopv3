

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'ClienteId'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table [doc_web_carrito]
	add ClienteId int null
	

	ALTER TABLE [doc_web_carrito]
	ADD CONSTRAINT FK_Carrito_Cliente
	FOREIGN KEY (ClienteId) REFERENCES cat_clientes(ClienteId)


END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Impuestos'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table [doc_web_carrito]
	add Impuestos money null

END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Subtotal'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table [doc_web_carrito]
	add Subtotal money null

END
go
