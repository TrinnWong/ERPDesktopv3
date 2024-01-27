using ConexionBD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class SincronizacionBusiness:BusinessObject
    {
        SisCuentaBusiness sisCuenta;
        ERPProdEntities contextOrigen;
        ERPProdEntities contextDestino;
        int err;
        //public SincronizacionBusiness()
        //{
        //    sisCuenta = new SisCuentaBusiness();
        //    contextDestino = new ERPProdEntities();
        //    contextOrigen = new ERPProdEntities(ConexionBD.Sistema.scMain);

        //}


       
        public SincronizacionBusiness()
        {
            string directorioRaiz = AppDomain.CurrentDomain.BaseDirectory;
            sisCuenta = new SisCuentaBusiness();
            var builder1 = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ERPProdCloudMater"].ConnectionString);
            var builder2 = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ERPProdEntities"].ConnectionString);
            


            contextOrigen = new ERPProdEntities(builder1.ProviderConnectionString);
            contextDestino = new ERPProdEntities(builder2.ProviderConnectionString);

        }

        public string Importar()
        {
            try
            {
                var cuenta = sisCuenta.ObtieneArchivoConfiguracionCuenta();
                int sucursalId = cuenta.ClaveSucursal??0;

                List<cat_empresas> lstEmpresasOri = contextOrigen.cat_empresas.ToList();
                List<cat_cajas> lstCajasOri = contextOrigen.cat_cajas.ToList();
                List<cat_configuracion> lstConfiguracion = contextOrigen.cat_configuracion.ToList();
                List<cat_tipos_cajas> lsTiposCajas = contextOrigen.cat_tipos_cajas.ToList();
                List<cat_sucursales> sucursalOri = contextOrigen.cat_sucursales.ToList();
                List<cat_usuarios> lstUsuariosOri = contextOrigen.cat_usuarios
                    .Where(w => w.cat_usuarios_sucursales.Where(s1 => s1.SucursalId == sucursalId).Count() > 0 || w.NombreUsuario.Contains("ADMIN")).ToList();
                List<cat_usuarios_sucursales> lstUsuariosSucursalesOri = contextOrigen.cat_usuarios_sucursales
                   .Where(w => w.SucursalId == sucursalId).ToList();
                List<cat_familias> lstFamiliasOri = contextOrigen.cat_familias.ToList();
                List<cat_subfamilias> lstSubFamiliasOri = contextOrigen.cat_subfamilias.ToList();
                List<cat_lineas> lstLineasOri = contextOrigen.cat_lineas.ToList();
                List<cat_productos> lstProductosOri = contextOrigen.cat_productos.ToList();
                List<cat_productos_precios> lstProductosPrecioOri = contextOrigen
                    .cat_productos_precios.ToList();
                List<rh_empleados> lstRHEmpleados = contextOrigen.rh_empleados.ToList();
                List<rh_puestos> lstPuestos = contextOrigen.rh_puestos.ToList();

                ImportEmpresas(ref contextDestino, lstEmpresasOri);
                ImportSucursales(ref contextDestino, sucursalOri);
                ImportConfguracion(ref contextDestino, lstConfiguracion);
                ImportTiposCajas(ref contextDestino, lsTiposCajas);
                ImportCajas(ref contextDestino, lstCajasOri);
                ImportPuestos(ref contextDestino, lstPuestos);
                ImportEmpleados(ref contextDestino, lstRHEmpleados);
                ImportUsuarios(ref contextDestino, lstUsuariosOri);
                ImportUsuariosSucursales(ref contextDestino, lstUsuariosSucursalesOri);
                ImportLineas(ref contextDestino, lstLineasOri);
                ImportFamilias(ref contextDestino, lstFamiliasOri);
                ImportSubFamilias(ref contextDestino, lstSubFamiliasOri);
                ImportProductos(ref contextDestino, lstProductosOri);
                ImportProductosPrecios(ref contextDestino, lstProductosPrecioOri);


                return "";
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.Importar",
                                                          ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }
        }

        public bool ImportConfguracion(ref ERPProdEntities context, List<cat_configuracion> lstConfiguraciones)
        {
            try
            {
                foreach (cat_configuracion itemConfiguracion in lstConfiguraciones)
                {
                    cat_configuracion configuracionSinc = context.cat_configuracion                
                    .Where(w => w.ConfiguradorId == itemConfiguracion.ConfiguradorId)
                    .FirstOrDefault();

                    if (configuracionSinc != null)
                    {
                        configuracionSinc.UnaFormaPago = itemConfiguracion.UnaFormaPago;
                        configuracionSinc.MasUnaFormaPago = itemConfiguracion.MasUnaFormaPago;
                        configuracionSinc.CosteoUEPS = itemConfiguracion.CosteoUEPS;
                        configuracionSinc.CosteoPEPS = itemConfiguracion.CosteoPEPS;
                        configuracionSinc.CosteoPromedio = itemConfiguracion.CosteoPromedio;
                        configuracionSinc.AfectarInventarioLinea = itemConfiguracion.AfectarInventarioLinea;
                        configuracionSinc.AfectarInventarioManual = itemConfiguracion.AfectarInventarioManual;
                        configuracionSinc.AfectarInventarioCorte = itemConfiguracion.AfectarInventarioCorte;
                        configuracionSinc.EnlazarPuntoVentaInventario = itemConfiguracion.EnlazarPuntoVentaInventario;
                        configuracionSinc.CajeroIncluirDetalleVenta = itemConfiguracion.CajeroIncluirDetalleVenta;
                        configuracionSinc.CajeroReqClaveSupervisor = itemConfiguracion.CajeroReqClaveSupervisor;
                        configuracionSinc.SuperIncluirDetalleVenta = itemConfiguracion.SuperIncluirDetalleVenta;
                        configuracionSinc.SuperIncluirVentaTel = itemConfiguracion.SuperIncluirVentaTel;
                        configuracionSinc.SuperIncluirDetGastos = itemConfiguracion.SuperIncluirDetGastos;
                        configuracionSinc.SuperEmail1 = itemConfiguracion.SuperEmail1;
                        configuracionSinc.SuperEmail2 = itemConfiguracion.SuperEmail2;
                        configuracionSinc.SuperEmail3 = itemConfiguracion.SuperEmail3;
                        configuracionSinc.SuperEmail4 = itemConfiguracion.SuperEmail4;
                        configuracionSinc.RetiroMontoEfec = itemConfiguracion.RetiroMontoEfec;
                        configuracionSinc.RetiroLectura = itemConfiguracion.RetiroLectura;
                        configuracionSinc.RetiroEscritura = itemConfiguracion.RetiroEscritura;
                        configuracionSinc.NombreImpresora = itemConfiguracion.NombreImpresora;
                        configuracionSinc.HardwareCaracterCajon = itemConfiguracion.HardwareCaracterCajon;
                        configuracionSinc.EmpleadoPorcDescuento = itemConfiguracion.EmpleadoPorcDescuento;
                        configuracionSinc.EmpleadoGlobal = itemConfiguracion.EmpleadoGlobal;
                        configuracionSinc.EmpleadoIndividual = itemConfiguracion.EmpleadoIndividual;
                        configuracionSinc.MontoImpresionTicket = itemConfiguracion.MontoImpresionTicket;
                        configuracionSinc.ApartadoAnticipo1 = itemConfiguracion.ApartadoAnticipo1;
                        configuracionSinc.ApartadoAnticipoHasta1 = itemConfiguracion.ApartadoAnticipoHasta1;
                        configuracionSinc.ApartadoAnticipo2 = itemConfiguracion.ApartadoAnticipo2;
                        configuracionSinc.ApatadoAnticipoEnAdelante2 = itemConfiguracion.ApatadoAnticipoEnAdelante2;
                        configuracionSinc.PorcentajeUtilidadProd = itemConfiguracion.PorcentajeUtilidadProd;
                        configuracionSinc.DesgloceMontoTicket = itemConfiguracion.DesgloceMontoTicket;
                        configuracionSinc.RetiroReqClaveSup = itemConfiguracion.RetiroReqClaveSup;
                        configuracionSinc.CajDeclaracionFondoCorte = itemConfiguracion.CajDeclaracionFondoCorte;
                        configuracionSinc.SupDeclaracionFondoCorte = itemConfiguracion.SupDeclaracionFondoCorte;
                        configuracionSinc.vistaPreviaImpresion = itemConfiguracion.vistaPreviaImpresion;
                        configuracionSinc.CajeroCorteDetGasto = itemConfiguracion.CajeroCorteDetGasto;
                        configuracionSinc.SupCorteDetGasto = itemConfiguracion.SupCorteDetGasto;
                        configuracionSinc.CajeroCorteCancelaciones = itemConfiguracion.CajeroCorteCancelaciones;
                        configuracionSinc.SupCorteCancelaciones = itemConfiguracion.SupCorteCancelaciones;
                        configuracionSinc.DevDiasVale = itemConfiguracion.DevDiasVale;
                        configuracionSinc.DevDiasGarantia = itemConfiguracion.DevDiasGarantia;
                        configuracionSinc.DevHorasGarantia = itemConfiguracion.DevHorasGarantia;
                        configuracionSinc.ApartadoDiasLiq = itemConfiguracion.ApartadoDiasLiq;
                        configuracionSinc.ApartadoDiasProrroga = itemConfiguracion.ApartadoDiasProrroga;
                        configuracionSinc.ReqClaveSupReimpresionTicketPV = itemConfiguracion.ReqClaveSupReimpresionTicketPV;
                        configuracionSinc.ReqClaveSupCancelaTicketPV = itemConfiguracion.ReqClaveSupCancelaTicketPV;
                        configuracionSinc.ReqClaveSupGastosPV = itemConfiguracion.ReqClaveSupGastosPV;
                        configuracionSinc.ReqClaveSupDevolucionPV = itemConfiguracion.ReqClaveSupDevolucionPV;
                        configuracionSinc.ReqClaveSupApartadoPV = itemConfiguracion.ReqClaveSupApartadoPV;
                        configuracionSinc.ReqClaveSupExistenciaPV = itemConfiguracion.ReqClaveSupExistenciaPV;
                        configuracionSinc.SerieTicketVenta = itemConfiguracion.SerieTicketVenta;
                        configuracionSinc.SerieTicketApartado = itemConfiguracion.SerieTicketApartado;
                        configuracionSinc.CorteCajaIncluirExistencia = itemConfiguracion.CorteCajaIncluirExistencia;
                        configuracionSinc.ImprimirTicketMediaCarta = itemConfiguracion.ImprimirTicketMediaCarta;
                        configuracionSinc.Giro = itemConfiguracion.Giro;
                        configuracionSinc.SolicitarComanda = itemConfiguracion.SolicitarComanda;
                        configuracionSinc.TieneRec = itemConfiguracion.TieneRec;
                        configuracionSinc.PorcRec = itemConfiguracion.PorcRec;
                        configuracionSinc.MontoRecargoDiario = itemConfiguracion.MontoRecargoDiario;
                        configuracionSinc.PedidoAnticipoPorc = itemConfiguracion.PedidoAnticipoPorc;
                        configuracionSinc.PedidoPoliticaId = itemConfiguracion.PedidoPoliticaId;

                        context.SaveChanges();
                    }
                    else
                    {
                        configuracionSinc = new cat_configuracion();
                        configuracionSinc.UnaFormaPago = itemConfiguracion.UnaFormaPago;
                        configuracionSinc.MasUnaFormaPago = itemConfiguracion.MasUnaFormaPago;
                        configuracionSinc.CosteoUEPS = itemConfiguracion.CosteoUEPS;
                        configuracionSinc.CosteoPEPS = itemConfiguracion.CosteoPEPS;
                        configuracionSinc.CosteoPromedio = itemConfiguracion.CosteoPromedio;
                        configuracionSinc.AfectarInventarioLinea = itemConfiguracion.AfectarInventarioLinea;
                        configuracionSinc.AfectarInventarioManual = itemConfiguracion.AfectarInventarioManual;
                        configuracionSinc.AfectarInventarioCorte = itemConfiguracion.AfectarInventarioCorte;
                        configuracionSinc.EnlazarPuntoVentaInventario = itemConfiguracion.EnlazarPuntoVentaInventario;
                        configuracionSinc.CajeroIncluirDetalleVenta = itemConfiguracion.CajeroIncluirDetalleVenta;
                        configuracionSinc.CajeroReqClaveSupervisor = itemConfiguracion.CajeroReqClaveSupervisor;
                        configuracionSinc.SuperIncluirDetalleVenta = itemConfiguracion.SuperIncluirDetalleVenta;
                        configuracionSinc.SuperIncluirVentaTel = itemConfiguracion.SuperIncluirVentaTel;
                        configuracionSinc.SuperIncluirDetGastos = itemConfiguracion.SuperIncluirDetGastos;
                        configuracionSinc.SuperEmail1 = itemConfiguracion.SuperEmail1;
                        configuracionSinc.SuperEmail2 = itemConfiguracion.SuperEmail2;
                        configuracionSinc.SuperEmail3 = itemConfiguracion.SuperEmail3;
                        configuracionSinc.SuperEmail4 = itemConfiguracion.SuperEmail4;
                        configuracionSinc.RetiroMontoEfec = itemConfiguracion.RetiroMontoEfec;
                        configuracionSinc.RetiroLectura = itemConfiguracion.RetiroLectura;
                        configuracionSinc.RetiroEscritura = itemConfiguracion.RetiroEscritura;
                        configuracionSinc.NombreImpresora = itemConfiguracion.NombreImpresora;
                        configuracionSinc.HardwareCaracterCajon = itemConfiguracion.HardwareCaracterCajon;
                        configuracionSinc.EmpleadoPorcDescuento = itemConfiguracion.EmpleadoPorcDescuento;
                        configuracionSinc.EmpleadoGlobal = itemConfiguracion.EmpleadoGlobal;
                        configuracionSinc.EmpleadoIndividual = itemConfiguracion.EmpleadoIndividual;
                        configuracionSinc.MontoImpresionTicket = itemConfiguracion.MontoImpresionTicket;
                        configuracionSinc.ApartadoAnticipo1 = itemConfiguracion.ApartadoAnticipo1;
                        configuracionSinc.ApartadoAnticipoHasta1 = itemConfiguracion.ApartadoAnticipoHasta1;
                        configuracionSinc.ApartadoAnticipo2 = itemConfiguracion.ApartadoAnticipo2;
                        configuracionSinc.ApatadoAnticipoEnAdelante2 = itemConfiguracion.ApatadoAnticipoEnAdelante2;
                        configuracionSinc.PorcentajeUtilidadProd = itemConfiguracion.PorcentajeUtilidadProd;
                        configuracionSinc.DesgloceMontoTicket = itemConfiguracion.DesgloceMontoTicket;
                        configuracionSinc.RetiroReqClaveSup = itemConfiguracion.RetiroReqClaveSup;
                        configuracionSinc.CajDeclaracionFondoCorte = itemConfiguracion.CajDeclaracionFondoCorte;
                        configuracionSinc.SupDeclaracionFondoCorte = itemConfiguracion.SupDeclaracionFondoCorte;
                        configuracionSinc.vistaPreviaImpresion = itemConfiguracion.vistaPreviaImpresion;
                        configuracionSinc.CajeroCorteDetGasto = itemConfiguracion.CajeroCorteDetGasto;
                        configuracionSinc.SupCorteDetGasto = itemConfiguracion.SupCorteDetGasto;
                        configuracionSinc.CajeroCorteCancelaciones = itemConfiguracion.CajeroCorteCancelaciones;
                        configuracionSinc.SupCorteCancelaciones = itemConfiguracion.SupCorteCancelaciones;
                        configuracionSinc.DevDiasVale = itemConfiguracion.DevDiasVale;
                        configuracionSinc.DevDiasGarantia = itemConfiguracion.DevDiasGarantia;
                        configuracionSinc.DevHorasGarantia = itemConfiguracion.DevHorasGarantia;
                        configuracionSinc.ApartadoDiasLiq = itemConfiguracion.ApartadoDiasLiq;
                        configuracionSinc.ApartadoDiasProrroga = itemConfiguracion.ApartadoDiasProrroga;
                        configuracionSinc.ReqClaveSupReimpresionTicketPV = itemConfiguracion.ReqClaveSupReimpresionTicketPV;
                        configuracionSinc.ReqClaveSupCancelaTicketPV = itemConfiguracion.ReqClaveSupCancelaTicketPV;
                        configuracionSinc.ReqClaveSupGastosPV = itemConfiguracion.ReqClaveSupGastosPV;
                        configuracionSinc.ReqClaveSupDevolucionPV = itemConfiguracion.ReqClaveSupDevolucionPV;
                        configuracionSinc.ReqClaveSupApartadoPV = itemConfiguracion.ReqClaveSupApartadoPV;
                        configuracionSinc.ReqClaveSupExistenciaPV = itemConfiguracion.ReqClaveSupExistenciaPV;
                        configuracionSinc.SerieTicketVenta = itemConfiguracion.SerieTicketVenta;
                        configuracionSinc.SerieTicketApartado = itemConfiguracion.SerieTicketApartado;
                        configuracionSinc.CorteCajaIncluirExistencia = itemConfiguracion.CorteCajaIncluirExistencia;
                        configuracionSinc.ImprimirTicketMediaCarta = itemConfiguracion.ImprimirTicketMediaCarta;
                        configuracionSinc.Giro = itemConfiguracion.Giro;
                        configuracionSinc.SolicitarComanda = itemConfiguracion.SolicitarComanda;
                        configuracionSinc.TieneRec = itemConfiguracion.TieneRec;
                        configuracionSinc.PorcRec = itemConfiguracion.PorcRec;
                        configuracionSinc.MontoRecargoDiario = itemConfiguracion.MontoRecargoDiario;
                        configuracionSinc.PedidoAnticipoPorc = itemConfiguracion.PedidoAnticipoPorc;
                        configuracionSinc.PedidoPoliticaId = itemConfiguracion.PedidoPoliticaId;
                        configuracionSinc.ConfiguradorId = itemConfiguracion.ConfiguradorId;

                        context.cat_configuracion.Add(configuracionSinc);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                              "ERP",
                                                              "ERP.Business.SincronizacionBusiness.ImportConfguracion",
                                                              ex);

                return false;
            }
        }

        public bool ImportCajas(ref ERPProdEntities context, List<cat_cajas> lstCajas)
        {
            try
            {
                foreach (cat_cajas itemCaja in lstCajas)
                {
                    cat_cajas cajaSinc = context.cat_cajas
                        
                        .Where(w => w.Clave == itemCaja.Clave)
                        .FirstOrDefault();

                    if (cajaSinc != null)
                    {
                        cajaSinc.Descripcion = itemCaja.Descripcion;
                        cajaSinc.Ubicacion = itemCaja.Ubicacion;
                        cajaSinc.Estatus = itemCaja.Estatus;
                        cajaSinc.Empresa = itemCaja.Empresa;
                        cajaSinc.Sucursal = itemCaja.Sucursal;
                        cajaSinc.TipoCajaId = itemCaja.TipoCajaId;
                        context.SaveChanges();
                    }
                    else
                    {
                        cajaSinc = new cat_cajas();
                        cajaSinc.Clave = itemCaja.Clave;
                        cajaSinc.Descripcion = itemCaja.Descripcion;
                        cajaSinc.Ubicacion = itemCaja.Ubicacion;
                        cajaSinc.Estatus = itemCaja.Estatus;
                        cajaSinc.Empresa = itemCaja.Empresa;
                        cajaSinc.Sucursal = itemCaja.Sucursal;
                        cajaSinc.TipoCajaId = itemCaja.TipoCajaId;
                        // Puedes asignar otras propiedades según sea necesario
                        context.cat_cajas.Add(cajaSinc);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                              "ERP",
                                                              "ERP.Business.SincronizacionBusiness.ImportCajas",
                                                              ex);

                return false;
            }
        }

        public bool ImportEmpresas(ref ERPProdEntities context, List<cat_empresas> lstEmpresasOri)
        {
            try
            {
                
                foreach (cat_empresas itemEmpresa in lstEmpresasOri)
                {
                    cat_empresas empresaSinc = context.cat_empresas
                        .Where(w => w.Clave == itemEmpresa.Clave).FirstOrDefault();

                    if(empresaSinc != null)
                    {
                        empresaSinc.Nombre = itemEmpresa.Nombre;
                        empresaSinc.NombreComercial = itemEmpresa.NombreComercial;
                        empresaSinc.RFC = itemEmpresa.RFC;
                        empresaSinc.Estatus = itemEmpresa.Estatus;
                        context.SaveChanges();
                    }
                    else
                    {
                        empresaSinc = new cat_empresas();
                        empresaSinc.Nombre = itemEmpresa.Nombre;
                        empresaSinc.NombreComercial = itemEmpresa.NombreComercial;
                        empresaSinc.RFC = itemEmpresa.RFC;
                        empresaSinc.Estatus = itemEmpresa.Estatus;

                        empresaSinc.Clave = itemEmpresa.Clave;

                        context.cat_empresas.Add(empresaSinc);
                        context.SaveChanges();
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;

            }
        }

        public bool ImportSucursales(ref ERPProdEntities context, List<cat_sucursales> lstSucursales)
        {
            try
            {
                foreach (cat_sucursales itemSucursal in lstSucursales)
                {
                    cat_sucursales sucursalSinc = context.cat_sucursales
                        
                        .Where(w => w.Clave == itemSucursal.Clave)
                        .FirstOrDefault();

                    if (sucursalSinc != null)
                    {
                        sucursalSinc.Empresa = itemSucursal.Empresa;
                        sucursalSinc.Calle = itemSucursal.Calle;
                        sucursalSinc.Colonia = itemSucursal.Colonia;
                        sucursalSinc.NoExt = itemSucursal.NoExt;
                        sucursalSinc.NoInt = itemSucursal.NoInt;
                        sucursalSinc.Ciudad = itemSucursal.Ciudad;
                        sucursalSinc.Estado = itemSucursal.Estado;
                        sucursalSinc.Pais = itemSucursal.Pais;
                        sucursalSinc.Telefono1 = itemSucursal.Telefono1;
                        sucursalSinc.Telefono2 = itemSucursal.Telefono2;
                        sucursalSinc.Email = itemSucursal.Email;
                        sucursalSinc.Estatus = itemSucursal.Estatus;
                        sucursalSinc.NombreSucursal = itemSucursal.NombreSucursal;
                        sucursalSinc.CP = itemSucursal.CP;
                        sucursalSinc.ServidorMailSMTP = itemSucursal.ServidorMailSMTP;
                        sucursalSinc.ServidorMailFrom = itemSucursal.ServidorMailFrom;
                        sucursalSinc.ServidorMailPort = itemSucursal.ServidorMailPort;
                        sucursalSinc.ServidorMailPassword = itemSucursal.ServidorMailPassword;

                        // Puedes asignar otras propiedades según sea necesario

                        context.SaveChanges();
                    }
                    else
                    {
                        sucursalSinc = new cat_sucursales();

                        sucursalSinc.Clave = itemSucursal.Clave;
                        sucursalSinc.Empresa = itemSucursal.Empresa;
                        sucursalSinc.Calle = itemSucursal.Calle;
                        sucursalSinc.Colonia = itemSucursal.Colonia;
                        sucursalSinc.NoExt = itemSucursal.NoExt;
                        sucursalSinc.NoInt = itemSucursal.NoInt;
                        sucursalSinc.Ciudad = itemSucursal.Ciudad;
                        sucursalSinc.Estado = itemSucursal.Estado;
                        sucursalSinc.Pais = itemSucursal.Pais;
                        sucursalSinc.Telefono1 = itemSucursal.Telefono1;
                        sucursalSinc.Telefono2 = itemSucursal.Telefono2;
                        sucursalSinc.Email = itemSucursal.Email;
                        sucursalSinc.Estatus = itemSucursal.Estatus;
                        sucursalSinc.NombreSucursal = itemSucursal.NombreSucursal;
                        sucursalSinc.CP = itemSucursal.CP;
                        sucursalSinc.ServidorMailSMTP = itemSucursal.ServidorMailSMTP;
                        sucursalSinc.ServidorMailFrom = itemSucursal.ServidorMailFrom;
                        sucursalSinc.ServidorMailPort = itemSucursal.ServidorMailPort;
                        sucursalSinc.ServidorMailPassword = itemSucursal.ServidorMailPassword;

                        // Puedes asignar otras propiedades según sea necesario

                        context.cat_sucursales.Add(sucursalSinc);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                              "ERP",
                                                              "ERP.Business.SincronizacionBusiness.ImportSucursales",
                                                              ex);

                return false;
            }
        }


        public bool ImportUsuarios(ref ERPProdEntities context, List<cat_usuarios> lstUsuarios)
        {
            try
            {
                foreach (cat_usuarios itemUsuario in lstUsuarios)
                {
                    cat_usuarios usuarioSinc = context.cat_usuarios
                        
                        .Where(w => w.IdUsuario == itemUsuario.IdUsuario).FirstOrDefault();

                    if (usuarioSinc != null)
                    {
                        usuarioSinc.Password = itemUsuario.Password;
                        usuarioSinc.PasswordSupervisor = itemUsuario.PasswordSupervisor;
                        usuarioSinc.PasswordSupervisorCajero = itemUsuario.PasswordSupervisorCajero;
                        usuarioSinc.Activo = itemUsuario.Activo;
                        usuarioSinc.CajaDefaultId = itemUsuario.CajaDefaultId;
                        usuarioSinc.EsSupervisor = itemUsuario.EsSupervisor;
                        usuarioSinc.EsSupervisorCajero = itemUsuario.EsSupervisorCajero;
                        usuarioSinc.NombreUsuario = itemUsuario.NombreUsuario;
                        usuarioSinc.IdSucursal = itemUsuario.IdSucursal;
                        usuarioSinc.Email = itemUsuario.Email;
                        context.SaveChanges();

                    }
                    else {
                        usuarioSinc = new cat_usuarios();

                        usuarioSinc.Password = itemUsuario.Password;
                        usuarioSinc.PasswordSupervisor = itemUsuario.PasswordSupervisor;
                        usuarioSinc.PasswordSupervisorCajero = itemUsuario.PasswordSupervisorCajero;
                        usuarioSinc.Activo = itemUsuario.Activo;
                        usuarioSinc.CajaDefaultId = itemUsuario.CajaDefaultId;
                        usuarioSinc.EsSupervisor = itemUsuario.EsSupervisor;
                        usuarioSinc.EsSupervisorCajero = itemUsuario.EsSupervisorCajero;
                        usuarioSinc.NombreUsuario = itemUsuario.NombreUsuario;
                        usuarioSinc.CreadoEl = itemUsuario.CreadoEl;
                        usuarioSinc.IdEmpleado = itemUsuario.IdEmpleado;
                        usuarioSinc.IdUsuario = itemUsuario.IdUsuario;
                        usuarioSinc.IdSucursal = itemUsuario.IdSucursal;
                        usuarioSinc.Email = itemUsuario.Email;

                        context.cat_usuarios.Add(usuarioSinc);
                        context.SaveChanges();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;
            }
        }

        public bool ImportUsuariosSucursales(ref ERPProdEntities context, List<cat_usuarios_sucursales> lstUsuariosSucursales)
        {
            try
            {
                foreach (cat_usuarios_sucursales itemUsuario in lstUsuariosSucursales)
                {
                    cat_usuarios_sucursales usuarioSinc = context.cat_usuarios_sucursales
                        
                        .Where(w => w.SucursalId == itemUsuario.SucursalId && 
                        w.UsuarioId == itemUsuario.UsuarioId).FirstOrDefault();

                    if (usuarioSinc == null)
                    {
                        usuarioSinc = new cat_usuarios_sucursales();

                        usuarioSinc.CreadoEl = DateTime.Now;
                        usuarioSinc.SucursalId = itemUsuario.SucursalId;
                        usuarioSinc.UsuarioId = itemUsuario.UsuarioId;

                        context.cat_usuarios_sucursales.Add(usuarioSinc);
                        

                    }
                  
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;
            }
        }

        public bool ImportLineas(ref ERPProdEntities context, List<cat_lineas> lstLineasOri)
        {
            try
            {

                foreach (cat_lineas itemLinea in lstLineasOri)
                {
                    cat_lineas lineaSinc = context.cat_lineas
                        .Where(w => w.Clave == itemLinea.Clave).FirstOrDefault();

                    if (lineaSinc != null)
                    {
                        lineaSinc.Descripcion = itemLinea.Descripcion;
                        lineaSinc.Empresa = itemLinea.Empresa;
                        lineaSinc.Estatus = itemLinea.Estatus;
                        lineaSinc.Sucursal = itemLinea.Sucursal;                       

                        context.SaveChanges();
                    }
                    else
                    {
                        lineaSinc = new cat_lineas();
                        lineaSinc.Descripcion = itemLinea.Descripcion;
                        lineaSinc.Empresa = itemLinea.Empresa;
                        lineaSinc.Estatus = itemLinea.Estatus;
                        lineaSinc.Sucursal = itemLinea.Sucursal;
                        lineaSinc.Clave = itemLinea.Clave;
                        context.cat_lineas.Add(lineaSinc);
                        context.SaveChanges();
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;

            }
        }

        public bool ImportFamilias(ref ERPProdEntities context, List<cat_familias> lstFamiliasOri)
        {
            try
            {

                foreach (cat_familias itemFamilia in lstFamiliasOri)
                {
                    cat_familias familiaSinc = context.cat_familias
                        .Where(w => w.Clave == itemFamilia.Clave).FirstOrDefault();

                    if (familiaSinc != null)
                    {
                        familiaSinc.Descripcion = itemFamilia.Descripcion;
                        familiaSinc.Empresa = itemFamilia.Empresa;
                        familiaSinc.Estatus = itemFamilia.Estatus;
                        familiaSinc.Orden = itemFamilia.Orden;
                        familiaSinc.ProductoPortadaId = itemFamilia.ProductoPortadaId;
                        familiaSinc.Sucursal = itemFamilia.Sucursal;
                        
                        context.SaveChanges();
                    }
                    else
                    {
                        familiaSinc = new cat_familias();
                        familiaSinc.Descripcion = itemFamilia.Descripcion;
                        familiaSinc.Empresa = itemFamilia.Empresa;
                        familiaSinc.Estatus = itemFamilia.Estatus;
                        familiaSinc.Orden = itemFamilia.Orden;
                        familiaSinc.ProductoPortadaId = itemFamilia.ProductoPortadaId;
                        familiaSinc.Sucursal = itemFamilia.Sucursal;
                        familiaSinc.Clave = itemFamilia.Clave;
                        context.cat_familias.Add(familiaSinc);
                        context.SaveChanges();
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;

            }
        }

        public bool ImportSubFamilias(ref ERPProdEntities context, List<cat_subfamilias> lstSubFamiliasOri)
        {
            try
            {

                foreach (cat_subfamilias itemSubFamilia in lstSubFamiliasOri)
                {
                    cat_subfamilias subfamiliaSinc = context.cat_subfamilias
                        .Where(w => w.Clave == itemSubFamilia.Clave).FirstOrDefault();

                    if (subfamiliaSinc != null)
                    {
                        subfamiliaSinc.Descripcion = itemSubFamilia.Descripcion;
                        subfamiliaSinc.Empresa = itemSubFamilia.Empresa;
                        subfamiliaSinc.Estatus = itemSubFamilia.Estatus;
                        subfamiliaSinc.Familia = itemSubFamilia.Familia;
                        subfamiliaSinc.Sucursal = itemSubFamilia.Sucursal;                       

                        context.SaveChanges();
                    }
                    else
                    {
                        subfamiliaSinc = new cat_subfamilias();

                        subfamiliaSinc.Descripcion = itemSubFamilia.Descripcion;
                        subfamiliaSinc.Empresa = itemSubFamilia.Empresa;
                        subfamiliaSinc.Estatus = itemSubFamilia.Estatus;
                        subfamiliaSinc.Familia = itemSubFamilia.Familia;
                        subfamiliaSinc.Sucursal = itemSubFamilia.Sucursal;
                        subfamiliaSinc.Clave = itemSubFamilia.Clave;
                        context.cat_subfamilias.Add(subfamiliaSinc);
                        context.SaveChanges();
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;

            }
        }

        public bool ImportProductos(ref ERPProdEntities context, List<cat_productos> lstProductosOri)
        {
            try
            {

                foreach (cat_productos itemProducto in lstProductosOri)
                {
                    cat_productos productosSinc = context.cat_productos
                        .Where(w => w.ProductoId == itemProducto.ProductoId).FirstOrDefault();

                    if (productosSinc != null)
                    {
                        productosSinc.ClaveAlmacen = itemProducto.ClaveAlmacen;
                        productosSinc.ClaveAnden = itemProducto.ClaveAnden;
                        productosSinc.ClaveFamilia = itemProducto.ClaveFamilia;
                        productosSinc.ClaveInventariadoPor = itemProducto.ClaveInventariadoPor;
                        productosSinc.ClaveLinea = itemProducto.ClaveLinea;
                        productosSinc.ClaveLote = itemProducto.ClaveLote;
                        productosSinc.ClaveMarca = itemProducto.ClaveMarca;
                        productosSinc.ClaveSubFamilia = itemProducto.ClaveSubFamilia;
                        productosSinc.ClaveUnidadMedida = itemProducto.ClaveUnidadMedida;
                        productosSinc.ClaveVendidaPor = itemProducto.ClaveVendidaPor;
                        productosSinc.CodigoBarras = itemProducto.CodigoBarras;
                        productosSinc.Color = itemProducto.Color;
                        productosSinc.Color2 = itemProducto.Color2;
                        productosSinc.ContenidoCaja = itemProducto.ContenidoCaja;
                        productosSinc.Descripcion = itemProducto.Descripcion;
                        productosSinc.DescripcionCorta = itemProducto.DescripcionCorta;
                        productosSinc.Empresa = itemProducto.Empresa;
                        productosSinc.Especificaciones = itemProducto.Especificaciones;
                        productosSinc.Estatus = itemProducto.Estatus;
                        productosSinc.FechaAlta = itemProducto.FechaAlta;
                        productosSinc.FechaCaducidad = itemProducto.FechaCaducidad;
                        productosSinc.Foto = itemProducto.Foto;
                        productosSinc.Inventariable = itemProducto.Inventariable;
                        productosSinc.Liquidacion = itemProducto.Liquidacion;
                        productosSinc.MateriaPrima = itemProducto.MateriaPrima;
                        productosSinc.MaximoInventario = itemProducto.MaximoInventario;
                        productosSinc.MinimoInventario = itemProducto.MinimoInventario;
                        productosSinc.NumeroDecimales = itemProducto.NumeroDecimales;
                        productosSinc.PorcUtilidad = itemProducto.PorcUtilidad;
                        productosSinc.ProdParaVenta = itemProducto.ProdParaVenta;
                        productosSinc.ProductoTerminado = itemProducto.ProductoTerminado;
                        productosSinc.ProdVtaBascula = itemProducto.ProdVtaBascula;
                        productosSinc.Seriado = itemProducto.Seriado;
                        productosSinc.SobrePedido = itemProducto.SobrePedido;
                        productosSinc.Sucursal = itemProducto.Sucursal;
                        

                        context.SaveChanges();
                    }
                    else
                    {
                        productosSinc = new cat_productos();
                        productosSinc.ClaveAlmacen = itemProducto.ClaveAlmacen;
                        productosSinc.ClaveAnden = itemProducto.ClaveAnden;
                        productosSinc.ClaveFamilia = itemProducto.ClaveFamilia;
                        productosSinc.ClaveInventariadoPor = itemProducto.ClaveInventariadoPor;
                        productosSinc.ClaveLinea = itemProducto.ClaveLinea;
                        productosSinc.ClaveLote = itemProducto.ClaveLote;
                        productosSinc.ClaveMarca = itemProducto.ClaveMarca;
                        productosSinc.ClaveSubFamilia = itemProducto.ClaveSubFamilia;
                        productosSinc.ClaveUnidadMedida = itemProducto.ClaveUnidadMedida;
                        productosSinc.ClaveVendidaPor = itemProducto.ClaveVendidaPor;
                        productosSinc.CodigoBarras = itemProducto.CodigoBarras;
                        productosSinc.Color = itemProducto.Color;
                        productosSinc.Color2 = itemProducto.Color2;
                        productosSinc.ContenidoCaja = itemProducto.ContenidoCaja;
                        productosSinc.Descripcion = itemProducto.Descripcion;
                        productosSinc.DescripcionCorta = itemProducto.DescripcionCorta;
                        productosSinc.Empresa = itemProducto.Empresa;
                        productosSinc.Especificaciones = itemProducto.Especificaciones;
                        productosSinc.Estatus = itemProducto.Estatus;
                        productosSinc.FechaAlta = itemProducto.FechaAlta;
                        productosSinc.FechaCaducidad = itemProducto.FechaCaducidad;
                        productosSinc.Foto = itemProducto.Foto;
                        productosSinc.Inventariable = itemProducto.Inventariable;
                        productosSinc.Liquidacion = itemProducto.Liquidacion;
                        productosSinc.MateriaPrima = itemProducto.MateriaPrima;
                        productosSinc.MaximoInventario = itemProducto.MaximoInventario;
                        productosSinc.MinimoInventario = itemProducto.MinimoInventario;
                        productosSinc.NumeroDecimales = itemProducto.NumeroDecimales;
                        productosSinc.PorcUtilidad = itemProducto.PorcUtilidad;
                        productosSinc.ProdParaVenta = itemProducto.ProdParaVenta;
                        productosSinc.ProductoTerminado = itemProducto.ProductoTerminado;
                        productosSinc.ProdVtaBascula = itemProducto.ProdVtaBascula;
                        productosSinc.Seriado = itemProducto.Seriado;
                        productosSinc.SobrePedido = itemProducto.SobrePedido;
                        productosSinc.Sucursal = itemProducto.Sucursal;
                        productosSinc.ProductoId = itemProducto.ProductoId;
                        context.cat_productos.Add(productosSinc);
                        context.SaveChanges();
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;

            }
        }

        public bool ImportProductosPrecios(ref ERPProdEntities context, List<cat_productos_precios> lstProductosPreciosOri)
        {
            try
            {

                foreach (cat_productos_precios itemProductoPrecio in lstProductosPreciosOri)
                {
                    cat_productos_precios productoPrecioSinc = context.cat_productos_precios
                        .Where(w => w.IdProductoPrecio == itemProductoPrecio.IdProductoPrecio).FirstOrDefault();

                    if (productoPrecioSinc != null)
                    {
                        productoPrecioSinc.IdPrecio = itemProductoPrecio.IdPrecio;
                        productoPrecioSinc.IdProducto = itemProductoPrecio.IdProducto;
                        productoPrecioSinc.MontoDescuento = itemProductoPrecio.MontoDescuento;
                        productoPrecioSinc.PorcDescuento = itemProductoPrecio.PorcDescuento;
                        productoPrecioSinc.Precio = itemProductoPrecio.Precio;                        

                        context.SaveChanges();
                    }
                    else
                    {
                        productoPrecioSinc = new cat_productos_precios();

                        productoPrecioSinc.IdPrecio = itemProductoPrecio.IdPrecio;
                        productoPrecioSinc.IdProducto = itemProductoPrecio.IdProducto;
                        productoPrecioSinc.MontoDescuento = itemProductoPrecio.MontoDescuento;
                        productoPrecioSinc.PorcDescuento = itemProductoPrecio.PorcDescuento;
                        productoPrecioSinc.Precio = itemProductoPrecio.Precio;


                        context.cat_productos_precios.Add(productoPrecioSinc);
                        context.SaveChanges();
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                          "ERP",
                                                          "ERP.Business.SincronizacionBusiness.ImportEmpresas",
                                                          ex);

                return false;

            }
        }


        public bool ImportTiposCajas(ref ERPProdEntities context, List<cat_tipos_cajas> lstTiposCajas)
        {
            try
            {
                foreach (cat_tipos_cajas itemTipoCaja in lstTiposCajas)
                {
                    cat_tipos_cajas tipoCajaSinc = context.cat_tipos_cajas
                        
                        .Where(w => w.TipoCajaId == itemTipoCaja.TipoCajaId)
                        .FirstOrDefault();

                    if (tipoCajaSinc != null)
                    {
                        tipoCajaSinc.Nombre = itemTipoCaja.Nombre;
                        tipoCajaSinc.Activo = itemTipoCaja.Activo;
                        context.SaveChanges();
                    }
                    else
                    {
                        tipoCajaSinc = new cat_tipos_cajas();
                       
                        tipoCajaSinc.TipoCajaId = itemTipoCaja.TipoCajaId;
                        tipoCajaSinc.Nombre = itemTipoCaja.Nombre;
                        tipoCajaSinc.Activo = itemTipoCaja.Activo;
                        // Puedes asignar otras propiedades según sea necesario
                        context.cat_tipos_cajas.Add(tipoCajaSinc);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                              "ERP",
                                                              "ERP.Business.SincronizacionBusiness.ImportTiposCajas",
                                                              ex);

                return false;
            }
        }

        public bool ImportEmpleados(ref ERPProdEntities context, List<rh_empleados> lstEmpleados)
        {
            try
            {
                foreach (rh_empleados itemEmpleado in lstEmpleados)
                {
                    rh_empleados empleadoSinc = context.rh_empleados
                       
                        .Where(w => w.NumEmpleado == itemEmpleado.NumEmpleado)
                        .FirstOrDefault();

                    if (empleadoSinc != null)
                    {
                        empleadoSinc.Nombre = itemEmpleado.Nombre;
                        empleadoSinc.SueldoNeto = itemEmpleado.SueldoNeto;
                        empleadoSinc.SueldoDiario = itemEmpleado.SueldoDiario;
                        empleadoSinc.SueldoHra = itemEmpleado.SueldoHra;
                        empleadoSinc.FormaPago = itemEmpleado.FormaPago;
                        empleadoSinc.TipoContrato = itemEmpleado.TipoContrato;
                        empleadoSinc.Puesto = itemEmpleado.Puesto;
                        empleadoSinc.Departamento = itemEmpleado.Departamento;
                        empleadoSinc.FechaIngreso = itemEmpleado.FechaIngreso;
                        empleadoSinc.FechaInicioLab = itemEmpleado.FechaInicioLab;
                        empleadoSinc.Estatus = itemEmpleado.Estatus;
                        empleadoSinc.Foto = itemEmpleado.Foto;
                        empleadoSinc.Empresa = itemEmpleado.Empresa;
                        empleadoSinc.Sucursal = itemEmpleado.Sucursal;

                        // Puedes asignar otras propiedades según sea necesario

                        context.SaveChanges();
                    }
                    else
                    {
                        empleadoSinc = new rh_empleados();

                        empleadoSinc.NumEmpleado = itemEmpleado.NumEmpleado;
                        empleadoSinc.Nombre = itemEmpleado.Nombre;
                        empleadoSinc.SueldoNeto = itemEmpleado.SueldoNeto;
                        empleadoSinc.SueldoDiario = itemEmpleado.SueldoDiario;
                        empleadoSinc.SueldoHra = itemEmpleado.SueldoHra;
                        empleadoSinc.FormaPago = itemEmpleado.FormaPago;
                        empleadoSinc.TipoContrato = itemEmpleado.TipoContrato;
                        empleadoSinc.Puesto = itemEmpleado.Puesto;
                        empleadoSinc.Departamento = itemEmpleado.Departamento;
                        empleadoSinc.FechaIngreso = itemEmpleado.FechaIngreso;
                        empleadoSinc.FechaInicioLab = itemEmpleado.FechaInicioLab;
                        empleadoSinc.Estatus = itemEmpleado.Estatus;
                        empleadoSinc.Foto = itemEmpleado.Foto;
                        empleadoSinc.Empresa = itemEmpleado.Empresa;
                        empleadoSinc.Sucursal = itemEmpleado.Sucursal;

                        // Puedes asignar otras propiedades según sea necesario

                        context.rh_empleados.Add(empleadoSinc);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                              "ERP",
                                                              "ERP.Business.SincronizacionBusiness.ImportEmpleados",
                                                              ex);

                return false;
            }
        }

        public bool ImportPuestos(ref ERPProdEntities context, List<rh_puestos> lstPuestos)
        {
            try
            {
                foreach (rh_puestos itemPuesto in lstPuestos)
                {
                    rh_puestos puestoSinc = context.rh_puestos
                        
                        .Where(w => w.Clave == itemPuesto.Clave)
                        .FirstOrDefault();

                    if (puestoSinc != null)
                    {
                        puestoSinc.Descripcion = itemPuesto.Descripcion;
                        puestoSinc.Estatus = itemPuesto.Estatus;
                        puestoSinc.Empresa = itemPuesto.Empresa;
                        puestoSinc.Sucursal = itemPuesto.Sucursal;
                        puestoSinc.PermitirEliminar = itemPuesto.PermitirEliminar;
                        puestoSinc.Mostrar = itemPuesto.Mostrar;

                        // Puedes asignar otras propiedades según sea necesario

                        context.SaveChanges();
                    }
                    else
                    {
                        puestoSinc = new rh_puestos();

                        puestoSinc.Clave = itemPuesto.Clave;
                        puestoSinc.Descripcion = itemPuesto.Descripcion;
                        puestoSinc.Estatus = itemPuesto.Estatus;
                        puestoSinc.Empresa = itemPuesto.Empresa;
                        puestoSinc.Sucursal = itemPuesto.Sucursal;
                        puestoSinc.PermitirEliminar = itemPuesto.PermitirEliminar;
                        puestoSinc.Mostrar = itemPuesto.Mostrar;

                        // Puedes asignar otras propiedades según sea necesario

                        context.rh_puestos.Add(puestoSinc);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                              "ERP",
                                                              "ERP.Business.SincronizacionBusiness.ImportPuestos",
                                                              ex);

                return false;
            }
        }


    }
}
