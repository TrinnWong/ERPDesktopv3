if not exists (
select 1
from [cat_tipos_movimiento_inventario]
where TipoMovimientoInventarioId = 21
)
BEGIN

	insert into [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	select 21,'Insumo Interno Produccion',1,0,null

END
go

if not exists (
select 1
from [cat_tipos_movimiento_inventario]
where TipoMovimientoInventarioId = 22
)
BEGIN

	insert into [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	select 22,'Producto Produccion',1,1,null

END
go

if not exists (
select 1
from [cat_tipos_movimiento_inventario]
where TipoMovimientoInventarioId = 23
)
BEGIN

	insert into [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	select 23,'(Cancelación) Insumo Interno Produccion',1,1,null

END
go


if not exists (
select 1
from [cat_tipos_movimiento_inventario]
where TipoMovimientoInventarioId = 24
)
BEGIN

	insert into [cat_tipos_movimiento_inventario](
	TipoMovimientoInventarioId,Descripcion,Activo,EsEntrada,TipoMovimientoCancelacionId
	)
	select 24,'(Cancelación) Producto Produccion',1,0,null

END
go

if exists(
select 1
from [cat_tipos_movimiento_inventario]
where TipoMovimientoInventarioId = 21 and
TipoMovimientoCancelacionId is null
)
BEGIN

update [cat_tipos_movimiento_inventario]
set TipoMovimientoCancelacionId = 23
where TipoMovimientoInventarioId = 21

END


if exists (
SELECT 1
from [cat_tipos_movimiento_inventario]
where TipoMovimientoInventarioId = 22 and
TipoMovimientoCancelacionId is null
)
BEGIN

update [cat_tipos_movimiento_inventario]
set TipoMovimientoCancelacionId = 24
where TipoMovimientoInventarioId = 22

END