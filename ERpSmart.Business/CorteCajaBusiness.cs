using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Business
{
    public class CorteCajaBusiness:BusinessObject
    {

        public doc_corte_caja GenerarCorteCaja(PuntoVentaContext puntoVentaContext,ref string error)
        {
            return null;
        }

        public static string imprimirCorteCajero(int sucursalId,int cajaId,int usuarioId)
        {
            int err = 0;
            try
            {

                ERPProdEntities oContext = new ERPProdEntities();
                ImpresorasBusiness oImpresora = new ImpresorasBusiness();
                cat_impresoras entityImpresora;
                entityImpresora = oImpresora.ObtenerCajaImpresora(cajaId);
                ERP.Reports.TacosAna.rptCorteCajaCajero1 oReport = new ERP.Reports.TacosAna.rptCorteCajaCajero1();
                DateTime fechaCorte = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                oReport.DataSource = oContext.p_rpt_corte_caja_cajero(sucursalId,
                    fechaCorte, cajaId).ToList();
                oReport.CreateDocument();

                if (entityImpresora != null)
                {
                    if (entityImpresora.NombreRed != "")
                    {
                        oReport.Print(entityImpresora.NombreRed);
                    }
                    

                }

                return "";

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                               "ERP",
                              "CorteCajaBusiness.imprimirCorteCajero",
                               ex);

                return String.Format("Ocurrió un problema con tu solicitud. Bitácora Num[{0}]",err);
            }

        }


    }
}
