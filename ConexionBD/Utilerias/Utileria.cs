using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConexionBD.Utilerias
{
    public static class Imagenes
    {

        public static byte[] ConvertStramToImage(string stream)
        {
            var base64Data = Regex.Match(stream, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] bytes = Convert.FromBase64String(base64Data);

            return bytes;
        }

        public static Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ReduceImg(Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("Quality is between 0 and 100");
            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            using (var stream = new MemoryStream())
            {
                img.Save(stream, jpegCodec, encoderParams);
                var b = new Bitmap(stream);
                return new Bitmap(b);
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }
    }


    public static class Fechas
    {
        public static string getNameDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Thursday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miercoles";
                case DayOfWeek.Tuesday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sábado";
                case DayOfWeek.Sunday:
                    return "Domingo";
                default:
                    break;
            }
            return "";
        }

        public static DateTime fechaNula { get { return new DateTime(1900, 1, 1); } }
    }
    public static class Nulos
    {
        #region IsNull
        public static string IsNull(object cadena)
        {
            if (cadena == null)
                return "";
            else
                return cadena.ToString();
        }

        public static int IsNull(object cadena, int valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return int.Parse(cadena.ToString());
        }

        public static decimal IsNull(object cadena, decimal valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return decimal.Parse(cadena.ToString());
        }






        public static bool IsNull(object cadena, bool valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return bool.Parse(cadena.ToString());
        }
        public static decimal? IsNullDecimal(object cadena, decimal? valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return decimal.Parse(cadena.ToString());
        }

        public static DateTime? IsNull(object cadena, DateTime? valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return DateTime.Parse(cadena.ToString());
        }

        public static DateTime IsNull(object cadena, DateTime valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return DateTime.Parse(String.Format("{0:dd/MM/yyyy}", cadena.ToString()));
        }

        public static TimeSpan? IsNullTime(object cadena, TimeSpan? valorDefault)
        {
            if (cadena == null || cadena.ToString().Trim() == "")
                return valorDefault;
            else
                return TimeSpan.Parse(cadena.ToString());
        }

        #endregion

    }
    public static class Letras
    {
        public static string DepurarNombre(string nombre)
        {
            if (nombre == null)
                return nombre;
            nombre = nombre.ToUpper();

            nombre = nombre.Replace("Á", "A");
            nombre = nombre.Replace("É", "E");
            nombre = nombre.Replace("Í", "I");
            nombre = nombre.Replace("Ó", "O");
            nombre = nombre.Replace("Ú", "U");
            nombre = nombre.Replace(" ", "");
            nombre = nombre.Replace("\n", "");

            return nombre;
        }

        public static string ObtenerMes(int Mes)
        {
            string nombreMes = "";
            if (Mes == 1)
            {
                nombreMes = "Enero";
            }
            else if (Mes == 2)
            {
                nombreMes = "Febrero";
            }
            else if (Mes == 3)
            {
                nombreMes = "Marzo";
            }
            else if (Mes == 4)
            {
                nombreMes = "Abril";
            }
            else if (Mes == 5)
            {
                nombreMes = "Mayo";
            }
            else if (Mes == 6)
            {
                nombreMes = "Junio";
            }
            else if (Mes == 7)
            {
                nombreMes = "Julio";
            }
            else if (Mes == 8)
            {
                nombreMes = "Agosto";
            }
            else if (Mes == 9)
            {
                nombreMes = "Septiembre";
            }
            else if (Mes == 10)
            {
                nombreMes = "Octubre";
            }
            else if (Mes == 11)
            {
                nombreMes = "Noviembre";
            }
            else if (Mes == 12)
            {
                nombreMes = "Diciembre";
            }
            return nombreMes;
        }

        public static string NumeroLetra(int numero)
        {
            string letra = "";
            switch (numero)
            {
                case 1:
                    letra = "un";
                    break;
                case 2:
                    letra = "dos";
                    break;
                case 3:
                    letra = "tres";
                    break;
                case 4:
                    letra = "cuatro";
                    break;
                case 5:
                    letra = "cinco";
                    break;
                case 6:
                    letra = "seis";
                    break;
                case 7:
                    letra = "siete";
                    break;
                case 8:
                    letra = "ocho";
                    break;
                case 9:
                    letra = "nueve";
                    break;
                case 10:
                    letra = "diez";
                    break;
                case 11:
                    letra = "once";
                    break;
                case 12:
                    letra = "doce";
                    break;
                case 13:
                    letra = "trece";
                    break;
                case 14:
                    letra = "catorce";
                    break;
                case 15:
                    letra = "quince";
                    break;
                case 16:
                    letra = "dieciseis";
                    break;
                case 17:
                    letra = "diecisiete";
                    break;
                case 18:
                    letra = "dieciocho";
                    break;
                case 19:
                    letra = "diecinueve";
                    break;
                case 20:
                    letra = "veinte";
                    break;
                case 21:
                    letra = "veintiuno";
                    break;
                case 22:
                    letra = "veintidos";
                    break;
                case 23:
                    letra = "veintitres";
                    break;
                case 24:
                    letra = "veinticuatro";
                    break;
                case 25:
                    letra = "veinticinco";
                    break;
                case 26:
                    letra = "veintiseis";
                    break;
                case 27:
                    letra = "veintisiete";
                    break;
                case 28:
                    letra = "veintiocho";
                    break;
                case 29:
                    letra = "veintinueve";
                    break;
                case 30:
                    letra = "treinta";
                    break;
                case 31:
                    letra = "treinta y un";
                    break;
                case 2000:
                    letra = "dos mil";
                    break;
                case 2001:
                    letra = "dos mil uno";
                    break;
                case 2002:
                    letra = "dos mil dos";
                    break;
                case 2003:
                    letra = "dos mil tres";
                    break;
                case 2004:
                    letra = "dos mil cuatro";
                    break;
                case 2005:
                    letra = "dos mil cinco";
                    break;
                case 2006:
                    letra = "dos mil seis";
                    break;
                case 2007:
                    letra = "dos mil siete";
                    break;
                case 2008:
                    letra = "dos mil ocho";
                    break;
                case 2009:
                    letra = "dos mil nueve";
                    break;
                case 2010:
                    letra = "dos mil diez";
                    break;
                case 2011:
                    letra = "dos mil once";
                    break;
                case 2012:
                    letra = "dos mil doce";
                    break;
                case 2013:
                    letra = "dos mil trece";
                    break;
                case 2014:
                    letra = "dos mil catorce";
                    break;
                case 2015:
                    letra = "dos mil quince";
                    break;
                case 2016:
                    letra = "dos mil dieciseis";
                    break;
                case 2017:
                    letra = "dos mil diecisiete";
                    break;
                case 2018:
                    letra = "dos mil dieciocho";
                    break;
                case 2019:
                    letra = "dos mil diecinueve";
                    break;
                case 2020:
                    letra = "dos mil veinte";
                    break;
                case 2021:
                    letra = "dos mil veintiuno";
                    break;
                case 2022:
                    letra = "dos mil veintidos";
                    break;
                case 2023:
                    letra = "dos mil veintitres";
                    break;
                case 2024:
                    letra = "dos mil veinticuatro";
                    break;
                case 2025:
                    letra = "dos mil veinticinco";
                    break;
                case 2026:
                    letra = "dos mil veintiseis";
                    break;
                case 2027:
                    letra = "dos mil veintisiete";
                    break;
                case 2028:
                    letra = "dos mil veintiocho";
                    break;
                case 2029:
                    letra = "dos mil veintinueve";
                    break;
                case 2030:
                    letra = "dos mil treinta";
                    break;
                case 2031:
                    letra = "dos mil treinta y un";
                    break;
                case 2032:
                    letra = "dos mil treinta y dos";
                    break;
                case 2033:
                    letra = "dos mil treinta y tres";
                    break;
                case 2034:
                    letra = "dos mil treinta y cuatro";
                    break;
                case 2035:
                    letra = "dos mil treinta y cinco";
                    break;
                case 2036:
                    letra = "dos mil treinta y seis";
                    break;
                case 2037:
                    letra = "dos mil treinta y siete";
                    break;
                case 2038:
                    letra = "dos mil treinta y ocho";
                    break;
                case 2039:
                    letra = "dos mil treinta y nueve";
                    break;
                case 2040:
                    letra = "dos mil cuarenta";
                    break;
                default:
                    letra = "";
                    break;
            }
            return letra;
        }

        public static string CantidadLetra(string numero, string ctvos)
        {
            string palabras, entero, dec, flag;
            entero = "";
            dec = "";
            palabras = "";

            int num, x, y;

            flag = "N";
            //**********Número Negativo***********
            if (numero.Substring(1, 1).Equals("-"))
            {
                numero = numero.Substring(2, numero.Length - 1);
                palabras = "menos";
            }

            // '**********Si tiene ceros a la izquierda*************
            for (x = 1; x < numero.Length; x++)
            {
                if (numero.Substring(0, 1).Equals("0"))
                {
                    numero = numero.Substring(1, numero.Length).Trim();
                }
                else
                {
                    break;
                }
            }
            //**************dividir parte entera y decimal********************

            for (y = 0; y < numero.Length; y++)
            {
                if (numero.Substring(y, 1).Equals("."))
                {
                    flag = "S";
                }
                else
                {
                    if (flag.Equals("N"))
                    {
                        entero = entero + numero.Substring(y, 1);
                    }
                    else
                    {
                        dec = dec + numero.Substring(y, 1);
                    }
                }
            }

            //centavos
            dec = ctvos;
            if (dec.Length == 1)
            {
                dec = dec + "0";
            }

            //'**********proceso de conversión***********
            flag = "N";

            if (Convert.ToInt32(numero) <= 999999999)
            {
                for (y = entero.Length; y >= 1; y--)
                {
                    num = entero.Length - (y);
                    switch (y)
                    {
                        case 3:
                        case 6:
                        case 9:
                            switch (entero.Substring(num, 1))
                            {
                                case "1":
                                    if (entero.Substring(num + 1, 1).Equals("0") && entero.Substring(num + 2, 1).Equals("0"))
                                    {
                                        palabras = palabras + "cien ";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Ciento ";
                                    }
                                    break;
                                case "2":
                                    palabras = palabras + "Docientos ";
                                    break;
                                case "3":
                                    palabras = palabras + "Trecientos ";
                                    break;
                                case "4":
                                    palabras = palabras + "Cuatrocientos ";
                                    break;
                                case "5":
                                    palabras = palabras + "Quinientos ";
                                    break;
                                case "6":
                                    palabras = palabras + "Seiscientos";
                                    break;
                                case "7":
                                    palabras = palabras + "Setecientos";
                                    break;
                                case "8":
                                    palabras = palabras + "Ochocientos ";
                                    break;
                                case "9":
                                    palabras = palabras + "Novecientos ";
                                    break;
                            }
                            break;
                        case 2:
                        case 5:
                        case 8:
                            switch (entero.Substring(num, 1))
                            {
                                case "1":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        flag = "S";
                                        palabras = palabras + "Diez ";
                                    }
                                    if (entero.Substring(num + 1, 1).Equals("1"))
                                    {
                                        flag = "S";
                                        palabras = palabras + "Once ";
                                    }
                                    if (entero.Substring(num + 1, 1).Equals("2"))
                                    {
                                        flag = "S";
                                        palabras = palabras + "Doce ";
                                    }
                                    if (entero.Substring(num + 1, 1).Equals("3"))
                                    {
                                        flag = "S";
                                        palabras = palabras + "Trece ";
                                    }
                                    if (entero.Substring(num + 1, 1).Equals("4"))
                                    {
                                        flag = "S";
                                        palabras = palabras + "Catorce ";
                                    }
                                    if (entero.Substring(num + 1, 1).Equals("5"))
                                    {
                                        flag = "S";
                                        palabras = palabras + "Quince ";
                                    }
                                    if (Convert.ToInt32(entero.Substring(num + 1, 1)) > 5)
                                    {
                                        flag = "N";
                                        palabras = palabras + "Dieci ";
                                    }
                                    break;
                                case "2":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Veinte ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Veinti";
                                        flag = "N";
                                    }
                                    break;
                                case "3":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Treinta ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Treinta y ";
                                        flag = "N";
                                    }

                                    break;
                                case "4":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Cuarenta ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Cuarenta y ";
                                        flag = "N";
                                    }
                                    break;
                                case "5":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Cincuenta ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Cincuenta y ";
                                        flag = "N";
                                    }
                                    break;
                                case "6":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Sesenta ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Sesenta y ";
                                        flag = "N";
                                    }
                                    break;
                                case "7":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Setenta ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Setenta y ";
                                        flag = "N";
                                    }
                                    break;
                                case "8":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Ochenta ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Ochenta y ";
                                        flag = "N";
                                    }
                                    break;
                                case "9":
                                    if (entero.Substring(num + 1, 1).Equals("0"))
                                    {
                                        palabras = palabras + "Noventa ";
                                        flag = "S";
                                    }
                                    else
                                    {
                                        palabras = palabras + "Noventa y ";
                                        flag = "N";
                                    }
                                    break;
                            }
                            break;
                        case 1:
                        case 4:
                        case 7:
                            switch (entero.Substring(num, 1))
                            {
                                case "1":
                                    if (flag.Equals("N")) { if (y == 1) { palabras = palabras + "Uno "; } }
                                    else
                                    { palabras = palabras + "Un "; }
                                    break;
                                case "2":
                                    if (flag.Equals("N")) { palabras = palabras + "Dos "; }
                                    break;
                                case "3":
                                    if (flag.Equals("N")) { palabras = palabras + "Tres "; }
                                    break;
                                case "4":
                                    if (flag.Equals("N")) { palabras = palabras + "Cuatro "; }
                                    break;
                                case "5":
                                    if (flag.Equals("N")) { palabras = palabras + "Cinco "; }
                                    break;
                                case "6":
                                    if (flag.Equals("N")) { palabras = palabras + "Seis "; }
                                    break;
                                case "7":
                                    if (flag.Equals("N")) { palabras = palabras + "Siete "; }
                                    break;
                                case "8":
                                    if (flag.Equals("N")) { palabras = palabras + "Ocho "; }
                                    break;
                                case "9":
                                    if (flag.Equals("N")) { palabras = palabras + "Nueve "; }
                                    break;
                            }
                            break;
                    }

                    // '***********Asigna la palabra mil***************
                    if (y == 4)
                    {
                        palabras = palabras + "Mil ";
                    }

                    // '**********Asigna la palabra millón*************
                    else if (y == 7)
                    {
                        if (entero.Length == 7 && entero.Substring(1, 1).Equals("1"))
                        {
                            palabras = palabras + "Millón ";
                        }
                    }
                    else if (y > 7)
                    {
                        palabras = palabras + "Millones ";
                    }
                }
                return palabras + " 00/" + dec;
            }
            else
            {
                return "";
            }
        }
    }

  

}
