-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

alter proc p_doc_pedidos_orden_detalle_del
@pPedidoDetalleId int
as

	declare @promocionCMId int,
		@pedidoId int,
		@comandaId int,
		@pedidoDetallePromoId int

	select @promocionCMId = PromocionCMId ,
		@pedidoId = PedidoId,
		@comandaId = ComandaId
	from doc_pedidos_orden_detalle
	where PedidoDetalleId = @pPedidoDetalleId

	if isnull(@promocionCMId,0) > 0
	begin
		select @pedidoDetallePromoId  = min(PedidoDetalleId) 
		from doc_pedidos_orden_detalle
		where PedidoDetalleId > @pPedidoDetalleId and ProductoId = 0 and
		PedidoId = @pedidoId

		update doc_pedidos_orden_detalle
		set Cantidad = 0,
			Cancelado = 1,		
			Descuento = 0,
			Impuestos = 0,
			Total = 0
		where PromocionCMId = @promocionCMId and
		isnull(Cancelado,0) = 0 and
		PedidoId = @pedidoId and
		PedidoDetalleId =@pedidoDetallePromoId AND
		ProductoId = 0 --Solo promociones
	end

	update doc_pedidos_orden_detalle
	set Cantidad = 0,
		Cancelado = 1,		
		Descuento = 0,
		Impuestos = 0,
		Total = 0
	where PedidoDetalleId = @pPedidoDetalleId

	

	


