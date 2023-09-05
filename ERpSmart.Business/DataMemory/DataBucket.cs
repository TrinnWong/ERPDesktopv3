using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERP.Business.Enumerados;

namespace ERP.Business.DataMemory
{
    public  class DataBucket
    {
        public static string ConnectionString { get; set; }
        public static List<cat_productos> lstProductos;
        public static List<cat_productos> lstProductosProduccion;
        public static List<cat_familias> lstFamilias;
        public static List<doc_clientes_productos_precios> lstClientesProductosPrecios;
        public static cat_impresoras entityImpresoraComanda;
        public static cat_impresoras entityImpresoraCaja;
        public static cat_configuracion entityConfiguracion;
        public static List<cat_productos>  GetProductosMemory(bool refresh)
        {
            
            if(lstProductos == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                lstProductos = oContext.cat_productos.Where(w=> w.Estatus == true).ToList();

            }

            return lstProductos;
        }
        public static List<cat_productos> GetProductosMemory(int sucursalId,bool refresh)
        {

            if (lstProductos == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                if(oContext.cat_sucursales_productos.Where(w=> w.SucursalId == sucursalId).Count() > 0)
                {
                    lstProductos = oContext.cat_productos.Where(w => w.Estatus == true && w.cat_sucursales_productos
                    .Where(s1 => s1.SucursalId == sucursalId).Count() > 0).ToList();
                }
                else
                {
                    lstProductos = oContext.cat_productos.Where(w => w.Estatus == true).ToList();
                }

                

            }

            return lstProductos;
        }


        public static List<cat_productos> GetProductosProduccionMemory(bool refresh, tipoProductoProduccion tipo)
        {

            if (lstProductosProduccion == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                lstProductosProduccion = oContext.cat_productos.Where(w => w.cat_productos_base.Count > 0).ToList();

            }

            if(tipo == tipoProductoProduccion.COCINA)
            {
                return lstProductosProduccion.Where(w=> w.cat_productos_base.Where(w1=> w1.ParaCocina == true).Count()>0).ToList();
            }
            if (tipo == tipoProductoProduccion.OTRO)
            {
                return lstProductosProduccion.Where(w => w.cat_productos_base.Where(w1 => (w1.ParaCocina??false) == false).Count() > 0).ToList();
            }
            else
            {
                return lstProductosProduccion;
            }

        }

        public static List<cat_familias> GetFamiliasMemory(bool refresh)
        {

            if (lstFamilias == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                lstFamilias = oContext.cat_familias.OrderBy(o=> o.Descripcion).ToList();

            }

            return lstFamilias;
        }

        public static List<doc_clientes_productos_precios> GetClientesProductosPrecios(bool refresh)
        {

            if (lstClientesProductosPrecios == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                lstClientesProductosPrecios = oContext.doc_clientes_productos_precios
                    .Where(w=> w.cat_clientes.Activo == true)
                    .ToList();

            }

            return lstClientesProductosPrecios;
        }

        public static cat_configuracion GetConfiguracion( bool refresh)
        {
            if (entityConfiguracion == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                entityConfiguracion = oContext.cat_configuracion.FirstOrDefault();



            }

            return entityConfiguracion;
        }

        public static cat_impresoras GetImpresoraComanda(int sucursalId, bool refresh)
        {
            if (entityImpresoraComanda == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                entityImpresoraComanda = oContext.cat_impresoras
                 .Where(w => w.SucursalId == sucursalId &&
                 w.cat_impresoras_comandas != null).FirstOrDefault();



            }

            return entityImpresoraComanda;
        }

        public static cat_impresoras GetImpresoraCaja(int cajaId, bool refresh)
        {
            if (entityImpresoraCaja == null || refresh)
            {
                ERPProdEntities oContext = new ERPProdEntities();

                entityImpresoraCaja = oContext.cat_impresoras
                .Where(
                w => w.cat_cajas_impresora.Where(s1 => s1.CajaId == cajaId).Count() > 0
                ).FirstOrDefault();



            }

            return entityImpresoraComanda;
        }

        public static void ClearData()
        {
            lstProductos = null;
            lstFamilias = null;
            lstClientesProductosPrecios = null;
            entityImpresoraCaja = null;
            entityImpresoraComanda = null;
        }

        public static void LoadAll()
        {
            GetProductosMemory(true);
            GetProductosProduccionMemory(true, tipoProductoProduccion.TODO);
            GetClientesProductosPrecios(true);           
            GetFamiliasMemory(true);
        }
    }
}
