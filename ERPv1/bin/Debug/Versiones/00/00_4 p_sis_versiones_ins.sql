if  exists(
	select 1
	from sysobjects
	where name = 'p_sis_versiones_ins'
)
drop proc p_sis_versiones_ins
go

-- p_sis_versiones_ins '2010.10.02,2010.10.03'
create proc p_sis_versiones_ins
@pVersiones varchar(5000)
as

	declare @versionId int

	select @versionId = isnull(max(VersionId),0) 
	from [sis_versiones]
	
	select *
	into #tmpVersiones
	from [dbo].fnSplitString(@pVersiones,',')

	insert into [dbo].[sis_versiones](VersionId,Nombre,CreadoEl,Completado,Intentos)
	select ROW_NUMBER() OVER(ORDER BY splitdata ASC)  + @versionId,splitdata,getdate(),0,0
	from #tmpVersiones
	where not exists (
		select 1
		from [sis_versiones]
		where Nombre = splitdata
	)
	order by splitdata