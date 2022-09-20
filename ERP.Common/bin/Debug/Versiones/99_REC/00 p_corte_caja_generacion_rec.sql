if  exists (
	select 1
	from sysobjects
	where name = 'p_corte_caja_generacion_rec'
)
drop proc p_corte_caja_generacion_rec
go

create proc [p_corte_caja_generacion_rec]
@pCajaId int,
@pUsuarioId int,
@pFechaHoraCorte datetime,
@pCorteCajaId int out,
@pPermitirCorteEnCero bit
as

	exec ERPTemp..[p_corte_caja_generacion] @pCajaId,@pUsuarioId,@pFechaHoraCorte,@pCorteCajaId out,@pPermitirCorteEnCero