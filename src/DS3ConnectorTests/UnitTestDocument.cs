using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DS3ConnectorTests
{
    /// <summary>
    /// Summary description for UnitTestDocument
    /// </summary>
    [TestClass]
    public class UnitTestDocument
    {
        private readonly DS3Connector.Proxy.Document proxy = null;
        private DS3Connector.DTO.DocumentInfo documentInfo = null;
        private int? documentId = null;

        #region Setup

        public UnitTestDocument()
        {
            proxy = new DS3Connector.Proxy.Document();
        }
        

        [TestInitialize]
        public void Initialize()
        {
            documentInfo = DocumentoInfoTeste();
        }


        [TestCleanup]
        public void CleanUp()
        {
            var newDocument = RecuperaDocumentoTeste(documentId);
            if (newDocument != null)
            {
                //Delete Document
                var deleteResult = proxy.Delete(new DS3Connector.DTO.UpdateDocument()
                {
                    Id = newDocument.Id,
                    DocTypeId = newDocument.DocType.Id,
                    DocumentInfo = newDocument.DocumentInfo
                });

                if (deleteResult.Status != Constants.SUCCESS)
                    Assert.Fail("Falha na exclusão do registro de teste!");
            }
        }


        #endregion Setup


        #region Search Document

        [TestMethod]
        public void ConsultaDocumento()
        {
            var documentList = proxy.Search(new DS3Connector.DTO.SearchRequest()
            {
                DocTypeId = 65,
                DocumentInfo = new DS3Connector.DTO.DocumentSearchRequest()
                {
                    ComarcaID = "64088",
                    VaraID = "10003220",
                    NroPacote = "582",
                    AnoPacote = "2002",
                    NroCaixa = "9009482868"
                }
            });

            Assert.IsTrue(documentList.Status == Constants.SUCCESS);
            Assert.IsTrue(documentList.TotalFound == 1);
            Assert.IsTrue(documentList.Data.Count == 1);
        }


        [TestMethod]
        public void ConsultaDocumentos()
        {
            List<DS3Connector.DTO.Document> documentos = new List<DS3Connector.DTO.Document>();

            var documentList = proxy.Search(new DS3Connector.DTO.SearchRequest()
            {
                DocTypeId = 65,
                DocumentInfo = new DS3Connector.DTO.DocumentSearchRequest()
                {
                    ComarcaID = "63982"
                }
            });

            Assert.IsTrue(documentList.Status == Constants.SUCCESS);
            Assert.IsTrue(documentList.TotalFound > documentList.Data.Count);

            var recordCount = documentList.TotalFound;
            var pageSize = documentList.TotalPerPage.Value;
            var page = 2;
            var pageCount = Convert.ToInt32(recordCount / pageSize);
            if (recordCount % pageSize != 0)
                pageCount = pageCount + 1;
                
            documentos.AddRange(documentList.Data);

            for ( var i=page; i <= pageCount; i++)
            {
                documentList = proxy.Search(new DS3Connector.DTO.SearchRequest()
                {
                    DocTypeId = 65,
                    Page = i,
                    DocumentInfo = new DS3Connector.DTO.DocumentSearchRequest()
                    {
                        ComarcaID = "63982"
                    }
                });
                documentos.AddRange(documentList.Data);
            }
            Assert.IsTrue(documentos.Count == recordCount);
            Assert.IsFalse(documentos.Any(x=>x.DocumentInfo.ComarcaID != "63982"));
        }


        [TestMethod]
        public void ConsultaDocumentoSemResultado()
        {
            List<DS3Connector.DTO.Document> documentos = new List<DS3Connector.DTO.Document>();

            var documentList = proxy.Search(new DS3Connector.DTO.SearchRequest()
            {
                DocTypeId = 65,
                DocumentInfo = new DS3Connector.DTO.DocumentSearchRequest()
                {
                    ComarcaID = "99999"
                }
            });

            Assert.IsTrue(documentList.Status == Constants.SUCCESS);
            Assert.IsTrue(documentList.TotalFound == 0);
            Assert.IsTrue(documentList.Data.Count == 0);
        }

        #endregion Search Document


        #region Create Document


        [TestMethod]
        public void CriarDocumento01()
        {
            var novoDocumento = proxy.Create(
                new DS3Connector.DTO.CreateDocument() {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                    {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        { 
                            FileURL = "https://cdn.pixabay.com/photo/2012/10/29/15/36/ball-63527_960_720.jpg"
                        }
                    },
                    DocumentInfo = documentInfo,
                }
            );

            Assert.IsTrue(novoDocumento.Status == Constants.SUCCESS);
            Assert.IsTrue(novoDocumento.Data.Id > 0);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.ComarcaID == documentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.VaraID == documentInfo.VaraID);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.NroCaixa == documentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.AnoPacote == documentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.NroPacote == documentInfo.NroPacote);


            documentId = novoDocumento.Data.Id;
            
            var tmp = RecuperaDocumentoTeste(novoDocumento.Data.Id);
            Assert.IsTrue(novoDocumento.Data.Id == tmp?.Id,  "Falha ao recuperar o documento após a criação");
            Assert.IsTrue(novoDocumento.Data.Attachments.Count > 0);
        }


        [TestMethod]
        public void CriarDocumento02()
        {
            var novoDocumento1 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                    {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            FileURL = "https://cdn.pixabay.com/photo/2012/10/29/15/36/ball-63527_960_720.jpg"
                        }
                    },
                    DocumentInfo = documentInfo,
                }
            );

            Assert.IsTrue(novoDocumento1.Status == Constants.SUCCESS);
            Assert.IsTrue(novoDocumento1.Data.Id > 0);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.ComarcaID == documentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.VaraID == documentInfo.VaraID);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.NroCaixa == documentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.AnoPacote == documentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.NroPacote == documentInfo.NroPacote);

            documentId = novoDocumento1.Data.Id;

            var novoDocumento2 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                    {
                        new DS3Connector.DTO.CreateDocumentAttachment()
                        {
                            FileURL = "https://cdn.pixabay.com/photo/2014/09/05/18/33/old-letters-436501_960_720.jpg"
                        }
                    },
                    DocumentInfo = documentInfo,
                }
            );

            Assert.IsTrue(novoDocumento2.Status == Constants.SUCCESS);
            Assert.IsTrue(novoDocumento2.Data.Id > 0);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.ComarcaID == documentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.VaraID == documentInfo.VaraID);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.NroCaixa == documentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.AnoPacote == documentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.NroPacote == documentInfo.NroPacote);

            //Sleep inserido par aguardar a replicação do cache
            Thread.Sleep(2500);


            var lst = RecuperaDocumentosTeste();
            if( lst.Count > 0 )
                Assert.IsTrue(lst.Any(x=>x.Id == novoDocumento1.Data.Id) && lst.Any(x => x.Id == novoDocumento2.Data.Id));


            var tmp1 = lst.First(x => x.Id == novoDocumento1.Data.Id);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.ComarcaID == tmp1.DocumentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.VaraID == tmp1.DocumentInfo.VaraID);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.NroCaixa == tmp1.DocumentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.AnoPacote == tmp1.DocumentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.NroPacote == tmp1.DocumentInfo.NroPacote);

            var tmp2 = lst.First(x => x.Id == novoDocumento2.Data.Id);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.ComarcaID == tmp2.DocumentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.VaraID == tmp2.DocumentInfo.VaraID);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.NroCaixa == tmp2.DocumentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.AnoPacote == tmp2.DocumentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento2.Data.DocumentInfo.NroPacote == tmp2.DocumentInfo.NroPacote);

        }



        [TestMethod]
        public void CriarDocumento03()
        {
            var novoDocumento1 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>(),
                    DocumentInfo = documentInfo,
                }
            );

            Assert.IsTrue(novoDocumento1.Status == Constants.SUCCESS);
            Assert.IsTrue(novoDocumento1.Data.Id > 0);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.ComarcaID == documentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.VaraID == documentInfo.VaraID);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.NroCaixa == documentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.AnoPacote == documentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento1.Data.DocumentInfo.NroPacote == documentInfo.NroPacote);

            documentId = novoDocumento1.Data.Id;
        }



        #endregion Create Document


        #region Update Document

        [TestMethod]
        public void UpdateDocument01()
        {
            //Cria Documento 
            var novoDocumento = proxy.Create(
                    new DS3Connector.DTO.CreateDocument()
                    {
                        DocTypeId = 65,
                        Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>()
                        {
                            new DS3Connector.DTO.CreateDocumentAttachment()
                            {
                                FileURL = "https://cdn.pixabay.com/photo/2012/10/29/15/36/ball-63527_960_720.jpg"
                            }
                        },
                        DocumentInfo = documentInfo,
                    }
                );

            Assert.IsTrue(novoDocumento.Status == Constants.SUCCESS);
            Assert.IsTrue(novoDocumento.Data.Id > 0);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.ComarcaID == documentInfo.ComarcaID);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.VaraID == documentInfo.VaraID);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.NroCaixa == documentInfo.NroCaixa);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.AnoPacote == documentInfo.AnoPacote);
            Assert.IsTrue(novoDocumento.Data.DocumentInfo.NroPacote == documentInfo.NroPacote);


            var novoDocumentInfo = this.documentInfo;

            //Atualiza Caixa
            novoDocumentInfo.NroCaixa = "9009637942";

            //Insere novo Attach
            //Atualiza o Documento
            var resultadoUpdate = proxy.Update(new DS3Connector.DTO.UpdateDocument()
            {
                DocTypeId = 65,
                Id = novoDocumento.Data.Id,
                DocumentInfo = documentInfo,
                NewDocumentInfo = novoDocumentInfo,
                Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>() { 
                    new DS3Connector.DTO.CreateDocumentAttachment()
                    { 
                        FileURL = "https://cdn.pixabay.com/photo/2014/09/05/18/33/old-letters-436501_960_720.jpg"
                    }
                }
            });


            Assert.IsTrue(resultadoUpdate.Status == Constants.SUCCESS);

            //Consulta Documento
            var tmp = RecuperaDocumentoTeste(novoDocumento.Data.Id);
            Assert.IsTrue(novoDocumento.Data.Id == tmp?.Id);
            Assert.IsTrue(resultadoUpdate.Data.Count > 0);
            Assert.IsTrue(resultadoUpdate.Data.First().Id == tmp?.Id);

            Assert.IsTrue(tmp.DocumentInfo.NroCaixa == novoDocumentInfo.NroCaixa );
            Assert.IsTrue(tmp.Attachments.Count == 2);
        }



        #endregion Update Document


        #region Delete Document


        [TestMethod]
        public void DeleteDocument01()
        {
            //Cria Documento
            var novoDocumento1 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>(),
                    DocumentInfo = documentInfo,
                }
            );

            Assert.IsTrue(novoDocumento1.Status == Constants.SUCCESS);
            Assert.IsTrue(novoDocumento1.Data.Id > 0);
            documentId = novoDocumento1.Data.Id;


            //Apaga Documento
            var resultDelete = proxy.Delete(new DS3Connector.DTO.UpdateDocument()
            {
                Id = novoDocumento1.Data.Id,
                DocTypeId = novoDocumento1.Data.DocType.Id,
                DocumentInfo = novoDocumento1.Data.DocumentInfo
            });

            Assert.IsTrue(resultDelete.Status == Constants.SUCCESS);
            Assert.IsTrue(resultDelete.Data.Id == novoDocumento1.Data.Id);


            //Consulta Documento
            var consultaResult = this.RecuperaDocumentoTeste(resultDelete.Data.Id);
            Assert.IsTrue(consultaResult == null);

        }


        [TestMethod]
        public void DeleteDocument02()
        {
            //Solicita Deleção de documento inexistente
            var resultDelete = proxy.Delete(new DS3Connector.DTO.UpdateDocument()
            {
                Id = 999999,
                DocTypeId = 65,
                DocumentInfo = documentInfo
            });

            Assert.IsTrue(resultDelete.Status != Constants.SUCCESS);
        }


        [TestMethod]
        public void DeleteDocument03()
        {
            documentInfo.NroCaixa = "90009999999999";

            var novoDocumento1 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>(),
                    DocumentInfo = documentInfo,
                }
            );
            Assert.IsTrue(novoDocumento1.Status == Constants.SUCCESS);


            var novoDocumento2 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>(),
                    DocumentInfo = documentInfo,
                }
            );
            Assert.IsTrue(novoDocumento2.Status == Constants.SUCCESS);


            var novoDocumento3 = proxy.Create(
                new DS3Connector.DTO.CreateDocument()
                {
                    DocTypeId = 65,
                    Attachments = new List<DS3Connector.DTO.CreateDocumentAttachment>(),
                    DocumentInfo = documentInfo,
                }
            );
            Assert.IsTrue(novoDocumento3.Status == Constants.SUCCESS);


            //Aguardando a replicação do cache
            Thread.Sleep(2500);


            //Solicita Deleção de documento sem informar o id com critério que retorna mais de um documento
            var resultDelete = proxy.Delete(new DS3Connector.DTO.UpdateDocument()
            {
                DocTypeId = 65,
                DocumentInfo = documentInfo
            });
            Assert.IsTrue(resultDelete.Status == Constants.SUCCESS);

            resultDelete = proxy.Delete(new DS3Connector.DTO.UpdateDocument()
            {
                DocTypeId = 65,
                DocumentInfo = documentInfo
            });
            Assert.IsTrue(resultDelete.Status == Constants.SUCCESS);

            resultDelete = proxy.Delete(new DS3Connector.DTO.UpdateDocument()
            {
                DocTypeId = 65,
                DocumentInfo = documentInfo
            });
            Assert.IsTrue(resultDelete.Status == Constants.SUCCESS);


            Assert.IsTrue(this.RecuperaDocumentoTeste(novoDocumento1.Data.Id) == null);
            Assert.IsTrue(this.RecuperaDocumentoTeste(novoDocumento2.Data.Id) == null);
            Assert.IsTrue(this.RecuperaDocumentoTeste(novoDocumento3.Data.Id) == null);
        }

        #endregion Delete Document


        #region Auxiliar Methods

        private DS3Connector.DTO.DocumentInfo DocumentoInfoTeste()
        {
            return new DS3Connector.DTO.DocumentInfo()
            {
                ComarcaID = "64021",
                VaraID = "10000426",
                NroPacote = DateTime.Now.ToString("yyyyMMddHHmmss"),
                AnoPacote = DateTime.Today.Year.ToString(),
                NroCaixa = "9009482868"
            };
        }

        private DS3Connector.DTO.Document RecuperaDocumentoTeste(int? documentId = null)
        {
            var documentList = proxy.Search(new DS3Connector.DTO.SearchRequest()
            {
                DocTypeId = 65,
                Id = documentId,
                DocumentInfo = documentInfo
            });

            if (documentList.Status == Constants.SUCCESS && documentList.TotalFound > 0)
                return documentList.Data.First();
            else
                return null;
        }


        private List<DS3Connector.DTO.Document> RecuperaDocumentosTeste()
        {
            var documentList = proxy.Search(new DS3Connector.DTO.SearchRequest()
            {
                DocTypeId = 65,
                DocumentInfo = documentInfo
            });


            if (documentList.Status == Constants.SUCCESS && documentList.TotalFound > 0)
                return documentList.Data;
            else
                return null;
        }
        #endregion
    }
}
