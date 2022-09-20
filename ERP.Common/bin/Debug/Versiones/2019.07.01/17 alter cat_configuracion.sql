IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TieneRec'
          AND Object_ID = Object_ID(N'cat_configuracion'))
begin

ALTER TABLE cat_configuracion
add TieneRec bit null

END

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PorcRec'
          AND Object_ID = Object_ID(N'cat_configuracion'))
begin

ALTER TABLE cat_configuracion
add PorcRec decimal(5,2) null


END


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Rec'
          AND Object_ID = Object_ID(N'doc_ventas'))
begin

alter table doc_ventas
add Rec bit null


END








