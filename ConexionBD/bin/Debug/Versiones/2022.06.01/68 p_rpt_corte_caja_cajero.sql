---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_corte_caja_cajero 1,'20220131',1
ALTER PROC p_rpt_corte_caja_cajero
@pSucursalId INT,
@pFecha DateTime,
@pCajaId INT
AS

	DECLARE @montoVentasTelefono MONEY,
		@corteCajaId INT

	SELECT @montoVentasTelefono = SUM(V.TotalVenta)
	FROM doc_pedidos_orden PO
	INNER JOIN doc_ventas V ON V.VentaId = PO.VentaId
	WHERE PO.Activo = 1 AND
	CONVERT(VARCHAR,V.Fecha,112) = CONVERT(VARCHAR,@pFecha,112) AND
	PO.SucursalId = @pSucursalId AND
	PO.TipoPedidoId = 2 AND--Pedido Telefono
	V.CajaId = @pCajaId

	SELECT @corteCajaId = MAX(CorteCajaId)
	FROM doc_corte_caja
	where CajaId = @pCajaId AND
	CONVERT(VARCHAR,FechaCorte,112) = CONVERT(VARCHAR,@pFecha,112)
	


	SELECT	
			CC.CorteCajaId,
			Caja = C.Descripcion,
			CC.TotalCorte,
			CC.FechaCorte,
			HoraCorte = CONVERT(varchar,CC.FechaCorte,108),
			U.NombreUsuario,
			Efectivo = ISNULL(SUM(CFP.Total),0),
			OtrasFP = ISNULL(SUM(CFP2.Total),0),
			FondoInicial = ISNULL(FI.Total,0),
			Gastos = ISNULL(G.Gastos,0),
			Retiros = ISNULL(SUM(R.MontoRetiro),0),
			TotalGlobal = ISNULL(SUM(CFP.Total),0) + ISNULL(SUM(CFP2.Total),0)  + ISNULL(FI.Total,0) -
						ISNULL(G.Gastos,0) -ISNULL(SUM(R.MontoRetiro),0),
			Ingresado = ISNULL(SUM(CCD.Total),0),
			Faltante = CASE WHEN ISNULL(SUM(CFP.Total),0) + ISNULL(SUM(CFP2.Total),0)  + ISNULL(FI.Total,0) -
						ISNULL(G.Gastos,0) -ISNULL(SUM(R.MontoRetiro),0) - ISNULL(SUM(CCD.Total),0) <= 0 THEN 0
						ELSE 
						ISNULL(SUM(CFP.Total),0) + ISNULL(SUM(CFP2.Total),0)  + ISNULL(FI.Total,0) -
						ISNULL(G.Gastos,0) -ISNULL(SUM(R.MontoRetiro),0) - ISNULL(SUM(CCD.Total),0)
						END,
			Excedente = CASE WHEN ISNULL(SUM(CFP.Total),0) + ISNULL(SUM(CFP2.Total),0)  + ISNULL(FI.Total,0) -
						ISNULL(G.Gastos,0) -ISNULL(SUM(R.MontoRetiro),0) - ISNULL(SUM(CCD.Total),0) >= 0 THEN 0
						ELSE 
						ISNULL(SUM(CFP.Total),0) + ISNULL(SUM(CFP2.Total),0)  + ISNULL(FI.Total,0) -
						ISNULL(G.Gastos,0) -ISNULL(SUM(R.MontoRetiro),0) - ISNULL(SUM(CCD.Total),0)
						END,
			VentasTelefono = ISNULL(@montoVentasTelefono,0),
			Denominacion = CAST(0 AS money),
			DenominacionValor = CAST(0 AS money),
			DenominacionCantidad = CAST(0 AS money)
	into #tmpResult
	FROM cat_sucursales SUC
	INNER JOIN cat_cajas C on C.Sucursal = SUC.Clave
	INNER JOIN doc_corte_caja CC ON CC.CajaId = C.Clave AND
							CONVERT(VARCHAR,CC.FechaCorte,112) = CONVERT(VARCHAR,@pFecha,112) and
							CC.CajaId = @pCajaId
	INNER JOIN cat_usuarios U ON U.IdUsuario = CC.CreadoPor
	INNER JOIN doc_corte_caja_fp CFP ON CFP.CorteCajaId = CC.CorteCajaId AND
										CFP.FormaPagoId = 1--EFECTIVO
	LEFT JOIN doc_declaracion_fondo_inicial FI ON FI.CorteCajaId = CC.CorteCajaId
	--LEFT JOIN doc_corte_caja_denominaciones ccdeno on ccdeno.CorteCajaId = CC.CorteCajaId
	--LEFT JOIN cat_denominaciones deno on deno.Clave = ccdeno.DenominacionId
	LEFT JOIN doc_corte_caja_denominaciones CCD ON CCD.CorteCajaId = CC.CorteCajaId
	LEFT JOIN doc_corte_caja_egresos G ON G.CorteCajaId = CC.CorteCajaId
	LEFT JOIN doc_corte_caja_fp CFP2 ON CFP2.CorteCajaId = CC.CorteCajaId AND
										CFP2.FormaPagoId <> 1--OTRAS
	LEFT JOIN doc_retiros R ON R.CajaId = CC.CajaId AND
								R.FechaRetiro  BETWEEN CC.FechaApertura AND CC.FechaCorte
	WHERE SUC.Clave = @pSucursalId and
	CC.CorteCajaId = @corteCajaId
	GROUP BY CC.CorteCajaId, 
			C.Descripcion,
			CC.TotalCorte,
			U.NombreUsuario,
			FI.Total,
			G.Gastos,
			CC.FechaCorte

	SELECT TMP.CorteCajaId,
			Caja ,
			TotalCorte,
			FechaCorte,
			HoraCorte ,
			NombreUsuario,
			Efectivo ,
			OtrasFP ,
			FondoInicial ,
			Gastos ,
			Retiros ,
			TotalGlobal ,
			Ingresado ,
			Faltante ,
			Excedente ,
			VentasTelefono,
			Denominacion = deno.Descripcion,
			DenominacionValor = CAST(ccDeno.Total AS MONEY),
			DenominacionCantidad = CAST(ccDeno.Cantidad AS MONEY)
	FROM #tmpResult TMP
	INNER JOIN doc_corte_caja_denominaciones ccDeno on ccDeno.CorteCajaId = TMP.CorteCajaId
	INNER JOIN cat_denominaciones deno on deno.Clave = ccDeno.DenominacionId

