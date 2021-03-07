using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairingTest.Web.Configuration
{
    public class HttpSettingsOptions
    {
        public const string HttpSettings = "HttpSettings";
        public int RetryCount { get; set; }
        public int InitialRetryDelay { get; set; }
    }
}
