using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.DTO
{
    #region DocType
    
    [DataContract]
    public class FieldProperty
    {
        [DataMember(Name = "field_form_name")]
        public string FieldFormName { get; set; }

        [DataMember(Name = "field_placeholder")]
        public string FieldPlaceHolder { get; set; }

        [DataMember(Name = "field_mask")]
        public string FieldMask { get; set; }

        [DataMember(Name = "field_default_value")]
        public string FieldDefaultValue { get; set; }

        [DataMember(Name = "field_name")]
        public string FieldName { get; set; }

        [DataMember(Name = "field_required")]
        public string FieldRequired { get; set; }

        [DataMember(Name = "field_in_search")]
        public string FieldInSearch { get; set; }

        [DataMember(Name = "field_in_list")]
        public string FieldInList { get; set; }
        
        [DataMember(Name = "select_list_type")]
        public string SelectListType { get; set; }

        [DataMember(Name = "object_dependent_id")]
        public string ObjectDependentId { get; set; }

        [DataMember(Name = "static_list_values")]
        public string StatisListValues { get; set; }
    }


    [DataContract]
    public class Field
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }


        [DataMember(Name = "field_type")]
        public string FieldType { get; set; }


        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "field_properties")]
        public FieldProperty Peroperties { get; set; }

        [DataMember(Name = "field_order")]
        public int Order { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }
  
    }

    [DataContract]
    public class DocTypeResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }

        
        [DataMember(Name = "show_user")]
        public bool? ShowUser { get; set; }


        [DataMember(Name = "show_created_at")]
        public bool? ShowCreatedAt { get; set; }


        [DataMember(Name = "show_log")]
        public bool? ShowLog { get; set; }


        [DataMember(Name = "fields")]
        public List<Field> Fields { get; set; }
    }

    #endregion

    #region Box Document

    public interface IBoxSearchRequest
    {
        string ComarcaID { get; set; }

        string VaraID { get; set; }

        string NroPacote { get; set; }

        string AnoPacote { get; set; }

        string NroCaixa { get; set; }
    }


    [DataContract]
    public class BoxSearchRequestInfo : IBoxSearchRequest
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
    public class BoxInfo : BoxSearchRequestInfo
    {
        [DataMember(Name = "ffield_253")]
        public string NroItem { get; set; }
    }


    [DataContract]
    public class BoxDocType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ffield_248")]
        public string FormField248 { get; set; }

        [DataMember(Name = "ffield_249")]
        public string FormField249 { get; set; }

        [DataMember(Name = "ffield_250")]
        public string FormField250 { get; set; }

        [DataMember(Name = "ffield_251")]
        public string FormField251 { get; set; }

        [DataMember(Name = "ffield_252")]
        public string FormField252 { get; set; }

        [DataMember(Name = "ffield_253")]
        public string FormField253 { get; set; }
    }

    #endregion

    #region Process Document

    public interface IProcessSearchRequest : IBoxSearchRequest
    {
        string NroProcesso { get; set; }

        string AnoProcesso { get; set; }
    }


    [DataContract]
    public class ProcessSearchRequestInfo : BoxSearchRequestInfo, IProcessSearchRequest
    {
        [DataMember(Name = "ffield_257")]
        public new string ComarcaID { get; set; }

        [DataMember(Name = "ffield_258")]
        public new string VaraID { get; set; }

        [DataMember(Name = "ffield_259")]
        public new string NroPacote { get; set; }

        [DataMember(Name = "ffield_260")]
        public new string AnoPacote { get; set; }

        [DataMember(Name = "ffield_261")]
        public new string NroCaixa { get; set; }

        [DataMember(Name = "ffield_263")]
        public string NroProcesso { get; set; }

        [DataMember(Name = "ffield_264")]
        public string AnoProcesso { get; set; }
    }


    [DataContract]
    public class ProcessInfo : ProcessSearchRequestInfo
    {
        [DataMember(Name = "ffield_262")]
        public string NroItem { get; set; }

    }


    [DataContract]
    public class ProcessDocType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ffield_257")]
        public string FormField257 { get; set; }

        [DataMember(Name = "ffield_258")]
        public string FormField258 { get; set; }

        [DataMember(Name = "ffield_259")]
        public string FormField259 { get; set; }

        [DataMember(Name = "ffield_260")]
        public string FormField260 { get; set; }

        [DataMember(Name = "ffield_261")]
        public string FormField261 { get; set; }

        [DataMember(Name = "ffield_262")]
        public string FormField262 { get; set; }

        [DataMember(Name = "ffield_263")]
        public string FormField263 { get; set; }

        [DataMember(Name = "ffield_264")]
        public string FormField264 { get; set; }
    }
    #endregion


    [DataContract]
    public class SearchRequest<T>
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get { return (this.DocumentInfo is ProcessSearchRequestInfo ? 67 : 65); } }

        [DataMember(Name = "page")]
        public int Page { get; set; } = 1;

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "hash_value")]
        public T DocumentInfo { get; set; }
    }


    [DataContract]
    public class Document<T, T2>
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
        public T DocumentInfo { get; set; }

        [DataMember(Name = "doc_type")]
        public T2 DocType { get; set; }

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
    public class CreateDocument<T>
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get { return (this.DocumentInfo is ProcessInfo ? 67 : 65); } }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "hash_value")]
        public T DocumentInfo { get; set; }

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
    public class UpdateDocument<T>
    {
        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get { return (this.DocumentInfo is ProcessInfo ? 67 : 65); } }

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "hash_value")]
        public T DocumentInfo { get; set; }

        [DataMember(Name = "hash_value_upd")]
        public T NewDocumentInfo { get; set; }

        [DataMember(Name = "attached_docs")]
        public List<CreateDocumentAttachment> Attachments { get; set; }
    }

}
