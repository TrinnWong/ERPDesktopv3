
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'DiasEntregaAdicSPedido'
          AND Object_ID = Object_ID('cat_web_configuracion'))
BEGIN
	alter table cat_web_configuracion
	add DiasEntregaAdicSPedido tinyint null
END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'DiasEntregaPedido'
          AND Object_ID = Object_ID('cat_web_configuracion'))
BEGIN
	
	alter table cat_web_configuracion
	add DiasEntregaPedido tinyint null

END
go


