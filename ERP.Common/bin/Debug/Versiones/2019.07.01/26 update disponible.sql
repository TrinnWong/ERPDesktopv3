update cat_productos_existencias
set Disponible = isnull(ExistenciaTeorica,0) - isnull(Apartado,0)