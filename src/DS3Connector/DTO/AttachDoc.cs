using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.DTO
{
    [DataContract]
    public class AttachDocSearchRequest
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "document_id")]
        public int? DocumentId { get; set; }

        [DataMember(Name = "page")]
        public int? Page { get; set; }

        [DataMember(Name = "hash_value")]
        public DocumentInfo DocumentInfo { get; set; }
    }

    [DataContract]
    public class EditAttach
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "document_id")]
        public int? DocumentId { get; set; }

        [DataMember(Name = "hash_value")]
        public DocumentInfo DocumentInfo { get; set; }

        [DataMember(Name = "url_file")]
        public string URL_FILE { get; set; }

        [DataMember(Name = "base_64")]
        public string Base64 { get; set; }
    }


}
