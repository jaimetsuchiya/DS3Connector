using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DS3ConnectorTests
{
    [TestClass]
    public class UnitTestDocType
    {
        private readonly DS3Connector.Proxy.DocType proxy = null;
        public UnitTestDocType()
        {
            proxy = new DS3Connector.Proxy.DocType();
        }

        [TestMethod]
        public void ConsultaSemParametro()
        {
            var docTypeList = proxy.Search(null);

            Assert.IsTrue(docTypeList.Status == Constants.SUCCESS);
            Assert.IsTrue(docTypeList.TotalFound == 2);
            Assert.IsTrue(docTypeList.Data.Count == 2);
        }

        [TestMethod]
        public void ConsultaComParametro65()
        {
            int id = 65;
            var docTypeList = proxy.Search(id);

            Assert.IsTrue(docTypeList.Status == Constants.SUCCESS);
            Assert.IsTrue(docTypeList.TotalFound == 1);
            Assert.IsTrue(docTypeList.Data.Count == 1);
            Assert.IsTrue(docTypeList.Data.First().Id == id);
        }

        [TestMethod]
        public void ConsultaComParametro67()
        {
            int id = 67;
            var docTypeList = proxy.Search(id);

            Assert.IsTrue(docTypeList.Status == Constants.SUCCESS);
            Assert.IsTrue(docTypeList.TotalFound == 1);
            Assert.IsTrue(docTypeList.Data.Count == 1);
            Assert.IsTrue(docTypeList.Data.First().Id == id);
        }

        [TestMethod]
        public void ConsultaComParametroInvalido()
        {
            int id = -1;
            var docTypeList = proxy.Search(id);
            Assert.IsTrue(docTypeList.Status == Constants.SUCCESS);
            Assert.IsTrue(docTypeList.TotalFound == 0);
            Assert.IsTrue(docTypeList.Data.Count == 0);
        }
    }
}
