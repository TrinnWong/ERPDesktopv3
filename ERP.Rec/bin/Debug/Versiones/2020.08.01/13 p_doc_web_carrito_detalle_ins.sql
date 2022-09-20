

alter proc [dbo].[p_doc_web_carrito_detalle_ins]
@pId int,
@pIdDetalle	int out,
@puUID	varchar(50),
@pProductoId	int,
@pCantidad	decimal(10,2),
@pDescripcion	varchar(250),
@pPrecioUnitario	money,
@pImporte	money,
@pCargoDetalleId int
as

	begin Tran

	declare @impuestos money=0,
			@porcImpuestos decimal(5,2)=0,
			@precioUnitario money,
			@subtotal money=0


	select @porcImpuestos = isnull(sum(isnull(Porcentaje,0)),0)
	from cat_productos_impuestos p
	inner join cat_impuestos i on i.Clave = p.ImpuestoId
	where ProductoId = @pProductoId

	if(isnull(@pCargoDetalleId,0) =0)
	begin

		select @pPrecioUnitario = pp.Precio
		from cat_productos p
		inner join cat_productos_precios pp on pp.IdProducto = p.ProductoId
		where p.ProductoId = @pProductoId and
		pp.IdPrecio = 1--venta
	end
	set @pImporte = @pPrecioUnitario * @pCantidad


	if(@porcImpuestos > 0)
	begin
		set @impuestos = @pImporte / (1+(@porcImpuestos/100))
	end

	set @subtotal = @pImporte-@impuestos



	

	select @pIdDetalle = isnull(max(IdDetalle),0) + 1
	from doc_web_carrito_detalle

	insert into [dbo].[doc_web_carrito_detalle](
		IdDetalle,		uUID,			ProductoId,		Cantidad,
		Descripcion,	PrecioUnitario,	Importe,		CreadoEl,
		Impuestos,		Subtotal,Id,CargoDetalleId
	)
	values(
		@pIdDetalle,	@puUID,			@pProductoId,	@pCantidad,
		@pDescripcion,	@pPrecioUnitario,@pImporte,		getdate(),
		@Impuestos,		@Subtotal,@pId,@pCargoDetalleId
	)

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	--Actualizar totales
	update doc_web_carrito
	set Total = (select sum(importe) from [doc_web_carrito_detalle] where uUID = @puUID),
		SubTotal = (select sum(Subtotal) from [doc_web_carrito_detalle] where uUID = @puUID),
		Impuestos = (select sum(Impuestos) from [doc_web_carrito_detalle] where uUID = @puUID)
	where uUID = @puUID


	if @@error <> 0
	begin
		rollback tran
		goto fin
	end


	commit tran

	fin:


