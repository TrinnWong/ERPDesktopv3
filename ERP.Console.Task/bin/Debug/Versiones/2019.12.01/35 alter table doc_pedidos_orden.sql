

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Para'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   
	alter table [dbo].[doc_pedidos_orden]
	add Para varchar(30) null

	
END
go