using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.DTO
{

    [DataContract]
    public class DocType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "show_user")]
        public bool ShowUser { get; set; }

        [DataMember(Name = "show_created_at")]
        public bool ShowCreatedAt { get; set; }

        [DataMember(Name = "show_log")]
        public bool ShowLog { get; set; }

        [DataMember(Name = "fields")]
        public List<DocTypeField> Fields { get; set; }
    }

    [DataContract]
    public class DocTypeField
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "field_type")]
        public string FieldType { get; set; }

        [DataMember(Name = "doc_type_id")]
        public int DocTypeId { get; set; }

        [DataMember(Name = "parent_id")]
        public int? ParentId { get; set; }

        [DataMember(Name = "field_order")]
        public int FieldOrder { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdateddAt { get; set; }

        [DataMember(Name = "field_properties")]
        public DocTypeFieldProperty Properties { get; set; }
    }

    [DataContract]
    public class DocTypeFieldProperty
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
        public string StaticListValues { get; set; }
    }

}
