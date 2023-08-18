
ALTER PROC [dbo].[p_InsertarVentaFormaPago]
@pFormaPagoId int,
@pVentaId bigint,
@pCantidad money,		
@pUsuarioCreacionId INT,
@pDigitoVerificador VARCHAR(20)
AS

	SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

	declare @cambio money

	select @cambio = isnull(cambio,0)
	from doc_ventas
	where  ventaid = @pVentaId

	if(@pformapagoid = 1)
		set @pCantidad = @pCantidad - @cambio

	INSERT INTO [dbo].[doc_ventas_formas_pago](
		FormaPagoId,
		VentaId,
		Cantidad,
		FechaCreacion,
		UsuarioCreacionId,
		digitoVerificador
	)
	VALUES(
	@pFormaPagoId,
		@pVentaId,
		@pCantidad,
		GETDATE(),
		@pUsuarioCreacionId,
		@pDigitoVerificador
	)






