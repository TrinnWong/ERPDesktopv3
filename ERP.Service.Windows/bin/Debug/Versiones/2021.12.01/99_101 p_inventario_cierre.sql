IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME= 'p_inventario_cierre'
)
DROP PROC p_inventario_cierre
GO
-- p_inventario_cierre 1,1
create proc p_inventario_cierre
@pSucursalId INT,
@pUsuarioId INT
AS
BEGIN

	DECLARE @MovimientoId INT,
		@Consecutivo INT,
		@MovimientoDetalleId INT

	SELECT IC.SucursalId,
			IC.ProductoId,
			Cantidad = SUM(IC.Cantidad)	
	INTO #TMP_INVENTARIO
	FROM doc_inventario_captura IC
	WHERE IC.SucursalId = @pSucursalId AND
	ISNULL(IC.Cerrado ,0)= 0
	GROUP BY IC.SucursalId,
	IC.ProductoId

	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0)+1
	from doc_inv_movimiento

	SELECT @Consecutivo =ISNULL(MAX(Consecutivo),0)+1
	from doc_inv_movimiento 
	WHERE TipoMovimientoId = 5--Ajuste por Entrada

	INSERT INTO doc_inv_movimiento(
	MovimientoId,	SucursalId,		FolioMovimiento,	TipoMovimientoId,
	FechaMovimiento,HoraMovimiento,	Comentarios,		ImporteTotal,
	Activo,			CreadoPor,		CreadoEl,			Autorizado,
	FechaAutoriza,	SucursalDestinoId,AutorizadoPor,	FechaCancelacion,
	ProductoCompraId,Consecutivo,	SucursalOrigenId,	VentaId,
	MovimientoRefId,Cancelado,TipoMermaId)

	SELECT @MovimientoId,@pSucursalId,CAST(@Consecutivo AS VARCHAR),5,
	GETDATE(),		GETDATE(),		'AJUSTE POR CIERRE DE INVENTARIO',0,
	1,				@pUsuarioId,	GETDATE(),			1,
	GETDATE(),		NULL,			@pUsuarioId,		NULL,
	NULL,			@Consecutivo,		NULL,			NULL,
	NULL,			NULL,		NULL
	

	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0)+1
	FROM doc_inv_movimiento_detalle

	INSERT INTO doc_inv_movimiento_detalle(
	MovimientoDetalleId,	MovimientoId,		ProductoId,		Consecutivo,
	Cantidad,				PrecioUnitario,		Importe,		Disponible,
	CreadoPor,				CreadoEl,			CostoUltimaCompra,CostoPromedio,	
	ValCostoUltimaCompra,	ValCostoPromedio,	ValorMovimiento, Flete,
	Comisiones,				SubTotal,			PrecioNeto
	)
	SELECT ROW_NUMBER() OVER(ORDER BY TMP.ProductoId ASC) +@MovimientoDetalleId,@MovimientoId,TMP.ProductoId,@Consecutivo,
	CASE WHEN ISNULL(PE.ExistenciaTeorica,0)  > 0 THEN ISNULL(PE.ExistenciaTeorica,0) * -1
		WHEN ISNULL(PE.ExistenciaTeorica,0)  < 0 THEN ISNULL(PE.ExistenciaTeorica,0) 
	END,					0,					0,			
	CASE WHEN ISNULL(PE.ExistenciaTeorica,0)  > 0 THEN ISNULL(PE.ExistenciaTeorica,0) * -1
		WHEN ISNULL(PE.ExistenciaTeorica,0)  < 0 THEN ISNULL(PE.ExistenciaTeorica,0) 
	END,--
	@pUsuarioId,			GETDATE(),			0,				0,
	0,						0,					0,				0,
	0,						0,					0
	FROM #TMP_INVENTARIO TMP
	LEFT JOIN cat_productos_existencias PE ON PE.ProductoId = TMP.ProductoId AND
									PE.SucursalId = @pSucursalId

	update doc_inv_movimiento
	SET Autorizado = 1,
		AutorizadoPor = @pUsuarioId,
		FechaAutoriza = GETDATE(),
		FechaMovimiento = GETDATE()
	where MovimientoId = @MovimientoId

	/*************************************************************************************************/
	SELECT @MovimientoId = ISNULL(MAX(MovimientoId),0)+1
	from doc_inv_movimiento

	SELECT @Consecutivo =ISNULL(MAX(Consecutivo),0)+1
	from doc_inv_movimiento 
	WHERE TipoMovimientoId = 5--Ajuste por Entrada

	INSERT INTO doc_inv_movimiento(
	MovimientoId,	SucursalId,		FolioMovimiento,	TipoMovimientoId,
	FechaMovimiento,HoraMovimiento,	Comentarios,		ImporteTotal,
	Activo,			CreadoPor,		CreadoEl,			Autorizado,
	FechaAutoriza,	SucursalDestinoId,AutorizadoPor,	FechaCancelacion,
	ProductoCompraId,Consecutivo,	SucursalOrigenId,	VentaId,
	MovimientoRefId,Cancelado,TipoMermaId)

	SELECT @MovimientoId,@pSucursalId,CAST(@Consecutivo AS VARCHAR),5,
	GETDATE(),		GETDATE(),		'AJUSTE POR CIERRE DE INVENTARIO',0,
	1,				@pUsuarioId,	GETDATE(),			1,
	GETDATE(),		NULL,			@pUsuarioId,		NULL,
	NULL,			@Consecutivo,		NULL,			NULL,
	NULL,			NULL,		NULL

	SELECT @MovimientoDetalleId = ISNULL(MAX(MovimientoDetalleId),0)+1
	FROM doc_inv_movimiento_detalle


	INSERT INTO doc_inv_movimiento_detalle(
	MovimientoDetalleId,	MovimientoId,		ProductoId,		Consecutivo,
	Cantidad,				PrecioUnitario,		Importe,		Disponible,
	CreadoPor,				CreadoEl,			CostoUltimaCompra,CostoPromedio,	
	ValCostoUltimaCompra,	ValCostoPromedio,	ValorMovimiento, Flete,
	Comisiones,				SubTotal,			PrecioNeto
	)
	SELECT ROW_NUMBER() OVER(ORDER BY TMP.ProductoId ASC) +@MovimientoDetalleId,@MovimientoId,TMP.ProductoId,@Consecutivo,
	ISNULL(TMP.Cantidad,0),					0,					0,			
	ISNULL(TMP.Cantidad,0),--
	@pUsuarioId,			GETDATE(),			0,				0,
	0,						0,					0,				0,
	0,						0,					0
	FROM #TMP_INVENTARIO TMP
	LEFT JOIN cat_productos_existencias PE ON PE.ProductoId = TMP.ProductoId AND
									PE.SucursalId = @pSucursalId

	update doc_inv_movimiento
	SET Autorizado = 1,
		AutorizadoPor = @pUsuarioId,
		FechaAutoriza = GETDATE(),
		FechaMovimiento = GETDATE()
	where MovimientoId = @MovimientoId

END