--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- p_punto_venta_validar_sesion 2,1,'',0
ALTER proc [dbo].[p_punto_venta_validar_sesion]
@pUsuarioId int,
@pCajaId int,
@pError varchar(250) out,
@pSesionId int out
as

		declare @usuarioActivo varchar(100)='',
				@essupervisor bit = 0
		set @pError = ''
		set @pSesionId = 0

		select @essupervisor = EsSupervisor
		from cat_usuarios 
		where IdUsuario = @pUsuarioId

	
		select @usuarioActivo = ua.NombreUsuario
		from doc_sesiones_punto_venta  s
		inner join cat_usuarios u on u.IdUsuario = @pUsuarioId and u.Activo = 1 and
									isnull(u.EsSupervisor,0) =0
									
		inner join cat_usuarios ua on ua.IdUsuario = s.UsuarioId and
								ua.IdUsuario <> @pUsuarioId
		where s.CajaId = @pCajaId and
		s.Finalizada = 0
	

		if rtrim(@usuarioActivo) != '' AND
		@essupervisor = 0
		begin
			set @pError = 'Existe una sesi�n activa por el usuario:' + @usuarioActivo
		end

		if exists(
			select 1
			from doc_ventas v
			--inner join doc_corte_caja_ventas ccv on ccv.VentaId = v.VentaId 
			where v.CajaId = @pCajaId and
			UsuarioCreacionId <> @pUsuarioId and
			not exists(
				select 1
				from doc_corte_caja_ventas cvv where cvv.VentaId = v.VentaId
			)
		)AND
		@essupervisor = 0
		BEGIN
			 
			select TOP 1 @pError= @pError + 'Existen un corte pendiente por otro usuario: ' + ISNULL(U.NombreUsuario,'')
			from doc_ventas v
			INNER JOIN cat_usuarios U ON U.IdUsuario = v.UsuarioCreacionId
			where v.CajaId = @pCajaId and
			UsuarioCreacionId <> @pUsuarioId and
			not exists(
				select 1
				from doc_corte_caja_ventas cvv where cvv.VentaId = v.VentaId
			)
		END

		if @pError = ''
		begin 
			select @pSesionId = s.SesionId
			from doc_sesiones_punto_venta  s		
			inner join cat_usuarios ua on ua.IdUsuario = s.UsuarioId
			where s.CajaId = @pCajaId and
			s.Finalizada = 0 and			
			ua.IdUsuario = @pUsuarioId
		end


	


