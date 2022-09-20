IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PedidoPoliticaId'
          AND Object_ID = Object_ID(N'cat_configuracion'))
BEGIN  
	
	alter table cat_configuracion
	add PedidoPoliticaId int null

	ALTER TABLE cat_configuracion
	ADD FOREIGN KEY (PedidoPoliticaId) REFERENCES cat_politicas(PoliticaId); 

END
go