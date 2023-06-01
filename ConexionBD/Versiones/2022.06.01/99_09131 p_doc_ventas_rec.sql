-- p_doc_ventas_rec 4,''
ALTER PROC p_doc_ventas_rec
@pSucursalId int,
@pError varchar(250)='' out
as

	declare @ventaId_i int,
			@porcRecortado decimal(14,2),
			@montoMaximoRec decimal (14,2),
			@montoRec_i decimal(14,2)=0,
			@lastFolio int,
			@esPrimero bit=1
	SET @pError = ''

	create table #tmpVentasRec( ventaId int)

	SELECT @porcRecortado = ISNULL(MAX(PorcRec),0)
	FROM cat_configuracion

	SELECT DISTINCT v.*
	INTO #tmpVentas
	FROM doc_ventas v
	INNER JOIN doc_ventas_formas_pago vfp on vfp.VentaId = v.VentaId AND
									vfp.FormaPagoId in (1) AND
									vfp.FormaPagoId not in (2,3,4,5)
	WHERE v.SucursalId = @pSucursalId AND
	NOT EXISTS (
		SELECT 1
		FROM doc_corte_caja_ventas CCV WHERE CCV.VentaId = v.VentaId
	)

	select * from #tmpVentas

	
	SELECT @montoMaximoRec =  (SUM(TotalVenta) * (@porcRecortado / 100))
	FROM #tmpVentas
	WHERE Activo = 1	
	

	SELECT @ventaId_i = MAX(VentaId)
	from #tmpVentas
	WHERE Activo = 1



	WHILE @ventaId_i IS NOT NULL
	BEGIN
		
		

		SELECT @montoRec_i = ISNULL(@montoRec_i,0) + ISNULL(TotalVenta,0)
		FROM #tmpVentas
		WHERE VentaId =@ventaId_i 

		IF @montoRec_i <= @montoMaximoRec OR @esPrimero = 1
		BEGIN
			INSERT INTO #tmpVentasRec(ventaId)
			VALUES(@ventaId_i)

			SELECT @ventaId_i = MAX(VentaId)
			FROM #tmpVentas
			WHERE VentaId < @ventaId_i AND
			Activo = 1

		END
		ELSE
		BEGIN
			SET @ventaId_i= NULL
		END

		SET @esPrimero = 0
		
	END

	

	BEGIN TRY

	BEGIN TRAN

	update doc_pedidos_orden
	SET VentaId = NULL,
	Activo = 0
	FROM doc_pedidos_orden PO
	INNER JOIN #tmpVentasRec TMP ON TMP.ventaId = PO.VentaId


	--ELIMINAR INVENTARIO
	DELETE doc_inv_movimiento_detalle
	FROM doc_inv_movimiento_detalle MD
	INNER JOIN doc_inv_movimiento M ON M.MovimientoId = MD.MovimientoId
	INNER JOIN #tmpVentasRec TMP ON TMP.ventaId = M.VentaId

	DELETE doc_inv_movimiento
	FROM doc_inv_movimiento M
	INNER JOIN #tmpVentasRec TMP ON TMP.ventaId = M.VentaId

	--VENTAS PAGOS doc_ventas_pagos
	DELETE doc_ventas_pagos
	FROM doc_ventas_pagos VP
	INNER JOIN #tmpVentasRec TMP ON TMP.ventaId = VP.VentaId


	--doc_ventas_formas_pago
	DELETE doc_ventas_formas_pago
	FROM doc_ventas_formas_pago VFP
	INNER JOIN #tmpVentasRec TMP ON TMP.ventaId = VFP.VentaId

	--doc_ventas_formas_pago_vale
	DELETE doc_ventas_formas_pago_vale
	FROM doc_ventas_formas_pago_vale FPV 
	INNER JOIN #tmpVentasRec TMP ON TMP.VentaId = FPV.VentaId

	--doc_ventas_detalle
	DELETE doc_ventas_detalle
	FROM doc_ventas_detalle VD 
	INNER JOIN #tmpVentasRec TMP ON TMP.VentaId = VD.VentaId

	DELETE doc_ventas
	FROM doc_ventas V
	INNER JOIN #tmpVentasRec TMP ON TMP.VentaId = V.VentaId

	--Refoliar
	SELECT @lastFolio = isnull(MAX(Folio),0)
	FROM doc_ventas V
	WHERE V.VentaId < (SELECT MIN(VentaId) FROM #tmpVentas	) AND
	V.SucursalId = @pSucursalId

	SELECT @ventaId_i = MIN(V.VentaId)
	FROM #tmpVentas TMP
	INNER JOIN doc_ventas V ON V.VentaId = TMP.VentaId

	WHILE @ventaId_i IS NOT NULL
	BEGIN
		
		SET @lastFolio = @lastFolio + 1

		UPDATE doc_ventas
		SET Folio = CAST(@lastFolio AS VARCHAR)
		where VentaId = @ventaId_i

		SELECT @ventaId_i = MIN(V.VentaId)
		FROM #tmpVentas TMP
		INNER JOIN doc_ventas V ON V.VentaId = TMP.VentaId 
		WHERE V.VentaId > @ventaId_i
	END

	COMMIT TRAN

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SET @pError = 'ERROR p_doc_ventas_rec LINEA:'+ CAST(ERROR_LINE() AS VARCHAR) + ' ' +ERROR_MESSAGE()
	END CATCH
	
	

