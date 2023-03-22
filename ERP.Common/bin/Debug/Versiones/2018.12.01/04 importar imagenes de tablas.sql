declare @productoImagen int

select @productoImagen = isnull(max(ProductoImageId),0)
from cat_productos_imagenes

insert into cat_productos_imagenes(
ProductoImageId,ProductoId,FileName,CreadoEl,FileByte,
Principal,Miniatura
)

select ROW_NUMBER() OVER(ORDER BY p.productoId ASC) + @productoImagen,ProductoId,rtrim(p.Clave)+'.jpg',GETDATE(),p.Foto,
1,null
from cat_productos p
where not exists(
	select 1
	from cat_productos_imagenes p1
	where p1.ProductoId = p.ProductoId
) and
p.Foto is not null


if(@@ROWCOUNT > 0)
begin
	update cat_productos
	set Foto = null
end