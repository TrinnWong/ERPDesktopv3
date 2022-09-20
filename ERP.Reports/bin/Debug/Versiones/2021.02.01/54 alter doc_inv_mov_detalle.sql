
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SubTotal'
          AND Object_ID = Object_ID(N'doc_inv_movimiento_detalle'))
BEGIN  
	
	alter table doc_inv_movimiento_detalle
	add SubTotal money null

END

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PrecioNeto'
          AND Object_ID = Object_ID(N'doc_inv_movimiento_detalle'))
BEGIN  
	
	alter table doc_inv_movimiento_detalle
	add PrecioNeto money null

END