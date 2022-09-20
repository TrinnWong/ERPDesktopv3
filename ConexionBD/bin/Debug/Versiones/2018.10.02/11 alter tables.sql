IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Pagado'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
   alter table doc_web_carrito
   add Pagado bit null
END


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'FechaPago'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
   alter table doc_web_carrito
   add FechaPago datetime null
END


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'VentaId'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
   alter table doc_web_carrito
   add VentaId bigint null

	ALTER TABLE doc_web_carrito
	ADD CONSTRAINT FK_Carrito_Ventas
	FOREIGN KEY (VentaId) REFERENCES doc_ventas(VentaId);
END