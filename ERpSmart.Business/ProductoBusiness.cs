using ConexionBD;
using ERP.Models;
using ERP.Models.Producto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ERP.Business.Enumerados;

namespace ERP.Business
{
    public class ProductoBusiness : BusinessObject
    {
        public ResultAPIModel GenerarAvisoMinMax()
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    List<cat_productos_existencias> lstProductoMin = oContext.cat_productos_existencias
                        .Where(w => w.Disponible <= w.cat_productos.MinimoInventario
                        && w.cat_productos.Estatus == true
                        && w.cat_productos.Inventariable == true
                        && w.cat_productos.doc_productos_minimo
                        .Where(s1=> DbFunctions.TruncateTime(s1.Fecha) == DbFunctions.TruncateTime(fechaActual) && s1.Notificacion == true).Count() <= 0
                        ).ToList();

                    foreach (var itemMin in lstProductoMin)
                    {
                        doc_productos_minimo oMinimo = new doc_productos_minimo();

                        oMinimo.CreadoEl = fechaActual;
                        oMinimo.Fecha = fechaActual.Date;
                        oMinimo.Notificacion = false;
                        oMinimo.ProductoId = itemMin.ProductoId;
                        oMinimo.SucursalId = itemMin.SucursalId;

                        oContext.doc_productos_minimo.Add(oMinimo);

                        oContext.SaveChanges();

                    }

                    //Enviar notificaciones a sucursales
                    #region Notificaciones

                    var sucursales = lstProductoMin.Select(
                        s => new
                        {
                            sucursalid = s.SucursalId,
                            nombreSucursal = s.cat_sucursales.NombreSucursal,
                            smtp = s.cat_sucursales.ServidorMailSMTP,
                            mailFrom = s.cat_sucursales.ServidorMailFrom,
                            port = s.cat_sucursales.ServidorMailPort,
                            pass = s.cat_sucursales.ServidorMailPassword
                        }
                        ).Distinct().ToList();


                   cat_configuracion oConfiguracion = oContext.cat_configuracion.FirstOrDefault();
                   

                    foreach (var item in sucursales)
                    {
                        string email = oConfiguracion.SuperEmail1 + ";" ?? "";
                        email = email+ oConfiguracion.SuperEmail2 +";" ?? "";
                        email = email + oConfiguracion.SuperEmail3 + ";" ?? "";
                        email = email + oConfiguracion.SuperEmail4 + ";" ?? "";

                        int port;

                        int.TryParse(item.port.ToString(), out port);
                        MailBusiness oMail = new MailBusiness(item.smtp, item.mailFrom, port, item.pass);

                        oMail.Send("Existen productos que llegaron al tope mínimo de disponibilidad, por favor ingrese a revisar el reporte de Máximos y Mínimos. Sucursal " + item.nombreSucursal,
                            email, "AVISO! Productos en mínimo", "", null);

                        oContext.Database.ExecuteSqlCommand("UPDATE doc_productos_minimo SET Notificacion =1 WHERE SucursalId = {0} and notificacion = 0", item.sucursalid);

                        oContext.SaveChanges();
                    }

                    #endregion

                    #region marcar productos como notificados
                   
                    #endregion

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }


            return result;
        }

        public ProductoMinMaxListModel GetMaxMinResumen(int sucursalId)
        {
            ProductoMinMaxListModel result = new ProductoMinMaxListModel();
            try
            {
                result.lstProductos = oContext.cat_productos
                    .Where(w => w.Inventariable == true && w.Estatus == true                     
                    && w.cat_productos_existencias.Where(s1=> s1.SucursalId == sucursalId).FirstOrDefault().Disponible < w.MinimoInventario
                    )

                    .Select(
                        s => new ProductoMinMaxModel()
                        {
                             claveProd = s.Clave,
                              disponible = s.cat_productos_existencias.Where(s1 => s1.SucursalId == sucursalId).Count()> 0 ?
                              s.cat_productos_existencias.Where(s1=> s1.SucursalId == sucursalId).FirstOrDefault().Disponible??0:0,
                               maximo = s.doc_productos_max_min.Where(s1=> s1.ProductoId == s.ProductoId && s1.SucursalId == sucursalId).Max(v=> (decimal?)v.Maximo) ?? 0,
                               minimo = s.doc_productos_max_min.Where(s1 => s1.ProductoId == s.ProductoId && s1.SucursalId == sucursalId).Max(v => (decimal?)v.Minimo) ?? 0,
                                productoId = s.ProductoId,
                                 solicitar = (s.doc_productos_max_min.Where(s1 => s1.ProductoId == s.ProductoId && s1.SucursalId == sucursalId).Max(v => (decimal?)v.Minimo) ?? 0) - 
                                            (s.cat_productos_existencias.Where(s1 => s1.SucursalId == sucursalId).Count() > 0 ?
                                               s.cat_productos_existencias.Where(s1 => s1.SucursalId == sucursalId).FirstOrDefault().Disponible ?? 0 : 0),
                                 descripcion = s.Descripcion
                        }
                    ).OrderByDescending(o=> o.solicitar).ToList();
            }
            catch (Exception ex)
            {
                result.error.error = ex.Message;


            }

            return result;
        }
        
        public static decimal ObtenerExistenciaSucursal(int productoId, int sucursalId,ref string error)
        {
            decimal result=0;
            try
            {
                ERPProdEntities oContext2 = new ERPProdEntities();
                cat_productos_existencias pe = oContext2
                    .cat_productos_existencias
                    .Where(w => w.ProductoId == productoId &&
                    w.SucursalId == sucursalId).FirstOrDefault();

                if (pe != null)
                {
                    result = pe.ExistenciaTeorica??0;
                }
            }
            catch (Exception ex)
            {
                error = "Ocurrió un error inesperado";
                
            }

            return result;
        }

        public static decimal ObtenerPrecio(int productoId, 
            tipoPrecioProducto tipo,int usuarioId,int sucursalId)
        {
            ERPProdEntities oContext = new ERPProdEntities();
            cat_productos producto = null;
            decimal precio=0;

            if(producto == null)
            {
                
                producto = oContext.cat_productos
               .Where(w => w.ProductoId == productoId)
               .FirstOrDefault();
            }
            if(producto != null)
            {
                

                if (producto.cat_productos_precios.Where(w=> w.IdPrecio == (int)tipo).Count() > 0)
                {
                    precio = producto.cat_productos_precios.Where(w => w.IdPrecio == (int)tipo).FirstOrDefault().Precio;
                    oContext = new ERPProdEntities();
                    var precioEspecial = oContext
                        .p_producto_precio_especial_vigente(producto.ProductoId, sucursalId).FirstOrDefault();

                   

                    if (precioEspecial != null)
                    {
                        if(precioEspecial.PrecioEspecial > 0)
                        {
                            return precioEspecial.PrecioEspecial;
                        }
                        else
                        {
                            if(precioEspecial.MontoAdicional > 0)
                            {
                                precio = precio + precioEspecial.MontoAdicional;
                            }
                            
                        }
                    }

                    return precio;
                }
                
            }

            return 0;
            
        }


        public static decimal ObtenerPrecioUnitario(int productoId, tipoPrecioProducto tipo, int usuarioId)
        {

            cat_productos producto = DataMemory.DataBucket
                .GetProductosMemory(false)
                .Where(w => w.ProductoId == productoId)
                .FirstOrDefault();

            decimal impuestos = producto.cat_productos_impuestos.Count() > 0 ?
                         (producto.cat_productos_impuestos.Sum(s => s.cat_impuestos.Porcentaje) ?? 0) :0;

            if (producto != null)
            {
                if (producto.cat_productos_precios.Where(w => w.IdPrecio == (int)tipo).Count() > 0)
                {
                    if(impuestos > 0)
                    {
                       return ERP.Utils.CalculosContaTool.DesgloceImpuestos(producto.cat_productos_precios.FirstOrDefault().Precio, impuestos).subtotal;
                    }
                    else
                    {
                        return producto.cat_productos_precios.Where(w => w.IdPrecio == (int)tipo).FirstOrDefault().Precio;
                    }
                    
                }
            }

            return 0;

        }


        public static decimal ObtenerPrecioNeto(int productoId, tipoPrecioProducto tipo, int usuarioId)
        {

            cat_productos producto = DataMemory.DataBucket
                .GetProductosMemory(false)
                .Where(w => w.ProductoId == productoId)
                .FirstOrDefault();

            decimal impuestos = producto.cat_productos_impuestos.Count() > 0 ?
                         (producto.cat_productos_impuestos.Sum(s => s.cat_impuestos.Porcentaje) ?? 0) : 0;

            if (producto != null)
            {
                if (producto.cat_productos_precios.Where(w => w.IdPrecio == (int)tipo).Count() > 0)
                {
                    if (impuestos > 0)
                    {
                        return ERP.Utils.CalculosContaTool.DesgloceImpuestos(producto.cat_productos_precios.FirstOrDefault().Precio, impuestos).subtotal;
                    }
                    else
                    {
                        return producto.cat_productos_precios.Where(w => w.IdPrecio == (int)tipo).FirstOrDefault().Precio;
                    }

                }
            }

            return 0;

        }

        public static decimal? ObtenerPrecioPorCliente(int productoId,int clienteId, int usuarioId,int sucursalId)
        {

            doc_clientes_productos_precios clientes_precios = DataMemory.DataBucket.GetClientesProductosPrecios(false)
                .Where(w => w.ClienteId == clienteId && w.ProductoId == productoId).FirstOrDefault();

            if (clientes_precios != null)
            {
                return clientes_precios.Precio;
            }

            return ObtenerPrecio(productoId, tipoPrecioProducto.PublicoGeneral,usuarioId,sucursalId);

        }

        public static decimal ObtenerDescuentoEmpleado(int productoId, int sucursalId, ref string error)
        {
            decimal result = 0;
            try
            {
                ERPProdEntities oContext2 = new ERPProdEntities();
                doc_empleados_productos_descuentos pe = oContext2
                    .doc_empleados_productos_descuentos
                    .Where(w => w.ProductoId == productoId).FirstOrDefault();

                if (pe != null)
                {
                    result = pe.MontoDescuento;
                }

                //buscar descuento por porcentaje
                if(result <= 0)
                {
                    cat_configuracion config = oContext2.cat_configuracion.FirstOrDefault();

                    if((config.EmpleadoPorcDescuento??0) > 0)
                    {
                        decimal precio = ObtenerPrecio(productoId, tipoPrecioProducto.PublicoGeneral, 1,sucursalId);

                        result = precio * ((config.EmpleadoPorcDescuento??0) / 100);
                    }
                }

                
            }
            catch (Exception )
            {
                error = "Ocurrió un error inesperado";

            }

            return result;
        }

        public static string NumeroPaquetesPorEmpleadoSemana(int EmpleadoId,int usuarioId)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {


                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "ProductoBusiness.NumeroPaquetesPorEmpleadoSemana",
                                    ex);

                return String.Format("Ocurrió un error inesperado, revise la bitácora numero [{0}]",err);
            }
        }
    }

}
