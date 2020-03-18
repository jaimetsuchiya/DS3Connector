using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.Proxy
{
    public class DocType: BaseProxy
    {
        private readonly ds3sdk.DS3Doctype ds3 = null;

        public DocType()
        {
            ds3 = new ds3sdk.DS3Doctype();
        }

        public DTO.OutputTransport<List<DTO.DocTypeResponse>> Search(int? id = null)
        {
            var proxy = new ds3sdk.DS3Doctype();
            var criteria = "";
            if( id.HasValue)
                criteria = "{ \"id\": " + id.Value.ToString() + " }";

            return base.FormatResult<List<DTO.DocTypeResponse>>(
                proxy.Search(criteria));
        }


        
    }
}
