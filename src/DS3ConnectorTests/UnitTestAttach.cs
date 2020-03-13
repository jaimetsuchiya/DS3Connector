using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DS3ConnectorTests
{
    [TestClass]
    public class UnitTestAttach
    {
        private readonly DS3Connector.Proxy.AttachDoc proxy = null;
        private readonly DS3Connector.Proxy.Document documentProxy = null;

        private DS3Connector.DTO.DocumentInfo documentInfo = null;
        private DS3Connector.DTO.Document document = null;

        #region Setup

        public UnitTestAttach()
        {
            proxy = new DS3Connector.Proxy.AttachDoc();
            documentProxy = new DS3Connector.Proxy.Document();
        }


        [TestInitialize]
        public void Initialize()
        {
            documentInfo = DocumentoInfoTeste();

            var novoDocumento = documentProxy.Create(
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

            if (novoDocumento.Status == Constants.SUCCESS)
                document = novoDocumento.Data;
        }


        [TestCleanup]
        public void CleanUp()
        {
            if (document != null)
            {
                //Delete Document
                var deleteResult = documentProxy.Delete(new DS3Connector.DTO.UpdateDocument()
                {
                    Id = document.Id,
                    DocTypeId = document.DocType.Id,
                    DocumentInfo = document.DocumentInfo
                });

                if (deleteResult.Status != Constants.SUCCESS)
                    Assert.Fail("Falha na exclusão do registro de teste!");
            }
        }


        #endregion Setup


        #region Auxiliar Methods

        private DS3Connector.DTO.DocumentInfo DocumentoInfoTeste()
        {
            return new DS3Connector.DTO.DocumentInfo()
            {
                ComarcaID = "64021",
                VaraID = "10000426",
                NroPacote = DateTime.Now.ToString("yyyyMMddHHmmss"),
                AnoPacote = DateTime.Today.Year.ToString(),
                NroCaixa = "9009999999"
            };
        }

        private DS3Connector.DTO.Document RecuperaDocumentoTeste(int? documentId = null)
        {
            var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest()
            {
                Id = documentId,
                DocTypeId = 65,
                DocumentInfo = documentInfo
            });


            if (documentList.Status == Constants.SUCCESS && documentList.TotalFound > 0 && documentList.Data != null && documentList.Data.Count > 0)
                return documentList.Data.First();
            else
                return null;
        }

        private List<DS3Connector.DTO.Document> RecuperaDocumentosTeste()
        {
            var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest()
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


        #region Search

        [TestMethod]
        public void SearchAttach01()
        {
            //Recupera o attach do documento teste pelo Id do attach
            var resultAttach = proxy.Search(new DS3Connector.DTO.AttachDocSearchRequest()
            {
                DocTypeId = document.DocType.Id,
                Id = document.Attachments.First().Id
            });

            Assert.IsTrue(resultAttach.Status == Constants.SUCCESS);
            Assert.IsTrue(resultAttach.Data.Count > 0);
            Assert.IsTrue(resultAttach.Data.First().Id == document.Attachments.First().Id);
        }


        [TestMethod]
        public void SearchAttach02()
        {
            //Recupera o attach do documento teste pelo Id do documento
            var resultAttach = proxy.Search(new DS3Connector.DTO.AttachDocSearchRequest()
            {
                DocTypeId = document.DocType.Id,
                DocumentId = document.Id
            });

            Assert.IsTrue(resultAttach.Status == Constants.SUCCESS);
            Assert.IsTrue(resultAttach.Data.Count > 0);
            Assert.IsTrue(resultAttach.Data.First().Id == document.Attachments.First().Id);
        }



        [TestMethod]
        public void SearchAttach03()
        {
            //Recupera o attach do documento teste pelo documentInfo
            var resultAttach = proxy.Search(new DS3Connector.DTO.AttachDocSearchRequest()
            {
                DocTypeId = document.DocType.Id,
                DocumentInfo = document.DocumentInfo
            });


            Assert.IsTrue(resultAttach.Status == Constants.SUCCESS);
            Assert.IsTrue(resultAttach.Data.Count > 0);
            Assert.IsTrue(resultAttach.Data.First().Id == document.Attachments.First().Id);
        }
        

        #endregion Search


        #region Create

        [TestMethod]
        public void CreateAttach01()
        {
            var imagesCount = document.Attachments.Count;

            //Insere um novo attach no documento teste
            var resultCreate = proxy.Create(new DS3Connector.DTO.EditAttach()
            {
                DocTypeId = document.DocType.Id,
                DocumentId = document.Id,
                DocumentInfo = document.DocumentInfo,
                URL_FILE = "https://image.shutterstock.com/image-photo/archive-folder-pile-files-600w-789157507.jpg"
            });

            Assert.IsTrue(resultCreate.Status == Constants.SUCCESS);
            Thread.Sleep(2500);

            var tmp = RecuperaDocumentoTeste(document.Id);
            Assert.IsTrue(tmp.Attachments.Count == imagesCount + 1);
        }

        #endregion Create


        #region Update

        [TestMethod]
        public void UpdateAttach01()
        {
            var imagesCount = document.Attachments.Count;

            //Altera o arquivo do documento teste
            var resultCreate = proxy.Update(new DS3Connector.DTO.EditAttach() 
            { 
                DocTypeId = document.DocType.Id,
                DocumentId = document.Id,
                Id = document.Attachments.First().Id,
                DocumentInfo = document.DocumentInfo,
                URL_FILE = "https://image.shutterstock.com/image-photo/archive-folder-pile-files-600w-789157507.jpg"
            });

            Assert.IsTrue(resultCreate.Status == Constants.SUCCESS);
            Thread.Sleep(2500);

            var tmp = RecuperaDocumentoTeste(document.Id);
            Assert.IsTrue(tmp.Attachments.Count == imagesCount);

        }



        #endregion Update


        #region Delete

        [TestMethod]
        public void DeleteAttach01()
        {
            var imagesCount = document.Attachments.Count;

            //Insere um novo attach no documento teste
            var resultCreate = proxy.Create(new DS3Connector.DTO.EditAttach()
            {
                DocTypeId = document.DocType.Id,
                DocumentId = document.Id,
                DocumentInfo = document.DocumentInfo,
                URL_FILE = "https://image.shutterstock.com/image-photo/archive-folder-pile-files-600w-789157507.jpg"
            });

            Assert.IsTrue(resultCreate.Status == Constants.SUCCESS);
            Thread.Sleep(2500);

            //Remove o arquivo do documento teste
            var resultDelete = proxy.Delete(new DS3Connector.DTO.EditAttach()
            {
                Id = resultCreate.Data.Id,
                DocTypeId = document.DocType.Id
            });

            Assert.IsTrue(resultDelete.Status == Constants.SUCCESS);
            Thread.Sleep(2500);


            var tmp = RecuperaDocumentoTeste(document.Id);
            Assert.IsTrue(tmp.Attachments.Count == imagesCount);
        }


        #endregion Delete
    }
}
