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



	insert into [dbo].[cat_productos_agrupados_detalle](
		ProductoAgrupadoId,ProductoId,CreadoEl
	)
	select @pProductoAgrupadoId,@pProductoId,getdate()