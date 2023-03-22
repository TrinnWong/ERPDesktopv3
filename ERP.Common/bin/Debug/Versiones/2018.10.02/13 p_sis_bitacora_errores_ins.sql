if exists (
	select 1
	from sysobjects
	where name = 'p_sis_bitacora_errores_ins'
)
drop proc p_sis_bitacora_errores_ins
go
create proc p_sis_bitacora_errores_ins
@pIdError	int out,
@pSistema	varchar(50),
@pClase	varchar(250),
@pMetodo	varchar(250),
@pError	varchar(500)
as

	select @pIdError = isnull(max(IdError),0) + 1
	from sis_bitacora_errores

	insert into sis_bitacora_errores(
		IdError,	Sistema,	Clase,		Metodo,
		Error,		CreadoEl
	)
	values(
		@pIdError,@pSistema,@pClase,@pMetodo,
		@pError,getdate()
	)