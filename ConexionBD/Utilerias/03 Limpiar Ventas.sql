BEGIN TRY
	BEGIN TRAN

	UPDATE doc_pedidos_orden
	SET VentaId = NULL

	UPDATE doc_inv_movimiento
	SET VentaId = NULL
	
	DELETE doc_reimpresion_ticket
	DELETE doc_corte_caja_egresos
	DELETE doc_declaracion_fondo_inicial_detalle
	DELETE doc_declaracion_fondo_inicial
	DELETE doc_corte_caja_denominaciones
	DELETE doc_corte_caja_fp
	DELETE doc_sesiones_punto_venta
	DELETE doc_corte_caja_ventas
	DELETE doc_corte_caja
	DELETE doc_ventas_formas_pago
	DELETE doc_pedidos_orden_programacion
	DELETE doc_pedidos_orden_detalle
	DELETE doc_pedidos_orden
	DELETE doc_ventas_detalle
	DELETE doc_ventas
	DELETE doc_inv_movimiento_detalle
	DELETE doc_inv_movimiento

	update cat_productos_existencias
	set ExistenciaTeorica = 0,
		Disponible = 0

	COMMIT TRAN

END TRY
BEGIN CATCH

	SELECT ERROR_MESSAGE()
	COMMIT TRAN
END CATCH