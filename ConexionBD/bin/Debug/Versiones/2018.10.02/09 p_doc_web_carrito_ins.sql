if exists (
	select 1
	from sysobjects
	where name = 'p_doc_web_carrito_ins'
)
drop proc p_doc_web_carrito_ins
go
create proc p_doc_web_carrito_ins
@puUID	varchar(50),
@pid	int out,
@pEmail	varchar(50),
@pTotal	money,
@pEnvioCalle	varchar(250),
@pEnvioColonia	varchar(100),
@pEnvioCiudad	varchar(70),
@pEnvioEstadoId	int,
@pEnvioCP	varchar(5),
@pEnvioPersonaRecibe	varchar(250),
@pEnvioTelefonoContacto	varchar(20),
@pClienteId int out
as

	begin tran

	insert into [dbo].[doc_web_carrito](
		uUID,						Email,		Total,			CreadoEl,
		EnvioCalle,	EnvioColonia,	EnvioCiudad,EnvioEstadoId,	EnvioCP,
		EnvioPersonaRecibe,EnvioTelefonoContacto
	)
	values(
		@puUID,						@pEmail,		@pTotal,			getdate(),
		@pEnvioCalle,		@pEnvioColonia,			@pEnvioCiudad,		@pEnvioEstadoId,	@pEnvioCP,
		@pEnvioPersonaRecibe,@pEnvioTelefonoContacto
	)

	if @@error <> 0
	begin
		rollback tran
		goto fin
	end

	/****Generar un cliente*****/

	select @pClienteId = isnull(ClienteId,0)
	from cat_clientes_web
	where lower(rtrim(email)) = lower(rtrim(@pEmail))

	if @pClienteId = 0
	Begin
		/****Generar un id de cliente*******/

		select @pClienteId = isnull(max(ClienteId),0)+ 1
		from cat_clientes_web

		insert into cat_clientes(ClienteId,Nombre,Activo )	
		values(@pClienteId,@pEmail,1)

		if @@error <> 0
		begin
			rollback tran
			goto fin
		end

		insert into cat_clientes_web(ClienteId,Email,Password,CreadoEl)
		values(@pClienteId,@pEmail,'1234',getdate())

		if @@error <> 0
		begin
			rollback tran
			goto fin
		end

	End
	
	update [doc_web_carrito]
	set clienteId = @pClienteId
	where uUID = @puUID

	if @@error <> 0
	begin
			rollback tran
			goto fin
	end
	

	select @pid = Id
	from [doc_web_carrito]
	where uUID = @puUID


	commit tran


	fin: