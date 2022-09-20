if exists (
	select 1
	from sysobjects
	where name = 'p_producto_promocion_sel'
)
drop proc p_producto_promocion_sel
go
-- p_producto_promocion_sel 1,478
create proc [dbo].[p_producto_promocion_sel]
@pSucursalId int,
@pProductoId int
as

	declare @diaSemena int

	select @diaSemena =datepart(weekday, getdate())	

	select PD.PromocionId,
		ProductoId = @pProductoId,
		p.PorcentajeDescuento
	into #tmpExcepciones
	from doc_promociones p
	inner join cat_productos pro on pro.ProductoId = @pProductoId and
									(
										(p.FechaInicioVigencia <= GETDATE() and
										p.FechaFinVigencia >= GETDATE())
										or
										P.Permanente = 1
									)
	inner join doc_promociones_excepcion pd on pd.PromocionId = p.PromocionId 	
	where p.SucursalId = @pSucursalId and
	p.Activo = 1 and
	(
		(p.Lunes = 1 and @diaSemena = 2) OR
		(p.Martes = 1 and @diaSemena = 3) OR
		(p.Miercoles = 1 and @diaSemena = 4) OR
		(p.Jueves = 1 and @diaSemena = 5) OR
		(p.Viernes = 1 and @diaSemena = 6) OR
		(p.Sabado = 1 and @diaSemena = 7) OR
		(p.Domingo = 1 and @diaSemena = 1) 
	) 
	AND (
		PD.ProductoId = PRO.ProductoId
		or(
			PD.ProductoId IS NULL and
			PD.LineaId = PRO.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia = PRO.ClaveSubFamilia
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId  is null AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId is null AND
			PD.FamiliaId is null AND
			PD.Subfamilia is null
		)
	)
	
	


	select TOP 1 PD.PromocionId,
		ProductoId = @pProductoId,
		p.PorcentajeDescuento		
	from doc_promociones p
	inner join cat_productos pro on pro.ProductoId = @pProductoId and
									(
										(p.FechaInicioVigencia <= GETDATE() and
										p.FechaFinVigencia >= GETDATE())
										or
										P.Permanente = 1
									)
	inner join doc_promociones_detalle pd on pd.PromocionId = p.PromocionId 
	--left join doc_promociones_excepcion pe on pe.ProductoId = p.PromocionId									
	where p.SucursalId = @pSucursalId and
	p.Activo = 1 and
	(
		(p.Lunes = 1 and @diaSemena = 2) OR
		(p.Martes = 1 and @diaSemena = 3) OR
		(p.Miercoles = 1 and @diaSemena = 4) OR
		(p.Jueves = 1 and @diaSemena = 5) OR
		(p.Viernes = 1 and @diaSemena = 6) OR
		(p.Sabado = 1 and @diaSemena = 7) OR
		(p.Domingo = 1 and @diaSemena = 1) 
	) 
	AND (
		PD.ProductoId = PRO.ProductoId
		or(
			PD.ProductoId IS NULL and
			PD.LineaId = PRO.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia = PRO.ClaveSubFamilia
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId = PRO.ClaveFamilia AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId =pro.ClaveLinea AND
			PD.FamiliaId  is null AND
			PD.Subfamilia IS NULL
		)
		or(
			PD.ProductoId IS NULL and
			PD.LineaId is null AND
			PD.FamiliaId is null AND
			PD.Subfamilia is null
		)
	)
	AND NOT EXISTS(
		SELECT 1
		FROM #tmpExcepciones st1
		where st1.PromocionId = PD.PromocionId
	)
	ORDER BY p.PorcentajeDescuento desc
	
	





