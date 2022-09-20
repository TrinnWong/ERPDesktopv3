-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_VentaTicket_Restaurante 1
alter proc p_rpt_VentaTicket_Restaurante
@pVentaId int
as
	

	select 
		v.VentaId,
			po.Personas,
		   Mesas = [dbo].[fnGetComandaMesas](po.PedidoId) + ' ' +po.Para
	from doc_ventas v
	inner join doc_pedidos_orden po  on po.VentaId = v.VentaId
	
	where v.VentaId = @pVentaId


