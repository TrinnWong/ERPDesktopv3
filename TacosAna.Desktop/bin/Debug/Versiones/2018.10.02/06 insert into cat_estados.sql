if not exists (
	select 1
	from cat_estados
)
begin
insert into [cat_estados]
select	1	,	1	,' Aguascalientes' union
select	2	,	1	,'Baja California' union
select	3	,	1	,'Baja California Sur' union
select	4	,	1	,'Campeche' union
select	5	,	1	,'Chiapas' union
select	6	,	1	,'Chihuahua' union
select	7	,	1	,'Ciudad de México' union
select	8	,	1	,'Coahuila de Zaragoza' union
select	9	,	1	,'Colima' union
select	10	,	1	,'Durango' union
select	11	,	1	,'Estado de México' union
select	12	,	1	,'Guanajuato' union
select	13	,	1	,'Guerrero' union
select	14	,	1	,'Hidalgo' union
select	15	,	1	,'Jalisco' union
select	16	,	1	,'Michoacán de Ocampo' union
select	17	,	1	,'Morelos' union
select	18	,	1	,'Nayarit' union
select	19	,	1	,'Nuevo León' union
select	20	,	1	,'Oaxaca' union
select	21	,	1	,'Puebla' union
select	22	,	1	,'Querétaro' union
select	23	,	1	,'Quintana Roo' union
select	24	,	1	,'San Luis Potosí' union
select	25	,	1	,'Sin Localidad' union
select	26	,	1	,'Sinaloa' union
select	27	,	1	,'Sonora' union
select	28	,	1	,'Tabasco' union
select	29	,	1	,'Tamaulipas' union
select	30	,	1	,'Tlaxcala' union
select	31	,	1	,'Veracruz de Ignacio de la Llave' union
select	32	,	1	,'Yucatán' union
select	33	,	1	,'Zacatecas'	
end
