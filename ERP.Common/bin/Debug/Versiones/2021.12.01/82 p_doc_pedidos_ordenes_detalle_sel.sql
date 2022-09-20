ALTER proc p_doc_pedidos_ordenes_detalle_sel
@pSucursalId INT,
@pFechaProgIni DateTime,
@pFechaProgFin DateTime,
@pTipoPedidoId INT
AS

	SELECT po.PedidoId,
		POD.PedidoDetalleId,
		POD.Cantidad,
		Clave = P.Clave,
		Descripcion = P.DescripcionCorta,
		PO.Total,
		POD.PrecioUnitario,
		P.ProductoId,
		RegistradoPor = U.NombreUsuario,
		Cliente = C.Nombre,
		CantidadPendienteBascula = POD.Cantidad - ISNULL(SUM(BB.Cantidad),0),
		po.TipoPedidoId,
		pop.FechaProgramada,
		pop.HoraProgramada
	FROM doc_pedidos_orden PO
	INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = po.PedidoId AND
					PO.SucursalId = @pSucursalId
	INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	INNER JOIN cat_usuarios U ON U.IdUsuario = PO.CreadoPor
	LEFT JOIN doc_basculas_bitacora BB ON BB.PedidoDetalleId = POD.PedidoDetalleId
	LEFT JOIN doc_pedidos_orden_programacion POP ON POP.PedidoId = PO.PedidoId
	LEFT JOIN cat_clientes C ON C.ClienteId = PO.ClienteId
	WHERE (CONVERT(VARCHAR,POP.FechaProgramada,112) <= CONVERT(VARCHAR,@pFechaProgFin,112) AND po.TipoPedidoId = @pTipoPedidoId)
	OR @pTipoPedidoId = 0
	GROUP BY po.PedidoId,
		POD.PedidoDetalleId,
		POD.Cantidad,
		P.Clave,
		P.DescripcionCorta,
		PO.Total,
		POD.PrecioUnitario,
		P.ProductoId,
		U.NombreUsuario,
		C.Nombre,
		po.TipoPedidoId,
		pop.FechaProgramada,
		pop.HoraProgramada


