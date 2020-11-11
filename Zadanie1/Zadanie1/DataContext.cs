using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
   public  class DataContext
    {
        public List<Wykaz> l_wykaz;
        public Dictionary<int, Katalog> d_katalog;
        public ObservableCollection<Zdarzenie> ob_zdarzenie;
        public List<OpisStanu> l_opisStanu;
            

        public DataContext()
        {
            this.l_wykaz = new List<Wykaz>();
            this.d_katalog = new Dictionary<int, Katalog>();
            this.ob_zdarzenie = new ObservableCollection<Zdarzenie>();
            this.l_opisStanu = new List<OpisStanu>();
        }
       
    }
}
