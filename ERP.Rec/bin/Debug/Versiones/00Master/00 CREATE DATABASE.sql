USE master;
GO

if not exists (
	select 1
	from sysdatabases
	where name = 'ERPProd_data'
)
begin
	CREATE DATABASE ERPProd_data
	ON
	( NAME = ERPProd_dat,  
		FILENAME = 'C:\ERP\ERPProd_data.mdf',
		SIZE = 10MB,
		MAXSIZE = 1000MB,
		FILEGROWTH = 5MB )  
	LOG ON
	( NAME = ERPProd_log,  
		FILENAME = 'C:\ERP\ERPProd_data.ldf',
		SIZE = 5MB,
		MAXSIZE = 25MB,
		FILEGROWTH = 5MB );

end
GO