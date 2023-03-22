if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_cancelacion'
)
drop proc p_doc_pedidos_orden_cancelacion
go

create proc p_doc_pedidos_orden_cancelacion
@pPedidoId int,
@pMotivoCancelacion varchar(150),
@pCanceladoPor int
as

	update doc_pedidos_orden
	set Cancelada = 1,
		FechaCancelacion = getdate(),
		MotivoCancelacion = @pMotivoCancelacion,
		CanceladoPor = @pCanceladoPor,
		Activo = 0
	where PedidoId = @pPedidoId