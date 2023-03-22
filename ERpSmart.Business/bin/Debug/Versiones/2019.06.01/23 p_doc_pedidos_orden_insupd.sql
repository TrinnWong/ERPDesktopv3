if  exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_insupd'
)
drop proc p_doc_pedidos_orden_insupd
go
create proc p_doc_pedidos_orden_insupd
@pPedidoId	int OUT,
@pSucursalId	int,
@pComandaId	int,
@pPorcDescuento	decimal(5,2),
@pSubtotal	money,
@pDescuento	money,
@pImpuestos	money,
@pTotal	money,
@pClienteId	int,
@pMotivoCancelacion	varchar(150),
@pActivo	bit,
@pCreadoPor	int,
@pPersonas tinyint,
@pFechaApertura Datetime,
@pFechaCierre Datetime
as


	set @pClienteId = case when @pClienteId =0 then null else @pClienteId end

	if not exists (
		select 1
		from [doc_pedidos_orden]
		where PedidoId = @pPedidoId
	)
	begin

		select @pPedidoId = isnull(max(PedidoId),0) + 1
		from [doc_pedidos_orden]
		
		insert into [dbo].[doc_pedidos_orden](
			PedidoId,SucursalId,ComandaId,PorcDescuento,Subtotal,Descuento,Impuestos,Total,ClienteId,MotivoCancelacion,
			Activo,CreadoEl,CreadoPor,Personas,FechaApertura,FechaCierre
		)
		select @pPedidoId,@pSucursalId,@pComandaId,@pPorcDescuento,@pSubtotal,@pDescuento,@pImpuestos,@pTotal,@pClienteId,@pMotivoCancelacion,
			1,getdate(),@pCreadoPor,@pPersonas,@pFechaApertura,@pFechaCierre
	end
	Else
	Begin
		update [doc_pedidos_orden]
		set ComandaId = @pComandaId,
			PorcDescuento = @pPorcDescuento,
			Subtotal = @pSubtotal,
			Descuento = @pDescuento,
			Impuestos = @pImpuestos,
			Total = @pTotal,
			ClienteId = @pClienteId,
			MotivoCancelacion = @pMotivoCancelacion,
			Activo = @pActivo,
			FechaCierre = @pFechaCierre,
			Personas = @pPersonas
		where PedidoId = @pPedidoId
			
	End

	