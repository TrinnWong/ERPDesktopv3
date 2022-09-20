using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConexionBD
{
    public class ClientesBusiness
    {
        public ERPProdEntities oContext;

        public ClientesBusiness()
        {
            oContext = new ERPProdEntities();
        }

        public string InsertarClienteAutomovil(ref cat_clientes cliente,
           ref  cat_clientes_automovil clienteAutomovil
            )
        {

            string error = "";

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ObjectParameter pClienteId = new ObjectParameter("pClienteId", 0);
                    ObjectParameter pClienteAutoId = new ObjectParameter("pClienteAutoId", 0);

                    oContext.p_cat_clientes_ins_upd(pClienteId, cliente.Nombre, cliente.RFC, cliente.Calle,
                        cliente.NumeroExt, cliente.NumeroInt, cliente.Colonia, cliente.CodigoPostal,
                        cliente.EstadoId, cliente.MunicipioId, cliente.PaisId, cliente.Telefono,
                        cliente.Telefono2, cliente.TipoClienteId, cliente.DiasCredito, cliente.LimiteCredito,
                        cliente.AntecedenteId, cliente.CreditoDisponible, cliente.SaldoGlobal, cliente.Activo,
                        cliente.ClienteEspecial, cliente.ClienteGral, cliente.PrecioId, cliente.GiroId, pClienteAutoId,
                        clienteAutomovil.Modelo, clienteAutomovil.Color, clienteAutomovil.Placas, clienteAutomovil.Observaciones);

                    scope.Complete();

                    cliente.ClienteId = pClienteId.Value != null ? int.Parse(pClienteId.Value.ToString()) : 0;
                    clienteAutomovil.ClienteAutoId = pClienteAutoId.Value != null ? int.Parse(pClienteAutoId.Value.ToString()) : 0;
                }

            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            

                return error;
        }
    }
}
