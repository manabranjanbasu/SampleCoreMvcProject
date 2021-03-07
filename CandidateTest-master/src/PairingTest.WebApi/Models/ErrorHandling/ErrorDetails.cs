using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PairingTest.API.Models.ErrorHandling
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = contractResolver
            });
        }
    }
}
