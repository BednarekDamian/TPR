using Dane;
using System;

namespace Servce
{
    public class ReasonS
    {
        private SalesReason salesReason;

        public ReasonS(SalesReason salesReason)
        {
            this.salesReason = salesReason;
        }

        internal SalesReason getSalesReason()
        {
            return this.salesReason;
        }
        public int SalesReasonID
        {
            get
            {
                return salesReason.SalesReasonID;
            }
        }
        public string Name
        {
            get
            {
                return salesReason.Name;
            }
            set
            {
                salesReason.Name = value;
            }
        }
        public string ReasonType
        {
            get
            {
                return salesReason.ReasonType;
            }
            set
            {
                salesReason.ReasonType = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return salesReason.ModifiedDate;
            }
            set
            {
                salesReason.ModifiedDate = value;
            }
        }

    }

}
