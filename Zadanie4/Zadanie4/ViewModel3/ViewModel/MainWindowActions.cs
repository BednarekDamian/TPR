using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model;

namespace ViewModel
{
    public  class MainWindowActions : Change
    {
        public ListOfReasons reasonList { get; set; }
        public Binding AddReason { get; set; }
        public Binding DeleteReason { get; set; }
        public Binding UpdateReason { get; set; }
        public Binding GetReason { get; set; }
        public Binding Refresh { get; set; }

        private SalesReasonModel newaReason;

        public MainWindowActions(): this(new ListOfReasons()) { }

        public MainWindowActions(ListOfReasons reasonsList)
        {
            reasonList = reasonsList;
            newaReason = new SalesReasonModel();
            this.AddReason = new Binding(AddeReasonF);
            this.DeleteReason = new Binding(DeleteReasonF);
            this.UpdateReason = new Binding(UpdateReasonF);
            this.GetReason = new Binding(GetReasonF);
            this.Refresh = new Binding(RefreshReasonF);
        }

        public ObservableCollection<SalesReasonModel> Reasons
        {
            get => ListOfReasons.Models;

            set
            {
                ListOfReasons.Models = value;
            }
        }
        public SalesReasonModel NewaReason
        {
            get => newaReason;
            set
            {
                newaReason = value;
                WhenPropertyChanged();
            }
        }
        public SalesReasonModel ToUpdateReason
        {
            get => reasonList.NModels;
            set
            {
                reasonList.NModels = value;
                WhenPropertyChanged();
            }
        }
        public SalesReasonModel ToGetReason
        {
            get => reasonList.NModels;
            set
            {
                reasonList.NModels = value;
                WhenPropertyChanged();
            }
        }
        private void AddeReasonF()
        {
            reasonList.AddModeal(newaReason);
        }
        private void DeleteReasonF()
        {
            reasonList.DeleteModel();
        }
        private void UpdateReasonF()
        {
            reasonList.UpdateModel();
        }
        private void GetReasonF()
        {
            reasonList.GetThisModel(ToGetReason.Id);
        }
        private void RefreshReasonF()
        {
            reasonList.ModelsRefresh();
        }
    }
}
