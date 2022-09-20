if  exists(
	select 1
	from sysobjects
	where name = 'p_cliente_web_ins'
)
drop proc p_cliente_web_ins
go



create proc p_cliente_web_ins
@pClienteId int out,
@pEmail varchar(150),
@pPassword varchar(20),
@pNombre varchar(500)
as
BEGIN

	select @pClienteId = isnull(MAX(ClienteId),0) + 1
	from [cat_clientes]

	begin tran

	insert into [dbo].[cat_clientes](
		ClienteId,Nombre,Activo
	)
	select @pClienteId,@pNombre,1

	if @@ERROR <> 0
	begin
		rollback tran
		goto fin
	end

	insert into [dbo].[cat_clientes_web](
		ClienteId,Email,Password,CreadoEl
	)
	select @pClienteId,@pEmail,@pPassword,GETDATE()

	if @@ERROR <> 0
	begin
		rollback tran
		goto fin
	end


	commit tran

	fin:

END



GO



