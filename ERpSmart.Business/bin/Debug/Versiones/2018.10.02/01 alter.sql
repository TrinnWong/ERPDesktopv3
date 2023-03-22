IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'ProductoId'
          AND Object_ID = Object_ID('cat_productos_agrupados'))
BEGIN
	alter table cat_productos_agrupados
	add ProductoId int not null

END
go

if not exists (
	 SELECT
    1 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME ='FK_productos_agrupados_productos'
)
begin

	alter table cat_productos_agrupados
	Add Constraint FK_productos_agrupados_productos 
	foreign key (ProductoId) references cat_productos(ProductoId)

end

go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Rating'
          AND Object_ID = Object_ID('cat_productos_agrupados'))
BEGIN
	alter table cat_productos_agrupados
	add Rating tinyint  null

END
go