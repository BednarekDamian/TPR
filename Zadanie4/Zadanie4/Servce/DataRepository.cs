using System;
using Dane;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    public class DataRepository : IDataRepo, IDisposable
    {
        private SaleReasonDataContext dataContext;

        public DataRepository()
        {
            this.dataContext = new SaleReasonDataContext();
        }

        #region add
        public void AddReason() 
        {
            SalesReason ReasonToAdd;
            Task.Run(() =>
            {
                dataContext.SalesReason.InsertOnSubmit();
                dataContext.SubmitChanges();
            });
        }

        #endregion
        #region Update
        public void UpdateReason()
        {
            Task.Run(()=>
            {
                SalesReason upReason = dataContext.SalesReason.Where(m => m.SalesReasonID == ...).FirstOrDefaukt();
            });
        }

        #endregion
        #region Delete
        public void DeleteReason()
        {
            Task.Run(() =>
            {
                dataContext.SalesReason.DeleteOnSubmit(GetReason());
                dataContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            });
        }

        #endregion
        #region Read
        public void GetReason()
        {
            Task.Run(() =>
            {
                dataContext.SalesReason.DeleteOnSubmit(GetReason());
                dataContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            });
        }

        #endregion




        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
