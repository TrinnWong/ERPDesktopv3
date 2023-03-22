if exists (
	select 1
	from sysobjects
	where name = 'p_doc_produccion_venta_salida'
)
drop proc p_doc_produccion_venta_salida
go
-- p_doc_produccion_venta_salida 5,''
create proc p_doc_produccion_venta_salida
@pVentaId INT,
@pError VARCHAR(100) OUT
AS
BEGIN

	SET @pError = ''
	DECLARE @MovimientoId INT,
		@MovimientoDetalleId INT
		
	BEGIN TRY

	BEGIN TRAN

	--oBTENER LA MATERIA PRIMA USADA EN LA VENTA
	SELECT 
		V.SucursalId,
		VD.ProductoId,
		VD.Cantidad,
		ProductoMateriaPrimaId = pb.ProductoBaseId,
		CantidadMateriaPrima = vd.Cantidad * pb.Cantidad,
		v.UsuarioCreacionId
	INTO #TMP_MOV_INV
	FROM doc_ventas v
	INNER JOIN doc_ventas_detalle vd on VD.VentaId = V.VentaId
	inner join cat_productos_base pb on pb.ProductoId = vd.ProductoId AND
								pb.GenerarSalidaVenta = 1
	WHERE v.VentaId = @pVentaId AND
	v.Activo = 1

	IF EXISTS (SELECT 1 FROM  #TMP_MOV_INV)
	BEGIN	

		SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
		FROM doc_inv_movimiento

		---GENERAR MOVIMIENTO INVENTARIO
		INSERT INTO doc_inv_movimiento(
				MovimientoId,	SucursalId,		FolioMovimiento,	TipoMovimientoId,		FechaMovimiento,
				HoraMovimiento,	Comentarios,	ImporteTotal,		Activo,					CreadoPor,
				CreadoEl,		Autorizado,		FechaAutoriza,		SucursalDestinoId,		AutorizadoPor,
				FechaCancelacion,ProductoCompraId,Consecutivo,		SucursalOrigenId,		VentaId,
				MovimientoRefId,Cancelado,		TipoMermaId
		)
		SELECT TOP 1 @MovimientoId, SucursalId, CAST(@MovimientoId AS VARCHAR),8 /*VENTA CAJA*/,dbo.fn_GetDateTimeServer(),
			CAST(dbo.fn_GetDateTimeServer() AS TIME),'Venta ID:' + cast(@pVentaId AS VARCHAR), 0, 1, UsuarioCreacionId,
			dbo.fn_GetDateTimeServer(),1,dbo.fn_GetDateTimeServer(),NULL,UsuarioCreacionId,
			NULL,NULL,CAST(@MovimientoId AS VARCHAR),SucursalId,@pVentaId,NULL,NULL,NULL
		FROM #TMP_MOV_INV

		SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0) + 1
		FROM doc_inv_movimiento_detalle

		INSERT INTO doc_inv_movimiento_detalle(
		MovimientoDetalleId,		MovimientoId,		ProductoId,		Consecutivo,		Cantidad,
		PrecioUnitario,				Importe,			Disponible,		CreadoPor,			CreadoEl,
		CostoUltimaCompra,			CostoPromedio,		ValCostoUltimaCompra,				ValCostoPromedio,
		ValorMovimiento,			Flete,				Comisiones,		SubTotal,			PrecioNeto
		)
		SELECT @MovimientoDetalleId,@MovimientoId,		ProductoMateriaPrimaId, CAST(@MovimientoDetalleId AS VARCHAR), CantidadMateriaPrima,
		0,							0,					0,				UsuarioCreacionId,	DBO.fn_GetDateTimeServer(),
		0,							0,					0,				0,
		0,							0,					0,				0,					0
		FROM #TMP_MOV_INV

	END

	COMMIT TRAN


	END TRY
	BEGIN CATCH

		ROLLBACK TRAN
		SELECT @pError = ERROR_MESSAGE() + '.ERROR LINE:'+CAST(ERROR_LINE() AS VARCHAR)

	END CATCH
END