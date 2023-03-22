-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_rpt_corte_caja_general 3,'20221123'
ALTER PROC p_rpt_corte_caja_general
@pSucursalId INT,
@pFecha DateTime
AS

	DECLARE @montoVentasTelefono MONEY,
		@efectivo MONEY,
		@tdebito MONEY,
		@tcredito MONEY,
		@otros MONEY

	SELECT @efectivo = ISNULL(SUM(VFP.Cantidad),0)
	FROM doc_ventas_formas_pago VFP
	INNER JOIN doc_ventas V ON V.VentaId = VFP.VentaId AND VFP.FormaPagoId IN(1) AND
							V.Activo = 1 AND
							V.FechaCancelacion IS NULL
	WHERE CONVERT(VARCHAR,V.Fecha,112) = CONVERT(VARCHAR,@pFecha,112)  AND
	V.SucursalId = @pSucursalId

	SELECT @tdebito = ISNULL(SUM(VFP.Cantidad),0)
	FROM doc_ventas_formas_pago VFP
	INNER JOIN doc_ventas V ON V.VentaId = VFP.VentaId AND VFP.FormaPagoId IN(3) AND
							V.Activo = 1 AND
							V.FechaCancelacion IS NULL
	WHERE CONVERT(VARCHAR,V.Fecha,112) = CONVERT(VARCHAR,@pFecha,112)  AND
	V.SucursalId = @pSucursalId

	SELECT @tcredito = ISNULL(SUM(VFP.Cantidad),0)
	FROM doc_ventas_formas_pago VFP
	INNER JOIN doc_ventas V ON V.VentaId = VFP.VentaId AND VFP.FormaPagoId IN(2) AND
							V.Activo = 1 AND
							V.FechaCancelacion IS NULL
	WHERE CONVERT(VARCHAR,V.Fecha,112) = CONVERT(VARCHAR,@pFecha,112)  AND
	V.SucursalId = @pSucursalId

	SELECT @otros = ISNULL(SUM(VFP.Cantidad),0)
	FROM doc_ventas_formas_pago VFP
	INNER JOIN doc_ventas V ON V.VentaId = VFP.VentaId AND VFP.FormaPagoId NOT IN(1,2,3) AND
							V.Activo = 1 AND
							V.FechaCancelacion IS NULL
	WHERE CONVERT(VARCHAR,V.Fecha,112) = CONVERT(VARCHAR,@pFecha,112) AND
	V.SucursalId = @pSucursalId



	SELECT @montoVentasTelefono = SUM(V.TotalVenta)
	FROM doc_pedidos_orden PO
	INNER JOIN doc_ventas V ON V.VentaId = PO.VentaId
	WHERE PO.Activo = 1 AND
	CONVERT(VARCHAR,V.Fecha,112) = CONVERT(VARCHAR,@pFecha,112) AND
	PO.SucursalId = @pSucursalId AND
	PO.TipoPedidoId = 2--Pedido Telefono

	


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
			FPEfectivo = @efectivo,
			FPTCredito = @tcredito,
			FPTDebito = @tdebito,
			FPOtros = @otros
	FROM cat_sucursales SUC
	INNER JOIN cat_cajas C on C.Sucursal = SUC.Clave
	INNER JOIN doc_corte_caja CC ON CC.CajaId = C.Clave AND
							CONVERT(VARCHAR,CC.FechaCorte,112) = CONVERT(VARCHAR,@pFecha,112)
	INNER JOIN cat_usuarios U ON U.IdUsuario = CC.CreadoPor
	INNER JOIN doc_corte_caja_fp CFP ON CFP.CorteCajaId = CC.CorteCajaId AND
										CFP.FormaPagoId = 1--EFECTIVO
	INNER JOIN doc_declaracion_fondo_inicial FI ON FI.CorteCajaId = CC.CorteCajaId
	LEFT JOIN doc_corte_caja_denominaciones CCD ON CCD.CorteCajaId = CC.CorteCajaId
	LEFT JOIN doc_corte_caja_egresos G ON G.CorteCajaId = CC.CorteCajaId
	LEFT JOIN doc_corte_caja_fp CFP2 ON CFP2.CorteCajaId = CC.CorteCajaId AND
										CFP2.FormaPagoId <> 1--OTRAS
	LEFT JOIN doc_retiros R ON R.CajaId = CC.CajaId AND
								R.FechaRetiro  BETWEEN CC.FechaApertura AND CC.FechaCorte
	WHERE SUC.Clave = @pSucursalId
	GROUP BY CC.CorteCajaId, 
			C.Descripcion,
			CC.TotalCorte,
			U.NombreUsuario,
			FI.Total,
			G.Gastos,
			CC.FechaCorte

