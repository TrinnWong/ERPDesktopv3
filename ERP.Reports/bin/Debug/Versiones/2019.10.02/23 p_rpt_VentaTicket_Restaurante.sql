if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_VentaTicket_Restaurante'
)
drop proc p_rpt_VentaTicket_Restaurante
go
-- p_rpt_VentaTicket_Restaurante 1
create proc p_rpt_VentaTicket_Restaurante
@pVentaId int
as
	

	select 
		v.VentaId,
			po.Personas,
		   Mesas = [dbo].[fnGetComandaMesas](po.PedidoId)
	from doc_ventas v
	inner join doc_pedidos_orden po  on po.VentaId = v.VentaId
	
	where v.VentaId = @pVentaId

