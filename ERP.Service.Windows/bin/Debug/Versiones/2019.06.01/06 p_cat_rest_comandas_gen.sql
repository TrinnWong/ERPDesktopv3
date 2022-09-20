if exists (
	select 1
	from sysobjects
	where name = 'p_cat_rest_comandas_gen'
)
drop proc p_cat_rest_comandas_gen
go
create proc p_cat_rest_comandas_gen
@pSucursalId int,
@pFolioInicio int,
@pFolioFin int,
@pCreadoPor int
as

	declare @folio int,
			@comandaId int

	select @folio = @pFolioInicio

	while @folio <= @pFolioFin
	begin

		select @comandaId = isnull(max(ComandaId),0)+1
		from cat_rest_comandas

		insert into cat_rest_comandas(
		ComandaId,		SucursalId,		Folio,		Disponible,
		CreadoPor,		CreadoEl
		)
			select @comandaId,@pSucursalId,@folio,1,
			@pCreadoPor,getdate()

		select 	@folio = @folio + 1
	end

	
