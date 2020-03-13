using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.DTO
{
    [DataContract]
    public class OutputTransport<T>
    {
        [DataMember(Name = "data")]
        public T Data { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "total_found")]
        public int TotalFound { get; set; }

        [DataMember(Name = "total_per_page")]
        public int? TotalPerPage { get; set; }

        [DataMember(Name = "page")]
        public int? Page { get; set; }
    }


}
