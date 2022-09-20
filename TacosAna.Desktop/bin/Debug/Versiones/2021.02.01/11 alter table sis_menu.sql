IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Activo'
          AND Object_ID = Object_ID(N'sis_menu'))
BEGIN

	alter table sis_menu
	alter column Activo bit NOT NULL
		
END
go