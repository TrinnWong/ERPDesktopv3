


alter table doc_ventas_detalle
alter column Cantidad decimal(16,5) null
go


alter table cat_productos_existencias
alter column ExistenciaTeorica decimal(16,5) null
go

alter table cat_productos_existencias
alter column Disponible decimal(16,5) null
go

alter table doc_inv_movimiento_detalle
alter column Cantidad decimal(16,5) null
go

alter table doc_inv_movimiento_detalle
alter column Disponible decimal(16,5) null
go