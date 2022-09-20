BEGIN TRY

ALTER TABLE doc_produccion_salida
DROP CONSTRAINT PK_doc_produccion_salida;



ALTER TABLE doc_produccion_entrada
DROP CONSTRAINT PK_doc_produccion_entrada;

END TRY
BEGIN CATCH
END CATCH