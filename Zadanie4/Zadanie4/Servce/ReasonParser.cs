using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Servce
{
    public static class ReasonParser
    {
        public static ReasonS CreateNewSalesReasonS(string id, string name, string reasonType)
        {
            SalesReason salesReason = new SalesReason
            {
                SalesReasonID = int.Parse(id),
                Name = name,
                ReasonType = reasonType,
                ModifiedDate = DateTime.Now
            };
            return new ReasonS(salesReason);
        }
        public static ReasonS CreateNewSalesReasonS(int id, string name, string reasonType)
        {
            SalesReason salesReason = new SalesReason
            {
                SalesReasonID = id,
                Name = name,
                ReasonType = reasonType,
                ModifiedDate = DateTime.Now
            };
            return new ReasonS(salesReason);
        }
    }
}
