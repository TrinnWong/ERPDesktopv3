IF NOT EXISTS (
	SELECT 1
	FROM cat_estatus
)
BEGIN

INSERT INTO cat_estatus(EstatusId,Descripcion,CreadoEl)
VALUES(1,'PR Registrada',GETDATE())


INSERT INTO cat_estatus(EstatusId,Descripcion,CreadoEl)
VALUES(2,'PR En Aprobación',GETDATE())


INSERT INTO cat_estatus(EstatusId,Descripcion,CreadoEl)
VALUES(3,'PR Aprobada',GETDATE())



INSERT INTO cat_estatus(EstatusId,Descripcion,CreadoEl)
VALUES(4,'PR Cancelada',GETDATE())


INSERT INTO cat_estatus(EstatusId,Descripcion,CreadoEl)
VALUES(5,'PO Creada',GETDATE())


INSERT INTO cat_estatus(EstatusId,Descripcion,CreadoEl)
VALUES(6,'PO Cancelada',GETDATE())

END
