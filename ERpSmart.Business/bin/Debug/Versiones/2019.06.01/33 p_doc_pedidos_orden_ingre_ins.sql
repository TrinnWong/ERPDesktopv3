if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_ingre_ins'
)
drop proc p_doc_pedidos_orden_ingre_ins
go
create proc p_doc_pedidos_orden_ingre_ins
@pPedidoDetalleId int,
@pProductoMateriaPrimaId int,
@pCon bit,
@pSin bit,
@pCreadoPor int
as

	insert into doc_pedidos_orden_ingre(PedidoDetalleId,ProductoId,CreadoEl,CreadoPor,Con, Sin)
	select @pPedidoDetalleId,@pProductoMateriaPrimaId,getdate(),@pCreadoPor,@pCon,@pSin
