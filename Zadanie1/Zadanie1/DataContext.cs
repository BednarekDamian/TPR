using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
   public  class DataContext
    {
        public List<Wykaz> wykazy;
        public Dictionary<int, Katalog> katalogi;
      

        public DataContext(List<Wykaz> wykazy, Dictionary<int, Katalog> katalogi)
        {
            this.wykazy = wykazy;
            this.katalogi = katalogi;
        }
       
    }
}
