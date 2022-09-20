if exists(
	select 1
	from sysobjects
	where name = 'p_cat_productos_agrupados_ins_upd'
)
drop proc p_cat_productos_agrupados_ins_upd
go
Create proc p_cat_productos_agrupados_ins_upd
@pProductoAgrupadoId	int out,	
@pProductoId	int,
@pEspecificaciones varchar(500),
@pLiquidacion bit
as

	declare @Descripcion	varchar(60),
			@DescripcionCorta	varchar(30)

	select @Descripcion =Descripcion ,
		@DescripcionCorta = DescripcionCorta,
		@pEspecificaciones = Especificaciones
	from cat_productos
	where ProductoId =@pProductoId 

	if isnull(@pProductoAgrupadoId,0) = 0
	begin

		select @pProductoAgrupadoId = isnull(max(ProductoAgrupadoId),0) + 1
		from cat_productos_agrupados
		
		insert into cat_productos_agrupados(
			ProductoAgrupadoId,Descripcion,DescripcionCorta,CreadoEl,Especificaciones,ProductoId,
			Liquidacion
		)
		values(
			@pProductoAgrupadoId,@Descripcion,@DescripcionCorta,getdate(),@pEspecificaciones,@pProductoId,
			@pLiquidacion
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
			ProductoId = @pProductoId,
			Liquidacion = @pLiquidacion
		where ProductoAgrupadoId = @pProductoAgrupadoId


		--update cat_productos
		--set Especificaciones = CASE WHEN ISNULL(@pEspecificaciones,'') = '' THEN Especificaciones
		--						ELSE @pEspecificaciones
		--						end
		--from cat_productos p
		--inner join cat_productos_agrupados pa on pa.ProductoId = p.ProductoId
		--where pa.ProductoAgrupadoId = @pProductoAgrupadoId

	End

	update cat_productos 
	set Liquidacion = @pLiquidacion
	from cat_productos p
	inner join cat_productos_agrupados_detalle pa on pa.ProductoId = p.ProductoId
	where pa.ProductoAgrupadoId = @pProductoAgrupadoId

	


