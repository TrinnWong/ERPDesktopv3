IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_corte_caja_venta_por_producto'
)
DROP PROC p_rpt_corte_caja_venta_por_producto
GO
-- p_rpt_corte_caja_venta_por_producto 1,22
CREATE PROC p_rpt_corte_caja_venta_por_producto
@EmpresaId INT,
@pCorteCajaId INT
AS

	declare @ValorPreferencia VARCHAR(500),
			@UsarOtros BIT=0
	

	SELECT @ValorPreferencia = ISNULL(pe.Valor,'')
	FROM sis_preferencias_empresa PE
	INNER JOIN sis_preferencias P ON P.Id = PE.PreferenciaId AND P.Preferencia = 'CorteCajaSubReporteVentasProd'
	WHERE PE.EmpresaId = @EmpresaId

	

	SELECT splitdata
	INTO #TMP_IdProdcutos
	FROM [dbo].[fnSplitString](@ValorPreferencia,',')

	

	IF NOT EXISTS (SELECT 1 FROM #TMP_IdProdcutos) SET @UsarOtros = 0 ELSE SET @UsarOtros = 1
	
	--INSERTAR PRODUCTOS QUE ESTÉN EN PREFERENCIA
	SELECT CC.CorteCajaId,
		P.Clave,
		Producto = P.Descripcion,
		Total = SUM(VD.Total)
	INTO #TMP_RESULT
	FROM doc_corte_caja CC
	INNER JOIN doc_corte_caja_ventas CCV ON CCV.CorteId = CC.CorteCajaId
	INNER JOIN doc_ventas V ON V.VentaId = CCV.VentaId AND V.FechaCancelacion IS NULL
	INNER JOIN doc_ventas_detalle VD ON VD.VentaId = V.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId	
	INNER JOIN #TMP_IdProdcutos TMP ON TMP.splitdata = P.ProductoId
	WHERE CC.CorteCajaId = @pCorteCajaId  
	GROUP BY CC.CorteCajaId,
		P.Clave,
		P.Descripcion

		

	IF (@UsarOtros = 0)
	BEGIN
		INSERT INTO #TMP_RESULT
		SELECT CC.CorteCajaId,
			P.Clave,
			Producto = P.Descripcion,
			Total = SUM(VD.Total)		
		FROM doc_corte_caja CC
		INNER JOIN doc_corte_caja_ventas CCV ON CCV.CorteId = CC.CorteCajaId
		INNER JOIN doc_ventas V ON V.VentaId = CCV.VentaId AND V.FechaCancelacion IS NULL
		INNER JOIN doc_ventas_detalle VD ON VD.VentaId = V.VentaId
		INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId		
		WHERE CC.CorteCajaId = @pCorteCajaId  
		GROUP BY CC.CorteCajaId,
			P.Clave,
			P.Descripcion
	END
	ELSE
	BEGIN
		INSERT INTO #TMP_RESULT
		SELECT CC.CorteCajaId,
			Clave = 'OTROS',
			Producto = 'OTROS',
			Total = SUM(VD.Total)		
		FROM doc_corte_caja CC
		INNER JOIN doc_corte_caja_ventas CCV ON CCV.CorteId = CC.CorteCajaId
		INNER JOIN doc_ventas V ON V.VentaId = CCV.VentaId AND V.FechaCancelacion IS NULL
		INNER JOIN doc_ventas_detalle VD ON VD.VentaId = V.VentaId
		INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId			
		WHERE CC.CorteCajaId = @pCorteCajaId   AND
		P.ProductoId NOT IN(
			SELECT splitdata
			FROM #TMP_IdProdcutos
		)
		GROUP BY CC.CorteCajaId
			
	END


	SELECT *
	FROM #TMP_RESULT





