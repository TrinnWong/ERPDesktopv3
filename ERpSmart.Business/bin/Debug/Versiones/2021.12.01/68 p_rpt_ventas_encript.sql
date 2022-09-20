IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_ventas_encript'
)
DROP PROC p_rpt_ventas_encript
GO
-- p_rpt_ventas_encript 1,'20220101','20220401'
create PROC p_rpt_ventas_encript
@pSucursalId INT,
@pFechaDel DATETIME,
@pFechaAl DATETIME
AS

	SELECT VD.VentaDetalleId,
			Serie = V.Serie,
			Folio = V.Folio,
			Clave = P.Clave,
			Fecha = V.Fecha,
			Producto = P.DescripcionCorta,
			Sucursal = S.NombreSucursal,
			Cantidad = cast(VD.Cantidad AS varchar) ,
			Total = CAST(VD.Total AS VARCHAR)
	into #TMP_Resultado
	FROM doc_ventas_detalle VD
	INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
	INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
	INNER JOIN cat_sucursales S ON S.Clave = V.SucursalId
	WHERE V.Fecha BETWEEN @pFechaDel AND @pFechaAl AND
	V.SucursalId = @pSucursalId



	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'0','A'),
		Total = REPLACE(Total,'0','A')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'1','B'),
		Total = REPLACE(Total,'1','B')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'2','C'),
		Total = REPLACE(Total,'2','C')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'3','D'),
		Total = REPLACE(Total,'3','D')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'4','E'),
		Total = REPLACE(Total,'4','E')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'5','F'),
		Total = REPLACE(Total,'5','F')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'6','G'),
		Total = REPLACE(Total,'6','G')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'7','H'),
		Total = REPLACE(Total,'7','H')

	UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'8','I'),
		Total = REPLACE(Total,'8','I')

		UPDATE #TMP_Resultado
	SET Cantidad = REPLACE(Cantidad,'9','J'),
		Total = REPLACE(Total,'9','J')

	SELECT * FROM  #TMP_Resultado


