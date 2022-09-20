IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EstatusProduccionId'
          AND Object_ID = Object_ID(N'doc_produccion'))
BEGIN

		alter table doc_produccion
		add EstatusProduccionId int not null


		ALTER TABLE doc_produccion
		ADD FOREIGN KEY (EstatusProduccionId) REFERENCES cat_estatus_produccion(EstatusProduccionId); 

		
END
go