if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_cargos_calculo'
)
drop proc p_doc_pedidos_cargos_calculo
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create proc p_doc_pedidos_cargos_calculo
@pPedidoId int,
@pCreadoPor int
as

	declare @uberEats bit,
			@productoUberEats int,
			@totalVenta money,
			@porc decimal(5,2),
			@montoConf money,
			@montoProducto money,
			@productoDetalleId int,
			@sucursalId int

	select @uberEats = UberEats,
		@productoUberEats = pd.PedidoDetalleId,
		@totalVenta = p.Total	,
		@sucursalId = p.SucursalId
	from doc_pedidos_orden p
	left join doc_pedidos_orden_detalle pd on pd.PedidoId = p.PedidoId and
										pd.CargoAdicionalId = 1 and--UBER EATS
										isnull(pd.Cancelado,0) = 0
	
	where p.PedidoId = @pPedidoId
	
	if(@uberEats = 1)
	begin

		select @montoConf = ca.MontoFijo,
		@porc = ca.PorcentajeVenta
		from doc_cargo_adicional_config ca
		where ca.SucursalId = @sucursalId

		select @totalVenta = sum(Total)
		from doc_pedidos_orden_detalle
		where PedidoId = @pPedidoId and
		isnull(Cancelado,0) = 0 and
		ProductoId <> -1 --UBER EATS		

		set @montoProducto = case when isnull(@montoConf,0) > 0 then @montoConf
								  else @totalVenta * (isnull(@porc,0)/100)
							 end		
		
		if (isnull(@productoUberEats,0) = 0)
		begin

			

			select @productoDetalleId = isnull(max(PedidoDetalleId),0) + 1
			from doc_pedidos_orden_detalle

			insert into doc_pedidos_orden_detalle(
				PedidoDetalleId,	PedidoId,		ProductoId,	Cantidad,
				PrecioUnitario,		PorcDescuento,	Descuento,	Impuestos,
				Notas,				Total,			CreadoPor,	CreadoEl,
				TasaIVA,			Impreso,		ComandaId,	Parallevar,
				Cancelado,			TipoDescuentoId,PromocionCMId,CargoAdicionalId
			)
			select @productoDetalleId,@pPedidoId,	-1,			1,
			@montoProducto,			0,				0,			0,
			'',						@montoProducto,	@pCreadoPor,getdate(),
			0,						1,				null,		0,
			0,					null,				null,		1

		end
		else
		begin

			update doc_pedidos_orden_detalle
			set Total = isnull(@montoProducto,0),
				PrecioUnitario = isnull(@montoProducto,0)
			where PedidoDetalleId =  @productoUberEats
		end

		--Marcar toda la venta para llevar
		update doc_pedidos_orden_detalle
		set Parallevar = 1
		where PedidoId = @pPedidoId 
	end
	else
	begin

		update doc_pedidos_orden_detalle
		set Cancelado = 1
		where PedidoId = @pPedidoId and
		CargoAdicionalId = 1-- UBER EATS
	end


	

