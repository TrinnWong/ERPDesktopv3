




alter Proc [dbo].[p_productos_compra_inv]
@pProductoCompraId int,
@pSucursalId int,
@pCreadoPor int
as


	declare @pMovimientoId int,
			@pMovimientoDetId int,
			@consecutivo int,
			@sucursalId int,
			@fletePonderacion float,
			@comisionPonderacion float,
			@pFleteTotal float,
			@pComisionTotal float,
			@totMovs float


	



	select @pMovimientoId = isnull(max(MovimientoId),0) + 1
	from [doc_inv_movimiento]

	select @sucursalId = @pSucursalId
	--from [doc_inv_movimiento]
	--where ProductoCompraId = @pProductoCompraId

	select @consecutivo = @pProductoCompraId-- isnull(max(Consecutivo ),0) + 1
	--from [doc_inv_movimiento]
	--where SucursalId = @sucursalId and
	--TipoMovimientoId = 2

	select @pMovimientoDetId = isnull(max(MovimientoDetalleId),0) + 1
	from [doc_inv_movimiento_detalle]

	begin tran

	/***ACTUALIZAR FLETE Y COMISION PODENRADO**/
	select @pFleteTotal = isnull(Total,0)
	from doc_productos_compra_cargos 
	where ProductoCompraId = @pProductoCompraId and ProductoId = -2

	select @pComisionTotal =isnull(Total,0)
	from doc_productos_compra_cargos 
	where ProductoCompraId = @pProductoCompraId and ProductoId = -3

	select @totMovs = isnull(sum(Cantidad),0)
	from doc_productos_compra_detalle
	where ProductoCompraId = @pProductoCompraId

	

	set @fletePonderacion = @pFleteTotal / @totMovs
	set @comisionPonderacion = @pComisionTotal / @totMovs

	--declare @error varchar(50)
	--set @error = cast( @pFleteTotal as varchar)
	--RAISERROR (15600,-1,-1, @error);  

	UPDATE doc_productos_compra_detalle
	SET Flete = isnull(@fletePonderacion,0) * Cantidad,
	Comisiones = isnull(@comisionPonderacion,0) * Cantidad
	where ProductoCompraId = @pProductoCompraId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	insert into [dbo].[doc_inv_movimiento](
		MovimientoId,SucursalId,FolioMovimiento,TipoMovimientoId,FechaMovimiento,
		HoraMovimiento,Comentarios,ImporteTotal,Activo,CreadoPor,CreadoEl,
		Autorizado,FechaAutoriza,AutorizadoPor,ProductoCompraId,Consecutivo
	)
	select @pMovimientoId,SucursalId,@consecutivo,2,getdate(),
	cast(getdate() as time),'',Total,1,@pCreadoPor,getdate(),
	1,getdate(),@pCreadoPor,@pProductoCompraId,@consecutivo
	from [dbo].[doc_productos_compra]
	where ProductoCompraId = @pProductoCompraId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	insert into [dbo].[doc_inv_movimiento_detalle](
		MovimientoDetalleId,MovimientoId,ProductoId,Consecutivo,Cantidad,
		PrecioUnitario,Importe,Disponible,CreadoPor,CreadoEl,Flete,Comisiones
	)
	select @pMovimientoDetId + ROW_NUMBER() OVER(ORDER BY ProductoId ASC),@pMovimientoId,ProductoId,ROW_NUMBER() OVER(ORDER BY ProductoId ASC),Cantidad,
	PrecioUnitario,Total,Cantidad,@pCreadoPor,GETDATE(),Flete,Comisiones
	from [dbo].[doc_productos_compra_detalle]
	where ProductoCompraId = @pProductoCompraId

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	commit tran

	fin:



	

	









