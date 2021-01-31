using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Servce;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ModelTests
    {
        IDataRepo testDataRepository;
        ListOfReasons reason_list;

        [TestInitialize]
        public void Initialize()
        {
            testDataRepository = new DataRepo_Test();
            reason_list = new ListOfReasons(testDataRepository);
        }

        [TestMethod]
        public void GetReasonTest()
        {
            SalesReasonModel reasonModel = reason_list.GetThisModel(0);
            Assert.AreEqual(reasonModel.Id, 0);
            Assert.AreEqual(reasonModel.Name, "Test1");
            Assert.AreEqual(reasonModel.ReasonSale, "type");

        }

        [TestMethod]
        public void DeleteLocationTest()
        {
            reason_list.GetThisModel(4);
            int before = reason_list.Models.Count;
            reason_list.DeleteModel();
            int after = reason_list.Models.Count;
            Assert.AreEqual(before, after);
        }

        [TestMethod]
        public void AddLocationTest()
        {
            SalesReasonModel reason = new SalesReasonModel(5, "Test6", "type", DateTime.Now);
            int before = reason_list.Models.Count;
            reason_list.AddModeal(reason);
            reason_list.ModelsRefresh();
            int after = reason_list.Models.Count;
            reason_list.AddModeal(reason);
            Assert.AreEqual(before + 1, after);
        }

        [TestMethod]
        public void UpdateLocationTest()
        {
            SalesReasonModel reason = new SalesReasonModel(0, "Test1", "type", DateTime.Now);
            reason_list.GetThisModel(0);
            reason_list.UpdateModel(reason);
            reason_list.ModelsRefresh();
            Assert.AreEqual(reason.Id, reason_list.Models[0].Id);
            Assert.AreEqual(reason.Name, reason_list.Models[0].Name);
            Assert.AreEqual(reason.ReasonSale, reason_list.Models[0].ReasonSale);

        }
    }
}
