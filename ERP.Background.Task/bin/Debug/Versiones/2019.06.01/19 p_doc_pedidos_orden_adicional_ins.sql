if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_adicional_ins'
)
drop proc p_doc_pedidos_orden_adicional_ins
go
create proc p_doc_pedidos_orden_adicional_ins
@pPedidoDetalleId int,
@pAdicionalId int,
@pCreadoPor int
as
		insert into doc_pedidos_orden_adicional(PedidoDetalleId,AdicionalId,CreadoEl,CreadoPor)
		select @pPedidoDetalleId,@pAdicionalId,getdate(),@pCreadoPor
