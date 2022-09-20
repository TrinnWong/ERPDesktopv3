IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Id'
          AND Object_ID = Object_ID(N'doc_produccion_entrada'))
BEGIN

		
	alter table  doc_produccion_entrada
	ADD Id INT IDENTITY(1,1)

	ALTER TABLE doc_produccion_entrada
	ADD CONSTRAINT PK_doc_produccion_entrada_2 PRIMARY KEY (Id);

		
END
go