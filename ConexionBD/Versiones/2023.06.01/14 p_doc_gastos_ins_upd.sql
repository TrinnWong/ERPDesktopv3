
if EXISTS (
	select 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_gastos_ins_upd'
)
DROP PROC p_doc_gastos_ins_upd
go
CREATE PROCEDURE [dbo].[p_doc_gastos_ins_upd]
    @GastoId INT OUT,
    @CentroCostoId INT,
    @GastoConceptoId INT,
    @Observaciones VARCHAR(300),
    @Monto MONEY,
    @CajaId INT=null,
   
    @CreadoPor INT,
    @SucursalId INT,
    @Activo BIT
AS
BEGIN

	if(ISNULL(@CentroCostoId,0) = 0 AND ISNULL(@GastoConceptoId,0) > 0)
	BEGIN
		SELECT @CentroCostoId = ClaveCentroCosto
		FROM cat_gastos
		WHERE Clave = @GastoConceptoId

	END


    IF ISNULL(@GastoId,0) = 0
    BEGIN

		SELECT @GastoId = ISNULL(MAX(GastoId),0)+1
		FROM doc_gastos

        -- Insertar nuevo registro
        INSERT INTO [dbo].[doc_gastos] (
			GastoId,
            [CentroCostoId],
            [GastoConceptoId],
            [Obervaciones],
            [Monto],
            [CajaId],
            [CreadoEl],
            [CreadoPor],
            [SucursalId],
            [Activo]
        )
        VALUES (
			@GastoId,
            @CentroCostoId,
            @GastoConceptoId,
            @Observaciones,
            @Monto,
            @CajaId,
            GETDATE(),
            @CreadoPor,
            @SucursalId,
            @Activo
        )

       
       
    END
    ELSE
    BEGIN
        -- Actualizar registro existente
        UPDATE [dbo].[doc_gastos]
        SET
            [CentroCostoId] = @CentroCostoId,
            [GastoConceptoId] = @GastoConceptoId,
            [Obervaciones] = @Observaciones,
            [Monto] = @Monto,
            [CajaId] = @CajaId,            
            [SucursalId] = @SucursalId,
            [Activo] = @Activo
        WHERE
            [GastoId] = @GastoId
    END
END
