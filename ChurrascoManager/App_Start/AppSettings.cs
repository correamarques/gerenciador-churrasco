using System;
using System.Configuration;
using System.Globalization;
using System.Web.Configuration;

namespace ChurrascoManager
{
    public class AppSettings
    {
        public static string SystemTitle { get { return Setting<string>("system:Title"); } }


        private static T Setting<T>(string name)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
                value = WebConfigurationManager.AppSettings[name];

            if (value == null)
                throw new Exception(String.Format("Could not find setting '{0}',", name));

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}