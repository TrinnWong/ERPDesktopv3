IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_gramos_favor_contra'
)
DROP PROC p_rpt_gramos_favor_contra
GO
-- p_rpt_gramos_favor_contra 0,'20220401','20220430'
CREATE PROC p_rpt_gramos_favor_contra
@pSucursalId INT,
@pDel DATETIME,
@pAl DATETIME
AS

--GRAMOS A FAVOR
SELECT 	
	VD.VentaDetalleId,
	S.NombreSucursal,
	GramosFavorContra = Cantidad - Total/PrecioUnitario,
	Producto = P.DescripcionCorta,
	FolioVenta = V.Serie + V.Folio,
	Importe = VD.PrecioUnitario * (Cantidad - Total/PrecioUnitario)
FROM doc_ventas_detalle VD
INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId
INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
INNER JOIN cat_sucursales S ON S.Clave = V.SucursalId
WHERE (PrecioUnitario * Cantidad) <> Total AND
PrecioUnitario > 0 AND
@pSucursalId IN (S.Clave,0 )  AND
V.FechaCreacion BETWEEN @pDel AND @pAl