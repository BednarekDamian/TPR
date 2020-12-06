using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Zadanie2
{
  
    public  class DataContext 
    {
        public List<Wykaz> wykazy  =new List<Wykaz>();
        public Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> opisyStanu=new List<OpisStanu>();

        public DataContext()
        {

        }

   
    }
}
