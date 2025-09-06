using Microsoft.Extensions.Configuration;

namespace App_University.Transversal.Util
{
    public static class Utils
    {
        private static IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        public static T GetFromAppSettings<T>(this string key)
        {
            var value = _config.GetSection(key).Value;
            if (string.IsNullOrEmpty(value))
                value = "";
            
            return (T)Convert.ChangeType(value, typeof(T));
           
        }

        public static string GetConectionString(this string key)
        {
            var value = _config.GetConnectionString(key);
            if (string.IsNullOrEmpty(value))
                value = "";
            return value;
        }

        public static T StringToAny <T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Cannot convert null to non-nullable type {typeof(T)}.");
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
