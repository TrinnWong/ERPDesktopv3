using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionBD.Utilerias
{
    public class ComboBoxItem
    {
        public int valor { get; set; }
        public string texo { get; set; }
    }

    public class ComboboxActions
    {
        public List<ComboBoxItem> CargarComboBox(ref ComboBox comboBox, bool filtroTodos, string clave, string descripcion, DataTable dt)
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>();
            string textoInicial = filtroTodos ? "(TODOS)" : "(SELECCIONAR)";
            ComboBoxItem cmb = new ComboBoxItem();
            cmb.texo = "(SELECCIONAR)";
            cmb.valor = 0;
            comboBox.Items.Add(cmb);

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        cmb = new ComboBoxItem();
                        cmb.valor = int.Parse(item[clave].ToString());
                        cmb.texo = item[descripcion].ToString();
                        comboBox.Items.Add(cmb);
                    }
                }
                catch { }
            }
            comboBox.SelectedIndex = 0;
            comboBox.DisplayMember = "texo";
            comboBox.ValueMember = "valor";
            return lista;
        }

        public void SeleccionarRegistroCombo(ref ComboBox cmb, int id)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                var prop = cmb.Items[i].GetType().GetProperty(cmb.ValueMember);
                if (prop != null && prop.GetValue(cmb.Items[i], null).ToString() == id.ToString())
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
