if not exists (
	select 1
	from cat_paises
	where PaisId = 1
)
begin
	insert into cat_paises
	select 1,'MÉXICO'
end