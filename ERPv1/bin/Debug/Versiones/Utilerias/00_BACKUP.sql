use master

declare @name varchar(100)

if exists (
	select *
	from sys.databases
	where name = 'ERPProd_data'
)
begin

	set @name='C:\ERP_BACKUP\ERPProd_data'+
	convert(varchar,getdate(),112)+'_'+
	cast(DATEPART(HOUR,GETDATE()) as varchar)+'_'+
	cast(DATEPART(minute,GETDATE()) as varchar)+'_'+
	cast(DATEPART(SECOND,GETDATE()) as varchar)+'.bak'

	BACKUP DATABASE ERPProd_data 
	TO DISK = @name

end


if exists (
	select *
	from sys.databases
	where name = 'ERPTemp'
)
begin

	set @name='C:\ERP_BACKUP\ERPTemp'+
	convert(varchar,getdate(),112)+'_'+
	cast(DATEPART(HOUR,GETDATE()) as varchar)+'_'+
	cast(DATEPART(minute,GETDATE()) as varchar)+'_'+
	cast(DATEPART(SECOND,GETDATE()) as varchar)+'.bak'

	BACKUP DATABASE ERPTemp 
	TO DISK = @name

end



GO
