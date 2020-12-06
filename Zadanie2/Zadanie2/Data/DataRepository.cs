using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Zadanie2
{
    public class DataRepository : IDataRepo ,ISerializable
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
        public DataContext GetDataContext()
        {
            return this.dataContex;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ObservableCollection<Zdarzenie> zdarzenia = (ObservableCollection<Zdarzenie>) GetAllZdarzenie();
            for(int i = 0; i < zdarzenia.Count; i++)
            {
                info.AddValue("idZdarzenia"+i, zdarzenia[i].idZdarzenie);
                info.AddValue("opis_stanu"+i, zdarzenia[i].opis_Stanu);
                info.AddValue("wykaz"+i, zdarzenia[i].wykaz);
                info.AddValue("data_zakupu"+i, zdarzenia[i].data_zakupu);
                info.AddValue("ilosc_zakupionych"+i, zdarzenia[i].ilosc_zakupionych);
                info.AddValue("cena_calkowita"+i, zdarzenia[i].cena_calkowita);
                
            }     
        }
 
    }

}
