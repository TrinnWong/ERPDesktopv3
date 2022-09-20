IF NOT EXISTS (
	SELECT 1
	FROM sis_apis
	where Tipo = 'SDKAdmin'
)
BEGIN
	INSERT INTO sis_apis(Id,Url,Tipo,Activo)
	VALUES(1,'http://admin.sdk.trinn.com.mx','SDKAdmin',1)
END

