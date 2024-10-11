BEGIN TRAN

BEGIN TRY

delete doc_corte_caja_ventas
delete [dbo].[doc_pedidos_orden_detalle_impresion]
DELETE doc_pagos_cancelaciones
delete [dbo].[doc_pagos]
DELETE doc_retiros
DELETE doc_gastos
DELETE doc_corte_caja_denominaciones
DELETE doc_declaracion_fondo_inicial_detalle
DELETE doc_declaracion_fondo_inicial
delete doc_pedidos_orden_programacion
delete doc_pedidos_orden_ingre
delete doc_pedidos_orden_adicional
delete doc_pedidos_orden_detalle
delete doc_pedidos_orden_mesa
delete doc_pedidos_orden_mesero
delete doc_pedidos_orden

delete doc_sesiones_punto_venta
delete doc_corte_caja_egresos
delete doc_corte_caja_fp
delete doc_corte_caja

delete doc_ventas_detalle
delete doc_ventas_formas_pago
delete [dbo].[doc_inv_movimiento_detalle]
delete [dbo].[doc_inv_movimiento]
delete doc_reimpresion_ticket
delete doc_ventas 

	COMMIT TRAN

END TRY
BEGIN CATCH
	
	ROLLBACK TRAN
	select ERROR_MESSAGE()
END CATCH

