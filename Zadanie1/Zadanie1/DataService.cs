using System;
using System.Collections.Generic;
using Zadanie1.Data;


namespace Zadanie1.logic
{
    public class DataService : IDataService
    {
        public IDataRepo dataRepo { get; set; }

        public DataService(IDataRepo dataRepo)
        {
            this.dataRepo = dataRepo;
        }

        public void DodajZdarzenie(int id, Wykaz wykaz, OpisStanu opisStanu, DateTimeOffset time, int ilosc)
        {
            dataRepo.AddZdarzenie(new Zdarzenie(id, opisStanu, wykaz, time, ilosc));
        }

        public IEnumerable<OpisStanu> OpisDlaKatalogu(Katalog katalog)
        {
            List<OpisStanu> opisStanu = new List<OpisStanu>();
           foreach( OpisStanu opis in dataRepo.GetAllOpisStanu())
            {
                if (opis.katalog.Equals(katalog))
                {
                    opisStanu.Add(opis);
                }
            }
            return opisStanu;
        }

        public void WyswietlKatalogi()
        {           
            foreach (Katalog katalog in dataRepo.GetAllKatalog())
            {
                Console.WriteLine(katalog);
            }
          
        }

        public void WyswietlZdarzenia()
        {
            foreach (Zdarzenie zdarzenie in dataRepo.GetAllZdarzenie())
            {
                Console.WriteLine(zdarzenie);
            }
        }

        public IEnumerable<Zdarzenie> ZdarazeniePomiedzyDatami(DateTimeOffset from, DateTimeOffset to)
        {
            List<Zdarzenie> listaZdarzen = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in dataRepo.GetAllZdarzenie())
            {
                int jeden = from.CompareTo(zdarzenie.data_zakupu);
                int dwa = to.CompareTo(zdarzenie.data_zakupu);
               if ( jeden<0 && dwa>0)
                {
                    listaZdarzen.Add(zdarzenie);
                }
            }
            return listaZdarzen;
        }

        public IEnumerable<Zdarzenie> ZdarzenieDlaWykazu(Wykaz wykaz)
        {
            List<Zdarzenie> listaZdarzen = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in dataRepo.GetAllZdarzenie())
            {
                if (zdarzenie.wykaz.Equals(wykaz))
                {
                    listaZdarzen.Add(zdarzenie);
                }
            }
            return listaZdarzen;
        }

     
    }
}
