using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.Proxy
{
    public class Document: BaseProxy
    {
        private readonly ds3sdk.DS3Document ds3 = null;

        public Document()
        {
            ds3 = new ds3sdk.DS3Document();
        }

        public DTO.OutputTransport<List<DTO.Document>> Search(DTO.SearchRequest criteria = null)
        {
            return base.FormatResult<List<DTO.Document>>(
                    ds3.Search (
                        base.Serialize(criteria)
                    ));
        }

        public DTO.OutputTransport<DTO.Document> Create(DTO.CreateDocument document)
        {
            return base.FormatResult<DTO.Document>(
                    ds3.Create (
                        base.Serialize(document)
                    ));
        }

        public DTO.OutputTransport<List<DTO.Document>> Update(DTO.UpdateDocument document)
        {
            return base.FormatResult<List<DTO.Document>>(
                ds3.Update(
                    base.Serialize(document)
                ));
        }

        public DTO.OutputTransport<DTO.Document> Delete(DTO.UpdateDocument document)
        {
            return base.FormatResult<DTO.Document>(
                ds3.Delete(
                    base.Serialize(document)
                ));
        }
    }
}
