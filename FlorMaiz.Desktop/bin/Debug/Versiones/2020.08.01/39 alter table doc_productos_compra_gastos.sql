IF NOT EXISTS (SELECT * 
  FROM sys.foreign_keys 
   WHERE object_id = OBJECT_ID(N'dbo.FK_Productos_compra_cargos_proveedores')
   AND parent_object_id = OBJECT_ID(N'dbo.doc_productos_compra_cargos')
)
begin

	ALTER TABLE doc_productos_compra_cargos
	ADD CONSTRAINT FK_Productos_compra_cargos_proveedores
	FOREIGN KEY (ProveedorId) REFERENCES cat_proveedores(ProveedorId); 

end