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

        public DTO.OutputTransport<List<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>>> Search(DTO.SearchRequest<DTO.IBoxSearchRequest> criteria = null)
        {
            return base.FormatResult<List<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>>>(
                    ds3.Search(
                        base.Serialize(criteria)
                    ));
        }


        public DTO.OutputTransport<List<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>>> Search(DTO.SearchRequest<DTO.IProcessSearchRequest> criteria = null)
        {
            return base.FormatResult<List<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>>>(
                    ds3.Search(
                        base.Serialize(criteria)
                    ));
        }


        public DTO.OutputTransport<List<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>>> Update(DTO.UpdateDocument<DTO.BoxInfo> document)
        {
            return base.FormatResult<List<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>>>(
                ds3.Update(
                    base.Serialize(document)
                ));
        }


        public DTO.OutputTransport<List<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>>> Update(DTO.UpdateDocument<DTO.ProcessInfo> document)
        {
            return base.FormatResult<List<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>>>(
                ds3.Update(
                    base.Serialize(document)
                ));
        }


        public DTO.OutputTransport<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>> Delete(DTO.UpdateDocument<DTO.BoxInfo> document)
        {
            return base.FormatResult<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>>(
                ds3.Delete(
                    base.Serialize(document)
                ));
        }


        public DTO.OutputTransport<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>> Delete(DTO.UpdateDocument<DTO.ProcessInfo> document)
        {
            return base.FormatResult<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>>(
                ds3.Delete(
                    base.Serialize(document)
                ));
        }


        public DTO.OutputTransport<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>> Create(DTO.CreateDocument<DTO.BoxInfo> document)
        {
            return base.FormatResult<DTO.Document<DTO.BoxInfo, DTO.BoxDocType>>(
                ds3.Create(
                    base.Serialize(document)
                ));
        }


        public DTO.OutputTransport<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>> Create(DTO.CreateDocument<DTO.ProcessInfo> document)
        {
            return base.FormatResult<DTO.Document<DTO.ProcessInfo, DTO.ProcessDocType>>(
                ds3.Create(
                    base.Serialize(document)
                ));
        }
    }
}
