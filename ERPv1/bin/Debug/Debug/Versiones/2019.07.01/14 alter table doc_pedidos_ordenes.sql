IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Cancelada'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   alter table [dbo].doc_pedidos_orden
	add Cancelada bit null

END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaCancelacion'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   alter table [dbo].doc_pedidos_orden
	add FechaCancelacion DateTime null

END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CanceladoPor'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   alter table [dbo].doc_pedidos_orden
	add CanceladoPor int null

END
go