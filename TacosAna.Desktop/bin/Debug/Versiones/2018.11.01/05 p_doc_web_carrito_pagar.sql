if exists (
	select 1
	from sysobjects
	where name = 'p_doc_web_carrito_pagar'
)
drop proc p_doc_web_carrito_pagar
go

create proc p_doc_web_carrito_pagar
@pSucursalId int,
@pId int,
@pTransactionRef varchar(30),
@pMontoPagado varchar(20)
as

	declare @FechaEstimadaEntrega datetime
	declare @diasPedido tinyint=0
	declare @diasAdicPedido tinyint=0

	select @FechaEstimadaEntrega = GETDATE();

	select @diasAdicPedido = DiasEntregaAdicSPedido,
			@diasPedido = DiasEntregaPedido
	from cat_web_configuracion
	where SucursalId = @pSucursalId

	set @FechaEstimadaEntrega = DATEADD(day,@diasPedido,@FechaEstimadaEntrega)

	if exists (
		select 1
		from doc_web_carrito_detalle d
		inner join cat_productos prod on prod.ProductoId = d.ProductoId
		inner join cat_productos_existencias pe on pe.ProductoId = prod.ProductoId and
											pe.SucursalId = @pSucursalId and
											pe.ExistenciaTeorica <= 0 
		where d.Id = @pId 
	)
	begin
		set @FechaEstimadaEntrega = DATEADD(day,@diasAdicPedido,@FechaEstimadaEntrega)
	end

	update doc_web_carrito
	set Pagado = 1,
		FechaPago = GETDATE(),
		TransactionRef = @pTransactionRef,
		MontoPaypal = @pMontoPagado,
		FechaEstimadaEntrega = @FechaEstimadaEntrega
	where id = @pId