if not exists (
	select 1
	from cat_cargos_adicionales
	where CargoAdicionalId = 2
)
begin
	insert into  cat_cargos_adicionales(
		CargoAdicionalId,Descripcion,CreadoEl,CargoTipoId
	)
	select 2,'Envío Didi',getdate(),null


end
