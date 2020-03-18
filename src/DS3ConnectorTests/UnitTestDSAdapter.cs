﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DS3Connector.Adapter;

namespace DS3ConnectorTests
{
    /// <summary>
    /// Summary description for UnitTestDSAdapter
    /// </summary>
    [TestClass]
    public class UnitTestDSAdapter
    {
        private readonly DS3Connector.Adapter.DsActions actions = null;
        private readonly DS3Connector.Proxy.Document documentProxy = null;

        private DS3Connector.DTO.BoxInfo boxInfo = null;
        private DS3Connector.DTO.ProcessInfo processInfo = null;
        private DS3Connector.DTO.Document<DS3Connector.DTO.BoxInfo, DS3Connector.DTO.BoxDocType> boxInfoDocument = null;
        private DS3Connector.DTO.Document<DS3Connector.DTO.ProcessInfo, DS3Connector.DTO.ProcessDocType> processInfoDocument = null;


        #region Metodos Auxiliares

        private DS3Connector.DTO.BoxInfo BoxInfoTeste()
        {
            return new DS3Connector.DTO.BoxInfo()
            {
                ComarcaID = "64021",
                VaraID = "10000426",
                NroPacote = DateTime.Now.ToString("yyyyMMddHHmmss"),
                AnoPacote = DateTime.Today.Year.ToString(),
                NroCaixa = "9009999999"
            };
        }


        private DS3Connector.DTO.ProcessInfo ProcessInfoTeste()
        {
            return new DS3Connector.DTO.ProcessInfo()
            {
                ComarcaID = "64021",
                VaraID = "10000426",
                NroPacote = DateTime.Now.ToString("yyyyMMddHHmmss"),
                AnoPacote = DateTime.Today.Year.ToString(),
                NroProcesso= DateTime.Now.ToString("yyyyMMddHHmmss"),
                AnoProcesso = DateTime.Today.Year.ToString(),
                NroCaixa = "9009999999"
            };
        }

        private DS3Connector.DTO.Document<DS3Connector.DTO.BoxInfo, DS3Connector.DTO.BoxDocType> RecuperaBoxTeste(int? documentId = null)
        {
            var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<DS3Connector.DTO.IBoxSearchRequest>()
            {
                Id = documentId,
                DocumentInfo = boxInfo
            });


            if (documentList.Status == Constants.SUCCESS && documentList.TotalFound > 0 && documentList.Data != null && documentList.Data.Count > 0)
                return documentList.Data.First();
            else
                return null;
        }

        private DS3Connector.DTO.Document<DS3Connector.DTO.ProcessInfo, DS3Connector.DTO.ProcessDocType> RecuperaProcessTeste(int? documentId = null)
        {
            var documentList = documentProxy.Search(new DS3Connector.DTO.SearchRequest<DS3Connector.DTO.IProcessSearchRequest>()
            {
                Id = documentId,
                DocumentInfo = processInfo
            });


            if (documentList.Status == Constants.SUCCESS && documentList.TotalFound > 0 && documentList.Data != null && documentList.Data.Count > 0)
                return documentList.Data.First();
            else
                return null;
        }
        #endregion

        #region Setup

        public UnitTestDSAdapter()
        {
            actions = new DS3Connector.Adapter.DsActions();
            documentProxy = new DS3Connector.Proxy.Document();
        }


        [TestInitialize]
        public void Initialize()
        {
            //Cria Imagem de Teste
        }


        [TestCleanup]
        public void CleanUp()
        {
        }


        #endregion Setup


        #region GetImagem

        /// <summary>
        /// Tipo de Imagem 1, Imagem existe
        /// </summary>
        [TestMethod]
        public void Teste01_GetImagem()
        {
            

        }

        [TestMethod]
        public void Teste02_GetImagem()
        {
            //Tipo de Imagem 2, Imagem existe
        }

        [TestMethod]
        public void Teste03_GetImagem()
        {
            //Tipo de Imagem 1, Imagem não existe
        }

        [TestMethod]
        public void Teste04_GetImagem()
        {
            //Tipo de Imagem 2, Imagem não existe
        }


        #endregion GetImagem


        #region  UpdateFile

        /// <summary>
        /// Tipo de Imagem 1, Upload Ok
        /// </summary>
        [TestMethod]
        public void Teste11_UpdateFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 2, Upload Ok
        /// </summary>
        [TestMethod]
        public void Teste12_UpdateFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 1, Base64 vazio
        /// </summary>
        [TestMethod]
        public void Teste13_UpdateFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 2, Base64 vazio
        /// </summary>
        [TestMethod]
        public void Teste14_UpdateFile()
        {


        }

        #endregion


        #region  SendFile

        /// <summary>
        /// Tipo de Imagem 1, Upload Ok
        /// </summary>
        [TestMethod]
        public void Teste21_SendFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 2, Upload Ok
        /// </summary>
        [TestMethod]
        public void Teste22_SendFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 1, Base64 vazio
        /// </summary>
        [TestMethod]
        public void Teste23_SendFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 2, Base64 vazio
        /// </summary>
        [TestMethod]
        public void Teste24_SendFile()
        {


        }

        #endregion


        #region  InactiveFile


        /// <summary>
        /// Tipo de Imagem 1, Arquivo oK
        /// </summary>
        [TestMethod]
        public void Teste31_InactiveFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 2, Arquivo oK
        /// </summary>
        [TestMethod]
        public void Teste32_InactiveFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 1, Arquivo não encontrado
        /// </summary>
        [TestMethod]
        public void Teste33_InactiveFile()
        {


        }

        /// <summary>
        /// Tipo de Imagem 2, Arquivo não encontrado
        /// </summary>
        [TestMethod]
        public void Teste34_InactiveFile()
        {


        }

        #endregion  InactiveFile

    }
}
