IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_retiro_automatico_SiNo'
)
DROP PROC p_retiro_automatico_SiNo
GO

/*
DW 20230602
Procedimiento almacenado que verifica si es necesario avisar al cajero que es necesario realizar un retiro 
*/

-- p_retiro_automatico_SiNo 4,3
CREATE PROC p_retiro_automatico_SiNo
@pSucursalId INT,
@pCajaId INT
AS

	DECLARE @TotalVentas MONEY,
		@TotalRetiros MONEY,
		@CantidadRetiro MONEY

	IF(
		DBO.fnPreferenciaAplicaSiNo('PV-RetiroAutomatico',@pSucursalId) = 1
	)
	BEGIN

		
		SELECT @CantidadRetiro = CAST(ISNULL(dbo.fnGetPreferenciaValor('PV-RetiroAutomatico',@pSucursalId),'0') AS MONEY)
		

		IF(@CantidadRetiro > 0)
		BEGIN

			SELECT @TotalVentas = ISNULL(SUM(vfp.Cantidad),0)
			FROM doc_ventas V
			INNER JOIN doc_ventas_formas_pago VFP ON VFP.VentaId = v.VentaId AND
												VFP.FormaPagoId = 1 AND --EFECTIVO AND
												V.CajaId = @pCajaId AND
												V.Activo = 1
			WHERE CAST(V.Fecha AS DATE) = CAST(GETDATE() AS DATE) 

			SELECT @TotalRetiros = ISNULL(SUM(R.MontoRetiro),0)
			FROM doc_retiros R
			WHERE R.CajaId = @pCajaId AND
			CAST(R.FechaRetiro AS DATE) = CAST(getdate() AS DATE)

			
			IF((@TotalVentas - @TotalRetiros)>@CantidadRetiro)
			BEGIN
				SELECT AplicaSiNo = CAST(1 AS BIT),
				CantidadDisponibleRetiro = @TotalVentas - @TotalRetiros
			END
			ELSE
			BEGIN
				SELECT AplicaSiNo = CAST(0 AS BIT),
				CantidadDisponibleRetiro = @TotalVentas - @TotalRetiros
			END

		END
		ELSE
		BEGIN
			SELECT AplicaSiNo = CAST(0 AS BIT),
			CantidadDisponibleRetiro = 0
		END

	END
	ELSE
	BEGIN
		SELECT AplicaSiNo = 0,
			CantidadDisponibleRetiro = 0
	END


	
	