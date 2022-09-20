IF NOT EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'FK_doc_pedidos_orden_cat_usuarios'
)
BEGIN

ALTER TABLE doc_pedidos_orden
ADD CONSTRAINT FK_doc_pedidos_orden_cat_usuarios
FOREIGN KEY (CreadoPor) REFERENCES cat_usuarios(IdUsuario);

END
