
-- p_doc_ventas_cancelacion 4,1,'PRUEBA WEB'
ALTER PROC [dbo].[p_doc_ventas_cancelacion]
@pVentaId INT,
@pUsuarioCancelaId INT,
@pMotivoCancelacion varchar(250)
AS


	if exists (
		select 1
		from doc_apartados
		where ventaId = @pVentaId and
		ventaId > 0
	)
	begin
		RAISERROR (15600,-1,-1, '*************NO ES POSIBLE CANCELAR TICKETS DE APARTADOS************');
		return
	end

	if exists (
		select 1
		from doc_corte_caja_ventas cc
		inner join  doc_ventas v on v.ventaId = cc.VentaId
		where v.VentaId = @pVentaId 
	)
	begin 
		RAISERROR (15600,-1,-1, '*************NO ES POSIBLE CANCELAR EL TICKET, YA EST� DENTRO DE UN CORTE************');
		return
	end

	if exists (
		select 1
		from  doc_ventas v 
		inner join doc_devoluciones dev on dev.VentaId = v.ventaid
		where v.VentaId = @pVentaId 
	)
	begin 
		RAISERROR (15600,-1,-1, '*************NO ES POSIBLE CANCELAR EL TICKET, TIENE UNA DEVOLUCI�N************');
		return
	end


	begin tran

	UPDATE dbo.doc_ventas
	SET Activo = 0,
		FechaCancelacion = GETDATE(),
		UsuarioCancelacionId = @pUsuarioCancelaId,
		MotivoCancelacion = @pMotivoCancelacion
	WHERE VentaId = @pVentaId

	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	update doc_inv_movimiento 
	set FechaCancelacion = GETDATE(),
		Cancelado = 1
	from doc_inv_movimiento m
	inner join doc_ventas v on v.VentaId = m.VentaId
	where isnull(m.Cancelado,0) = 0 and
	v.VentaId = @pVentaId

	
	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	update doc_web_carrito
	set Pagado = 0,
		FechaPago = null
	where VentaId = @pVentaId

	
	if @@error <> 0
	begin 
		rollback tran
		goto fin
	end

	commit tran
	fin:





