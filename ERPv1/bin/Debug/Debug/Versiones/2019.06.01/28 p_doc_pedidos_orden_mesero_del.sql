if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_mesero_del'
)

drop proc p_doc_pedidos_orden_mesero_del
go
create proc p_doc_pedidos_orden_mesero_del
@pPedidoOrdenId int
as

	delete [doc_pedidos_orden_mesero]
	where PedidoOrdenId = @pPedidoOrdenId