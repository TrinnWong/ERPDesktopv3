if not exists (
	SELECT 1
	FROM [doc_rango_gramos_venta]
)
BEGIN


INSERT INTO [dbo].[doc_rango_gramos_venta](RangoIniVenta,
RangoFinVenta,
EstablecerValor)
VALUES(.500,.510,.5)

INSERT INTO [dbo].[doc_rango_gramos_venta](RangoIniVenta,
RangoFinVenta,
EstablecerValor)
VALUES(1,1.010,1)


INSERT INTO [dbo].[doc_rango_gramos_venta](RangoIniVenta,
RangoFinVenta,
EstablecerValor)
VALUES(1.5,1.510,1.5)


INSERT INTO [dbo].[doc_rango_gramos_venta](RangoIniVenta,
RangoFinVenta,
EstablecerValor)
VALUES(2,2.010,2)

END