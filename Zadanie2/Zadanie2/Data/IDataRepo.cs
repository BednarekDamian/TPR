using System.Collections.Generic;


namespace Zadanie2
{
    public interface IDataRepo
    {
        void AddWykaz( Wykaz wykaz);
        Wykaz GetWykaz(int id);
        void DeleteWykaz(Wykaz wykaz);
        IEnumerable<Wykaz> GetAllWykaz();

        void AddKatalog(Katalog katalog);
        Katalog GetKatalog(int id);
        void DeleteKatalog(Katalog katalog);     
        IEnumerable<Katalog> GetAllKatalog();

        void AddOpisStanu(OpisStanu opisStanu);
        OpisStanu GetOpisStanu(int id);
        void DeleteOpisStanu(OpisStanu opisStanu);      
        IEnumerable<OpisStanu> GetAllOpisStanu();

        void AddZdarzenie(Zdarzenie zdarzenie);
        Zdarzenie GetZdarzenie(int id);
        void DeleteZdarzenie(Zdarzenie zdarzenie);     
        IEnumerable<Zdarzenie> GetAllZdarzenie();

    }
}
