if  exists (
	select 1
	from sysobjects
	where name = 'p_cat_configuracion_rest_ins_upd'
)
drop proc p_cat_configuracion_rest_ins_upd
go
create proc p_cat_configuracion_rest_ins_upd
@pId int,
@pSolicitarFolioComanda bit
as

	if not exists(
		select 1
		from [cat_configuracion_restaurante]
	)
	begin
		set @pId = 1

		insert into [cat_configuracion_restaurante]
		select @pId,@pSolicitarFolioComanda
		
	end
	Else
	begin

		update [cat_configuracion_restaurante]
		set SolicitarFolioComanda = @pSolicitarFolioComanda
	end
go