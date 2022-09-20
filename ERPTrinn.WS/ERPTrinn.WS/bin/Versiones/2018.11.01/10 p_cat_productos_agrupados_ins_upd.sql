if exists (
	select 1
	from sysobjects
	where name = 'p_cat_productos_agrupados_ins_upd'
)
drop proc p_cat_productos_agrupados_ins_upd
go
Create proc p_cat_productos_agrupados_ins_upd
@pProductoAgrupadoId	int out,	
@pProductoId	int,
@pEspecificaciones varchar(500)
as

	declare @Descripcion	varchar(60),
			@DescripcionCorta	varchar(30)

	select @Descripcion =Descripcion ,
		@DescripcionCorta = DescripcionCorta 
	from cat_productos
	where ProductoId =@pProductoId 

	if isnull(@pProductoAgrupadoId,0) = 0
	begin

		select @pProductoAgrupadoId = isnull(max(ProductoAgrupadoId),0) + 1
		from cat_productos_agrupados
		
		insert into cat_productos_agrupados(
			ProductoAgrupadoId,Descripcion,DescripcionCorta,CreadoEl,Especificaciones,ProductoId
		)
		values(
			@pProductoAgrupadoId,@Descripcion,@DescripcionCorta,getdate(),@pEspecificaciones,@pProductoId
		)

		insert into cat_productos_agrupados_detalle(ProductoAgrupadoId,ProductoId,CreadoEl)
		values(@pProductoAgrupadoId,@pProductoId,getdate())
	end
	Else
	Begin
		
		update 	cat_productos_agrupados
		set Descripcion=@Descripcion,
			DescripcionCorta=@DescripcionCorta,
			Especificaciones=@pEspecificaciones,
			ProductoId = @pProductoId
		where ProductoAgrupadoId = @pProductoAgrupadoId


		update cat_productos
		set Especificaciones = @pEspecificaciones
		from cat_productos p
		inner join cat_productos_agrupados pa on pa.ProductoId = p.ProductoId
		where pa.ProductoAgrupadoId = @pProductoAgrupadoId

	End

	

