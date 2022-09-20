IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_ventas_detalle'
)
DROP PROC p_rpt_ventas_detalle
GO
-- p_rpt_ventas_detalle 1,'20220719','20220719'
CREATE PROC p_rpt_ventas_detalle
@pSucursalId INT,
@pFechaIni DATETIME,
@pFechaFin DATETIME
AS

SELECT	V.Folio,
		P.Clave, 
		Producto = P.Descripcion,
		FechaMovimiento = V.FechaCreacion,
		FormaPago = fp.Descripcion,
		Cantidad = vd.Cantidad,
		PrecioUnitario = vd.PrecioUnitario,
		Total = vd.Total,
		Usuario = u.NombreUsuario,
		Caja = c.Descripcion,
		Cancelada = case when v.Activo = 1 THEN 'NO' ELSE 'SI' END,
		FechaCancelacion = V.FechaCancelacion
FROM doc_ventas_detalle VD
INNER JOIN doc_ventas V ON V.VentaId = VD.VentaId AND v.SucursalId = @pSucursalId
INNER JOIN doc_ventas_formas_pago VFP ON VFP.VentaId = V.VentaId
INNER JOIN cat_formas_pago FP ON FP.FormaPagoId = VFP.FormaPagoId
INNER JOIN cat_productos P ON P.ProductoId = VD.ProductoId
inner join cat_usuarios u on u.IdUsuario = v.UsuarioCreacionId
INNER JOIN cat_cajas C ON C.Clave = v.CajaId
WHERE CONVERT(VARCHAR,v.FechaCreacion,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) and CONVERT(VARCHAR,@pFechaFin,112) 
ORDER BY v.FechaCreacion DESC