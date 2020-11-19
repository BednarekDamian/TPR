using System;
using System.Collections.Generic;
using Zadanie1.Data;

namespace Zadanie1.logic
{
    public interface IDataService
    {
       
        void WyswietlKatalogi();
        IEnumerable<OpisStanu> OpisDlaKatalogu(Katalog katalog);
        void  WyswietlZdarzenia();
        IEnumerable<Zdarzenie> ZdarzenieDlaWykazu(Wykaz wykaz);
        IEnumerable<Zdarzenie> ZdarazeniePomiedzyDatami(DateTimeOffset from, DateTimeOffset to);
        void DodajZdarzenie(int id,Wykaz wykaz, OpisStanu opisStanu, DateTimeOffset time, int ilosc);

    }
}
