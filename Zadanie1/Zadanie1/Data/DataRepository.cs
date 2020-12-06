using System;
using System.Collections.Generic;


namespace Zadanie1.Data
{
    public class DataRepository : IDataRepo
    {
        private DataContext dataContex;
        private DataFiller dataFiller;
        public DataRepository()
        {
            dataContex = new DataContext();           
        }

        public DataRepository(DataFiller dataFiller)
        {
            dataContex = new DataContext();
            this.dataFiller = dataFiller;
            this.dataFiller.Filling(dataContex);

        }
     
        public void AddKatalog(Katalog katalog)
        {
            dataContex.katalogi.Add(katalog.idKatalogu, katalog);
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            dataContex.opisyStanu.Add(opisStanu);
        }

        public void AddWykaz(Wykaz wykaz)
        {
            dataContex.wykazy.Add(wykaz);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            dataContex.zdarzenia.Add(zdarzenie);
        }

        public void DeleteKatalog(Katalog katalog)
        {
            dataContex.katalogi.Remove(katalog.idKatalogu);
        }

        public void DeleteOpisStanu(OpisStanu opisStanu)
        {
            dataContex.opisyStanu.Remove(opisStanu);
        }

        public void DeleteWykaz(Wykaz wykaz)
        {
            dataContex.wykazy.Remove(wykaz);
        }

        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {
            dataContex.zdarzenia.Remove(zdarzenie);
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            List<Katalog> katalogi = new List<Katalog>();
            foreach(KeyValuePair<int,Katalog> katalog in dataContex.katalogi)
            {
                katalogi.Add(katalog.Value);
            }
            return katalogi;
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dataContex.opisyStanu;
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return dataContex.wykazy;
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return dataContex.zdarzenia;
        }

        public Katalog GetKatalog(int id)
        {
            return dataContex.katalogi[id];
        }

        public OpisStanu GetOpisStanu(int id)
        {
            return dataContex.opisyStanu[id];
        }

        public Wykaz GetWykaz(int id)
        {
            return dataContex.wykazy[id];
        }

        public Zdarzenie GetZdarzenie(int id)
        {
            return dataContex.zdarzenia[id];
        }

     
    }

}
