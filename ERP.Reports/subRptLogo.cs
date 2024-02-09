using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for subRptLogo.
    /// </summary>
    public partial class subRptLogo : GrapeCity.ActiveReports.SectionReport
    {

        public subRptLogo()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            
        }

        private void reportHeader1_Format(object sender, EventArgs e)
        {
            ERPProdEntities oContext = new ERPProdEntities();

            cat_empresas entity = oContext.cat_empresas.FirstOrDefault();

            if (entity != null)
            {
                if (entity.Logo != null)
                {
                    byte[] imagen = entity.Logo;

                    if (imagen.Length > 0)
                    {

                        using (var ms = new MemoryStream(imagen))
                        {
                            Image logo = Image.FromStream(ms);

                            string fileFoto = AppDomain.CurrentDomain.BaseDirectory + "logo.jpg";

                            if (System.IO.File.Exists(fileFoto))
                            {

                                uiFoto.Image = Image.FromFile(fileFoto);

                            }
                            else
                            {
                                uiFoto.Image = logo;
                            }
                           





                        }
                    }
                }
                
            }
        }
    }
}
