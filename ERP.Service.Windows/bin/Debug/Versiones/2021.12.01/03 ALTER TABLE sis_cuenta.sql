IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'URLValidacion'
          AND Object_ID = Object_ID(N'sis_cuenta'))
BEGIN

	
	ALTER TABLE sis_cuenta
	ADD URLValidacion varchar(1000)


		
END
go