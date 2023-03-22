
ALTER proc [dbo].[p_rpt_Comanda]
@pPedidoId int,
@pComandaId int,
@pMarcarImpresos bit,
@pNotas varchar(250)
as

	select Fecha = GETDATE(),
		Folio = ISNULL(TP.Folio,'') + ISNULL(p.Folio,''),
		Cantidad = pd.Cantidad ,
		Descripcion = pd.Descripcion + dbo.fnGetComandaAdicionales(pd.PedidoDetalleId),
		pd.Parallevar,
		Mesas = dbo.fnGetComandaMesas(@pPedidoId),
		Para = case when isnull(pd.Parallevar,0) = 1 then 'PARA LLEVAR' 
				when isnull(pd.Parallevar,0) = 0 then 'PARA MESA' 
				end,
		Notas = ISNULL(@pNotas,'') + ISNULL(p.Notas,''),
		Recibe = p.Para
	from doc_pedidos_orden p
	inner join doc_pedidos_orden_detalle pd on pd.PedidoId = p.PedidoId
	inner join cat_rest_comandas com on com.ComandaId = pd.ComandaId
	inner join cat_productos prod on prod.ProductoId = pd.ProductoId
	LEFT JOIN	cat_tipos_pedido TP ON TP.TipoPedidoId = p.TipoPedidoId
	where p.PedidoId = @pPedidoId and isnull(Impreso,0) = 0
	and isnull(pd.Cancelado,0) = 0 
	and prod.productoId > 0
	--and
	--@pComandaId in (pd.ComandaId ,0 )
	order by cast(pd.Parallevar as int) ASC,pd.CreadoEl

	if(@pMarcarImpresos = 1)
	begin

		update doc_pedidos_orden_detalle
		set Impreso = 1		
		where PedidoId = @pPedidoId and
		isnull(Impreso,0) = 0

	end


	--update doc_pedidos_orden
	--set Total = (select isnull(sum(Total),0) from doc_pedidos_orden_detalle where PedidoId = @pPedidoId),
	--	Impuestos = (select isnull(sum(Impuestos),0) from doc_pedidos_orden_detalle where PedidoId = @pPedidoId)
	--where PedidoId = @pPedidoId

	--update doc_pedidos_orden
	--set Subtotal = Total-isnull(Impuestos,0)
	--where PedidoId = @pPedidoId


