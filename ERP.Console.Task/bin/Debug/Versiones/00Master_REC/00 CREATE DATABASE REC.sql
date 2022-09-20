USE master;
GO

if not exists (
	select 1
	from sysdatabases
	where name = 'ERPTemp'
)
begin
	CREATE DATABASE ERPTemp
	ON
	( NAME = ERPTemp_dat,  
		FILENAME = 'C:\ERP\ERPTemp.mdf',
		SIZE = 10MB,
		MAXSIZE = 1000MB,
		FILEGROWTH = 5MB )  
	LOG ON
	( NAME = ERPTemp_log,  
		FILENAME = 'C:\ERP\ERPTemp.ldf',
		SIZE = 5MB,
		MAXSIZE = 25MB,
		FILEGROWTH = 5MB );

end
GO