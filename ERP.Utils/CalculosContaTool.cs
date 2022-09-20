using ERP.Models.CalculoConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utils
{
    public class CalculosContaTool
    {
        public static ImporteDesgloceModel DesgloceIVA(decimal importe, decimal iva)
        {
            ImporteDesgloceModel result = new ImporteDesgloceModel();
            try
            {
                result.subtotal = importe / (1 + (iva / 100));
                result.impuestos = importe - result.subtotal;
                result.total = importe;
            }
            catch (Exception ex)
            {

                result.error.error = ex.Message;
            }

            return result;
        }

        public static ImporteDesgloceModel DesgloceImpuestos(decimal importe, decimal porcImpuestos)
        {
            ImporteDesgloceModel result = new ImporteDesgloceModel();
            try
            {
                result.subtotal = importe / (1 + (porcImpuestos / 100));
                result.impuestos = importe - result.subtotal;
                result.total = importe;
            }
            catch (Exception ex)
            {

                result.error.error = ex.Message;
            }

            return result;
        }


        public static ImporteDesgloceModel AgregarImpuesto(decimal importe, decimal porcImpuestos)
        {
            ImporteDesgloceModel result = new ImporteDesgloceModel();
            try
            {
                result.subtotal = importe;// / (1 + (porcImpuestos / 100));
                result.impuestos = (result.subtotal * ((1 + (porcImpuestos / 100))))-importe;
                result.total = result.subtotal + result.impuestos;
            }
            catch (Exception ex)
            {

                result.error.error = ex.Message;
            }

            return result;
        }
    }
}
