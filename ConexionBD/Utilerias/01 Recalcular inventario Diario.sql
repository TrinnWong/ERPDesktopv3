BEGIN TRY


	DECLARE @SucursalId INT

	SELECT *
	INTO #TMP_SUCURSALES
	FROM cat_sucursales
	WHERE Clave = 4

	SELECT * FROM #TMP_SUCURSALES

	SELECT @SucursalId =MIN(Clave)
	from #TMP_SUCURSALES
	

	WHILE @SucursalId IS NOT NULL
	BEGIN

		SELECT @SucursalId

		exec p_doc_productos_existencias_diario_upd @SucursalId,1,''

		SELECT @SucursalId =MIN(Clave)
		from #TMP_SUCURSALES
		WHERE Clave > @SucursalId
	END


	DROP TABLE #TMP_SUCURSALES

END TRY
BEGIN CATCH

	SELECT ERROR_MESSAGE()

END CATCH