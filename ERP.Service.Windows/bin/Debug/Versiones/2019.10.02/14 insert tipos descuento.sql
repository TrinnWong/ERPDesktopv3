if not exists (
	select 1
	from cat_tipos_descuento
	where TipoDescuentoId in(1,2,3)
)
begin

INSERT INTO cat_tipos_descuento
select 1,'Descuento Promocion'
union
select 2,'Cortesía'
union
select 3,'Descuento Empleado'

end
go