if exists(
	select 1
	from cat_web_configuracion
	where DiasEntregaAdicSPedido is null
	and DiasEntregaPedido is null
)
begin
	update cat_web_configuracion
	set DiasEntregaAdicSPedido = 7,
		DiasEntregaPedido = 6
end