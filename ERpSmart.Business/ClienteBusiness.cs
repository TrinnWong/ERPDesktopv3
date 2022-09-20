using ConexionBD;
using ERP.Models;
using ERP.Models.Cargo;
using ERP.Models.Cliente;
using ERP.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ERP.Business
{
    public class ClienteBusiness:BusinessObject
    {
        public  List<ClienteLicenciaModel> GetLicenciaPV(string KeyClient, string tipoProducto, string version)
        {
            ERPProdEntities  oContext = new ERPProdEntities();
            List<ClienteLicenciaModel> result = new List<ClienteLicenciaModel>();

            result = oContext.p_doc_clientes_licencia_sel(KeyClient)
                   .Select(
                   s => new ClienteLicenciaModel()
                   {
                       ClienteLicenciaId = s.ClienteLicenciaId,
                       FechaVigencia = s.FechaVigencia,
                       productoId = s.ProductoId,
                       Vigente = s.Vigente
                   }
                ).ToList();
            //result.Add(new ClienteLicenciaModel() { ClienteLicenciaId = 1, productoId = 1, FechaVigencia = DateTime.Now, Vigente = true });

            return result;
        }

        public ResultAPIModel RegistroDemoPV(ClienteRegistroDemoModel model)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                

                ObjectParameter pError = new ObjectParameter("pError", "");
                oContext.p_api_clientes_registro_demo(model.Nombre, model.Email, model.Giro, pError,"");

                if (pError.Value.ToString().Length > 0)
                {
                    result.ok = false;
                    result.error = pError.Value.ToString();
                }

            }
            catch (Exception ex)
            {

                result.error = ex.Message;
                result.ok = false;
                result.error = ex.Message;
            }
           

            return result;
        }

        public ClienteListModel GetClientes(int sucursalId)
        {
            ClienteListModel result = new ClienteListModel();

            result.lstClientes = oContext.cat_clientes
                .Where(w=> w.SucursalBaseId == sucursalId)
                .Select(
                    s => new ClienteModel()
                    {
                        apellidoMaterno = s.ApellidoMaterno,
                        apellidoPaterno = s.ApellidoPaterno,
                        nombre = s.Nombre,
                        clienteId=s.ClienteId,
                        clave = s.Clave,
                        activo = s.Activo ?? false,
                        sucursal = s.cat_sucursales != null ? s.cat_sucursales.NombreSucursal :"",
                         email = s.cat_clientes_web ==null ? "" : s.cat_clientes_web.Email
                         
                    }
                ).OrderByDescending(o=> o.clienteId).ToList();


            return result;
        }
        
        public ResultAPIModel Add(ClienteModel model)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cat_clientes eCliente = new cat_clientes();

                    int clienteId = model.clienteId;

                    string email = model.email;
                    string clave = model.clave;
                    cat_clientes_contacto eCliente2 = oContext.cat_clientes_contacto.Where(w => ( w.Email == email || w.Email2 == email) ).FirstOrDefault();

                    if (eCliente2 != null)
                    {
                        result.error = "Ya existe un usuario con ese email o con la misma clave";
                        return result;
                    }
                    eCliente = oContext.cat_clientes.Where(w => w.Clave == clave).FirstOrDefault();
                    if(eCliente != null)
                    {
                        result.error = "Ya existe un usuario con esta clave";
                        return result;
                    }

                    eCliente = new cat_clientes();
                   
                    cat_clientes_contacto eClienteContacto = oContext.cat_clientes_contacto.Where(w => w.ClienteId == clienteId).FirstOrDefault();
                   

                    eCliente.ClienteId = (oContext.cat_clientes.Max(m => (int?)m.ClienteId) ?? 0) + 1;
                    eCliente.Clave = model.clave;
                    eCliente.Nombre = model.nombre;
                    eCliente.ApellidoMaterno = model.apellidoMaterno;
                    eCliente.ApellidoPaterno = model.apellidoPaterno;
                    eCliente.Activo = true;
                    eCliente.SucursalBaseId = model.sucursalId;
                    oContext.cat_clientes.Add(eCliente);
                    oContext.SaveChanges();

                    if (eClienteContacto == null)
                    {
                        eClienteContacto = new cat_clientes_contacto();

                        eClienteContacto.ClienteId = eCliente.ClienteId;
                        eClienteContacto.Email = model.email;
                        eClienteContacto.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        oContext.cat_clientes_contacto.Add(eClienteContacto);
                        oContext.SaveChanges();

                        cat_clientes_web entityWeb = new cat_clientes_web();

                        entityWeb.ClienteId = eCliente.ClienteId;
                        entityWeb.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        entityWeb.Email = model.email;
                        entityWeb.Password = model.email;
                        oContext.cat_clientes_web.Add(entityWeb);
                        oContext.SaveChanges();
                    }
                    else
                    {
                        eClienteContacto.Email = model.email;
                    }

                    oContext.SaveChanges();

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ResultAPIModel Edit(ClienteModel model)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    string email = model.email;
                    int clienteId = model.clienteId;
                    string clave = model.clave;
                    cat_clientes_contacto eCliente2 = oContext.cat_clientes_contacto.Where(w => (w.Email == email || w.Email2 == email) && w.ClienteId != clienteId).FirstOrDefault();
                    cat_clientes eCliente = new cat_clientes();

                    if (eCliente2 != null)
                    {
                        result.error = "Ya existe un usuario con ese email";
                        return result;
                    }

                    eCliente = oContext.cat_clientes.Where(w => w.Clave == clave  && w.ClienteId != clienteId).FirstOrDefault();
                    if (eCliente != null)
                    {
                        result.error = "Ya existe un usuario con esta clave";
                        return result;
                    }

                    eCliente = new cat_clientes();

                    eCliente = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault();
                    cat_clientes_contacto eClienteContacto = oContext.cat_clientes_contacto.Where(w => w.ClienteId == clienteId).FirstOrDefault();

                    eCliente.Clave = model.clave;
                    eCliente.Nombre = model.nombre;
                    eCliente.ApellidoMaterno = model.apellidoMaterno;
                    eCliente.ApellidoPaterno = model.apellidoPaterno;
                    eCliente.Activo = model.activo;
                    eCliente.SucursalBaseId = model.sucursalId;

                    if (eClienteContacto == null)
                    {
                        eClienteContacto = new cat_clientes_contacto();

                        eClienteContacto.ClienteId = clienteId;
                        eClienteContacto.Email = model.email;
                        eClienteContacto.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        oContext.cat_clientes_contacto.Add(eClienteContacto);
                    }
                    else
                    {
                        eClienteContacto.Email = model.email;
                    }

                    cat_clientes_web entityWeb = oContext.cat_clientes_web
                        .Where(w => w.ClienteId == clienteId).FirstOrDefault();

                    if (entityWeb == null)
                    {
                        entityWeb = new cat_clientes_web();
                        entityWeb.ClienteId = clienteId;
                        entityWeb.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        entityWeb.Email = model.email;

                        oContext.cat_clientes_web.Add(entityWeb);

                        
                    }
                    else
                    {
                        entityWeb.ClienteId = clienteId;
                        entityWeb.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        entityWeb.Email = model.email;
                    }

                    oContext.SaveChanges();

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ClienteModel Get(int clienteId)
        {
            ClienteModel result = new ClienteModel();
            try
            {
                result = oContext.cat_clientes.Where(w => w.ClienteId == clienteId)
                    .Select(
                        s=> new ClienteModel()
                        {
                             activo = s.Activo??false,
                              apellidoMaterno = s.ApellidoMaterno,
                               apellidoPaterno = s.ApellidoPaterno,
                                clave = s.Clave,
                                 clienteId = s.ClienteId,
                                  email = s.cat_clientes_contacto != null ? s.cat_clientes_contacto.Email : "",
                                   nombre = s.Nombre,
                                   sucursalId = s.SucursalBaseId??0
                        }
                    )
                    .FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public ClienteModel Login(string email, string pass)
        {
            ClienteModel result = new ClienteModel();
            try
            {
                cat_clientes_web entity = oContext.cat_clientes_web
                    .Where(w => w.Email == email).FirstOrDefault();

                if(entity != null)
                {
                    if (entity.Password != pass)
                    {
                        result.error = "El password es incorrecto";
                    }
                    else
                    {
                        result.clienteId = entity.ClienteId;
                        result.email = entity.Email;
                        result.clave = entity.cat_clientes.Clave;
                        result.nombre = entity.cat_clientes.Nombre;
                        result.apellidoMaterno = entity.cat_clientes.ApellidoMaterno;
                        result.apellidoPaterno = entity.cat_clientes.ApellidoPaterno;
                    }
                }
                else
                {
                    result.error = "El usuario no existe";
                }


            }
            catch (Exception ex)
            {
                result.error = ex.Message;
                
            }
            return result;
        }

        public CargoPendienteModel GetCargoPendiente(int clienteId)
        {

            CargoPendienteModel result = new CargoPendienteModel();
            decimal montoRecargo = 0;
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity != null)
            {
                montoRecargo = entity.MontoRecargoDiario ?? 0;
            }

            try
            {
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                result.cargoDetalle = oContext.doc_cargos_detalle
                    .Where(w => w.doc_cargos.Activo == true &&
                    w.Saldo > 0 &&
                    w.doc_cargos.ClienteId == clienteId
                    )
                    .Select(
                        s=> new CargoDetalleModel()
                        {
                             cargoDetalleId = s.CargoDetalleId,
                               cargoId =  s.CargoId,
                                fechaCargo = s.FechaCargo,
                                 total = s.Total,
                                  saldo =  DbFunctions.TruncateTime(fechaActual) > DbFunctions.TruncateTime(s.FechaCargo) ?
                                              (s.Saldo ?? 0) + ((DbFunctions.DiffDays(DbFunctions.TruncateTime(s.FechaCargo), DbFunctions.TruncateTime(fechaActual)) ?? 0) * montoRecargo)
                                                : (s.Saldo ?? 0),
                                  saldoVencido = System.Data.Entity.DbFunctions.TruncateTime(s.FechaCargo) >= System.Data.Entity.DbFunctions.TruncateTime(fechaActual) ? 0 :
                                               DbFunctions.TruncateTime(fechaActual) > DbFunctions.TruncateTime(s.FechaCargo) ?
                                              (s.Saldo ?? 0) + ((DbFunctions.DiffDays(DbFunctions.TruncateTime(s.FechaCargo), DbFunctions.TruncateTime(fechaActual)) ?? 0) * montoRecargo)
                                                : (s.Saldo ?? 0),
                                  vencido =System.Data.Entity.DbFunctions.TruncateTime(s.FechaCargo) >= System.Data.Entity.DbFunctions.TruncateTime(fechaActual) ? false : true,
                                  concepto = s.doc_cargos.cat_productos.Descripcion
                        }
                    )
                    .OrderBy(o=> o.fechaCargo)
                    .ToList();
            }
            catch (Exception ex)
            {

                result.ok.error = ex.Message;
            }
            return result;
        }

        public ResultAPIModel RecuperarPass(string email)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                cat_clientes_web eCliente = oContext.cat_clientes_web.Where(w => w.Email.ToUpper() == email.ToUpper()).FirstOrDefault();

                if(eCliente == null)
                {
                    result.error = "El email no está registrado";
                    return result;
                }
                else
                {
                    if((eCliente.Password == null?"": eCliente.Password)=="")
                    {
                        result.error = "Existe un problema con tu password no es posible enviartelo";
                        return result;
                    }
                    else
                    {
                        string mensaje = PlantillasHTML.email;

                        mensaje = mensaje.Replace("{password}", eCliente.Password.Trim());

                        MailBusiness oMail = new MailBusiness();

                        result.error = oMail.Send(mensaje, eCliente.Email,"Recuperación de contraseña", "", null);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public ResultAPIModel CambiarPass(ClienteCambiarPassModel model)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                int clienteId = model.clienteId;

                cat_clientes_web eCliente = oContext.cat_clientes_web
                    .Where(w => w.ClienteId == clienteId).FirstOrDefault();

                if(eCliente.Password == model.passAnterior)
                {
                    if(model.passNuevo1 != model.passNuevo2)
                    {
                        result.error = "La nueva contraseña no coincide";
                    }
                    else
                    {
                        eCliente.Password = model.passNuevo1;

                        oContext.SaveChanges();
                    }
                }
                else
                {
                    result.error = "Tu contraseña anterior es incorrecta";
                    
                }


            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }
       
    }
}
