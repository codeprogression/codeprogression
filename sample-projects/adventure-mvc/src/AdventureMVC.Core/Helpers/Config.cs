using System;
using System.Configuration;

namespace AdventureMVC.Core.Helpers
{
    public class Config
    {
        /// <summary>
        /// Gets a setting from the configuration
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="name">Name of configuration parameter</param>
        /// <returns>Typed object</returns>
        public static T GetSetting<T>(string name) where T : IConvertible
        {
            var appSetting = ConfigurationManager.AppSettings[name];
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), appSetting, true);
            }
            return (T)Convert.ChangeType(appSetting, typeof(T));
        }
        /// <summary>
        /// Gets a setting from the configuration.  If the parameter does not exist, return the default type value.
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="name">Name of configuration parameter</param>
        /// <returns>Typed object</returns>
        public static T GetSettingOrDefault<T>(string name) where T : IConvertible
        {
            try
            {
                return GetSetting<T>(name);
            }
            catch
            {
                return default(T);
            }
        }
        /// <summary>
        /// Gets a setting from the configuration
        /// </summary>
        /// <param name="name">Name of configuration parameter</param>
        /// <returns>string</returns>
        public static string GetSetting(string name)
        {
            return GetSetting<string>(name);
        }

        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ToString();
        }
//        public static string GetDefaultConnectionString()
//        {
//            return DatabaseFactory.CreateDatabase().CreateConnection().ConnectionString;
//            //            return GetConnectionString(defaultDatabase);
//        }
    }
}