using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
   public  class DataContext
    {
        public List<Wykaz> wykazy;
        public Dictionary<int, Katalog> katalogi;
        public ObservableCollection<Zdarzenie> zdarzenia;
        public List<OpisStanu> opisyStanu;
            

        public DataContext()
        {
            this.wykazy = new List<Wykaz>();
            this.katalogi = new Dictionary<int, Katalog>();
            this.zdarzenia = new ObservableCollection<Zdarzenie>();
            this.opisyStanu = new List<OpisStanu>();
        }
       
    }
}
