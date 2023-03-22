
IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CajaId'
          AND Object_ID = Object_ID(N'doc_gastos'))
BEGIN

	
	
		ALTER TABLE doc_gastos
		Alter Column  CajaId int NULL		
		
END
go
