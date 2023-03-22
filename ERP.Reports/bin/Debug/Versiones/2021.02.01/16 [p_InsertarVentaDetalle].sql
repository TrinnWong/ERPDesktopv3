-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
alter PROC [dbo].[p_InsertarVentaDetalle]
@pVentaDetalleId bigint,
@pVentaId bigint,
@pProductoId int,
@pCantidad decimal(16,5) ,
@pDescripcion varchar(60),
@pPrecioUnitario money,
@pPorcDescuneto decimal(5,2),
@pDescuento money,
@pImpuestos money,
@pTotal money,
@pUsuarioCreacionId int,
@pFechaCreacion datetime,
@pTipoDescuentoId int,
@pPromocionCMId int,
@pCargoAdicionalId int,
@pCargoDetalleId int
AS

	declare @tasaIVA decimal(5,2),
			@subtotal money

	set @pPromocionCMId = case when @pPromocionCMId = 0 then null else @pPromocionCMId end

	select @tasaIVA = sum(i.Porcentaje)
	from [dbo].[cat_productos_impuestos] p
	inner join cat_impuestos i on i.Clave = p.ImpuestoId
	where p.ProductoId = @pProductoId and
	i.Clave = 1

	if(isnull(@tasaIVA,0) > 0)
	begin 
		
		set @pImpuestos = @pTotal * (@tasaIVA/100)
		set @subtotal = @pTotal - @pImpuestos
		
	end



	SELECT @pVentaDetalleId = ISNULL(MAX(VentaDetalleId),0) + 1
	FROM doc_ventas_detalle

	begin tran

	INSERT INTO dbo.doc_ventas_detalle
	(
	    VentaDetalleId,
	    VentaId,
	    ProductoId,
	    Cantidad,
	    PrecioUnitario,
	    PorcDescuneto,
	    Descuento,
	    Impuestos,
	    Total,
	    UsuarioCreacionId,
	    FechaCreacion,
		TasaIVA,
		TipoDescuentoId,
		PromocionCMId,
		CargoAdicionalId,
		CargoDetalleId,
		Descripcion
	)
	VALUES
	(	@pVentaDetalleId	,        -- VentaDetalleId - bigint
	    @pVentaId,        -- VentaId - bigint
	    @pProductoId,        -- ProductoId - int
	    @pCantidad,     -- Cantidad - decimal(14, 3)
	    @pPrecioUnitario,     -- PrecioUnitario - money
	    @pPorcDescuneto,     -- PorcDescuneto - decimal(5, 2)
	    @pDescuento,     -- Descuento - money
	    @pImpuestos,     -- Impuestos - money
	    @pTotal,     -- Total - money
	    @pUsuarioCreacionId,        -- UsuarioCreacionId - int
	    GETDATE(), -- FechaCreacion - datetime
		@tasaIVA,
		case when @pTipoDescuentoId = 0 then null else @pTipoDescuentoId end,
		@pPromocionCMId,
		@pCargoAdicionalId,
		@pCargoDetalleId,
		@pDescripcion
	    )


	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	update doc_ventas_detalle
	set Descuento = (PrecioUnitario * Cantidad) - Total
	where VentaDetalleId = @pVentaDetalleId

	
	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	update doc_ventas
	set TotalDescuento =(select sum(case when s1.ProductoId = 0 /*promociones*/ then (s1.Total*-1) else s1.Descuento end ) from doc_ventas_detalle s1 where s1.VentaId = @pVentaId )
	where ventaId = @pVentaId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	update doc_ventas
	set Impuestos =(select sum(s1.Impuestos) from doc_ventas_detalle s1 where s1.VentaId = @pVentaId )
	where ventaId = @pVentaId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	update doc_ventas
	set TotalVenta =(select sum(Total) from doc_ventas_detalle s1 where s1.VentaId = @pVentaId )
	where ventaId = @pVentaId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	update doc_ventas
	set SubTotal =TotalVenta - isnull(Impuestos,0)
	where ventaId = @pVentaId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end



	commit tran
	fin:













