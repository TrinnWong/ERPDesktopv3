USE master;
GO

if not exists (
	select 1
	from sysdatabases
	where name = 'erplocaldb'
)
begin
	CREATE DATABASE erplocaldb
	ON
	( NAME = erplocaldb,  
		FILENAME = 'C:\ERP\erplocaldb.mdf',
		SIZE = 10MB,
		MAXSIZE = 1000MB,
		FILEGROWTH = 5MB )  
	LOG ON
	( NAME = erplocaldb_log,  
		FILENAME = 'C:\ERP\erplocaldb.ldf',
		SIZE = 5MB,
		MAXSIZE = 25MB,
		FILEGROWTH = 5MB );

end
GO