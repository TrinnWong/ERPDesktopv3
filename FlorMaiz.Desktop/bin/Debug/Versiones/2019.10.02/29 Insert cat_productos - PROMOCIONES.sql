if not exists (
	select 1
	from cat_productos
	where ProductoId = 0
)
begin
	insert into cat_productos(ProductoId,Clave,Descripcion,DescripcionCorta,FechaAlta,Estatus)
	select 0,'0','Promociones','Promociones',getdate(),1
end