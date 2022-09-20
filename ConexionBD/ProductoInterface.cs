using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConexionBD
{
    public class ProductoInterface
    {
        Business con;
        Resultado resultado;
        ERPProdEntities model;

        public ProductoInterface()
        {
            con = new Business();
            model = new ERPProdEntities();
        }

        public DataTable ConsultarListado(string busqueda)
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select ProductoId, cp.Clave, cp.Descripcion [Producto],"+
                   " cp.DescripcionCorta[Descripción Corta], "+
                    " CASE when cp.Estatus = 1 then 'Activo' else 'Inactivo' end[Estatus], " +
                    " cud.Descripcion[Unidad de Medida], " +
                    " cip.Descripcion[Inventariado Por], " +
                    " cm.Descripcion[Marca], cf.Clave[Familia], csf.Descripcion[SubFamilia], " +
                    " cp.FechaAlta[Fecha Alta]  ,cvp.Descripcion[Vendido Por] " +
                    " FROM dbo.cat_productos cp left join cat_unidadesmed cud on cud.Clave = cp.ClaveUnidadMedida " +
                    " left join cat_unidadesmed cip on cip.Clave = cp.ClaveInventariadoPor " +
                    " LEFT join cat_marcas cm on cm.Clave = cp.ClaveMarca " +
                    " LEFT join cat_familias cf on cf.Clave = cp.ClaveFamilia " +
                    " LEFT join cat_subfamilias csf on csf.Clave = cp.ClaveSubFamilia " +
                    " LEFT join cat_unidadesmed cvp on cvp.Clave = cp.ClaveSubFamilia  ";

                comandoSelect = comandoSelect + "where cp.clave like '%"+busqueda+"%' OR cp.Descripcion like '%" + busqueda + "%'";

                tabla = "Producto";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar los datos. " + ex.Message;
            }
            return dt;
        }

        public DataTable ConsultarRegistro(int clave, bool verificarNoExistaClave)
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select ProductoId, Clave, Descripcion, DescripcionCorta, FechaAlta, ClaveMarca, ClaveFamilia, ClaveSubFamilia, ClaveLinea, "
                    + "ClaveUnidadMedida, ClaveInventariadoPor, ClaveVendidaPor, Estatus Estatus, ProductoTerminado, Inventariable, MateriaPrima, ProdParaVenta, "
                    + "	ProdVtaBascula, Seriado, NumeroDecimales, PorcDescuentoEmpleado, ContenidoCaja,foto,ClaveAlmacen,ClaveAnden,ClaveLote,FechaCaducidad, "
                    + " MaximoInventario=isnull(MaximoInventario,0), MinimoInventario = isnull(MinimoInventario,0),PorcUtilidad,talla,color,color2,especificaciones,SobrePedido "
                    + "from cat_productos "
                    + "where productoId " + (verificarNoExistaClave ? "!" : "") + "= " + clave;

                tabla = "Producto";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar el registro. " + ex.Message;
            }
            return dt;
        }

        public Resultado Agregar(string clave, string descripcion, string descripcionCorta, int claveMarca, int claveFamilia, int claveSubFamilia, int claveLinea,
            int claveUnidadMedida, int? claveInventariadoPor, int? claveVendidaPor, bool estatus, bool productoTerminado, bool inventariable, bool materiaPrima,
            bool prodParaVenta, bool prodVtaBascula, bool seriado, int numeroDecimales, decimal porcDesEmpleados, int contenidoCaja, byte[] foto, int? empresa, int? sucursal,
            int? almacen, int? anden, int? lote, DateTime? fechaCaducidad, decimal minimoInventario, decimal maximoInventario, decimal porcUtilidad,
            string talla, string color, string color2, string especificaciones,bool sobrePedido,            
            ref int productoId)
        {
            resultado = new Resultado();
            string comandoInsert = "";
            string strEmpresa = empresa == null ? "null" : empresa.ToString();
            string strSucursal = sucursal == null ? "null" : sucursal.ToString();
            string strFoto = foto == null ? "null" : "@Pic";


            fechaCaducidad = fechaCaducidad == DateTime.MinValue ? null : fechaCaducidad;
            claveInventariadoPor = claveInventariadoPor == 0 ? null : claveInventariadoPor;
            claveVendidaPor = claveVendidaPor == 0 ? null : claveVendidaPor;

            try
            {
                //comandoInsert = "insert into cat_productos "
                //                + "(ProductoId, Clave, DescripcionCorta, FechaAlta, ClaveMarca, ClaveFamilia, ClaveSubFamilia, ClaveLinea, ClaveUnidadMedida, ClaveInventariadoPor, ClaveVendidaPor, "
                //                + "Estatus, ProductoTerminado, Inventariable, MateriaPrima, ProdParaVenta, ProdVtaBascula, Seriado, NumeroDecimales, PorcDescuentoEmpleado, ContenidoCaja, Foto, Empresa, Sucursal) "
                //                + "values((select max(ProductoId) from cat_productos), '" + clave + "', '" + descripcion + "', '" + descripcionCorta + "', Getdate(), " + claveMarca + ", " + claveFamilia + ", " 
                //                + claveSubFamilia + ", " + claveLinea + ", " + claveUnidadMedida + ", " + claveInventariadoPor + ", " + claveVendidaPor + ", " + (estatus == true ? 1 : 0) + ", " 
                //                + (productoTerminado == true ? 1 : 0) + ", " + (inventariable == true ? 1 : 0) + ", " + (materiaPrima == true ? 1 : 0) + ", " + (prodParaVenta == true ? 1 : 0) + ", "
                //                + (prodVtaBascula == true ? 1 : 0) + ", " + (seriado == true ? 1 : 0) + ", "+ numeroDecimales + ", " + porcDesEmpleados + ", " + contenidoCaja + ", " + strFoto + ", " 
                //                + strEmpresa + ", " + strSucursal + ")";
                //resultado = con.Insert(comandoInsert);

                ObjectParameter param = new ObjectParameter("pProductoId", 0);
                model.p_cat_productos_ins(param, clave, descripcion, descripcionCorta, DateTime.Now, claveMarca, claveFamilia, claveSubFamilia, 
                    claveLinea, claveUnidadMedida, claveInventariadoPor,claveVendidaPor, estatus, productoTerminado, inventariable, materiaPrima, 
                    prodParaVenta, prodVtaBascula, seriado, (byte?)numeroDecimales, porcDesEmpleados,
                     contenidoCaja, empresa, sucursal, foto,almacen,anden,lote,fechaCaducidad,minimoInventario,maximoInventario, porcUtilidad,
                     talla,color,color2,especificaciones,sobrePedido);

                productoId = int.Parse(param.Value.ToString());
                resultado.ok = true;
                resultado.mensaje = "El registro fue guardado exitosamente";
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de insertar los datos. " + ex.Message;
            }
            return resultado;
        }

        public Resultado Actualizar(int productoId, string clave, string descripcion, string descripcionCorta, int claveMarca, int claveFamilia, int claveSubFamilia, int claveLinea,
            int claveUnidadMedida, int? claveInventariadoPor, int? claveVendidaPor, bool estatus, bool productoTerminado, bool inventariable, bool materiaPrima, bool prodParaVenta,
            bool prodVtaBascula, bool seriado, int numeroDecimales, decimal porcDescuentoEmpleado, int contenidoCaja, byte[] foto,
            int? almacen,int? anden,int? lote, DateTime? fechaCaducidad,decimal minimoInventario,decimal maximoInventario, decimal porcUtilidad,
            string talla, string color, string color2, string especificaciones,bool sobrePedido)
        {
            resultado = new Resultado();
            string comandoUpdate = "";
            try
            {
                claveInventariadoPor = claveInventariadoPor == 0 ? null : claveInventariadoPor;
                claveVendidaPor = claveVendidaPor == 0 ? null : claveVendidaPor;
                //comandoUpdate = "update cat_productos "
                //                + "set ProductoId = "+productoId+" Clave = '"+clave+"', Descripcion = '" + descripcion + "', DescripcionCorta = '" + descripcionCorta + "', ClaveMarca = "+ claveMarca
                //                + ", ClaveFamilia = " + claveFamilia + ", ClaveSubFamilia = " + claveSubFamilia + ", ClaveLinea = " + claveLinea + ", ClaveUnidadMedida = " + claveUnidadMedida + ", ClaveInventariadoPor = " + claveInventariadoPor
                //                + ", ClaveVendidaPor = " + claveVendidaPor + ", Estatus = " + (estatus == true ? 1 : 0) + ", ProductoTerminado = " + (productoTerminado == true ? 1 : 0) + ", Inventariable = " + (inventariable == true ? 1 : 0) 
                //                + ", MateriaPrima = " + (materiaPrima == true ? 1 : 0) + ", ProdParaVenta = " + (prodVtaBascula == true ? 1 : 0) + ", ProdVtaBascula = " + (prodVtaBascula == true ? 1 : 0) + ", Seriado = " + (seriado == true ? 1 : 0)
                //                + "where ProductoId = " + clave;
                //resultado = con.Update(comandoUpdate);
                model.p_cat_productos_upd(productoId, clave, descripcion, descripcionCorta, null, claveMarca, claveFamilia, claveSubFamilia, claveLinea, claveUnidadMedida, claveInventariadoPor,
                    claveVendidaPor, estatus, productoTerminado, inventariable, materiaPrima, prodParaVenta, prodVtaBascula, seriado, (byte?)numeroDecimales,
                    porcDescuentoEmpleado, contenidoCaja, null, null, foto,almacen,anden,lote,fechaCaducidad==DateTime.MinValue ? null: fechaCaducidad,minimoInventario,maximoInventario, porcUtilidad,
                    talla,color,color2,especificaciones,sobrePedido);

                resultado.ok = true;
                resultado.mensaje = "El registro fue guardado exitosamente";
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de actualizar los datos. " + ex.Message;
            }
            return resultado;
        }

        public Resultado Eliminar(int clave)
        {
            resultado = new Resultado();
            string comandoDelete = "";
            model = new ERPProdEntities();

            try
            {
                cat_productos entity = model.cat_productos.Where(w => w.ProductoId == clave).FirstOrDefault();

                entity.Estatus = false;               

                model.SaveChanges();

                resultado.ok = true;

                resultado.mensaje = "El producto ha sido dado de baja ";
            }
            catch (Exception ex)
            {

                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de eliminar los datos. " + ex.Message;
            }
            //try
            //{
            //    comandoDelete = string.Format("delete from cat_productos where ProductoId = {0}", clave);
            //    resultado = con.Delete(comandoDelete);
            //}
            //catch (Exception ex)
            //{
            //    resultado.ok = false;
            //    resultado.mensaje = "Ocurrió un error al tratar de eliminar los datos. " + ex.Message;
            //}


            return resultado;
        }

        #region ComboBox

        public DataTable ConsultaComboBox()
        {
            string comandoSelect = "", tabla = "";
            resultado = new Resultado();

            DataTable dt = new DataTable();
            try
            {
                comandoSelect = "select ProductoId, Clave, Descripcion from cat_productos where Estatus = 1";
                tabla = "Producto";

                dt = con.Select(comandoSelect, tabla);
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.mensaje = "Ocurrió un error al tratar de consultar los datos. " + ex.Message;
            }

            return dt;
        }

        #endregion

        #region preciosventa

        public string aplicarPrecioVenta(int productoId, decimal precioVenta)
        {
            string error = "";

            try
            {

                if (precioVenta <= 0)
                {
                    error = "El precio venta no puede ser cero";
                    return error;
                }
                model = new ERPProdEntities();
                cat_productos_precios entity;
                if (precioVenta > 0)
                {

                   
                    entity = model.cat_productos_precios.Where(
                            w => w.IdProducto == productoId &&
                            w.IdPrecio == (byte)Enumerados.precios.publicoGral
                        ).FirstOrDefault();

                    using (TransactionScope scope = new TransactionScope())
                    {
                        /**********insertar Historico*******************/
                        cat_productos_cambio_precio cambioPrecion = new cat_productos_cambio_precio();

                        cambioPrecion.Id = model.cat_productos_cambio_precio.Count() > 0? model.cat_productos_cambio_precio.Max(m => m.Id) + 1 : 1;

                        cambioPrecion.FechaRegistro = DateTime.Now;
                        cambioPrecion.PrecioId = (byte)Enumerados.precios.publicoGral;
                        cambioPrecion.PrecioNuevo = precioVenta;
                        cambioPrecion.PrecioAnterior = entity != null? (entity.Precio) : 0 ;
                        cambioPrecion.UsuarioRegistroId = null;
                        cambioPrecion.ProductoId = productoId;

                        model.cat_productos_cambio_precio.Add(cambioPrecion);

                        model.SaveChanges();

                        if (entity != null)
                        {
                            entity.Precio = precioVenta;
                            model.SaveChanges();
                        }
                        else
                        {

                            entity = new cat_productos_precios();

                            entity.IdProductoPrecio = model.cat_productos_precios.Count() > 0 ?
                                                model.cat_productos_precios.Max(m => m.IdProductoPrecio) + 1 : 1;
                            entity.IdPrecio = (byte)Enumerados.precios.publicoGral;
                            entity.IdProducto = productoId;
                            entity.MontoDescuento = 0;
                            entity.PorcDescuento = 0;
                            entity.Precio = precioVenta;

                            model.cat_productos_precios.Add(entity);

                            model.SaveChanges();


                        }


                        scope.Complete();
                    }

                  
                }

                
            }
            catch (Exception ex)
            {
                error = ex.Message;

                
            }

            return error;
            
        }

        public string modificarPrecioProducto(int precioId,int productoId,
            decimal descuento,
            ref decimal montoDescuento,
            ref decimal precioNuevo
            )
        {

            string error = "";
            try
            {

                if (descuento > 100)
                {
                    error = "El procentaje de descuento no es válido";
                }
                model = new ERPProdEntities();
                cat_productos_precios entityPrecioVta = model.cat_productos_precios.Where(
                     w => w.IdPrecio == (byte)Enumerados.precios.publicoGral &&
                     w.IdProducto == productoId
                     ).FirstOrDefault();

                if (entityPrecioVta != null)
                {
                    decimal precioVenta = entityPrecioVta.Precio;

                   montoDescuento = precioVenta * (descuento / 100);
                    precioNuevo = precioVenta - montoDescuento;

                    cat_productos_precios entityPrecioSel = model.cat_productos_precios.Where(
                   w => w.IdPrecio == precioId &&
                   w.IdProducto == productoId
                   ).FirstOrDefault();

                    if (entityPrecioSel != null)
                    {
                        entityPrecioSel.Precio = precioVenta - montoDescuento;
                        entityPrecioSel.MontoDescuento = montoDescuento;
                        entityPrecioSel.PorcDescuento = descuento;
                        model.SaveChanges();
                    }
                    else {
                        entityPrecioSel = new cat_productos_precios();

                        entityPrecioSel.IdProductoPrecio = model.cat_productos_precios.Count() > 0 ?
                                            model.cat_productos_precios.Max(m => m.IdProductoPrecio) + 1 : 1;
                        entityPrecioSel.IdPrecio = (byte)precioId;
                        entityPrecioSel.IdProducto = productoId;
                        entityPrecioSel.MontoDescuento = montoDescuento;
                        entityPrecioSel.PorcDescuento = descuento;
                        entityPrecioSel.Precio = precioNuevo;

                        model.cat_productos_precios.Add(entityPrecioSel);

                        model.SaveChanges();
                    }

                  


                }
                else {
                    error = "No fue posible encontrar el precio de venta";
                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string agregarImpuesto(int productoId, int impuestoId) {


            string error = "";

            try
            {
                model = new ERPProdEntities();
                cat_productos_impuestos entity = model.cat_productos_impuestos
                    .Where(w => w.ProductoId == productoId && w.ImpuestoId == impuestoId).FirstOrDefault();

                if (entity == null)
                {
                    entity = new cat_productos_impuestos();

                    entity.ProductoImpuestoId = model.cat_productos_impuestos.Count() > 0 ?
                        model.cat_productos_impuestos.Max(m => m.ProductoImpuestoId) + 1 :
                        1;

                    entity.ImpuestoId = impuestoId;
                    entity.ProductoId = productoId;

                    model.cat_productos_impuestos.Add(entity);

                    model.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
            

        }
        #endregion


        public static void buscarPromocion(int productoId, int sucursalId, ref int promocionId, ref decimal porcentajePromocion)
        {
            ERPProdEntities oContext = new ERPProdEntities();
            var result = oContext.p_producto_promocion_sel(sucursalId, productoId,0,0).FirstOrDefault();

            if (result != null)
            {
                porcentajePromocion = result.PorcentajeDescuento;
                promocionId = result.PromocionId;
            }
        }


        public string importarImagenes(string pathImages)
        {
            string error = "";

            try
            {
                var archivos = System.IO.Directory.GetFiles(pathImages);

                foreach (var file in archivos)
                {
                    string fileNameExt = Path.GetFileName(file.ToString());
                    string fileName =  Path.GetFileNameWithoutExtension(file.ToString());
                    string[] fileNameSplit = fileName.Split('_');
                    string claveProd = fileNameSplit[0];
                    cat_productos entityProducto = model.cat_productos
                        .Where(w => w.Clave == claveProd).FirstOrDefault();

                    if (entityProducto != null)
                    {
                        byte[] imageByte = File.ReadAllBytes(file);
                        int productoId = entityProducto.ProductoId;
                        if (imageByte.Length > 0)
                        {
                            //entityProducto.Foto = imageByte;
                            //model.SaveChanges();

                            if (
                                model.cat_productos_imagenes
                                .Where(w => w.ProductoId == productoId && w.FileName == fileNameExt)
                                .Count() == 0
                                )
                            {
                                cat_productos_imagenes entityImagen = new cat_productos_imagenes();

                                entityImagen.ProductoImageId = model.cat_productos_imagenes.Count() > 0 ?
                                    model.cat_productos_imagenes.Max(m => m.ProductoImageId) + 1 : 1;
                                entityImagen.CreadoEl = DateTime.Now;
                                entityImagen.FileByte = imageByte;
                                entityImagen.FileName = fileNameExt;
                                entityImagen.ProductoId = entityProducto.ProductoId;
                                model.cat_productos_imagenes.Add(entityImagen);
                                model.SaveChanges();
                            }

                        }
                    }
                           


                }

                ProductosFotosBusiness oFotosB = new ProductosFotosBusiness();
                oFotosB.UpLoadImage();
            }
            catch (Exception ex)
            {
                error = ex.Message;                
            }

            return error;
        }

        public string importarImagenProducto(int productoId,string[] pathImages)
        {
            string error = "";

            try
            {
                

                cat_productos entityProducto = model.cat_productos
                        .Where(w => w.ProductoId == productoId).FirstOrDefault();

                foreach (var file in pathImages)
                {
                    string fileNameExt = Path.GetFileName(file.ToString());
                    string fileName = Path.GetFileNameWithoutExtension(file.ToString());
                    string fileExt = Path.GetExtension(file.ToString());
                    string[] fileNameSplit = fileName.Split('_');
                    string namePhoto = productoId.ToString() + "_" + fileNameExt;
                    string claveProd = fileNameSplit[0];
                    bool principal = false;

                    cat_productos_imagenes imagenPrincipal =  model.cat_productos_imagenes
                        .Where(w => w.ProductoId == productoId && w.Principal == true)
                        .FirstOrDefault();

                    if (imagenPrincipal == null)
                    {
                        principal = true;
                    }

                    if (entityProducto != null)
                    {
                        byte[] imageByte = File.ReadAllBytes(file);
                        
                        if (imageByte.Length > 0)
                        {
                            //entityProducto.Foto = imageByte;
                            //model.SaveChanges();

                            if (
                                model.cat_productos_imagenes
                                .Where(w => w.ProductoId == productoId && w.FileName == fileNameExt)
                                .Count() == 0
                                )
                            {
                                cat_productos_imagenes entityImagen = new cat_productos_imagenes();

                                entityImagen.ProductoImageId = model.cat_productos_imagenes.Count() > 0 ?
                                    model.cat_productos_imagenes.Max(m => m.ProductoImageId) + 1 : 1;
                                entityImagen.CreadoEl = DateTime.Now;
                                entityImagen.FileByte = imageByte;
                                entityImagen.FileName = principal == true ? entityProducto.ProductoId.ToString().Trim() + ".JPG"  : namePhoto;
                                entityImagen.ProductoId = entityProducto.ProductoId;
                                entityImagen.Principal = principal;
                                model.cat_productos_imagenes.Add(entityImagen);
                                model.SaveChanges();
                            }

                        }
                    }



                }

                ProductosFotosBusiness oFotosB = new ProductosFotosBusiness();
                oFotosB.UpLoadImage();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        public cat_productos GetByClave(string clave)
        {
            try
            {
                model = new ERPProdEntities();

                return model.cat_productos
                    .Where(
                        w => w.Clave == clave
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
