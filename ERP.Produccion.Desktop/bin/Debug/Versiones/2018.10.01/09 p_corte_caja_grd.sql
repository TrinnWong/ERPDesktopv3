


-- [p_doc_corte_caja_grd] 2,2,'20180501','20180504'
alter Proc [dbo].[p_doc_corte_caja_grd]
@pSucursalId int,
@pUsuarioId int,
@pFechaDel DateTime,
@pFechaAl DateTime
as

	


	select CC.CajaId,
		CC.TotalCorte,
		CC.TotalEgresos,
		CC.TotalIngresos,
		CC.CreadoEl,
		cc.CorteCajaId,
		Sucursal = suc.NombreSucursal,
		Caja = c.Descripcion
	from doc_corte_caja cc
	inner join cat_cajas c on c.Clave = cc.CajaId
	inner join cat_sucursales suc on suc.clave = c.sucursal
	inner join cat_usuarios usu on usu.IdUsuario = @pUsuarioId
	where --c.Sucursal = @pSucursalId and
	(
		@pUsuarioId in (cc.CreadoPor,0) 
		OR
		usu.EsSupervisor = 1

	) and
	convert(varchar,cc.CreadoEl,112) between convert(varchar,@pFechaDel,112) and convert(varchar,@pFechaAl,112)
	ORDER BY CC.CorteCajaId DESC





