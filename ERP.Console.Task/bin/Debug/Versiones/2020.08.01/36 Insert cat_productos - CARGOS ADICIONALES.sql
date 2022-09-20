if not exists (
	select 1
	from cat_productos
	where ProductoId = -2
)
begin
	insert into cat_productos(ProductoId,Clave,Descripcion,DescripcionCorta,FechaAlta,Estatus)
	select -2,'-2','Fletes','Fletes',getdate(),1
end

if not exists (
	select 1
	from cat_productos
	where ProductoId = -3
)
begin
	insert into cat_productos(ProductoId,Clave,Descripcion,DescripcionCorta,FechaAlta,Estatus)
	select -3,'-3','Comisiones','Comisiones',getdate(),1
end