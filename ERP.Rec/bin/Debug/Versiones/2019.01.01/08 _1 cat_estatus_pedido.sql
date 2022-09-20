if not exists (
	select 1
	from sysobjects
	where name = 'cat_estatus_pedido'
)
begin

	CREATE TABLE [dbo].[cat_estatus_pedido](
		[EstatusPedidoId] [smallint] NOT NULL,
		[Descripcion] [varchar](50) NOT NULL,
		[CreadoEl] [datetime] NOT NULL,
	 CONSTRAINT [PK_cat_pedido_estatus] PRIMARY KEY CLUSTERED 
	(
		[EstatusPedidoId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

End


if not exists (
	select 1
	from cat_estatus_pedido
)
begin

	insert into cat_estatus_pedido
	select 1,'Registrado por Cliente',getdate()

	insert into cat_estatus_pedido
	select 2,'Solicitado a Proveedor',getdate()

	insert into cat_estatus_pedido
	select 3,'En Transito',getdate()

	insert into cat_estatus_pedido
	select 4,'Recibido',getdate()

	insert into cat_estatus_pedido
	select 5,'Entregado a Cliente',getdate()

	insert into cat_estatus_pedido
	select 6,'Cancelado',getdate()
end


