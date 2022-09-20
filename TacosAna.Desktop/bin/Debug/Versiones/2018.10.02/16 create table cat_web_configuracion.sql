if not exists (
	select 1
	from [cat_web_configuracion]
	where SucursalId = 1
)
begin
INSERT INTO [cat_web_configuracion](SucursalId,Dominio,ServidorFTP,UsuarioFTP,
PasswordFTP,FolderProductos)
SELECT 1,'https://www.masymaszapatos.com','ftp://ftp.site4now.net/',
'maszapatos','zapatos2018','Content/Productos/'
end