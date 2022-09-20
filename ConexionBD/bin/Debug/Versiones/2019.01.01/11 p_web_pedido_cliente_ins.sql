IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_web_pedido_cliente_ins'
)
DROP PROC p_web_pedido_cliente_ins
GO
-- p_web_pedido_cliente_ins 1,0,'Daniel','8331593533',1,1,1,0,'Monaco','2015','5','Arenal',1,29,'00000'
create proc p_web_pedido_cliente_ins
@pSucursalId int,
@pPedidoClienteId int out,
@pNombre varchar(100),
@pWhatsApp varchar(20),
@pProductoId int,
@pPedidoConfiguracionId int,
@pTieneCostoEnvio bit,
@pSitioEntregaId int,
@pCalle varchar(50),
@pNumeroExt varchar(10),
@pNumeroInt varchar(10),
@pColonia varchar(50),
@pMunicipioId int,
@pEstadoId int,
@pCP varchar(5)
as

	declare @pClienteId int,
		@pClienteDireccionId int,
		@municipio varchar(100),
		@pedidoClienteId int,
		@pedidoClienteDetId int

	set @pEstadoId = 29 --TAMAULIPAS
	set @pSitioEntregaId = case when isnull(@pSitioEntregaId,0) =0 then null else @pSitioEntregaId end

	set @pMunicipioId = case when @pMunicipioId = 0 then null else @pMunicipioId end

	select @municipio = Nombre
	from cat_municipios
	where MunicipioId = @pMunicipioId

	begin tran
	--Crear Cliente


	select @pClienteId = min(ClienteId)
	from cat_clientes
	where ltrim(Telefono) = ltrim(@pWhatsApp)
	Or LTRIM(Telefono2) = ltrim(@pWhatsApp)

	


	if(
		isnull(@pClienteId,0) = 0
	)
	begin

	

		select @pClienteId = isnull(max(ClienteId),0) + 1
		from cat_clientes



		insert into cat_clientes(
			ClienteId,	Nombre,		RFC,	Calle,
			NumeroExt,	NumeroInt,	Colonia,	CodigoPostal,
			EstadoId,	MunicipioId, PaisId,	Telefono,
			Telefono2,	TipoClienteId,	DiasCredito,	LimiteCredito,
			Activo		
		)
		select @pClienteId,@pNombre, '',	@pCalle,
		@pNumeroExt,	@pNumeroInt, @pColonia, @pCP,
		@pEstadoId,		@pMunicipioId, 1,		@pWhatsApp,
			@pWhatsApp,	null,		null,				null,
			1


		if @@error <> 0
		begin
			rollback tran
			goto fin
		end
	end

	--Crear dirección cliente
	if (
		isnull(@pSitioEntregaId,0) = 0 and
		isnull(@pCP,'') <> ''
	)
	begin
		
		select @pClienteDireccionId = MAX(ClienteDireccionId)
		from cat_clientes_direcciones
		where ClienteId = @pClienteId and
		CodigoPostal = @pCP

		IF(
			ISNULL(@pClienteDireccionId ,0) = 0
		)
		BEGIN

			SELECT @pClienteDireccionId = isnull(max(ClienteDireccionId),0) + 1
			FROM cat_clientes_direcciones

			INSERT INTO cat_clientes_direcciones(
				ClienteDireccionId,	ClienteId,			TipoDireccionId,
				Calle,				NumeroInterior,		NumeroExterior,
				Colonia,			Ciudad,				EstadoId,
				PaisId,				CodigoPostal,	CreadoEl
			)
			SELECT @pClienteDireccionId, @pClienteId, 1,
			@pCalle,		@pNumeroInt,				@pNumeroExt,
			@pColonia,			@municipio,				@pEstadoId,
			1,						@pCP,				getdate()

			if @@error <> 0
			begin
				rollback tran
				goto fin
			end
			
		END
		else
		begin
			update cat_clientes_direcciones
			set Calle = @pCalle,
				NumeroInterior = @pNumeroInt,
				NumeroExterior = @pNumeroExt,
				Colonia = @pColonia,
				Ciudad = @municipio,
				EstadoId = @pEstadoId,
				CodigoPostal = @pCP
			where ClienteDireccionId = @pClienteDireccionId

			if @@error <> 0
			begin
				rollback tran
				goto fin
			end
		end
	end

	--Crear Pedido
	select @pedidoClienteId = isnull(max(PedidoClienteId),0) + 1
	from doc_pedidos_clientes

	insert into doc_pedidos_clientes(
		PedidoClienteId,	SucursalId,		ClienteId,		EstatusId,	
		FechaEntregaProgramada,HoraEntrega,	FechaEntregaReal,SitioEntregaId,
		ClienteDireccionId,	CreadoEl,		PedidoConfiguracionId
	)
	select @pedidoClienteId,@pSucursalId,	@pClienteId,   1,
		FechaInicioEntrega,		null,		null,			@pSitioEntregaId,
		@pClienteDireccionId,GETDATE(),		@pPedidoConfiguracionId
	from doc_pedidos_configuracion
	where PedidoConfiguracionId = @pPedidoConfiguracionId
	
	if @@error <> 0
	begin
			rollback tran
			goto fin
	end

	select @pedidoClienteDetId = isnull(max(PedidoClienteDetId),0) + 1
	from doc_pedidos_clientes_det

	insert into doc_pedidos_clientes_det(
		PedidoClienteDetId,	PedidoClienteId,	ProductoId,	Cantidad,
		CreadoEl
	)
	select @pedidoClienteDetId,@pedidoClienteId,@pProductoId,1,
	GETDATE()

	if @@error <> 0
	begin
			rollback tran
			goto fin
	end




	commit tran
	
	fin:
	
