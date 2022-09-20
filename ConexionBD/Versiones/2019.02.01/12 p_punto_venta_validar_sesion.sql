
-- p_punto_venta_validar_sesion 1,1,'',0
alter proc [dbo].[p_punto_venta_validar_sesion]
@pUsuarioId int,
@pCajaId int,
@pError varchar(250) out,
@pSesionId int out
as

		declare @usuarioActivo varchar(100)=''
		set @pError = ''
		set @pSesionId = 0

	
		select @usuarioActivo = ua.NombreUsuario
		from doc_sesiones_punto_venta  s
		inner join cat_usuarios u on u.IdUsuario = @pUsuarioId and u.Activo = 1 and
									isnull(u.EsSupervisor,0) =0
									
		inner join cat_usuarios ua on ua.IdUsuario = s.UsuarioId and
								ua.IdUsuario <> @pUsuarioId
		where s.CajaId = @pCajaId and
		s.Finalizada = 0
	

		if rtrim(@usuarioActivo) != ''
		begin
			set @pError = 'Existe una sesión activa por el usuario:' + @usuarioActivo
		end

		if not exists(
			select 1
			from doc_ventas v
			inner join doc_corte_caja_ventas ccv on ccv.VentaId = v.VentaId 
			where v.CajaId = @pCajaId and
			UsuarioCreacionId <> @pUsuarioId
		)
		BEGIN
			set @pError = @pError + 'Existen un corte pendiente por otro usuario' 
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


	





