using System;
using System.Collections.Generic;
using System.Text;

namespace Servce
{
    public interface IDataRepo
    {
        void AddReason(ReasonS reasonS);
        void UpdateReason(ReasonS reasonS, int id);
        void DeleteReason(int id);
        ReasonS GetSalesReason(int id);
        IEnumerable<ReasonS> GetAllReasons();
        void Dispose();
    }
}
