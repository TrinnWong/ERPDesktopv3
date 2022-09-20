if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_mesero_ins'
)

drop proc p_doc_pedidos_orden_mesero_ins
go
create proc p_doc_pedidos_orden_mesero_ins
@pPedidoOrdenId int,
@pEmpleadoId int
as

	insert into [dbo].[doc_pedidos_orden_mesero](
		PedidoOrdenId,EmpleadoId,CreadoEl
	)
	select @pPedidoOrdenId,@pEmpleadoId,getdate()