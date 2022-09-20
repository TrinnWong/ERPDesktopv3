if exists(
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_mesa_ins'
)
drop proc p_doc_pedidos_orden_mesa_ins
go
create proc p_doc_pedidos_orden_mesa_ins
@pPedidoOrdenId int,
@pMesaId int
as


	insert into doc_pedidos_orden_mesa(
		PedidoOrdenId,MesaId,CreadoEl
	)
	select @pPedidoOrdenId,@pMesaId,getdate()

