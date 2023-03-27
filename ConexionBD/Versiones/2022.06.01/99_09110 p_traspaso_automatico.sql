IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_traspaso_automatico'
)
DROP PROC p_traspaso_automatico
GO
create proc p_traspaso_automatico
@pMovimientoOrigenId INT,
@pUsuarioId INT,
@pError VARCHAR(250) OUT
AS

	DECLARE @TipoMovimientoId INT,
		@TipoMovimientoNuevoId INT,
		@SucursalOrigenId INT,
		@SucursalDestinoId INT,
		@MovimientoId INT,
		@MovimientoDetalleId INT,
		@Consecutivo INT,
		@Generar BIT=0

	SET @pError = ''

	BEGIN TRY

	BEGIN TRAN

	SELECT @TipoMovimientoId = TipoMovimientoId
	FROM doc_inv_movimiento M 
	WHERE M.MovimientoId = @pMovimientoOrigenId

	--SI ES SALIDA POR TRASPASO
	IF(@TipoMovimientoId = 4)
	BEGIN

		SELECT @SucursalOrigenId = SucursalDestinoId
		FROM doc_inv_movimiento M 
		WHERE M.MovimientoId = @pMovimientoOrigenId

		SET @TipoMovimientoNuevoId = 3--entrada por traspaso

		SET @Generar = 1
	
	END



	--SI ES SALIDA POR TRASPASO (DEVOLUCIÓN)
	IF(@TipoMovimientoId = 30)
	BEGIN

		SELECT @SucursalOrigenId = SucursalDestinoId
		FROM doc_inv_movimiento M 
		WHERE M.MovimientoId = @pMovimientoOrigenId

		SET @TipoMovimientoNuevoId = 28--entrada por traspaso(Devolución)

		SET @Generar = 1
		
	END

	if @Generar = 1
	BEGIN

		SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0) + 1
		FROM doc_inv_movimiento

		SELECT @Consecutivo = ISNULL(MAX(Consecutivo),0) + 1
		FROM doc_inv_movimiento
		WHERE SucursalId = @SucursalOrigenId AND
		TipoMovimientoId = @TipoMovimientoNuevoId


		INSERT INTO doc_inv_movimiento(MovimientoId,	SucursalId,		FolioMovimiento,		TipoMovimientoId,
									FechaMovimiento,	HoraMovimiento,	Comentarios,			ImporteTotal,
									Activo,				CreadoPor,		CreadoEl,				Autorizado,
									FechaAutoriza,		SucursalDestinoId,	AutorizadoPor,		FechaCancelacion,
									ProductoCompraId,	Consecutivo,	SucursalOrigenId,		VentaId,
									MovimientoRefId,	Cancelado,		TipoMermaId,			FechaCorteExistencia)
		SELECT						@MovimientoId,		@SucursalOrigenId,		FolioMovimiento,		@TipoMovimientoNuevoId,
									GETDATE(),			GETDATE(),	Comentarios+'|TRASPASO GENERADO DE MENERA AUTMÁTICA',			ImporteTotal,
									1,					@pUsuarioId,		GETDATE(),				1,
									GETDATE(),			SucursalDestinoId,	AutorizadoPor,		FechaCancelacion,
									ProductoCompraId,	Consecutivo,	SucursalOrigenId,		VentaId,
									MovimientoRefId,	0,				TipoMermaId,			FechaCorteExistencia
		FROM doc_inv_movimiento
		WHERE MovimientoId = @pMovimientoOrigenId

		SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0)
		FROM doc_inv_movimiento_detalle

		INSERT INTO doc_inv_movimiento_detalle(
			MovimientoDetalleId,	MovimientoId,		ProductoId,			Consecutivo,
			Cantidad,				PrecioUnitario,		Importe,			Disponible,
			CreadoPor,				CreadoEl,			CostoUltimaCompra,	CostoPromedio,
			ValCostoUltimaCompra,	ValCostoPromedio,	ValorMovimiento,	Flete,
			Comisiones,				SubTotal,			PrecioNeto
		)
		SELECT @MovimientoDetalleId + ROW_NUMBER() OVER(ORDER BY MovimientoId DESC) ,	@MovimientoId,		ProductoId,			Consecutivo,
			Cantidad,				PrecioUnitario,		Importe,			Disponible,
			@pUsuarioId,				GETDATE(),			CostoUltimaCompra,	CostoPromedio,
			ValCostoUltimaCompra,	ValCostoPromedio,	ValorMovimiento,	Flete,
			Comisiones,				SubTotal,			PrecioNeto
		FROM doc_inv_movimiento_detalle
		WHERE MovimientoId = @pMovimientoOrigenId

	END

	COMMIT TRAN

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN

		SET @pError = ERROR_MESSAGE()
		
	END CATCH