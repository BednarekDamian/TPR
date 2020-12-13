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
            /*   CustomFormatter formater = new CustomFormatter();
               List<Wykaz> wykazy = (List<Wykaz>)GetAllWykaz();

               GetWykaz(0).GetObjectData(info, context);
               GetKatalog(0).GetObjectData(info, context);
               GetOpisStanu(0).GetObjectData(info, context);
               GetZdarzenie(0).GetObjectData(info, context);*/

            int i = 0;
            foreach (Wykaz wykaz in dataContex.wykazy)
            {
                string key = "Wykaz_" + i.ToString();
                info.AddValue(key, GetWykaz(i), typeof(Wykaz));
                i++;
            }
            IEnumerable<Katalog> katalogi = GetAllKatalog();
            i = 0;
            foreach (Katalog katalog in katalogi)
            {
                string key = "Katalog_" + i.ToString();
                info.AddValue(key, GetKatalog(i), typeof(Katalog));
                i++;
            }
            i = 0;
            foreach (OpisStanu opis in dataContex.opisyStanu)
            {
                string key = "OpisStanu_" + i.ToString();
                info.AddValue(key, GetOpisStanu(i), typeof(OpisStanu));
                i++;
            }
            i = 0;
            foreach (Zdarzenie zdarzenie in dataContex.zdarzenia)
            {
                string key = "Zdarzenie_" + i.ToString();
                info.AddValue(key, GetZdarzenie(i), typeof(Zdarzenie));
                i++;
            }
        }
 
    }

}
