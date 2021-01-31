using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Servce;
using System;
using ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestClass]
        public class ViewModelTests
        {
            IDataRepo testDataRepository;
            ListOfReasons reason_list;
            MainWindowActions mainWindowActions;


            [TestInitialize]
            public void Initialize()
            {
                testDataRepository = new DataRepo_Test();
                reason_list = new ListOfReasons(testDataRepository);
                mainWindowActions = new MainWindowActions(reason_list);
            }

            #region MainWindow
            [TestMethod]
            public void MainWindowInitializationTest()
            {
                Assert.IsNotNull(mainWindowActions.reasonList);
                Assert.IsNotNull(mainWindowActions.DeleteReason);
                Assert.IsNotNull(mainWindowActions.Refresh);

            }

            [TestMethod]
            public void CanExecuteMainWindowTest()
            {

                Assert.IsTrue(mainWindowActions.DeleteReason.CanExecute(null));
                Assert.IsTrue(mainWindowActions.Refresh.CanExecute(null));
            }

            [TestMethod]
            public void DeleteRecordTest()
            {
                reason_list.GetThisModel(0);
                int before = reason_list.Models.Count;
                mainWindowActions.DeleteReason.Execute(null);
                int after = reason_list.Models.Count;
                Assert.AreEqual(before - 1, after);
            }

            [TestMethod]
            public void DeleteRecordFailTest()
            {
                int before = reason_list.Models.Count;
                mainWindowActions.DeleteReason.Execute(null);
                int after = reason_list.Models.Count;
                Assert.AreEqual(before, after);
            }

            [TestMethod]
            public void RefreshRecordTest()
            {
                int before = mainWindowActions.reasonList.Models.Count;
                SalesReasonModel reason_model = new SalesReasonModel(5, "Test6", "type", DateTime.Now);
                reason_list.AddModeal(reason_model);
                int after = mainWindowActions.reasonList.Models.Count;
                Assert.AreNotEqual(before + 1, after);
                mainWindowActions.Refresh.Execute(null);
                after = mainWindowActions.reasonList.Models.Count;
                Assert.AreEqual(before + 1, after);
            }
            #endregion
        }
    }
}
