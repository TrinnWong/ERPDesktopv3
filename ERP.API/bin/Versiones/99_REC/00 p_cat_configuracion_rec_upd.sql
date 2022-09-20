
if exists(
	select * from master..sysdatabases
	where name = 'ERPTemp'
)
begin
	use ERPTemp

end
go


if exists (
	select 1
	from sysobjects
	where name = 'p_cat_configuracion_rec_upd'
)
drop proc p_cat_configuracion_rec_upd
go
create proc p_cat_configuracion_rec_upd
@pAplicaRec bit
as
Begin

	if exists(
		select 1
		from  sys.databases
		where name = 'ERPTemp'
	)
	begin
		update ERPTemp..cat_configuracion
		set TieneRec = @pAplicaRec
	end

	if exists(
		select 1
		from  sys.databases
		where name = 'ERPProd_data'
	)
	begin
		update ERPProd_data..cat_configuracion
		set TieneRec = @pAplicaRec
	end

END
go

if exists(
	select * from master..sysdatabases
	where name = 'ERPProd_data'
)
begin
	use ERPProd_data

end
go

	

	


	

