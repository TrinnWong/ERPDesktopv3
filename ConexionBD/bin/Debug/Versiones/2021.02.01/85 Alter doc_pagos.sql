IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ClienteId'
          AND Object_ID = Object_ID(N'doc_pagos'))
BEGIN


	
	alter table  [dbo].doc_pagos
	ALTER COLUMN ClienteId int null
	

		
END
go