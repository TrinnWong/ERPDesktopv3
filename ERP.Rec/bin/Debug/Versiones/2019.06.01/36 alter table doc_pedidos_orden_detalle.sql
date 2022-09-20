

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Parallevar'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN
   
alter table doc_pedidos_orden_detalle
add Parallevar bit null




END
go