using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.Proxy
{
    public class AttachDoc: BaseProxy
    {
        private readonly ds3sdk.DS3Attacheddoc proxy = null;
        public AttachDoc()
        {
            proxy = new ds3sdk.DS3Attacheddoc();
        }

        public DTO.OutputTransport<List<DTO.DocumentAttachment>> Search(DTO.AttachDocSearchRequest<DTO.BoxInfo> criteria)
        {
            return base.FormatResult<List<DTO.DocumentAttachment>>(
                proxy.Search(
                    base.Serialize(criteria)
                ));
        }

        public DTO.OutputTransport<List<DTO.DocumentAttachment>> Search(DTO.AttachDocSearchRequest<DTO.ProcessInfo> criteria)
        {
            return base.FormatResult<List<DTO.DocumentAttachment>>(
                proxy.Search(
                    base.Serialize(criteria)
                ));
        }

        public DTO.OutputTransport<DTO.DocumentAttachment> Create(DTO.EditAttach<DTO.BoxInfo> attach)
        {
            return base.FormatResult<DTO.DocumentAttachment>(
                proxy.Create(
                    base.Serialize(attach)
                ));
        }
        public DTO.OutputTransport<DTO.DocumentAttachment> Create(DTO.EditAttach<DTO.ProcessInfo> attach)
        {
            return base.FormatResult<DTO.DocumentAttachment>(
                proxy.Create(
                    base.Serialize(attach)
                ));
        }

        public DTO.OutputTransport<DTO.DocumentAttachment> Update(DTO.EditAttach<DTO.BoxInfo> attach)
        {
            return base.FormatResult<DTO.DocumentAttachment>(
                proxy.Update(
                    base.Serialize(attach)
                ));
        }


        public DTO.OutputTransport<DTO.DocumentAttachment> Update(DTO.EditAttach<DTO.ProcessInfo> attach)
        {
            return base.FormatResult<DTO.DocumentAttachment>(
                proxy.Update(
                    base.Serialize(attach)
                ));
        }

        public DTO.OutputTransport<string> Delete(DTO.EditAttach<DTO.BoxInfo> attach)
        {
            return base.FormatResult<string>(
                proxy.Delete(
                    base.Serialize(attach)
                ));
        }


        public DTO.OutputTransport<string> Delete(DTO.EditAttach<DTO.ProcessInfo> attach)
        {
            return base.FormatResult<string>(
                proxy.Delete(
                    base.Serialize(attach)
                ));
        }
    }
}
