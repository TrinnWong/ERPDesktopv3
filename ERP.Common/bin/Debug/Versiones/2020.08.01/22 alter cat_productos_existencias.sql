IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CostoPromedioInicial'
          AND Object_ID = Object_ID(N'cat_productos_existencias'))
BEGIN
   
	alter table cat_productos_existencias
	add CostoPromedioInicial money null
	
END
go