----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
if exists (
	select 1
	from sysobjects
	where name = 'p_venta_afecta_inventario'
)
drop proc p_venta_afecta_inventario
go
create Proc [dbo].[p_venta_afecta_inventario]
@pVentaId int,
@pSucursalId int
as

	DECLARE @movimientoid int,
			@consecutivo int,
			@movimientoDetalleId int,
			@folioVenta varchar(20)

	select @movimientoid = isnull(max(MovimientoId),0) + 1
	from doc_inv_movimiento

	select @consecutivo = isnull(max(Consecutivo),0) + 1
	from doc_inv_movimiento 
	where SucursalId = @pSucursalId and
	TipoMovimientoId = 8 --Venta en Caja

	select @folioVenta = isnull(Serie,'') + cast(@pVentaId as varchar)
	from [dbo].[cat_configuracion_ticket_venta]
	where sucursalId = @pSucursalId

	if(@folioVenta is null)
	begin
		select @folioVenta = cast(@pVentaId as varchar)
	end

	begin tran


	insert into doc_inv_movimiento(
		MovimientoId,		SucursalId,		FolioMovimiento,		TipoMovimientoId,		FechaMovimiento,
		HoraMovimiento,		Comentarios,	ImporteTotal,			Activo,					CreadoPor,
		CreadoEl,			Autorizado,		FechaAutoriza,			SucursalDestinoId,		AutorizadoPor,
		FechaCancelacion,	ProductoCompraId,Consecutivo,			SucursalOrigenId,		VentaId
	)
	select @movimientoid,	v.SucursalId,	@consecutivo,			8,						GETDATE(),
	getdate(),				@folioVenta,	v.TotalVenta,			1,						v.UsuarioCreacionId,
	getdate(),				1,				GETDATE(),				null,					UsuarioCreacionId,
	null,					null,			@consecutivo,			null,					v.VentaId
	from doc_ventas V
	where VentaId = @pVentaId AND
	V.Activo = 1

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	

	select @movimientoDetalleId = isnull(max(MovimientoDetalleId),0) + 1
	from doc_inv_movimiento_detalle

	--Detalle de movs sin productos base
	insert into doc_inv_movimiento_detalle(
		MovimientoDetalleId,	MovimientoId,	ProductoId,	Consecutivo,	Cantidad,
		PrecioUnitario,			Importe,		Disponible,	CreadoPor,		CreadoEl
	)
	select @movimientoDetalleId + ROW_NUMBER() OVER(ORDER BY vd.ProductoId ASC), @movimientoid, 
	vd.ProductoId,ROW_NUMBER() OVER(ORDER BY vd.ProductoId ASC),
	Cantidad = case when count(distinct pb.ProductoBaseId) > 0 then 0 else sum(vd.Cantidad) end,			VD.PrecioUnitario,			VD.Total,	
	--Si tiene productos base, insertar cantidad 0 ya que no se debe de inventariar, solo dejar registro		
	Disponible = case when count(distinct pb.ProductoBaseId) > 0 then 0 else sum(vd.Cantidad) end,
	v.UsuarioCreacionId,GETDATE()
	from doc_ventas V
	inner join doc_ventas_detalle vd on vd.VentaId = V.VentaId
	left join cat_productos_base pb on pb.ProductoId = vd.ProductoId
	where v.VentaId = @pVentaId AND
	V.Activo = 1
	group by vd.ProductoId,VD.PrecioUnitario,VD.Total,v.UsuarioCreacionId

	select @movimientoDetalleId = isnull(max(MovimientoDetalleId),0) + 1
	from doc_inv_movimiento_detalle

	--Detalle de movs con productos base
	insert into doc_inv_movimiento_detalle(
		MovimientoDetalleId,	MovimientoId,	ProductoId,	Consecutivo,	Cantidad,
		PrecioUnitario,			Importe,		Disponible,	CreadoPor,		CreadoEl
	)
	select @movimientoDetalleId + ROW_NUMBER() OVER(ORDER BY pb.ProductoBaseId ASC), @movimientoid, 
	pb.ProductoBaseId,ROW_NUMBER() OVER(ORDER BY pb.ProductoBaseId ASC),
	sum(pb.Cantidad),			0,			0,	
	--Si tiene productos base, insertar cantidad 0 ya que no se debe de inventariar, solo dejar registro		
	Cantidad = sum(pb.Cantidad),
	v.UsuarioCreacionId,GETDATE()
	from doc_ventas V
	inner join doc_ventas_detalle vd on vd.VentaId = V.VentaId
	inner join cat_productos_base pb on pb.ProductoId = vd.ProductoId
	where v.VentaId = @pVentaId AND
	V.Activo = 1
	group by pb.ProductoBaseId,v.UsuarioCreacionId




	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	--Si es producto con LIcencia, agregar la licencia al cliente
	if exists(
		select 1
		from doc_ventas_detalle vd
		inner join cat_productos_licencias pl on pl.ProductoId = vd.ProductoId
		where vd.VentaId = @pVentaId

	)
	begin
	
		exec p_doc_cliente_licencia_gen @pVentaId

	end

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	commit tran

	fin:
	

	












