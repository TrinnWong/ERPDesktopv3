

alter Proc [dbo].[p_doc_productos_compra_cancelar]
@pProductoCompraId int,
@pUsuarioId int
as

	begin tran

	update doc_productos_compra
	set FechaCancelacion = getdate(),
	CanceladoPor = @pUsuarioId,
	Activo = 0
	where  ProductoCompraId = @pProductoCompraId and
	FechaCancelacion is null

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	update [doc_inv_movimiento]
	set Cancelado = 1,
	FechaCancelacion = GETDATE(),
	Activo = 0
	from [doc_inv_movimiento]
	where  ProductoCompraId = @pProductoCompraId 

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	commit tran
	fin:









