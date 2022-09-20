if exists (
	select 1
	from sysobjects
	where name = 'p_cat_configuracion_ins_upd'
)
drop proc p_cat_configuracion_ins_upd
go

create proc [dbo].[p_cat_configuracion_ins_upd]
@pConfiguradorId	int,
@pUnaFormaPago	bit,
@pMasUnaFormaPago	bit,
@pCosteoUEPS	bit,
@pCosteoPEPS	bit,
@pCosteoPromedio	bit,
@pAfectarInventarioLinea	bit,
@pAfectarInventarioManual	bit,
@pAfectarInventarioCorte	bit,
@pEnlazarPuntoVentaInventario	bit,
@pCajeroIncluirDetalleVenta	bit,
@pCajeroReqClaveSupervisor	bit,
@pSuperIncluirDetalleVenta	bit,
@pSuperIncluirVentaTel	bit,
@pSuperIncluirDetGastos	bit,
@pSuperEmail1	varchar(100),
@pSuperEmail2	varchar(100),
@pSuperEmail3	varchar(100),
@pSuperEmail4	varchar(100),
@pRetiroMontoEfec	money,
@pRetiroLectura	bit,
@pRetiroEscritura	bit,
@pNombreImpresora	varchar(200),
@pHardwareCaracterCajon	varchar(50),
@pEmpleadoPorcDescuento	decimal(5,2),
@pEmpleadoGlobal	bit,
@pEmpleadoIndividual	bit,
@pMontoImpresionTicket	money,
@pApartadoAnticipo1	money,
@pApartadoAnticipoHasta1	money,
@pApartadoAnticipo2	money,
@pApatadoAnticipoEnAdelante2	money,
@pPorcentajeUtilidadProd	decimal(5,2),
@pDesgloceMontoTicket	bit,
@pRetiroReqClaveSup bit,
@pCajDeclaracionFondoCorte bit,
@pSupDeclaracionFondoCorte bit,
@pvistaPreviaImpresion bit,
@pCajeroCorteDetGasto bit,
@pSupCorteDetGasto bit,
@pCajeroCorteCancelaciones bit,
@pSupCorteCancelaciones bit,
@pDevDiasVale	tinyint,
@pDevDiasGarantia	tinyint,
@pDevHorasGarantia	tinyint,
@pApartadoDiasLiq tinyint,
@pApartadoDiasProrroga tinyint,
@pReqClaveSupReimpresionTicketPV	bit,
@pReqClaveSupCancelaTicketPV	bit,
@pReqClaveSupGastosPV	bit,
@pReqClaveSupDevolucionPV	bit,
@pReqClaveSupApartadoPV	bit,
@pReqClaveSupExistenciaPV	bit,
@pCorteCajaIncluirExistencia bit,
@pImprimirTicketMediaCarta bit,
@pSolicitarComanda bit,
@pGiro varchar(50)
as

	update cat_configuracion
	set 
		UnaFormaPago = @pUnaFormaPago,
		MasUnaFormaPago=@pMasUnaFormaPago,
		CosteoUEPS=@pCosteoUEPS,
		CosteoPEPS=@pCosteoPEPS,
		CosteoPromedio=@pCosteoPromedio,
		AfectarInventarioLinea=@pAfectarInventarioLinea,
		AfectarInventarioManual=@pAfectarInventarioManual,
		AfectarInventarioCorte=@pAfectarInventarioCorte,
		EnlazarPuntoVentaInventario=@pEnlazarPuntoVentaInventario,
		CajeroIncluirDetalleVenta=@pCajeroIncluirDetalleVenta,
		CajeroReqClaveSupervisor=@pCajeroReqClaveSupervisor,
		SuperIncluirDetalleVenta=@pSuperIncluirDetalleVenta,
		SuperIncluirVentaTel=@pSuperIncluirVentaTel,
		SuperIncluirDetGastos=@pSuperIncluirDetGastos,
		SuperEmail1=@pSuperEmail1,
		SuperEmail2=@pSuperEmail2,
		SuperEmail3=@pSuperEmail3,
		SuperEmail4=@pSuperEmail4,
		RetiroMontoEfec=@pRetiroMontoEfec,
		RetiroLectura=@pRetiroLectura,
		RetiroEscritura=@pRetiroEscritura,
		NombreImpresora=@pNombreImpresora,
		HardwareCaracterCajon=@pHardwareCaracterCajon,
		EmpleadoPorcDescuento=@pEmpleadoPorcDescuento,
		EmpleadoGlobal=@pEmpleadoGlobal,
		EmpleadoIndividual=@pEmpleadoIndividual,
		MontoImpresionTicket=@pMontoImpresionTicket,
		ApartadoAnticipo1=@pApartadoAnticipo1,
		ApartadoAnticipoHasta1=@pApartadoAnticipoHasta1,
		ApartadoAnticipo2=@pApartadoAnticipo2,
		ApatadoAnticipoEnAdelante2=@pApatadoAnticipoEnAdelante2,
		PorcentajeUtilidadProd=@pPorcentajeUtilidadProd,
		DesgloceMontoTicket=@pDesgloceMontoTicket,
		RetiroReqClaveSup = @pRetiroReqClaveSup,
		CajDeclaracionFondoCorte = @pCajDeclaracionFondoCorte,
		SupDeclaracionFondoCorte = @pSupDeclaracionFondoCorte,
		vistaPreviaImpresion=@pvistaPreviaImpresion,
		CajeroCorteDetGasto = @pCajeroCorteDetGasto,
		SupCorteDetGasto = @pSupCorteDetGasto,
		CajeroCorteCancelaciones = @pCajeroCorteCancelaciones,
		SupCorteCancelaciones = @pSupCorteCancelaciones,
		DevDiasVale = @pDevDiasVale,
		DevDiasGarantia=@pDevDiasGarantia,
		DevHorasGarantia=@pDevHorasGarantia,
		ApartadoDiasLiq = @pApartadoDiasLiq,
		ApartadoDiasProrroga = @pApartadoDiasProrroga,
		ReqClaveSupReimpresionTicketPV	=@pReqClaveSupReimpresionTicketPV,
		ReqClaveSupCancelaTicketPV	=@pReqClaveSupCancelaTicketPV,
		ReqClaveSupGastosPV	=@pReqClaveSupGastosPV,
		ReqClaveSupDevolucionPV	=@pReqClaveSupDevolucionPV,
		ReqClaveSupApartadoPV	=@pReqClaveSupApartadoPV,
		ReqClaveSupExistenciaPV	=@pReqClaveSupExistenciaPV,
		CorteCajaIncluirExistencia = @pCorteCajaIncluirExistencia,
		ImprimirTicketMediaCarta = @pImprimirTicketMediaCarta,
		SolicitarComanda = @pSolicitarComanda,
		Giro = @pGiro
where ConfiguradorId = 1













