if exists(SELECT 1 FROM sys.triggers WHERE name = 'tr_cat_productos_precios_after_update')
begin 
	drop trigger [tr_cat_productos_precios_after_update]
end
go 
create  TRIGGER [dbo].[tr_cat_productos_precios_after_update] ON [dbo].[cat_productos_precios] AFTER UPDATE
AS 
BEGIN
	declare @IdPrecioMax int, @UltimoPrecio decimal(16,6)= 0, @IdKey int 
	select @IdPrecioMax= max(t1.id)
	from [cat_productos_cambio_precio] t1 inner join inserted t2 on t2.IdProducto = t1.ProductoId and t2.IdPrecio=  t1.PrecioId
	
	select @UltimoPrecio= PrecioNuevo from [cat_productos_cambio_precio] where id= @IdPrecioMax

	if exists (select 1 from inserted where Precio<>@UltimoPrecio)
	begin 
		select @IdKey = max(Id)+1 from [cat_productos_cambio_precio] 
		insert into [cat_productos_cambio_precio](Id, ProductoId, PrecioId, PrecioAnterior, PrecioNuevo, FechaRegistro, UsuarioRegistroId)
		select @IdKey, t1.IdProducto, PrecioId= t1.IdPrecio , PrecioAnterior= @UltimoPrecio, PrecioNuevo=t1.Precio,  FechaRegistro= dbo.fn_GetDateTimeServer(), UsuarioRegistroId= 1
		from inserted t1
	end
end
go 
