if exists (
	select 1
	from sysobjects
	where name = 'p_cat_configuracion_ini_exis'
)
drop proc p_cat_configuracion_ini_exis
go
create proc p_cat_configuracion_ini_exis
@pSucursalId int
as

	declare @exis bit = 1,
			@productosCount int = 0,
			@ticketConfig bit = 0

	select @productosCount = isnull(count(distinct p.Clave),0)
	from cat_productos p
	where p.ProductoId > 0

	select @ticketConfig = 1
	from cat_configuracion_ticket_venta
	where SucursalId = @pSucursalId and
	(
		rtrim(isnull(TextoCabecera1,'')) <> '' OR
		rtrim(isnull(TextoCabecera2,'')) <> '' OR
		rtrim(isnull(TextoPie,'')) <> ''
	)

	set @exis =case when @productosCount = 0 OR @ticketConfig = 0 then 0 else 2 end

	select Existe = @exis
	


	

