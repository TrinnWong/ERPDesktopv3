IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PedidoAnticipoPorc'
          AND Object_ID = Object_ID(N'cat_configuracion'))
BEGIN

	alter table cat_configuracion
	add PedidoAnticipoPorc decimal(5,2) null

END
go