if exists (
	select 1
	from sysobjects
	where name ='fnGetComandaMesas'
)
drop function dbo.fnGetComandaMesas
go
CREATE FUNCTION dbo.fnGetComandaMesas
(
	@pPedidoId int
)
RETURNS varchar(500)
AS
BEGIN
	
	DECLARE @Result varchar(500)=''


	select @Result = @Result +  m.Nombre + ','
	from doc_pedidos_orden_mesa pm
	inner join cat_rest_mesas m on m.MesaId = pm.MesaId
	where PedidoOrdenId = @pPedidoId


	

	-- Return the result of the function
	RETURN @Result

END
GO

