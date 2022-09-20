if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedido_promo_cm_ins'
)
drop proc p_doc_pedido_promo_cm_ins
go
create proc p_doc_pedido_promo_cm_ins
@pPedidoId int,
@pProductoId int,
@pPromocionCMId int,
@pImporte money,
@pCreadoPor int,
@pError varchar(250) out
as


	declare @PedidoDetalleId int,
			@porcimpuestos decimal(5,2),
			@impuestos decimal(5,2),
			@subTotal money


	BEGIN TRY  

		select @PedidoDetalleId = isnull(max(PedidoDetalleId),0)+1
		from doc_pedidos_orden_detalle		

		--CREAR PARTIDA DE DESCUENTO
		select @porcimpuestos = sum(i.Porcentaje) / 100
		from cat_productos_impuestos pim
		inner join cat_impuestos i on i.Clave = pim.ImpuestoId
		where ProductoId = @pProductoId


		set @impuestos = isnull((@porcimpuestos * @pImporte),0)

		set @subTotal = isnull(@pImporte,0) - isnull(@impuestos,0)
		
		insert into doc_pedidos_orden_detalle(
			PedidoDetalleId,	PedidoId,		ProductoId,	Cantidad,
			PrecioUnitario,		PorcDescuento,Descuento,	Impuestos,
			Notas,				Total,		CreadoPor,		CreadoEl,
			TasaIVA,			Impreso,	ComandaId,		Parallevar,
			Cancelado,			TipoDescuentoId,PromocionCMId
		)
		select @PedidoDetalleId,@pPedidoId,		p.ProductoId,1,
		(isnull(@pImporte,0) * -1),				0,			0,		(@impuestos*-1),
		'',					(@pImporte*-1),	@pCreadoPor,	GETDATE(),
		isnull(@porcimpuestos,0),			0,			null,			0,
		0,						1/*Promocion*/,@pPromocionCMId
		from cat_productos p
		where ProductoId = 0 and --Producto para promociones
		@pPromocionCMId > 0
		--Marcar el detalle con la promoción
		update doc_pedidos_orden_detalle
		set PromocionCMId = @pPromocionCMId
		where PedidoId = @pPedidoId and
		ProductoId = @pProductoId and
		PromocionCMId is null


	END TRY  
	BEGIN CATCH  
		set @pError = ERROR_MESSAGE()
	END CATCH  
	
	
	
	