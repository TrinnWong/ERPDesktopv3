if exists (
	select 1
	from sysobjects
	where name = 'p_cat_productos_agrupados_detalle_ins'
)
drop proc p_cat_productos_agrupados_detalle_ins
go
create proc p_cat_productos_agrupados_detalle_ins
@pProductoAgrupadoId int,
@pProductoId int
as

	declare @especificaciones varchar(500)

	select @especificaciones = Especificaciones
	from cat_productos_agrupados
	where ProductoAgrupadoId = @pProductoAgrupadoId 

	insert into [dbo].[cat_productos_agrupados_detalle](
		ProductoAgrupadoId,ProductoId,CreadoEl
	)
	select @pProductoAgrupadoId,@pProductoId,getdate()

	update cat_productos
	set Especificaciones = @especificaciones
	where ProductoId = @pProductoId



