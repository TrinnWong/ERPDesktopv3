if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_ingre_del'
)
drop proc p_doc_pedidos_orden_ingre_del
go
create proc p_doc_pedidos_orden_ingre_del
@pPedidoDetalleId int
as


	delete doc_pedidos_orden_ingre
	where PedidoDetalleId = @pPedidoDetalleId

	
