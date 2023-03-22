SELECT *
INTO #tmp_sucursales
FROM cat_sucursales

DECLARE @sucursalId INT

SELECT @sucursalId = MIN(Clave)
from #tmp_sucursales

WHILE @sucursalId IS NOT NULL
BEGIN

	EXEC p_doc_productos_existencias_diario_upd @sucursalId,1,''


	SELECT @sucursalId = MIN(Clave)
	from #tmp_sucursales
	WHERE Clave > @sucursalId
END