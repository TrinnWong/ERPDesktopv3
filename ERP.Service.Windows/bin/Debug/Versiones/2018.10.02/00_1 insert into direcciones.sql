if not exists(
	select 1
	from [cat_tipos_direcciones]
	where TipoDireccionId = 1
)
begin
	insert into [dbo].[cat_tipos_direcciones]
	select 1,'Dirección de envío para compras',getdate()
END