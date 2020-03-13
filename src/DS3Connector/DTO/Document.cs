using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.DTO
{
    [DataContract]
    public class DocumentSearchRequest
    {
        [DataMember(Name = "ffield_248")]
        public string ComarcaID { get; set; }

        [DataMember(Name = "ffield_249")]
        public string VaraID { get; set; }

        [DataMember(Name = "ffield_250")]
        public string NroPacote { get; set; }

        [DataMember(Name = "ffield_251")]
        public string AnoPacote { get; set; }

        [DataMember(Name = "ffield_252")]
        public string NroCaixa { get; set; }

    }


    [DataContract]
    public class SearchRequest
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; } = 1;

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "hash_value")]
        public DocumentSearchRequest DocumentInfo { get; set; }
    }


    [DataContract]
    public class DocumentInfo : DocumentSearchRequest
    {

        [DataMember(Name = "ffield_253")]
        public string NroItem { get; set; }
    }


    [DataContract]
    public class DocumentDocType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }


        [DataMember(Name = "ffield_248")]
        public string Label_FormField248 { get; set; }


        [DataMember(Name = "ffield_249")]
        public string Label_FormField249 { get; set; }


        [DataMember(Name = "ffield_250")]
        public string Label_FormField250 { get; set; }


        [DataMember(Name = "ffield_251")]
        public string Label_FormField251 { get; set; }


        [DataMember(Name = "ffield_252")]
        public string Label_FormField252 { get; set; }


        [DataMember(Name = "ffield_253")]
        public string Label_FormField253 { get; set; }
    }


    [DataContract]
    public class Document
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DataMember(Name = "hash_value")]
        public DocumentInfo DocumentInfo { get; set; }

        [DataMember(Name = "doc_type")]
        public DocumentDocType DocType { get; set; }

        [DataMember(Name = "attached_docs")]
        public List<DocumentAttachment> Attachments { get; set; }

        [DataMember(Name = "logs")]
        public List<DocumentLog> Logs { get; set; }
    }


    [DataContract]
    public class DocumentAttachment
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }


        [DataMember(Name = "doc_file_name")]
        public string FileName { get; set; }


        [DataMember(Name = "doc_content_type")]
        public string ContentType { get; set; }


        [DataMember(Name = "doc_file_size")]
        public int FileSize { get; set; }


        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }


        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }


        [DataMember(Name = "url_doc")]
        public string URL { get; set; }


        [DataMember(Name = "url_doc_expire")]
        public string URLWithExpiration { get; set; }


        [DataMember(Name = "base64")]
        public string Base64 { get; set; }
    }


    [DataContract]
    public class DocumentLog
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }


        [DataMember(Name = "document_id")]
        public int DocumentId { get; set; }


        [DataMember(Name = "username")]
        public string UserName { get; set; }


        [DataMember(Name = "action")]
        public string Action { get; set; }


        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }


        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }


        [DataMember(Name = "user_id")]
        public int? UserId { get; set; }


        [DataMember(Name = "note")]
        public string Note { get; set; }


    }


    [DataContract]
    public class CreateDocument
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "hash_value")]
        public DocumentInfo DocumentInfo { get; set; }

        [DataMember(Name = "attached_docs")]
        public List<CreateDocumentAttachment> Attachments { get; set; }
    }


    [DataContract]
    public class CreateDocumentAttachment
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "base64")]
        public string Base64 { get; set; }

        [DataMember(Name = "url_file")]
        public string FileURL { get; set; }
    }


    [DataContract]
    public class UpdateDocument
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "hash_value")]
        public DocumentInfo DocumentInfo { get; set; }

        [DataMember(Name = "hash_value_upd")]
        public DocumentInfo NewDocumentInfo { get; set; }


        [DataMember(Name = "attached_docs")]
        public List<CreateDocumentAttachment> Attachments { get; set; }
    }

}
