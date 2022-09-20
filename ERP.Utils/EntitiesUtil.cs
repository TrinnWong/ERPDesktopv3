using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utils
{
    public class EntitiesUtil
    {
        public static string GetValuesModel(object modelObject)
        {
            string result = "";
            Type myType = modelObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(modelObject, null);

                result = result + String.Format(prop.Name + ":[{0}]", (propValue == null ? "NULL" : propValue).ToString());
            }

            return result;

        }
    }
}
