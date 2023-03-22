IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ClaveSucursal'
          AND Object_ID = Object_ID(N'sis_cuenta'))
BEGIN

	
	ALTER TABLE sis_cuenta
	ADD ClaveSucursal int NULL


		
END
go