IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'VentaId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN
   
alter table doc_pedidos_orden
add VentaId bigint null


ALTER TABLE doc_pedidos_orden
ADD CONSTRAINT FK_Pedidos_Ventas
FOREIGN KEY (VentaId) REFERENCES doc_ventas(VentaId);


END
go






