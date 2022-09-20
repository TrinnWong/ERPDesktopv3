if exists (
	select 1
	from sysobjects
	where name = 'p_cat_clientes_ins_upd'
)
drop proc p_cat_clientes_ins_upd
go
create proc p_cat_clientes_ins_upd
@pClienteId int out,
@pNombre varchar(500),
@pRFC varchar(15),
@pCalle varchar(100),
@pNumeroExt varchar(10),
@pNumeroInt varchar(10),
@pColonia varchar(50),
@pCodigoPostal varchar(5),
@pEstadoId int,
@pMunicipioId int,
@pPaisId int,
@pTelefono varchar(15),
@pTelefono2 varchar(15),
@pTipoClienteId int,
@pDiasCredito smallint,
@pLimiteCredito money,
@pAntecedenteId int,
@pCreditoDisponible money,
@pSaldoGlobal money,
@pActivo bit,
@pClienteEspecial bit,
@pClienteGral bit,
@pPrecioId tinyint,
@pGiroId int,
@pClienteAutoId int out,
@pModelo varchar(150),
@pColor varchar(50),
@pPlacas varchar(20),
@pObservaciones varchar(300)
as



	if isnull(@pClienteId,0) = 0
	begin


		select @pClienteId = isnull(max(ClienteId),0) + 1
		from cat_clientes


		insert into cat_clientes(
			ClienteId,	Nombre,		RFC,		Calle,		NumeroExt,		NumeroInt,
			Colonia,	CodigoPostal,EstadoId,	MunicipioId,PaisId,			Telefono,
			Telefono2,	TipoClienteId,DiasCredito,LimiteCredito,AntecedenteId,CreditoDisponible,
			SaldoGlobal,Activo,		ClienteEspecial,ClienteGral,PrecioId,	GiroId
		)
		select @pClienteId,@pNombre,@pRFC,@pCalle,@pNumeroExt,@pNumeroInt,
		@pColonia,	@pCodigoPostal,@pEstadoId,@pMunicipioId,@pPaisId,@pTelefono,
		@pTelefono2,@pTipoClienteId,@pDiasCredito,@pLimiteCredito,@pAntecedenteId,@pCreditoDisponible,
		@pSaldoGlobal,1,@pClienteEspecial,@pClienteGral,@pPrecioId,@pGiroId


	

	End
	Else
	Begin
		update cat_clientes
		set Nombre = @pNombre,		RFC=@pRFC,		Calle=@pCalle,		NumeroExt=@pNumeroExt,		
			NumeroInt=@pNumeroInt,	Colonia=@pColonia,	CodigoPostal=@pCodigoPostal,
			EstadoId=@pEstadoId,	
			MunicipioId=@pMunicipioId,
			PaisId=@pPaisId,			
			Telefono=@pTelefono,
			Telefono2=@pTelefono2,	
			TipoClienteId=@pTipoClienteId,
			DiasCredito=@pDiasCredito,
			LimiteCredito=@pLimiteCredito,
			AntecedenteId=@pAntecedenteId,
			CreditoDisponible=@pCreditoDisponible,
			SaldoGlobal=@pSaldoGlobal,
			Activo=@pActivo,		
			ClienteEspecial=@pClienteEspecial,
			ClienteGral=@pClienteGral,
			PrecioId=@pPrecioId,
			GiroId=@pGiroId
		Where ClienteId = @pClienteId
	End

	if isnull(@pClienteAutoId,0) = 0
	begin

		select @pClienteAutoId = isnull(max(ClienteAutoId),0) +1
		from cat_clientes_automovil

		insert into cat_clientes_automovil(
		ClienteAutoId,	ClienteId,	Modelo,	Color,
		Placas,				Observaciones,CreadoEl
		)
		select @pClienteAutoId,@pClienteId, @pModelo,@pColor,
		@pPlacas,@pObservaciones,GETDATE()
	end
	Else
	Begin
		Update cat_clientes_automovil
		set Modelo=@pModelo,	
		Color = @pColor,
		Placas = @pPlacas,				
		Observaciones = @pObservaciones
		where ClienteAutoId = @pClienteAutoId
	End


	


