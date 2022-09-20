IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Orden'
          AND Object_ID = Object_ID('cat_familias'))
BEGIN
alter table cat_familias
add Orden smallint null

END
go
