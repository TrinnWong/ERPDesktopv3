if not exists (
	select 1
	from cat_cargos_adicionales
)
begin

	insert into cat_cargos_adicionales(
		CargoAdicionalId,Descripcion,CreadoEl
	)
	select 1,'Envío UBER EATS',GETDATE()
end