using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Servce;

namespace Model
{
    public class ListOfReasons 
    {
        private readonly IDataRepo dataRepo;

        private SalesReasonModel nModel;

        private ObservableCollection<SalesReasonModel> models;

        public ListOfReasons() : this(new DataRepository()) { }

        public ListOfReasons(IDataRepo dataRepo)
        {
            this.dataRepo = dataRepo;
            Models = new ObservableCollection<SalesReasonModel>();
            ModelsFiller();
        }

        public ObservableCollection<SalesReasonModel> Models
        {
            get => models;
            set
            {
                models = value;
            }
        }
        public SalesReasonModel NModels
        {
            get => nModel;
            set
            {
                nModel = value;
;            }
        }
        public void ModelsRefresh()
        {
            Models.Clear();
            ModelsFiller();
        }
        private void ModelsFiller()
        {
            IEnumerable<ReasonS> dataFromServce = dataRepo.GetAllReasons();
            foreach (ReasonS reason in dataFromServce)
            {
                models.Add(new SalesReasonModel(reason.SalesReasonID, reason.Name, reason.ReasonType, reason.ModifiedDate));
            }
        }

        #region CRUD
        public void AddModeal(SalesReasonModel model)
        {
            this.dataRepo.AddReason(ReasonParser.CreateNewSalesReasonS(model.Id, model.Name, model.ReasonSale));
        }
        public void DeleteModel()
        {
            if (nModel != null)
            {
                this.dataRepo.DeleteReason(nModel.Id);
                Models.Remove(nModel);
            }
        }
        public void UpdateModel()
        {
            if (nModel != null)
            {
                this.dataRepo.UpdateReason(ReasonParser.CreateNewSalesReasonS(nModel.Id, nModel.Name, nModel.ReasonSale), nModel.Id);
            }
        }
        public SalesReasonModel GetThisModel(int id)
        {
            ReasonS tModel = this.dataRepo.GetSalesReason(id);
            return new SalesReasonModel(tModel.SalesReasonID, tModel.Name, tModel.ReasonType, tModel.ModifiedDate);
        }
        #endregion
    }
}
