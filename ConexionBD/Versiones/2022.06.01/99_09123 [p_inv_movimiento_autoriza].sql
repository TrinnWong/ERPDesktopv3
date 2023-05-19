----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER Proc [dbo].[p_inv_movimiento_autoriza]
@pMovimientoId int,
@pAutorizadoPor int
as

	update [dbo].[doc_inv_movimiento]
	set Autorizado = 1,
		AutorizadoPor = @pAutorizadoPor,
		FechaAutoriza = getdate(),
		Activo = 1
	where  MovimientoId = @pMovimientoId

	if exists(
		select 1
		from doc_inv_movimiento m
		where m.MovimientoId = @pMovimientoId and
		m.TipoMovimientoId = 7 --Entrada drecta
	)
	begin
		 exec p_Actualizar_CompraListaPrecios 0,@pMovimientoId,@pAutorizadoPor,''
	end




