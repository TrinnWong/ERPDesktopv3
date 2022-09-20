if not exists (
	select 1
	from cat_productos
	where ProductoId = -1
)
begin
	insert into cat_productos(ProductoId,Clave,Descripcion,DescripcionCorta,FechaAlta,Estatus,CodigoBarras)
	select -1,'-1','Cargo Adic.','Cargo Adic.',getdate(),1,'-1'
end
