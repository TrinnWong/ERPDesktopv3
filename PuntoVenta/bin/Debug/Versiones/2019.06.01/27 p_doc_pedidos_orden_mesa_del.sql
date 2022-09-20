if exists(
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_mesa_del'
)
drop proc p_doc_pedidos_orden_mesa_del
go
create proc p_doc_pedidos_orden_mesa_del
@pPedidoOrdenId int
as


	delete doc_pedidos_orden_mesa
	where PedidoOrdenId = @pPedidoOrdenId

