IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Version'
          AND Object_ID = Object_ID(N'cat_productos'))
BEGIN
   
	
alter table cat_productos
add Version varchar(20) null



END
go

