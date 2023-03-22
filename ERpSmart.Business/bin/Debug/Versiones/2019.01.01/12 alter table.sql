
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Precio'
          AND Object_ID = Object_ID('doc_pedidos_configuracion_det'))
BEGIN
	alter table doc_pedidos_configuracion_det
	add Precio money null
END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Precio'
          AND Object_ID = Object_ID('doc_pedidos_clientes_det'))
BEGIN
	alter table doc_pedidos_clientes_det
	add Precio money null
END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'CostoEnvio'
          AND Object_ID = Object_ID('doc_pedidos_clientes'))
BEGIN
	alter table doc_pedidos_clientes
	add CostoEnvio money null
END
go

