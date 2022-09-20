if exists (
	select 1
	from sysobjects
	where name = 'p_doc_promociones_cm_ins_upd'
)
drop proc p_doc_promociones_cm_ins_upd
go

create proc p_doc_promociones_cm_ins_upd
@pPromocionCMId int out,
@pSucursalId int,
@pNombrePromocion varchar(150),
@pFechaVigencia DateTime,
@pHoraVigencia time,
@pLunes bit,
@pMartes bit,
@pMiercoles bit,
@pJueves bit,
@pViernes  bit,
@pSabado bit,
@pDomingo bit,
@pCreadoPor int,
@pActivo bit
as


	if isnull(@pPromocionCMId,0) = 0
	begin
		select @pPromocionCMId = isnull(max(PromocionCMId),0) + 1
		from doc_promociones_cm

		insert into doc_promociones_cm(
			PromocionCMId,	SucursalId,		NombrePromocion,	FechaRegistro,
			FechaVigencia,	HoraVigencia,	Lunes,				Martes,			
			Miercoles,		Jueves,			Viernes,			Sabado,
			Domingo,		CreadoPor,		Activo
		)
		select @pPromocionCMId,	@pSucursalId,		@pNombrePromocion,	getdate(),
			@pFechaVigencia,	@pHoraVigencia,	@pLunes,				@pMartes,			
			@pMiercoles,		@pJueves,			@pViernes,			@pSabado,
			@pDomingo,		@pCreadoPor,		1
	end
	Else
	Begin
		update doc_promociones_cm
		set 
		NombrePromocion = @pNombrePromocion,		
		FechaVigencia = @pFechaVigencia,
		HoraVigencia = @pHoraVigencia,
		Lunes = @pLunes,
		Martes = @pMartes,
		Miercoles = @pMiercoles,
		Jueves = @pJueves,
		Viernes = @pViernes,
		Sabado = @pSabado,
		Domingo = @pDomingo,
		Activo = @pActivo
		where PromocionCMId = @pPromocionCMId
	End