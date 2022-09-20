IF NOT EXISTS (
	SELECT 1
	FROM cat_denominaciones
	WHERE Valor IN (5,2,1,.50)
)
BEGIN

INSERT INTO cat_denominaciones(Clave,Descripcion,Valor,Orden,Estatus,Empresa,Sucursal)
VALUES(8,'5',5,8,1,null,null)

INSERT INTO cat_denominaciones(Clave,Descripcion,Valor,Orden,Estatus,Empresa,Sucursal)
VALUES(9,'2',2,9,1,null,null)

INSERT INTO cat_denominaciones(Clave,Descripcion,Valor,Orden,Estatus,Empresa,Sucursal)
VALUES(10,'1',1,10,1,null,null)


INSERT INTO cat_denominaciones(Clave,Descripcion,Valor,Orden,Estatus,Empresa,Sucursal)
VALUES(11,'.50',.50,11,1,null,null)

END