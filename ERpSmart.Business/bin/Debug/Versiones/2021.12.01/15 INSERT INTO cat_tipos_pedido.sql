IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_pedido
	where TipoPedidoId = 3
)
BEGIN

	INSERT INTO cat_tipos_pedido
	values(3,'Pedido Venta Caja','')

END

