using ConexionBD;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class EquipoComputoBusiness : BusinessObject
    {
        
        public static ResultAPIModel RegistrarEquipo(int sucursalId)
        {
            ResultAPIModel result = new ResultAPIModel();
            string PCId = string.Empty;
           
            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();
                ERPProdEntities oContext = null;
                foreach (ManagementObject mo in moc)
                {
                    if (PCId == "")
                    {
                        //Get only the first CPU's ID
                        PCId = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                if(PCId.Length > 0)
                {
                    oContext = new ERPProdEntities();

                    cat_equipos_computo equipo = oContext.cat_equipos_computo
                        .Where(w => w.HardwareID == PCId && w.SucursalId == sucursalId).FirstOrDefault();

                    if(equipo == null)
                    {
                        equipo = new cat_equipos_computo();

                        equipo.EquipoComputoId = (oContext.cat_equipos_computo.Max(m => (int?)m.EquipoComputoId) ?? 0) + 1;
                        equipo.HardwareID = PCId;
                        equipo.PCName = Environment.MachineName;
                        equipo.IPPublica = "";
                        equipo.CreadoEl = DateTime.Now;
                        equipo.SucursalId = sucursalId;
                        oContext.cat_equipos_computo.Add(equipo);

                        oContext.SaveChanges();
                    }
                }



            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                      "ERP",
                                      "EquipoComputoBusiness.RegistrarEquipo",
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

            }

            return result;
        }

        public static string GetProcessorID()
        {
            ResultAPIModel result = new ResultAPIModel();
            string PCId = string.Empty;

            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();
                ERPProdEntities oContext = null;
                foreach (ManagementObject mo in moc)
                {
                    if (PCId == "")
                    {
                        //Get only the first CPU's ID
                        PCId = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                return PCId;

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                      "ERP",
                                      "EquipoComputoBusiness.GetProcessorID",
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

            }

            return "";
        }

        
    }
}
