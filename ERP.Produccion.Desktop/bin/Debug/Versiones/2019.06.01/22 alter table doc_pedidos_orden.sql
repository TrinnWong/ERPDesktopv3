IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Personas'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   alter table [dbo].[doc_pedidos_orden]
	add Personas tinyint not null

END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaApertura'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   alter table [dbo].[doc_pedidos_orden]
add FechaApertura DateTime not null


END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaCierre'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
alter table [dbo].[doc_pedidos_orden]
add FechaCierre DateTime not null
END
go







