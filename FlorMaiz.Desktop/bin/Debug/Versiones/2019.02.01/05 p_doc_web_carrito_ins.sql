
alter proc p_doc_web_carrito_ins
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
@pClienteId int out,
@pFechaEstimadaEntrega DateTime

as

	
	
	select @pid = case when isnull(max(id),0)  <= 100 then 1000 
					else isnull(max(id),0)  +1
					end
	from doc_web_carrito

	

	begin tran

	insert into [dbo].[doc_web_carrito](
		Id,
		uUID,						Email,		Total,			CreadoEl,
		EnvioCalle,	EnvioColonia,	EnvioCiudad,EnvioEstadoId,	EnvioCP,
		EnvioPersonaRecibe,EnvioTelefonoContacto,
		FechaEstimadaEntrega
	)
	values(
		@pid,
		@puUID,						@pEmail,		@pTotal,			getdate(),
		@pEnvioCalle,		@pEnvioColonia,			@pEnvioCiudad,		@pEnvioEstadoId,	@pEnvioCP,
		@pEnvioPersonaRecibe,@pEnvioTelefonoContacto,
		@pFechaEstimadaEntrega
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
		from cat_clientes

		insert into cat_clientes(ClienteId,Nombre,Activo,Telefono )	
		values(@pClienteId,@pEmail,1,@pEnvioTelefonoContacto)

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

	if @pClienteId > 0
	begin

		declare @ClienteDireccionId int

		select @ClienteDireccionId = isnull(ClienteDireccionId,0)
		from cat_clientes_direcciones 
		where ClienteId = @pClienteId and
		CodigoPostal = @pEnvioCP

		if(isnull(@ClienteDireccionId,0) = 0)
		begin
			select @ClienteDireccionId = isnull(max(ClienteDireccionId),0) +1

			from cat_clientes_direcciones
			--Generar Direcci�n
			insert into cat_clientes_direcciones(
				ClienteDireccionId,	ClienteId,	TipoDireccionId,	Calle,
				NumeroInterior,	NumeroExterior,	Colonia,			Ciudad,
				EstadoId,		PaisId,			CodigoPostal,		CreadoEl
			)
			select @ClienteDireccionId,@pClienteId,1,				@pEnvioCalle,
			'',					'',				@pEnvioColonia,		@pEnvioCiudad,
			@pEnvioEstadoId,	1,				@pEnvioCP,			getdate()
		end
		Else
		Begin

			update cat_clientes_direcciones
			set Calle = @pEnvioCalle,
				Colonia = @pEnvioColonia,
				Ciudad = @pEnvioCiudad,
				EstadoId = @pEnvioEstadoId,
				CodigoPostal = @pEnvioCP
			where ClienteDireccionId = @ClienteDireccionId
		End	


		
		if @@error <> 0
		begin
				rollback tran
				goto fin
		end
	end

	
	update [doc_web_carrito]
	set clienteId = @pClienteId
	where uUID = @puUID

	if @@error <> 0
	begin
			rollback tran
			goto fin
	end
	

	

	commit tran


	fin:


