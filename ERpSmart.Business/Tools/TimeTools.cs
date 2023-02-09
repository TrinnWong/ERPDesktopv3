using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Tools
{
    public class TimeTools
    {
        public static DateTime ConvertToTimeZoneDefault()
        {
            ConexionBD.ERPProdEntities oContext = new ConexionBD.ERPProdEntities();
            DateTime date = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            TimeZoneInfo timeZoneInfo;

            DateTime dateTime;

            //Set the time zone information to US Mountain Standard Time 

            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

            //Get date and time in US Mountain Standard Time 

            dateTime = TimeZoneInfo.ConvertTime(date.ToUniversalTime(), timeZoneInfo);

            //Print out the date and time

            return dateTime;
        }

        public static FechaActualModel FechaActual()
        {
            FechaActualModel result = new FechaActualModel();
            DateTime DT = ConvertToTimeZoneDefault();

            result.anio = DT.Year;
            result.mes = DT.Month;
            result.dia = DT.Day;

            return result;

        }

        public static int ConvertDateToInt(DateTime fecha)
        {
            int result=0;

            return result;
        }

    }
}
