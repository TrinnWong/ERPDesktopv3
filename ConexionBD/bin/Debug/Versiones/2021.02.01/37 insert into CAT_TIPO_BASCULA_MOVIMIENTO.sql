if not exists (
	select 1
	from cat_tipos_bascula_bitacora
)
BEGIN


	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 1 ,'Venta Mostrador',GETDATE()
	union
	SELECT 2,'Insumo para Produccion',GETDATE()
	union
	SELECT 3,'Salida Producto de Producción',GETDATE()

END