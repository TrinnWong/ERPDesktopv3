if not exists (
	select 1
	from cat_cargos_tipos
)
begin

insert into cat_cargos_tipos(
	CargoTipoId,Tipo,CreadoEl
)
select 1,'Envío',getdate()

end
go