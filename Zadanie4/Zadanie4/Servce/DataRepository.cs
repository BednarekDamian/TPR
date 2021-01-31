using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//repo
namespace Servce
{
    public class DataRepository : IDataRepo, IDisposable
    {
        private SaleReasonDataContext dataContext;

        public DataRepository()
        {
            this.dataContext = new SaleReasonDataContext();
        }

        #region add
        public void AddReason(ReasonS reasonS)
        {
            SalesReason ReasonToAdd = reasonS.getSalesReason();
            Task.Run(() =>
            {
                dataContext.SalesReason.InsertOnSubmit(ReasonToAdd);
                dataContext.SubmitChanges();
            });
        }

        #endregion
        #region Update
        public void UpdateReason(ReasonS reasonS, int id)
        {
            Task.Run(() =>
            {
                SalesReason upReason = dataContext.SalesReason.Where(m => m.SalesReasonID == reasonS.SalesReasonID).FirstOrDefault();
                foreach (System.Reflection.PropertyInfo property in upReason.GetType().GetProperties())
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(upReason, property.GetValue(reasonS.getSalesReason()));
                    }
                }
                dataContext.SubmitChanges();
            });
        }

        #endregion
        #region Delete
        public void DeleteReason(int id)
        {
            Task.Run(() =>
            {
                dataContext.SalesReason.DeleteOnSubmit(GetSalesReason(id).getSalesReason());
                dataContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            });
        }

        #endregion
        #region Read
        public ReasonS GetSalesReason(int id)
        {
            SalesReason reason = dataContext.SalesReason.Where(e => e.SalesReasonID == id).FirstOrDefault();
            return new ReasonS(reason);
        }


        public IEnumerable<ReasonS> GetAllReasons()
        {
            List<ReasonS> reasonS = new List<ReasonS>();
            IQueryable<SalesReason> salesReasons = dataContext.SalesReason;
            foreach (SalesReason salesReason in salesReasons)
            {
                reasonS.Add(new ReasonS(salesReason));
            }
            return reasonS;
        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
