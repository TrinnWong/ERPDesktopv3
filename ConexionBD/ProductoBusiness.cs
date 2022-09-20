using ConexionBD.Models;
using ERP.Models;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionBD
{
    public class ProductoBusiness:BusinessObject
    {
        public ProductoBusiness()
        {

        }

        public List<ERP.Models.ProductoModel> GetList()
        {
            List<ERP.Models.ProductoModel> result = new List<ERP.Models.ProductoModel>();
            try
            {
                result = oContext.cat_productos
                    .Where(w=> w.ProductoId > 0)
                    .Select(
                         s => new ERP.Models.ProductoModel()
                         {
                             activo = s.Estatus ?? false,
                             clave = s.Clave,
                             descripcion = s.Descripcion,
                             productoId = s.ProductoId
                         }
                    ).OrderByDescending(o=> o.productoId).ToList();
            }
            catch (Exception ex)
            {

                
            }

            return result;
        }

        public ERP.Models.ProductoModel Get(int productoId)
        {
            ERP.Models.ProductoModel result = new ERP.Models.ProductoModel();
            try
            {
                result = oContext.cat_productos
                    .Where(w => w.ProductoId == productoId)
                    .Select(
                         s => new ERP.Models.ProductoModel()
                         {
                             activo = s.Estatus ?? false,
                             clave = s.Clave,
                             descripcion = s.Descripcion,
                             productoId = s.ProductoId
                         }
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {


            }

            return result;
        }

        public ResultAPIModel Add(ERP.Models.ProductoModel producto)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                string clave = producto.clave;
                if (producto.descripcion.Length == 0)
                {
                    result.error = "La descripción es requerida";
                }
                if (producto.clave.Length == 0)
                {
                    result.error = "La descripción es requerida";
                }

                if(result.error.Length > 0)
                {
                    return result;
                }

                cat_productos entity = new cat_productos();

                entity = oContext.cat_productos.Where(w => w.Clave == clave).FirstOrDefault();

                if(entity != null)
                {
                    result.error = "Ya existe un articulo con la clave";
                    return result;
                }

                entity = new cat_productos();

                entity.ProductoId = oContext.cat_productos.Max(m => (int?)m.ProductoId ?? 0) + 1;
                entity.Clave = producto.clave;
                entity.Descripcion = producto.descripcion;
                entity.DescripcionCorta = producto.descripcion;
                entity.Estatus = true;
                entity.ClaveFamilia = (int)Enumerados.Familia.SinDefinir;
                entity.ClaveSubFamilia = (int)Enumerados.SubFamilia.SinDefinir;
                entity.ClaveLinea = (int)Enumerados.Lineas.SinDefinir;
                
                oContext.cat_productos.Add(entity);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ResultAPIModel Edit(ERP.Models.ProductoModel producto)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                string clave = producto.clave;
                int productoId = producto.productoId;
                if (producto.descripcion.Length == 0)
                {
                    result.error = "La descripción es requerida";
                }
                if (producto.clave.Length == 0)
                {
                    result.error = "La descripción es requerida";
                }

                if (result.error.Length > 0)
                {
                    return result;
                }

                cat_productos entity = new cat_productos();

                entity = oContext.cat_productos.Where(w => w.Clave == clave && w.ProductoId != productoId).FirstOrDefault();

                if (entity != null)
                {
                    result.error = "Ya existe un articulo con la clave";
                    return result;
                }

                entity = oContext.cat_productos.Where(w => w.ProductoId == productoId).FirstOrDefault();               
                
                entity.Descripcion = producto.descripcion;
                entity.DescripcionCorta = producto.descripcion;                
                entity.ClaveFamilia = (int)Enumerados.Familia.SinDefinir;
                entity.ClaveSubFamilia = (int)Enumerados.SubFamilia.SinDefinir;
                entity.ClaveLinea = (int)Enumerados.Lineas.SinDefinir;
                entity.Estatus = producto.activo;
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public  string ImportarProductosConfigInicial(string path,PuntoVentaContext puntoVentaContext, ref Guid uuid)
        {
            string error = "";
            uuid = Guid.NewGuid();
            try
            {
                oContext = new ERPProdEntities();


                string ruta = path;// Application.StartupPath + "\\Files\\cargaProductos.xlsx"; ;

                var book = new ExcelQueryFactory(ruta);

                var shetNames = book.GetWorksheetNames().ToList();

                List<ProductoImportacionModel> lstImportacion = new List<ProductoImportacionModel>();
                List<ProductoImportacionModel> lstImportacionFor = new List<ProductoImportacionModel>();
                bool formato2 = false;

                int i = 0;

                foreach (var nameSheet in shetNames)
                {

                    if (i > 0)
                    {
                        break;
                    }
                    i++;
                    var workS = book.Worksheet(nameSheet);
                    int columnas = 0;
                    try
                    {
                        columnas = workS.FirstOrDefault().Count;
                        formato2 = true;
                    }
                    catch (Exception)
                    {

                    }

                    var lstWork = workS.ToList();
                    for (int iRow = 0; iRow < lstWork.Count()-1; iRow++)
                    {
                       
                            ProductoImportacionModel row = new ProductoImportacionModel();


                            if ((lstWork[iRow][0] == null ? "" : lstWork[iRow][0].ToString()).Length > 0)
                            {

                            row.descripcionCorta = columnas > 0 ? lstWork[iRow][0].ToString() : "";
                            row.descripcionLarga = columnas > 0 ? lstWork[iRow][0].ToString() : "";
                            row.linea = columnas > 1 ? lstWork[iRow][1].ToString() : "";
                            row.familia = columnas > 2 ? lstWork[iRow][2].ToString() : "";
                            row.existencias = columnas > 3 ? decimal.Parse(lstWork[iRow][3].ToString()) : 0;
                            row.costoUltimaCompra = columnas > 5 ? float.Parse(lstWork[iRow][5].ToString()) : 0;
                            row.precio = columnas > 4 ? decimal.Parse(lstWork[iRow][4].ToString()) : 0;

                            row.claveProducto = columnas > 6 ? lstWork[iRow][6].ToString() : "";
                            row.subfamilia = columnas > 7 ? lstWork[iRow][7].ToString() : "";
                            row.iva = columnas > 8 ? int.Parse(lstWork[iRow][8].ToString()) : 0;
                            row.unidad = columnas > 9 ? lstWork[iRow][9].ToString() : "";
                                row.marca = columnas > 10 ? lstWork[iRow][10].ToString() : "";
                                
                               row.materiaPrima = columnas > 11 ? (int.Parse(lstWork[iRow][11].ToString())==1?true:false) : false;
                                row.prodParaVenta = columnas > 12 ? (int.Parse(lstWork[iRow][12].ToString())==1?true:false) : true;
                                /*row.unidadLicencia = columnas > 13 ? lstWork[iRow][13].ToString() : "";
                               row.tiempoLicencia = columnas > 14 ? short.Parse((lstWork[iRow][14] == "" ? "0": lstWork[iRow][14]).ToString()) : (short)0;
                                row.version = columnas > 15 ? lstWork[iRow][15].ToString() : "";*/
                                row.descripcionCorta = columnas > 13 ? lstWork[iRow][13].ToString() : "";
                             row.costoPromedio = columnas > 14 ? float.Parse(lstWork[iRow][14].ToString()) : 0;
                            row.productoActivo = columnas > 15 ? (int.Parse(lstWork[iRow][15].ToString()) == 1 ? true : false) : true;
                            row.productoTerminado = columnas > 16 ? (int.Parse(lstWork[iRow][16].ToString()) == 1 ? true : false) : true;
                            row.productoInventariable = columnas > 17 ? (int.Parse(lstWork[iRow][17].ToString()) == 1 ? true : false) : true;
                            row.productoBascula = columnas > 18 ? (int.Parse(lstWork[iRow][18].ToString()) == 1 ? true : false) : true;
                            row.productoSeriado = columnas > 19 ? (int.Parse(lstWork[iRow][19].ToString()) == 1 ? true : false) : true;
                            row.unidadInvetario = columnas > 20 ? lstWork[iRow][20].ToString() : "";
                            row.unidadVenta = columnas > 21 ? lstWork[iRow][21].ToString() : "";
                            row.minimoInventario = columnas > 22 ? float.Parse(lstWork[iRow][22].ToString()) : 0;
                            row.maximoInventario = columnas > 23 ? float.Parse(lstWork[iRow][23].ToString()) : 0;
                            row.cantidadProductoCaja = columnas > 24 ? float.Parse(lstWork[iRow][24].ToString()) : 0;
                            row.codigoBarras = columnas > 25 ? lstWork[iRow][25].ToString():"";
                            lstImportacionFor.Add(row);
                            }

                        
                    }

                    //lstImportacionFor =
                    //  workS
                    //  .Select(
                    //      s => new ProductoImportacionModel()
                    //      {
                    //          claveProducto = s[5].Cast<string>(),
                    //          descripcionCorta = s[0].Cast<string>(),
                    //          descripcionLarga = s[0].Cast<string>(),
                    //          existencias = s[3].Cast<decimal>(),
                    //          familia = s[2].Cast<string>(),
                    //          linea = s[1].Cast<string>(),
                    //          precio = s[4].Cast<decimal>(),
                    //          iva = s[7].Cast<int>(),
                    //          unidad = s[8].Cast<string>(),
                    //          marca = s[9].Cast<string>(),
                    //          subfamilia = s[6].Cast<string>(),
                    //          materiaPrima = columnas > 10 ? s[10].Cast<bool>() : false,
                    //          prodParaVenta = columnas > 11 ? s[11].Cast<bool>() :true,
                    //          unidadLicencia = columnas > 12 ?  s[12].Cast<string>() : "",
                    //          tiempoLicencia = columnas > 13 ? s[13].Cast<short>() : (short)0,
                    //          version = columnas > 14 ?  s[14].Cast<string>() : ""
                    //      }
                    //  ).ToList();


                 

                    lstImportacion = lstImportacion.Union(lstImportacionFor).ToList();
                }
                int empresa = puntoVentaContext.empresaId;
                int sucursal = puntoVentaContext.sucursalId;
                int usuarioId =puntoVentaContext.usuarioId;
                ObjectParameter pInsertado = new ObjectParameter("pInsertado", false);
                //using (TransactionScope scope = new TransactionScope())
                //{
                ObjectParameter pError = new ObjectParameter("pError", "");
                string prodActual = "";
                try
                {

                    //Revisar si ya se realizó una carga inicial o entrada directa
                    bool respuesta = false;
                    IList<ProductoImportacionModel> lstTran = lstImportacion.ToArray();


                    IList<ProductoImportacionModel> lstTran2 = lstTran.ToArray();
                    foreach (ProductoImportacionModel prod in lstTran2.Where(w=> w.claveProducto != null))
                    {
                        prodActual = prod.claveProducto;
                        pError = new ObjectParameter("pError", "");
                        oContext.p_productos_importacion(empresa, sucursal, prod.linea, prod.familia, prod.claveProducto,
                            prod.descripcionCorta, prod.descripcionLarga, prod.precio, prod.existencias,prod.costoPromedio, pInsertado, prod.iva, prod.unidad, prod.marca,
                            prod.subfamilia, prod.talla, prod.sexo, prod.color, prod.colorSecundario, false, usuarioId, uuid, prod.materiaPrima, prod.prodParaVenta,
                            prod.unidadLicencia,prod.tiempoLicencia,prod.version,prod.costoUltimaCompra,prod.productoActivo,
                            prod.productoTerminado,prod.productoInventariable,prod.productoBascula,prod.productoSeriado,
                            prod.unidadInvetario,prod.unidadVenta,prod.minimoInventario,prod.maximoInventario,prod.cantidadProductoCaja,prod.codigoBarras,pError);

                        if (pError.Value.ToString().Length >0)
                        {
                            error = error + "ERROR:No fue posible insertar el producto:" + prod.claveProducto + " \n\r";
                        }
                        else
                        {
                            oContext.SaveChanges();
                        }
                        

                    }

                    oContext.SaveChanges();

                    
                    //scope.Complete();
                   //error = error + "El proceso concluyó con éxito" + " \n\r";
                }
                catch (Exception ex)
                {
                    
                    error= error + "ERROR:Error al intentar insertar el producto " + prodActual + "," + ex.Message + " \n";

                }

                //}


            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return error;

        }
    }
}
