if exists (

	select 1
	from sysobjects
	where name = 'p_api_clientes_registro_demo'
)
drop proc p_api_clientes_registro_demo
go

-- p_api_clientes_registro_demo 'daniel','danw217@gmail.com',1,''
create proc p_api_clientes_registro_demo
@pNombre varchar(100),
@pEmail varchar(100),
@pGiro smallint,
@pError varchar(250) out

as

	

	declare @uuid Uniqueidentifier;
	declare @KeyClient varchar(150),
			@clienteId int,
			@notificacionId int

	set @uuid = NEWID();
	set @KeyClient = dbo.fn_ENCODE_TO_BASE64(@uuid)

	if exists(
		select 1
		from cat_clientes_contacto
		where ltrim(rtrim(email)) =ltrim(rtrim(@pEmail)) 
	)
	begin

		set @pError = 'Ya existe un usuario registrado con este EMAIL'
		return;
	end

	select @clienteId = isnull(max(ClienteId),0)+1
	from cat_clientes
	
	BEGIN TRY  

		begin tran

		insert into cat_clientes(ClienteId,Nombre,GiroNegocioId,Activo)
		select @clienteId,@pNombre,@pGiro,1

		insert into cat_clientes_contacto(ClienteId,Email,CreadoEl)
		select @clienteId,@pEmail,getdate()


		select @notificacionId = isnull(max(notificacionId),0) + 1
		from sis_notificaciones 

		insert into sis_notificaciones(
		NotificacionId,Para,Asunto,Mensaje,FechaProgramadaEnvio,Enviada,
		FechaEnvio,CreadoPor,CreadoEl,ModificadoPor,ModificadoEl,De
		)
		select @notificacionId,@pEmail,'Trinn - DEMO Punto de Venta',Html,getdate(),0,
		null,1,getdate(),null,null,'contacto@trinn.com.mx'
		from sis_correos_tipos 
		where TipoCorreoId = 1 --Registro DEMO

		commit tran
	END TRY  
	BEGIN CATCH  
		rollback tran
		set @pError = error_message()
		
	END CATCH  
 


	


	


