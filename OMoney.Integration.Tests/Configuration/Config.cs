using System.Configuration;

namespace OMoney.Integration.Tests.Configuration
{
    class Config
    {
        public static string MainApplicationBaseUrl
        {
            get { return ConfigurationManager.AppSettings["MainApplicationBaseUrl"]; }

        }
    }
}
