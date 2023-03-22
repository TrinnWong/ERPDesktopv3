if exists (
	select 1
	from sysobjects
	where name = 'p_rpt_corte_caja_tpv_digito_previo'
)
drop proc [p_rpt_corte_caja_tpv_digito_previo]
go

-- p_rpt_corte_caja_tpv_digito 2
create proc [dbo].[p_rpt_corte_caja_tpv_digito_previo]
@pCorteCajaId int
as

	select Folio = v.Serie + v.Folio,
		Importe = vfp.Cantidad,
		Digito = digitoVerificador
	from [dbo].[doc_corte_caja_ventas_previo] ccv
	inner join [dbo].[doc_ventas_formas_pago] vfp on vfp.VentaId = ccv.VentaId
	inner join doc_ventas v on v.VentaId = vfp.VentaID
	where ccv.CorteId = @pCorteCajaId and
	vfp.FormaPagoId in (2,3)

	union


	select Folio = cast(v.ApartadoId as varchar),
		Importe = vfp.Cantidad,
		Digito = digitoVerificador
	from [dbo].[doc_corte_caja_apartados_pagos_previo] ccv
	inner join [dbo].[doc_apartados_formas_pago] vfp on vfp.ApartadoPagoId = ccv.ApartadoPagoId
	inner join doc_apartados_pagos ap on  ap.ApartadoPagoId = ccv.ApartadoPagoId
	inner join [dbo].[doc_apartados] v on v.ApartadoId = ap.ApartadoId
	where ccv.CorteCajaId = @pCorteCajaId and
	vfp.FormaPagoId in (2,3)

