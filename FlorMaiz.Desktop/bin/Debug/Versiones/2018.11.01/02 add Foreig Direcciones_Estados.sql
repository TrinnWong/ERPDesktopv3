
IF NOT EXISTS(
	SELECT
    * 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME ='FK_clientes_direcciones_Estados'
)
BEGIN
	ALTER TABLE cat_clientes_direcciones
	ADD CONSTRAINT FK_clientes_direcciones_Estados
	FOREIGN KEY (EstadoId) REFERENCES cat_estados(EstadoId)
END
go