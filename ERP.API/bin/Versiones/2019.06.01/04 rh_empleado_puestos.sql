if not exists (
	select 1
	from sysobjects
	where name = 'rh_empleado_puestos'
)
begin
CREATE TABLE [dbo].[rh_empleado_puestos](
	[EmpleadoId] [int] NOT NULL,
	[PuestoId] [int] NOT NULL,
	[CreadoPor] [int] NOT NULL,
	[CreadoEl] [datetime] NOT NULL,
 CONSTRAINT [PK_rh_empleado_puestos] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC,
	[PuestoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[rh_empleado_puestos]  WITH CHECK ADD  CONSTRAINT [FK_rh_empleado_puestos_rh_empleados] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[rh_empleados] ([NumEmpleado])


ALTER TABLE [dbo].[rh_empleado_puestos] CHECK CONSTRAINT [FK_rh_empleado_puestos_rh_empleados]


ALTER TABLE [dbo].[rh_empleado_puestos]  WITH CHECK ADD  CONSTRAINT [FK_rh_empleado_puestos_rh_puestos] FOREIGN KEY([PuestoId])
REFERENCES [dbo].[rh_puestos] ([Clave])


ALTER TABLE [dbo].[rh_empleado_puestos] CHECK CONSTRAINT [FK_rh_empleado_puestos_rh_puestos]

END

