using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.Adapter
{
    public class DsKeyword
    {
        public DsKeyword(int id, string name, string value)
        {
            this.Id = id;
            this.Name = name;
            this.Value = value;
        }

        public int Id { get; }
        public string Name { get; }
        public string Value { get; }
    }

    public class DsFile
    {
        public DsFile(string arquivo)
        {
            this.Name = arquivo;
        }
        public DsFile(string nome, string extensao, byte[] fileData)
        {
            this.FileData = FileData;
            this.Name = nome;
            this.Extension = extensao;
        }

        public byte[] FileData { get; }
        public string Name { get; }
        public string Extension { get; }
        public string MimeType { get; }
    }

    public class DsSearchDoc
    {
        public DsSearchDoc(string message, int errorCode)
        {
            this.Msg = message;
            this.CodErro = errorCode;
        }
        public DsSearchDoc(string message, int errorCode, List<DsDocumento> docs)
        {
            this.Docs = docs;
            this.CodErro = errorCode;
            this.Msg = message;
        }

        public string Msg { get; }
        public int CodErro { get; }
        public List<DsDocumento> Docs { get; }
    }


    public class DsDocumento
    {
        public DsDocumento() { }
        public DsDocumento(DateTime createDate, string link, long size, string documentType, string ext)
        {
            this.CreateDate = createDate;
            this.Link = link;
            this.Size = size;
            this.DocumentType = documentType;
            this.Ext = ext;
        }

        public DateTime CreateDate { get; set; }
        public string Link { get; set; }
        public long Size { get; set; }
        public string DocumentType { get; set; }
        public string Ext { get; set; }
    }
    public class DsMessage
    {
        public DsMessage() { }
        public DsMessage(string mensagem, int codErro)
        {
            this.Texto = mensagem;
            this.CodErro = CodErro;

        }
        public DsMessage(string mensagem, int codErro, string login) 
        {
            this.Texto = mensagem;
            this.CodErro = CodErro;
            this.Login = login;
        }


        public string Texto { get; }
        public int CodErro { get; }
        public string Login { get; }
    }

}
