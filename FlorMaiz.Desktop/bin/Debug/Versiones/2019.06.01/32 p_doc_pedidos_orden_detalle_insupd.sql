if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_detalle_insupd'
)
drop proc p_doc_pedidos_orden_detalle_insupd
go

create proc p_doc_pedidos_orden_detalle_insupd
@pPedidoDetalleId	int out,
@pPedidoId	int,
@pProductoId	int,
@pCantidad	decimal(14,3),
@pPrecioUnitario	money,
@pPorcDescuento	decimal(5,2),
@pDescuento	money,
@pImpuestos	money,
@pNotas	varchar(200),
@pTotal	money,
@pCreadoPor	int,
@pTasaIVA	decimal(5,2)
as

	select @pPrecioUnitario = Precio
	from  cat_productos_precios 
	where IdProducto = @pProductoId and
	IdPrecio = 1

	if not exists (
		select 1
		from [doc_pedidos_orden_detalle]
		where PedidoDetalleId = @pPedidoDetalleId
	)
	begin

		select @pPedidoDetalleId = isnull(max(PedidoDetalleId),0) + 1
		from [doc_pedidos_orden_detalle]

		insert into  [dbo].[doc_pedidos_orden_detalle](
			PedidoDetalleId,	PedidoId,	ProductoId,	Cantidad,	PrecioUnitario,	PorcDescuento,
			Descuento,			Impuestos,	Notas,		Total,		CreadoPor,		CreadoEl,
			TasaIVA,			Impreso
		)
		select @pPedidoDetalleId,	@pPedidoId,		@pProductoId,	@pCantidad,		@pPrecioUnitario,	@pPorcDescuento,
			@pDescuento,			@pImpuestos,	@pNotas,		@pCantidad * @pPrecioUnitario  ,		@pCreadoPor,		getdate(),
			@pTasaIVA,			0
	end
	Else
	Begin
		update [doc_pedidos_orden_detalle]
		set ProductoId=@pProductoId,
			Cantidad = @pCantidad,
			PrecioUnitario = @pPrecioUnitario,
			PorcDescuento = @pPorcDescuento,
			Descuento = @pDescuento,
			Impuestos = @pImpuestos,
			Notas = @pNotas,
			Total = @pTotal,
			TasaIVA = @pTasaIVA
		WHERE PedidoDetalleId = PedidoDetalleId

	End