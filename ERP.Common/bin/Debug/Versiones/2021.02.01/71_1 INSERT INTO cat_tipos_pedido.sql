IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_pedido
)
BEGIN

INSERT INTO cat_tipos_pedido 
VALUES(1,'Pedido Cliente/Mayoreo')

INSERT INTO cat_tipos_pedido 
VALUES(2,'Pedido Por Teléfono')

INSERT INTO cat_tipos_pedido 
VALUES(3,'Pedido Pago Inmediato')

END
GO
