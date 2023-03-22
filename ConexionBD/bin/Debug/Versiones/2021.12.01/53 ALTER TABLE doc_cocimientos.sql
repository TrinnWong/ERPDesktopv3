IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaHoraIni'
          AND Object_ID = Object_ID(N'doc_cocimientos'))
BEGIN

	
	ALTER TABLE doc_cocimientos
	ADD FechaHoraIni DateTime NULL


END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaHoraFin'
          AND Object_ID = Object_ID(N'doc_cocimientos'))
BEGIN

	
	ALTER TABLE doc_cocimientos
	ADD FechaHoraFin DateTime NULL


END
go