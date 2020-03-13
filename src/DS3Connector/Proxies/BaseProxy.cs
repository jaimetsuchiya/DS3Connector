using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.Proxy
{
    public class BaseProxy
    {
        public string Serialize<T>(T instance)
        {
            return JsonConvert.SerializeObject(instance, 
                    Formatting.None, 
                    new JsonSerializerSettings {
                        NullValueHandling = NullValueHandling.Ignore
                    });

        }

        public DTO.OutputTransport<T> FormatResult<T>(string result)
        {
            var tmp = JsonConvert.DeserializeObject<DTO.OutputTransport<dynamic>>(result);
            if (tmp.Status == "SUCCESS")
            {
                return JsonConvert.DeserializeObject<DTO.OutputTransport<T>>(result);
            }
            else
            {
                return new DTO.OutputTransport<T>() { Status = tmp.Status, Message = tmp.Message };
            }
        }
    }
}
