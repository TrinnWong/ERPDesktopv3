-- [p_venta_afecta_inventario_corte] 0,''
ALTER PROC [dbo].[p_venta_afecta_inventario_corte]
@pSucursalId INT,
@pError VARCHAR(250) OUT
AS
BEGIN

DECLARE @VentaId INT,
	@SucursalId INT


	BEGIN TRY

		SELECT V.VentaId
		INTO #TMP_VENTA
		FROM doc_ventas V
		WHERE V.VentaId NOT IN (
			SELECT IM.VentaId
			FROM doc_inv_movimiento IM
			WHERE IM.VentaId = V.VentaId
		) 
		AND	@pSucursalId IN(0,V.SucursalId)
		AND V.FechaCancelacion IS NULL

		SELECT @VentaId = MIN(VentaId)
		FROM #TMP_VENTA TMP
	

		WHILE @VentaId IS NOT NULL
		BEGIN

			PRINT @VentaId
			BEGIN TRY

				--BEGIN TRAN

				SELECT @SucursalId = SucursalId
				FROM doc_ventas
				WHERE VentaId = @VentaId

				DECLARE @movimientoid int,
						@consecutivo int,
						@movimientoDetalleId int,
						@folioVenta varchar(20)

				select @movimientoid = isnull(max(MovimientoId),0) + 1
				from doc_inv_movimiento

				select @consecutivo = isnull(max(Consecutivo),0) + 1
				from doc_inv_movimiento 
				where SucursalId = @SucursalId and
				TipoMovimientoId = 8 --Venta en Caja

				select @folioVenta = isnull(Serie,'') + cast(@VentaId as varchar)
				from [dbo].[cat_configuracion_ticket_venta]
				where sucursalId = @SucursalId

				if(@folioVenta is null)
				begin
					select @folioVenta = cast(@VentaId as varchar)
				end


		
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
				where VentaId = @VentaId AND
				V.Activo = 1


				select @movimientoDetalleId = isnull(max(MovimientoDetalleId),0) + 1
				from doc_inv_movimiento_detalle

				--Detalle de movs sin productos base
				insert into doc_inv_movimiento_detalle(
					MovimientoDetalleId,	MovimientoId,	ProductoId,	Consecutivo,	Cantidad,
					PrecioUnitario,			Importe,		Disponible,	CreadoPor,		CreadoEl
				)
				select @movimientoDetalleId + ROW_NUMBER() OVER(ORDER BY vd.ProductoId ASC), @movimientoid, 
				vd.ProductoId,ROW_NUMBER() OVER(ORDER BY vd.ProductoId ASC),
				Cantidad = sum(vd.Cantidad),			VD.PrecioUnitario,			VD.Total,	
				--Si tiene productos base, insertar cantidad 0 ya que no se debe de inventariar, solo dejar registro		
				Disponible =  sum(vd.Cantidad),
				v.UsuarioCreacionId,GETDATE()
				from doc_ventas V
				inner join doc_ventas_detalle vd on vd.VentaId = V.VentaId
				--left join cat_productos_base pb on pb.ProductoId = vd.ProductoId
				where v.VentaId = @VentaId AND
				V.Activo = 1
				group by vd.ProductoId,VD.PrecioUnitario,VD.Total,v.UsuarioCreacionId

				select @movimientoDetalleId = isnull(max(MovimientoDetalleId),0) + 1
				from doc_inv_movimiento_detalle

				--COMMIT TRAN

			END TRY
			BEGIN CATCH
				--ROLLBACK TRAN
				SET @pError = ERROR_MESSAGE()
				return

			END CATCH


			SELECT @VentaId = MIN(VentaId)
			FROM #TMP_VENTA
			WHERE VentaId > @VentaId

		END

	
	

	END TRY
	BEGIN CATCH
	
		SET @pError = ERROR_MESSAGE()
		return
	END CATCH


END