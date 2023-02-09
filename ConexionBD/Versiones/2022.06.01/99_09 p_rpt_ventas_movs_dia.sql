if  exists (
	select 1
	from sysobjects
	where name = 'p_rpt_ventas_movs_dia'
)
drop proc p_rpt_ventas_movs_dia
go

create proc p_rpt_ventas_movs_dia
@pSucursalId INT,
@pFechaIni DATETIME,
@pFechaFin DATETIME
AS


	declare @ValorPreferencia VARCHAR(500),
			@UsarOtros BIT=0
	
	--Obtener productos que se quieren agrupar
	SELECT @ValorPreferencia = ISNULL(pe.Valor,'')
	FROM sis_preferencias_empresa PE
	INNER JOIN cat_sucursales S ON S.Clave = @pSucursalId
	INNER JOIN sis_preferencias P ON P.Id = PE.PreferenciaId AND P.Preferencia = 'CorteCajaSubReporteVentasProd'
	WHERE PE.EmpresaId = S.Empresa


	SELECT ProductoId = splitdata
	INTO #TMP_IdProdcutos
	FROM [dbo].[fnSplitString](@ValorPreferencia,',')

	

	CREATE TABLE #TMP_RESULT(
		Id Int IDENTITY(1,1),
		Tipo VARCHAR(250) NULL,
		Detalle VARCHAR(250) NULL,
		Valor	FLOAT

	)

	

	--RESUMEN
	INSERT INTO #TMP_RESULT(Tipo,Detalle,Valor)
	SELECT 'RESUMEN VENTAS',
			'Ventas Totales',
			Sum(VD.Total)
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND
							CAST(V.Fecha AS DATE) BETWEEN CAST(@pFechaIni AS DATE) AND CAST(@pFechaFin AS DATE)
	LEFT JOIN #TMP_IdProdcutos TMP ON TMP.
	WHERE V.Activo = 1 
