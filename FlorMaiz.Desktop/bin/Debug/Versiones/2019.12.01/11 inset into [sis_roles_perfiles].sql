
if not exists (
	select 1
	from [sis_roles_perfiles]
)
begin

	--Gerente
	insert into [dbo].[sis_roles_perfiles](RolId,PerfilId,CreadoEl)
	select 2,PerfilId,getdate()
	from sis_perfiles

	--Cajero sin priv. para corte
	insert into [dbo].[sis_roles_perfiles](RolId,PerfilId,CreadoEl)
	select 3,2,getdate()
	union
	select 3,3,getdate()
	union
	select 3,4,getdate()
	union
	select 3,5,getdate()

	--Cajero sin priv. para corte
	insert into [dbo].[sis_roles_perfiles](RolId,PerfilId,CreadoEl)
	select 4,2,getdate()
	union
	select 4,3,getdate()
	union
	select 4,4,getdate()
	union
	select 4,5,getdate()
	union
	select 4,7,getdate()

	--Comandero
	insert into [dbo].[sis_roles_perfiles](RolId,PerfilId,CreadoEl)
	select 5,1,getdate()
	
	

end