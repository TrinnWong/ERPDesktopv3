IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_chart_ventas_sucursal_meses_series'
)
DROP PROC p_chart_ventas_sucursal_meses_series
GO

-- p_rpt_ventas_sucursal_meses 0,6,1
create proc p_chart_ventas_sucursal_meses_series
@pSucursalId INT,
@pMesesAtras INT=6,
@pTipoResultado INT=1,
@pUsuarioId INT
AS

	

	CREATE TABLE #RESULT_VALUES(
		Mes VARCHAR(250),
		Sucursal1 VARCHAR(100),
		Sucursal2 VARCHAR(100),
		Sucursal3 VARCHAR(100),
		Sucursal4 VARCHAR(100),
		Sucursal5 VARCHAR(100),
		Sucursal6 VARCHAR(100),
		Sucursal7 VARCHAR(100),
		Sucursal8 VARCHAR(100),
		Sucursal9 VARCHAR(100),
		Sucursal10 VARCHAR(100),
		Sucursal11 VARCHAR(100),
		Sucursal12 VARCHAR(100),
		Sucursal13 VARCHAR(100),
		Sucursal14 VARCHAR(100),
		Sucursal15 VARCHAR(100),
		Sucursal16 VARCHAR(100),
		Sucursal17 VARCHAR(100),
		Sucursal18 VARCHAR(100),
		Sucursal19 VARCHAR(100),
		Sucursal20 VARCHAR(100),
		Sucursal21 VARCHAR(100),
		Sucursal22 VARCHAR(100),
		Sucursal23 VARCHAR(100),
		Sucursal24 VARCHAR(100),
		Sucursal25 VARCHAR(100),
		Sucursal26 VARCHAR(100),
		Sucursal27 VARCHAR(100),
		Sucursal28 VARCHAR(100),
		Sucursal29 VARCHAR(100),
		Sucursal30 VARCHAR(100),
		Sucursal31 VARCHAR(100),
		Sucursal32 VARCHAR(100),
		Sucursal33 VARCHAR(100),
		Sucursal34 VARCHAR(100),
		Sucursal35 VARCHAR(100),
		Sucursal36 VARCHAR(100),
		Sucursal37 VARCHAR(100),
		Sucursal38 VARCHAR(100),
		Sucursal39 VARCHAR(100),
		Sucursal40 VARCHAR(100)

	
	)

	declare @FechaInicio DATETIME=dateadd(MONTH,-@pMesesAtras,GETDATE())

	SET @FechaInicio = DATEADD(month, DATEDIFF(month, 0, @FechaInicio), 0)

	SELECT SucursalId= S.Clave,
		Sucursal = S.NombreSucursal,
		V.Fecha,
		v.TotalVenta
	INTO #TMP_VENTAS
	FROM cat_sucursales S
	
	INNER JOIN doc_ventas V ON V.SucursalId = S.Clave AND
						@pSucursalId IN(0,S.Clave) AND
						CAST(V.Fecha AS DATE) BETWEEN  CAST(@FechaInicio AS DATE) AND CAST(GETDATE() AS DATE)


	
	
	SELECT 
		
		i=IDENTITY(int,1,1),
		SucursalId = R.SucursalId,
		R.Sucursal
	INTO #TMP_SUCURSALES
	FROM #TMP_VENTAS R
	GROUP BY R.SucursalId,R.Sucursal
	ORDER BY R.Sucursal

	SELECT * FROM #TMP_SUCURSALES