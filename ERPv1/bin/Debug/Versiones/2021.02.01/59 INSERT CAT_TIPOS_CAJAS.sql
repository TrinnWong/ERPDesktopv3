IF NOT EXISTS (
	SELECT 1
	FROM CAT_TIPOS_CAJAS	
)
BEGIN

	INSERT INTO cat_tipos_cajas(TipoCajaId,Nombre,Activo)
	SELECT 1,'En Sucursal',1
	UNION
	SELECT 2,'Movil',2

END