if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_buscar'
)
drop proc p_doc_pedidos_orden_buscar
go
create proc p_doc_pedidos_orden_buscar
@pMesasId varchar(500),
@pComandaId int
as


	select mesaId = splitdata
	into #tmpMesas
	from [dbo].[fnSplitString](@pMesasId,',')


	select PedidoId = isnull(max(p.PedidoId),0)
	from doc_pedidos_orden p
	inner join doc_pedidos_orden_mesa pm on pm.PedidoOrdenId = p.PedidoId
	inner join #tmpMesas m on m.mesaId = pm.MesaId
	where p.VentaId is null and
	isnull(p.MotivoCancelacion,'') = ''