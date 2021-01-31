using Dane;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servce;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    class DataRepo_Test : IDataRepo
    {
        List<ReasonS> reasons_List;
        public DataRepo_Test()
        {
            reasons_List = InitTestList();
        }
        public void AddReason(ReasonS reasonS)
        {
            reasons_List.Add(reasonS);
        }

        public void DeleteReason(int id)
        {
            reasons_List.RemoveAt(id);
        }



        public IEnumerable<ReasonS> GetAllReasons()
        {
            return reasons_List;
        }

        public ReasonS GetSalesReason(int id)
        {
            return reasons_List[id];
        }

        public void UpdateReason(ReasonS reasonS, int id)
        {
            reasons_List[id] = reasonS;
        }
        private List<ReasonS> InitTestList()
        {
            List<ReasonS> initList = new List<ReasonS>
            {
                ReasonParser.CreateNewSalesReasonS(0, "Test1", "type"),
                ReasonParser.CreateNewSalesReasonS(1, "Test2","type"),
                ReasonParser.CreateNewSalesReasonS(2, "Test3","type"),
                ReasonParser.CreateNewSalesReasonS(3, "Test4", "type"),
                ReasonParser.CreateNewSalesReasonS(4, "Test5", "type")
            };
            return initList;
        }
    }
}