using DS3Connector.DTO;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS3Connector.Adapter
{
    public class DsActions
    {
        private const string SUCCESS = "SUCCESS";
        private readonly DS3Connector.Proxy.AttachDoc attachProxy;
        private readonly DS3Connector.Proxy.Document documentProxy;

        public DsActions()
        {
            attachProxy = new Proxy.AttachDoc();
            documentProxy = new Proxy.Document();
        }

        public DsMessage EnviarArquivo(string NomeDocumento, List<DsKeyword> ChavesDocumento, DsFile arquivo)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            if(docTypeId.Value == 65)
            {
                var novoDocumento = documentProxy.Create(
                   new DS3Connector.DTO.CreateDocument<BoxInfo>()
                   {
                       Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                       {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            Base64 = System.Convert.ToBase64String(arquivo.FileData),
                        }
                       },
                       DocumentInfo = ConvertTo.BoxInfo(ChavesDocumento),
                   }
               );

                return new DsMessage(novoDocumento.Message, (novoDocumento.Status == SUCCESS ? 0 : 500));
            }
            else
            {
                var novoDocumento = documentProxy.Create(
                   new DS3Connector.DTO.CreateDocument<ProcessInfo>()
                   {
                       Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                       {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            Base64 = System.Convert.ToBase64String(arquivo.FileData),
                        }
                       },
                       DocumentInfo = ConvertTo.ProcessInfo(ChavesDocumento),
                   }
               );

                return new DsMessage(novoDocumento.Message, (novoDocumento.Status == SUCCESS ? 0 : 500));
            }
        }

        public DsMessage EnviarArquivo(string NomeDocumento, List<DsKeyword> ChavesDocumento, string arquivo)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            if( docTypeId.Value == 65 )
            {
                var novoDocumento = documentProxy.Create(
                    new DS3Connector.DTO.CreateDocument<BoxInfo>()
                    {
                        Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                        {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            Base64 = System.Convert.ToBase64String(File.ReadAllBytes(arquivo)),
                        }
                        },
                        DocumentInfo = ConvertTo.BoxInfo(ChavesDocumento),
                    }
                );
                return new DsMessage(novoDocumento.Message, (novoDocumento.Status == SUCCESS ? 0 : 500));
            }
            else
            {
                var novoDocumento = documentProxy.Create(
                    new DS3Connector.DTO.CreateDocument<ProcessInfo>()
                    {
                        Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                        {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            Base64 = System.Convert.ToBase64String(File.ReadAllBytes(arquivo)),
                        }
                        },
                        DocumentInfo = ConvertTo.ProcessInfo(ChavesDocumento),
                    }
                );
                return new DsMessage(novoDocumento.Message, (novoDocumento.Status == SUCCESS ? 0 : 500));
            }
        }

        public DsMessage ExcluirArquivo(string NomeDocumento, List<DsKeyword> ChavesDocumento)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            //Apaga Documento
            if( docTypeId == 65)
            {
                var resultDelete = documentProxy.Delete(new DS3Connector.DTO.UpdateDocument<BoxInfo>()
                {
                    DocumentInfo = ConvertTo.BoxInfo(ChavesDocumento)
                });

                return new DsMessage(resultDelete.Message, (resultDelete.Status == SUCCESS && resultDelete.TotalFound > 0 ? 0 : 404));
            }
            else
            {
                var resultDelete = documentProxy.Delete(new DS3Connector.DTO.UpdateDocument<ProcessInfo>()
                {
                    DocumentInfo = ConvertTo.ProcessInfo(ChavesDocumento)
                });

                return new DsMessage(resultDelete.Message, (resultDelete.Status == SUCCESS && resultDelete.TotalFound > 0 ? 0 : 404));
            }
        }

        public DsMessage PesquisarArquivos(string NomeDocumento, List<DsKeyword> ChavesDocumento)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            if(docTypeId == 65)
            {
                var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<DTO.IBoxSearchRequest>()
                {
                    DocumentInfo = ConvertTo.BoxSearchRequestInfo(ChavesDocumento)
                });

                return new DsMessage(documentList.Message, (documentList.Status == SUCCESS && documentList.TotalFound > 0 ? 0 : 404));
            }
            else
            {
                var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<DTO.IProcessSearchRequest>()
                {
                    DocumentInfo = ConvertTo.ProcessSearchRequestInfo(ChavesDocumento)
                });

                return new DsMessage(documentList.Message, (documentList.Status == SUCCESS && documentList.TotalFound > 0 ? 0 : 404));
            }
        }

        public DsSearchDoc PesquisarArquivosObjeto(string NomeDocumento, List<DsKeyword> ChavesDocumento)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            if (docTypeId == 65)
            {
                var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<DTO.IBoxSearchRequest>()
                {
                    DocumentInfo = ConvertTo.BoxSearchRequestInfo(ChavesDocumento)
                });

                return new DsSearchDoc(documentList.Message,
                                        (documentList.Status == SUCCESS && documentList.TotalFound > 0 ? 0 : 404),
                                        ConvertTo.DsDocumentoList(documentList.Data));
            }
            else
            {
                var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<DTO.IProcessSearchRequest>()
                {
                    DocumentInfo = ConvertTo.ProcessSearchRequestInfo(ChavesDocumento)
                });

                return new DsSearchDoc(documentList.Message,
                                    (documentList.Status == SUCCESS && documentList.TotalFound > 0 ? 0 : 404),
                                    ConvertTo.DsDocumentoList(documentList.Data));
            }
            
        }


        public DsMessage updFile(string NomeDocumento, List<DsKeyword> ChavesDocumento, List<DsKeyword> ChavesDocumentoAtualizar, DsFile arquivo)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            //Searh Old Document
            if( docTypeId.Value == 65)
            {
                var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<IBoxSearchRequest>()
                {
                    DocumentInfo = ConvertTo.BoxInfo(ChavesDocumento)
                });

                if (documentList.Status == SUCCESS && documentList.Data != null && documentList.Data.Count > 0 && documentList.Data.First().Attachments.Count > 0)
                {
                    for (var i = 0; i < documentList.Data.First().Attachments.Count; i++)
                    {
                        var resultDelete = attachProxy.Delete(new DS3Connector.DTO.EditAttach<BoxInfo>()
                        {
                            Id = documentList.Data.First().Attachments[i].Id
                        });

                        if (resultDelete.Status != SUCCESS)
                            throw new ApplicationException(resultDelete.Message);
                    }
                }

                var resultadoUpdate = documentProxy.Update(new DS3Connector.DTO.UpdateDocument<BoxInfo>()
                {
                    DocumentInfo = ConvertTo.BoxInfo(ChavesDocumento),
                    NewDocumentInfo = ConvertTo.BoxInfo(ChavesDocumentoAtualizar),
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>() {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            Base64 = System.Convert.ToBase64String(arquivo.FileData)
                        }
                    }
                });

                return new DsMessage(resultadoUpdate.Message, (resultadoUpdate.Status == SUCCESS ? 0 : 500));
            }
            else
            {
                var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<IProcessSearchRequest>()
                {
                    DocumentInfo = ConvertTo.ProcessInfo(ChavesDocumento)
                });

                if (documentList.Status == SUCCESS && documentList.Data != null && documentList.Data.Count > 0 && documentList.Data.First().Attachments.Count > 0)
                {
                    for (var i = 0; i < documentList.Data.First().Attachments.Count; i++)
                    {
                        var resultDelete = attachProxy.Delete(new DS3Connector.DTO.EditAttach<ProcessInfo>()
                        {
                            Id = documentList.Data.First().Attachments[i].Id
                        });

                        if (resultDelete.Status != SUCCESS)
                            throw new ApplicationException(resultDelete.Message);
                    }
                }

                var resultadoUpdate = documentProxy.Update(new DS3Connector.DTO.UpdateDocument<ProcessInfo>()
                {
                    DocumentInfo = ConvertTo.ProcessInfo(ChavesDocumento),
                    NewDocumentInfo = ConvertTo.ProcessInfo(ChavesDocumentoAtualizar),
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>() {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            Base64 = System.Convert.ToBase64String(arquivo.FileData)
                        }
                    }
                });

                return new DsMessage(resultadoUpdate.Message, (resultadoUpdate.Status == SUCCESS ? 0 : 500));
            }
        }

        public DsMessage updFile(string NomeDocumento, List<DsKeyword> ChavesDocumento, List<DsKeyword> ChavesDocumentoAtualizar)
        {
            var docTypeId = ConvertTo.DocTypeId(NomeDocumento);
            if (!docTypeId.HasValue)
                throw new InvalidCastException("Tipo de documento inválido!");

            if(docTypeId.Value == 65 )
            {
                var resultadoUpdate = documentProxy.Update(new DS3Connector.DTO.UpdateDocument<BoxInfo>()
                {
                    DocumentInfo = ConvertTo.BoxInfo(ChavesDocumento),
                    NewDocumentInfo = ConvertTo.BoxInfo(ChavesDocumentoAtualizar)
                });

                return new DsMessage(resultadoUpdate.Message, (resultadoUpdate.Status == SUCCESS ? 0 : 404));

            }
            else
            {
                var resultadoUpdate = documentProxy.Update(new DS3Connector.DTO.UpdateDocument<ProcessInfo>()
                {
                    DocumentInfo = ConvertTo.ProcessInfo(ChavesDocumento),
                    NewDocumentInfo = ConvertTo.ProcessInfo(ChavesDocumentoAtualizar)
                });

                return new DsMessage(resultadoUpdate.Message, (resultadoUpdate.Status == SUCCESS ? 0 : 404));

            }
        }
    }

    public static class ConvertTo
    {
        public static int? DocTypeId(string tipoDocumento)
        {
            int? result = null;

            if (!string.IsNullOrEmpty(tipoDocumento))
            {
                if (tipoDocumento.Trim().ToUpper().StartsWith("ESPELHO DA CAIXA"))
                    result = 65;
                else if (tipoDocumento.Trim().ToUpper().StartsWith("FOLHA DE PROCESSO"))
                    result = 67;
            }

            return result;
        }

        public static DTO.BoxInfo BoxInfo(List<DsKeyword> keywords)
        {
            var result = new DTO.BoxInfo();

            if (keywords != null)
            {
                foreach (var key in keywords)
                {
                    switch (key.Id)
                    {
                        case 19:
                            result.ComarcaID = key.Value;
                            break;

                        case 20:
                            result.VaraID = key.Value;
                            break;

                        case 21:
                            result.NroPacote = key.Value;
                            break;

                        case 22:
                            result.AnoPacote = key.Value;
                            break;

                        case 23:
                            result.NroCaixa = key.Value;
                            break;

                        case 24:
                            result.NroItem = key.Value;
                            break;
                    }
                }
            }

            return result;
        }

        public static DTO.BoxSearchRequestInfo BoxSearchRequestInfo(List<DsKeyword> keywords)
        {
            var result = new DTO.BoxSearchRequestInfo();

            if (keywords != null)
            {
                foreach (var key in keywords)
                {
                    switch (key.Id)
                    {
                        case 19:
                            result.ComarcaID = key.Value;
                            break;

                        case 20:
                            result.VaraID = key.Value;
                            break;

                        case 21:
                            result.NroPacote = key.Value;
                            break;

                        case 22:
                            result.AnoPacote = key.Value;
                            break;

                        case 23:
                            result.NroCaixa = key.Value;
                            break;

                    }
                }
            }

            return result;
        }

        public static DTO.ProcessInfo ProcessInfo(List<DsKeyword> keywords)
        {
            var result = new DTO.ProcessInfo();

            if (keywords != null)
            {
                foreach (var key in keywords)
                {
                    switch (key.Id)
                    {
                        case 19:
                            result.ComarcaID = key.Value;
                            break;

                        case 20:
                            result.VaraID = key.Value;
                            break;

                        case 21:
                            result.NroPacote = key.Value;
                            break;

                        case 22:
                            result.AnoPacote = key.Value;
                            break;

                        case 23:
                            result.NroCaixa = key.Value;
                            break;

                        case 24:
                            result.NroItem = key.Value;
                            break;

                        case 25:
                            result.NroProcesso = key.Value;
                            break;

                        case 26:
                            result.AnoProcesso = key.Value;
                            break;
                    }
                }
            }

            return result;
        }

        public static DTO.ProcessSearchRequestInfo ProcessSearchRequestInfo(List<DsKeyword> keywords)
        {
            var result = new DTO.ProcessSearchRequestInfo();

            if (keywords != null)
            {
                foreach (var key in keywords)
                {
                    switch (key.Id)
                    {
                        case 19:
                            result.ComarcaID = key.Value;
                            break;

                        case 20:
                            result.VaraID = key.Value;
                            break;

                        case 21:
                            result.NroPacote = key.Value;
                            break;

                        case 22:
                            result.AnoPacote = key.Value;
                            break;

                        case 23:
                            result.NroCaixa = key.Value;
                            break;

                        case 25:
                            result.NroProcesso = key.Value;
                            break;

                        case 26:
                            result.AnoProcesso = key.Value;
                            break;
                    }
                }
            }

            return result;
        }

        public static List<DsDocumento> DsDocumentoList(List<Document<BoxInfo, BoxDocType>> documentList)
        {
            var result = new List<DsDocumento>();

            if( documentList != null)
            {
                for (var i = 0; i < documentList.Count; i++)
                    result.Add(ConvertTo.DsDocumento(documentList[i]));
            }

            return result;
        }

        public static List<DsDocumento> DsDocumentoList(List<Document<ProcessInfo, ProcessDocType>> documentList)
        {
            var result = new List<DsDocumento>();

            if (documentList != null)
            {
                for (var i = 0; i < documentList.Count; i++)
                    result.Add(ConvertTo.DsDocumento(documentList[i]));
            }

            return result;
        }

        public static DsDocumento DsDocumento(Document<BoxInfo, BoxDocType> document)
        {
            var result = new DsDocumento();

            result.CreateDate = document.CreatedAt.Value;
            result.DocumentType = document.DocType.Name;
            if (document.Attachments != null && document.Attachments.Count > 0)
            {
                result.Link = document.Attachments.First().URL;
                result.Size = document.Attachments.First().FileSize;
                result.Ext = Path.GetExtension(document.Attachments.First().ContentType);
            }

            return result;
        }

        public static DsDocumento DsDocumento(Document<ProcessInfo, ProcessDocType> document)
        {
            var result = new DsDocumento();

            result.CreateDate = document.CreatedAt.Value;
            result.DocumentType = document.DocType.Name;
            if (document.Attachments != null && document.Attachments.Count > 0)
            {
                result.Link = document.Attachments.First().URL;
                result.Size = document.Attachments.First().FileSize;
                result.Ext = Path.GetExtension(document.Attachments.First().ContentType);
            }

            return result;

        }


    }
}
