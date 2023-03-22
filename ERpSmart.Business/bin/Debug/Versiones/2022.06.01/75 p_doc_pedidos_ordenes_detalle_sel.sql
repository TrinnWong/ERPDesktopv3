-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_doc_pedidos_ordenes_detalle_sel 10,'20220915','20220915',0
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
		CantidadPendienteBascula = CASE WHEN P.ProdVtaBascula = 1 THEN POD.Cantidad - ISNULL(SUM(BB.Cantidad),0) ELSE 0 END,
		po.TipoPedidoId,
		pop.FechaProgramada,
		pop.HoraProgramada,
		VentaId = ISNULL(v.VentaId,0),
		TipoCaja = ISNULL(TCAJA.Nombre,''),
		RequiereBascula = p.ProdVtaBascula,
		TotalDetalle = POD.Total
	FROM doc_pedidos_orden PO
	INNER JOIN doc_pedidos_orden_detalle POD ON POD.PedidoId = po.PedidoId AND
					PO.SucursalId = @pSucursalId AND
					ISNULL(POD.Cancelado,0) = 0
	INNER JOIN cat_productos P ON P.ProductoId = POD.ProductoId
	INNER JOIN cat_usuarios U ON U.IdUsuario = PO.CreadoPor
	LEFT JOIN cat_cajas CAJA ON CAJA.Clave = PO.CajaId 
	LEFT JOIN cat_tipos_cajas TCAJA ON TCAJA.TipoCajaId = CAJA.TipoCajaId
	LEFT JOIN doc_basculas_bitacora BB ON BB.PedidoDetalleId = POD.PedidoDetalleId
	LEFT JOIN doc_pedidos_orden_programacion POP ON POP.PedidoId = PO.PedidoId
	LEFT JOIN cat_clientes C ON C.ClienteId = PO.ClienteId
	LEFT JOIN doc_ventas V ON V.VentaId = PO.VentaId AND V.Activo = 1
	WHERE (CONVERT(VARCHAR,POP.FechaProgramada,112) <= CONVERT(VARCHAR,@pFechaProgFin,112) AND po.TipoPedidoId = @pTipoPedidoId) or
	(CONVERT(VARCHAR,PO.CreadoEl,112) <= CONVERT(VARCHAR,@pFechaProgFin,112) AND po.TipoPedidoId = @pTipoPedidoId)
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
		pop.HoraProgramada,
		v.VentaId,
		TCAJA.Nombre,
		p.ProdVtaBascula,
		POD.Total




