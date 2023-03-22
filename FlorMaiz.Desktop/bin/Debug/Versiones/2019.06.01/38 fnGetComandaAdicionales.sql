if exists (
	select 1
	from sysobjects
	where name ='fnGetComandaAdicionales'
)
drop function dbo.fnGetComandaAdicionales
go
CREATE FUNCTION dbo.fnGetComandaAdicionales
(
	@pPedidoDetalleId int
)
RETURNS varchar(500)
AS
BEGIN
	
	DECLARE @Result varchar(500),
			@ingredientes varchar(500)='',
			@adicionales varchar(500)='',
			@notas varchar(500) = ''

	select @ingredientes= @ingredientes + ' '+
						case when i.Con = 1 then 'C/'
							 when i.Sin = 1 then 'S/'
						end+
						isnull(p.DescripcionCorta,'')
	from doc_pedidos_orden_ingre i	
	inner join cat_productos p on p.ProductoId = i.ProductoId
	where PedidoDetalleId = @pPedidoDetalleId

	select @adicionales = @adicionales +
						' /'+
						isnull(a.Descripcion,'')
	from doc_pedidos_orden_adicional pa
	inner join cat_rest_platillo_adicionales a on a.Id = pa.AdicionalId
	where pa.PedidoDetalleId = @pPedidoDetalleId


	select @notas = Notas
	from doc_pedidos_orden_detalle
	where PedidoDetalleId = @pPedidoDetalleId

	set @Result = isnull(@ingredientes,'') + ' '+
					isnull(@adicionales,'') +' '+ isnull(@notas,'')


	

	-- Return the result of the function
	RETURN @Result

END
GO

