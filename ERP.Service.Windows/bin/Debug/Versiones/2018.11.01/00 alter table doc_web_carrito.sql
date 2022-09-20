alter table doc_web_carrito
alter column id int not null
go



if not exists (
	SELECT 1
	FROM sys.indexes 
	WHERE name='IX_doc_web_carrito' AND object_id = OBJECT_ID('doc_web_carrito')
)
begin
	CREATE UNIQUE NONCLUSTERED INDEX [IX_doc_web_carrito] ON [dbo].[doc_web_carrito]
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	
end
go



IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'MontoPaypal'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table doc_web_carrito
	add MontoPaypal varchar(20)

END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'TransactionRef'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table doc_web_carrito
	add TransactionRef varchar(30)

END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'FechaEstimadaEntrega'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table doc_web_carrito
	add FechaEstimadaEntrega DateTime null

END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'EntregadoEl'
          AND Object_ID = Object_ID('doc_web_carrito'))
BEGIN
	alter table doc_web_carrito
	add EntregadoEl DateTime null

END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Id'
          AND Object_ID = Object_ID('doc_web_carrito_detalle'))
BEGIN
	alter table doc_web_carrito_detalle
	add Id int null

	ALTER TABLE doc_web_carrito_detalle
	ADD CONSTRAINT FK_Carrito_CarritoDetalle
	FOREIGN KEY (Id) REFERENCES doc_web_carrito(id);
END
go

