--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_pedido_orden_sel 17
ALTER PROC p_rpt_pedido_orden_sel
@pPedidoId INT
AS

	SELECT PO.PedidoId,
		Folio = 'P'+PO.Folio,
		Cliente = C.Nombre,
		Direccion = ISNULL(C.Calle,'') +' '+ isnull(C.NumeroExt,'') +' '+ ISNULL(C.NumeroInt,'') +' '+ ISNULL(C.Colonia,'') + ISNULL(C.Telefono,'') + '' + ISNULL(C.Telefono2,'') ,
		FechaPedido = PO.FechaApertura,		
		ClaveProducto = P.Clave,
		Producto = P.DescripcionCorta,
		Cantidad = POD.Cantidad,
		Precio = POD.PrecioUnitario,
		Total = POD.Total,
		Devolucion = POD.CantidadDevolucion
	FROM doc_pedidos_orden PO
	INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = PO.PedidoId
	INNER JOIN cat_clientes C ON C.ClienteId = PO.ClienteId
	INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	WHERE PO.PedidoId = @pPedidoId

