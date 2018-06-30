using System.Configuration;

namespace HHCoApps.Repository
{
    internal static class DbUtilities
    {
        internal static string GetConnString(string dbName)
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }
    }
}
