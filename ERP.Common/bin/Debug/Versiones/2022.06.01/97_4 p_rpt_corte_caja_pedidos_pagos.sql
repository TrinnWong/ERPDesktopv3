if exists (
	SELECT 1
	FROM sysobjects
	where name = 'p_rpt_corte_caja_pedidos_pagos'
)


DROP PROC p_rpt_corte_caja_pedidos_pagos
go
-- p_rpt_corte_caja_pedidos_pagos 3,'20221220'
CREATE PROC p_rpt_corte_caja_pedidos_pagos
@pSucursalId INT,
@pFecha DATETIME
AS

	SELECT 
		Cliente = CLI.Nombre,
		P.FechaPago, 
		P.Monto,
		PedidoFolio = po.Folio
	FROM doc_pagos P
	INNER JOIN doc_cargos C ON C.CargoId = P.CargoId AND
							C.SucursalId = @pSucursalId
	INNER JOIN doc_pedidos_orden PO ON PO.CargoId = C.CargoId
	left JOIN cat_clientes CLI ON CLI.ClienteId = C.ClienteId
	WHERE CONVERT(VARCHAR,p.FechaPago,112) = CONVERT(VARCHAR,@pFecha,112)

	