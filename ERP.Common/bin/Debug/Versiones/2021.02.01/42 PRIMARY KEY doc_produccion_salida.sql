IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Id'
          AND Object_ID = Object_ID(N'doc_produccion_salida'))
BEGIN

		
	alter table  doc_produccion_salida
	ADD Id INT IDENTITY(1,1)

	ALTER TABLE doc_produccion_salida
	ADD CONSTRAINT PK_doc_produccion_salida_2 PRIMARY KEY (Id);

		
END
go