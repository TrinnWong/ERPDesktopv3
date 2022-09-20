
alter proc [dbo].[p_doc_pedidos_orden_detalle_insupd]
@pPedidoDetalleId	int out,
@pPedidoId	int,
@pProductoId	int,
@pCantidad	decimal(14,3),
@pPrecioUnitario	money,
@pPorcDescuento	decimal(5,2),
@pDescuento	money,
@pImpuestos	money,
@pNotas	varchar(200),
@pTotal	money,
@pCreadoPor	int,
@pTasaIVA	decimal(5,2),
@pParallevar bit,
@pComandaId int OUT,
@pTipoDescuentoId tinyint
as

	declare @sucursalId int,
			@porcIVA decimal(5,2)

	select @sucursalId = SucursalId
	from doc_pedidos_orden
	where PedidoId = @pPedidoId

	create table #tmpPromocion
	(
		PromocionId int,
		ProdutoId	int,
		PorcentajeDescuento decimal(5,2)
	)

	select @pTipoDescuentoId = 3
	from doc_pedidos_orden o
	inner join cat_clientes c on c.ClienteId = o.ClienteId and
								c.EmpleadoId is not null
	where PedidoId = @pPedidoId and @pTipoDescuentoId <> 2 --Solo para desc diferentes a cortesia

	--Obtener descuento de promociones activas
	if(isnull(@pPorcDescuento,0) = 0 )
	begin
		insert into #tmpPromocion(PromocionId,ProdutoId,PorcentajeDescuento)
		exec p_producto_promocion_sel @sucursalId,@pProductoId

		if exists (
		select 1
		from #tmpPromocion
		)
		begin
			select @pPorcDescuento = isnull(PorcentajeDescuento,0)
			from #tmpPromocion
		end


	end

	--Si es cortesía
	if @pTipoDescuentoId = 2
	begin
		set @pPorcDescuento = 100
	end	

	--Si es descuento empleado
	if @pTipoDescuentoId = 3
	begin

		--Si el descuento de la promocion es mayor, dejar el descuento de la promocion sobre el del empleado
		select @pPorcDescuento = case when isnull(EmpleadoPorcDescuento,0) > @pPorcDescuento 
									then  isnull(EmpleadoPorcDescuento,0) 
									else @pPorcDescuento 
								end,
				@pTipoDescuentoId = case when isnull(EmpleadoPorcDescuento,0) < @pPorcDescuento 
									then  1
									else @pTipoDescuentoId 
								end
		from cat_configuracion 

	end

	select @porcIVA = (Porcentaje / 100)
	from cat_productos_impuestos pi
	inner join cat_impuestos i on i.Clave = pi.ImpuestoId 
	where pi.ProductoId = @pProductoId and
	pi.ImpuestoId = 1--IVA	

	select @pPrecioUnitario = Precio
	from  cat_productos_precios 
	where IdProducto = @pProductoId and
	IdPrecio = 1

	set @pTotal = @pPrecioUnitario * @pCantidad
	set @pDescuento = (@pTotal * (@pPorcDescuento/100))
	set @pTotal = @pTotal - @pDescuento

	set @pImpuestos = case when @porcIVA > 0 then  @pTotal / (1 + @porcIVA) else 0 end

	

	if not exists (
		select 1
		from [doc_pedidos_orden_detalle]
		where PedidoDetalleId = @pPedidoDetalleId
	)
	begin


		--Comanda
		if(isnull(@pComandaId,0)=0)
		begin
			select @pComandaId = min(c.ComandaId)
			from cat_rest_comandas c
			inner join doc_pedidos_orden p on p.PedidoId = @pPedidoId
			left join doc_pedidos_orden_detalle pd on pd.ComandaId = c.ComandaId
			where Disponible = 1 and
			p.SucursalId = P.SucursalId  and
			pd.ComandaId is null


			if(isnull(@pComandaId,0) = 0)
			begin
				

				select @pComandaId = isnull(max(ComandaId),0) + 1
				from cat_rest_comandas 

				insert into cat_rest_comandas(
					ComandaId,SucursalId,Folio,Disponible,CreadoPor,CreadoEl
				)
				select @pComandaId,p.SucursalId,cast(@pComandaId as varchar),0,@pCreadoPor,getdate()
				from  doc_pedidos_orden p where p.PedidoId = @pPedidoId

				 
			end
		end

		update cat_rest_comandas
		set Disponible = 0
		where ComandaId = @pComandaId

		select @pPedidoDetalleId = isnull(max(PedidoDetalleId),0) + 1
		from [doc_pedidos_orden_detalle]

		insert into  [dbo].[doc_pedidos_orden_detalle](
			PedidoDetalleId,	PedidoId,	ProductoId,	Cantidad,	PrecioUnitario,	PorcDescuento,
			Descuento,			Impuestos,	Notas,		Total,		CreadoPor,		CreadoEl,
			TasaIVA,			Impreso,	Parallevar,	ComandaId,	TipoDescuentoId
		)
		select @pPedidoDetalleId,	@pPedidoId,		@pProductoId,	@pCantidad,		@pPrecioUnitario,	@pPorcDescuento,
			@pDescuento,			@pImpuestos,	@pNotas,		@pTotal  ,		@pCreadoPor,		getdate(),
			@pTasaIVA,			0,			@pParallevar, @pComandaId,case when @pTipoDescuentoId =0 then null else @pTipoDescuentoId end
	end
	Else
	Begin
		update [doc_pedidos_orden_detalle]
		set ProductoId=@pProductoId,
			Cantidad = @pCantidad,
			PrecioUnitario = @pPrecioUnitario,
			PorcDescuento = @pPorcDescuento,
			Descuento = @pDescuento,
			Impuestos = @pImpuestos,
			Notas = @pNotas,
			Total = @pTotal - isnull(@pDescuento,0),
			TasaIVA = @pTasaIVA,
			TipoDescuentoId = case when @pTipoDescuentoId = 0 then null else @pTipoDescuentoId end
		WHERE PedidoDetalleId = PedidoDetalleId

	End

	update doc_pedidos_orden
	set Descuento = (select isnull(sum(Descuento),0) from doc_pedidos_orden_detalle where PedidoId = @pPedidoId)
	where PedidoId = @pPedidoId

	update doc_pedidos_orden
	set Total = (select isnull(sum(Total),0) from doc_pedidos_orden_detalle where PedidoId = @pPedidoId) - isnull(Descuento,0),
		Impuestos = (select isnull(sum(Impuestos),0) from doc_pedidos_orden_detalle where PedidoId = @pPedidoId)
	where PedidoId = @pPedidoId

	update doc_pedidos_orden
	set Subtotal = Total-isnull(Impuestos,0)
	where PedidoId = @pPedidoId


