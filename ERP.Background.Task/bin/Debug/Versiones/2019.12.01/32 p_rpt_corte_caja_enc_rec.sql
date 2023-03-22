if  exists (
	select 1
	from sysobjects
	where name = 'p_rpt_corte_caja_enc_rec'
)
drop proc p_rpt_corte_caja_enc_rec
go

create proc p_rpt_corte_caja_enc_rec
@pCorteCajaId int
as

	exec ERPTemp..p_rpt_corte_caja_enc @pCorteCajaId