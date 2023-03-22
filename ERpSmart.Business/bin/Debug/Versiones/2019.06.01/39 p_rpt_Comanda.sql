if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_Comanda'
)
drop proc p_rpt_Comanda
go

create proc p_rpt_Comanda
@pPedidoId int,
@pComandaId int,
@pMarcarImpresos bit
as

	select Fecha = GETDATE(),
		Folio = com.Folio,
		Cantidad = pd.Cantidad ,
		Descripcion = prod.Descripcion + dbo.fnGetComandaAdicionales(pd.PedidoDetalleId),
		pd.Parallevar,
		Mesas = dbo.fnGetComandaMesas(@pPedidoId),
		Para = case when isnull(pd.Parallevar,0) = 1 then 'PARA LLEVAR' 
				when isnull(pd.Parallevar,0) = 0 then 'PARA MESA' 
				end
	from doc_pedidos_orden p
	inner join doc_pedidos_orden_detalle pd on pd.PedidoId = p.PedidoId
	inner join cat_rest_comandas com on com.ComandaId = pd.ComandaId
	inner join cat_productos prod on prod.ProductoId = pd.ProductoId
	where p.PedidoId = @pPedidoId and isnull(Impreso,0) = 0
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