
-- p_api_clientes_registro_demo 'daniel','danw217@gmail.com',1,''
alter proc p_api_clientes_registro_demo
@pNombre varchar(100),
@pEmail varchar(100),
@pGiro smallint,
@pError varchar(250) out,
@pProductosId varchar(100)

as

	
	set @pProductosId = '1,2'
	declare @uuid Uniqueidentifier;
	declare @KeyClient varchar(150),
			@clienteId int,
			@notificacionId int

	select splitdata 
	into #tmpProductos
	from[dbo].[fnSplitString](@pProductosId,',')

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

		insert into cat_clientes(ClienteId,Nombre,GiroNegocioId,Activo,KeyClient)
		select @clienteId,@pNombre,@pGiro,1,@KeyClient

		insert into cat_clientes_contacto(ClienteId,Email,CreadoEl)
		select @clienteId,@pEmail,getdate()

		declare  @pClienteLicenciaId int

		select @pClienteLicenciaId = isnull(max(ClienteLicenciaId),0) + 1
		from doc_clientes_licencias

		insert into doc_clientes_licencias(
			ClienteLicenciaId,ClienteId,ProductoId,FechaVigencia,
			Vigente,CreadoEl,ModificadoEl
		)
		select @pClienteLicenciaId + ROW_NUMBER() OVER(ORDER BY pl.ProductoId ASC) ,@clienteId,pl.ProductoId,
		case when pl.UnidadLicencia = 'd' then dateadd(dd,pl.TiempoLicencia+1,getdate())
			when pl.UnidadLicencia = 'm' then dateadd(mm,pl.TiempoLicencia+1,getdate())
			when pl.UnidadLicencia = 'y' then dateadd(yy,pl.TiempoLicencia+1,getdate())
		end,1,getdate(),null

		from #tmpProductos p
		inner join cat_productos_licencias pl on pl.ProductoId = cast(p.splitdata as int)
		group by pl.ProductoId,pl.UnidadLicencia,pl.TiempoLicencia


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
 


	


	





