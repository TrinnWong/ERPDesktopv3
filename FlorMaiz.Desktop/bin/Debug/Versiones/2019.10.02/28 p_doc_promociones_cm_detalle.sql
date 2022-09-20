if exists (
	select 1
	from sysobjects
	where name = 'p_doc_promociones_cm_detalle'
)
drop proc p_doc_promociones_cm_detalle
go

create proc p_doc_promociones_cm_detalle
@pPromocionCMDetId int out,
@pPromocionCMId int,
@pProductoId int,
@pCantidadCompraMinima decimal(10,2),
@pCantidadCobro decimal(10,2)
as

	if(isnull(@pPromocionCMDetId,0) = 0)
	begin

		select @pPromocionCMDetId = isnull(max(PromocionCMDetId),0) + 1
		from doc_promociones_cm_detalle

		insert into doc_promociones_cm_detalle(
			PromocionCMDetId,		PromocionCMId,		ProductoId,
			CantidadCompraMinima,	CantidadCobro,		CreadoEL
		)
		select @pPromocionCMDetId,	@pPromocionCMId,	@pProductoId,
		@pCantidadCompraMinima,	@pCantidadCobro,getdate()
	end
	Else
	Begin
		update doc_promociones_cm_detalle
		set ProductoId = @pProductoId,
			CantidadCompraMinima = @pCantidadCompraMinima,
			CantidadCobro = @pCantidadCobro
		where PromocionCMDetId = @pPromocionCMDetId
	End