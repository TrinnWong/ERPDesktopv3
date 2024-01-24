USE [master]
GO

--IF NOT EXISTS (SELECT name 
--                FROM [sys].[server_principals]
--                WHERE name = N'pv')
--Begin

--CREATE LOGIN [pv] WITH PASSWORD='PV2018$', DEFAULT_DATABASE=[C:\ERP\ERPProd_data.MDF], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON


--ALTER LOGIN [pv] DISABLE


--ALTER SERVER ROLE [sysadmin] ADD MEMBER [pv]

--Alter login pv enable
--end

--go


IF NOT EXISTS (SELECT name 
                FROM [sys].[server_principals]
                WHERE name = N'pv')
Begin

CREATE LOGIN [pv] WITH PASSWORD='PV2018$', DEFAULT_DATABASE=[erplocaldb], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON


ALTER LOGIN [pv] DISABLE


ALTER SERVER ROLE [sysadmin] ADD MEMBER [pv]

Alter login pv enable
end

go


