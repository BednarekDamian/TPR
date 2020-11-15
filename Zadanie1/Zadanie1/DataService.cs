using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataService
    {
        private DataRepository dataR;

        public DataService(DataRepository dataR)
        {
            this.dataR = dataR;
        }

        #region Wyswietlanie
        public void WyswietlKatalog(IEnumerable<Katalog> katalogi)
        {
            Dictionary<int, Katalog> dictKatalog = katalogi.ToDictionary(x => Int32.Parse(x.IdKatalogu), x => x);
            for (int i = 0; i < katalogi.Count(); i++)
            {
                Console.WriteLine(dictKatalog[i].ALL);
            }
        }

        public void WyswietlOpis(IEnumerable<OpisStanu> opisy)
        {
            List<OpisStanu> listaOpisy = opisy.ToList<OpisStanu>();
            for (int i = 0; i < opisy.Count(); i++)
            {
                Console.WriteLine(listaOpisy[i].ALL);
            }
        }
        public void WyswietlZdarzenia(IEnumerable<Zdarzenie> zdarzenia)
        {
            ObservableCollection<Zdarzenie> kolekcjazdarzen = new ObservableCollection<Zdarzenie>(zdarzenia);
            for (int i = 0; i < zdarzenia.Count(); i++)
            {
                Console.WriteLine(kolekcjazdarzen[i].ALL);
            }
        }
        public void WyswietlWykazy(IEnumerable<Wykaz> wykazy)
        {
            List<Wykaz> listaW = wykazy.ToList<Wykaz>();
            for (int i = 0; i < wykazy.Count(); i++)
            {
                Console.WriteLine(listaW[i].ALL);
            }
        }
        #endregion

        #region Szukanie
        public List<Wykaz> WyszukajWykaz(string x)
        {
            List<Wykaz> all = this.dataR.GetAllWykaz().ToList<Wykaz>();
            List<Wykaz> listaW = new List<Wykaz>();
            string xyz = "";
            for (int i = 0; i < this.dataR.GetAllWykaz().Count(); i++)
            {
                xyz = all[i].ALL;
                if (xyz.Contains(x))
                {
                    listaW.Add(all[i]);
                }
            }
            return listaW;
        }

        public Dictionary<int, Katalog> SzukajKatalog(string e)
        {
            Dictionary<int, Katalog> all = this.dataR.GetAllKatalog().ToDictionary(x => Int32.Parse(x.IdKatalogu), x => x);
            Dictionary<int, Katalog> nDicti = new Dictionary<int, Katalog>();
            string xyz = "";
            int i = 0;
            for (int b = 0; b < this.dataR.GetAllWykaz().Count(); b++)
            {
                xyz = all[b].ALL;
                if (xyz.Contains(e))
                {
                    nDicti.Add(i, all[b]);
                    i++;
                }
            }
            return nDicti;
        }

        public List<OpisStanu> znajdzOpis(double min, double max)
        {
            List<OpisStanu> all = this.dataR.GetAllOpis().ToList();
            List<OpisStanu> listaOpis = new List<OpisStanu>();
            for (int i = 0; i < this.dataR.GetAllOpis().Count(); i++)
            {
                if (all[i].Cena > min && all[i].Cena < max) listaOpis.Add(all[i]);
            }
            return listaOpis;
        }

        public ObservableCollection<Zdarzenie> SzukajZdarzenie(DateTimeOffset s, DateTimeOffset e)
        {
            ObservableCollection<Zdarzenie> all = new ObservableCollection<Zdarzenie>(this.dataR.GetZdarzenia());
            ObservableCollection<Zdarzenie> zCollection = new ObservableCollection<Zdarzenie>();
            for (int i = 0; i < this.dataR.GetZdarzenia().Count(); i++)
            {
                if (all[i].Opis_Stanu.Data_zakupu > s && all[i].Opis_Stanu.Data_zakupu < e) zCollection.Add(all[i]);
            }
            return zCollection;
        }
        #endregion
        #region polaczenie
        public IEnumerable<Zdarzenie> ZdarzenieOpisu(OpisStanu p)
        {
            ObservableCollection<Zdarzenie> all = new ObservableCollection<Zdarzenie>(this.dataR.GetZdarzenia());
            ObservableCollection<Zdarzenie> zOpis = new ObservableCollection<Zdarzenie>();
            foreach (var d in all)
            {
                if (d.Wykaz.Equals(p)) zOpis.Add(d);
            }
            return (IEnumerable<Zdarzenie>)zOpis;
        }
        public IEnumerable<Zdarzenie> ZdarzenieWykazu(Wykaz a)
            {
            ObservableCollection<Zdarzenie> all = new ObservableCollection<Zdarzenie>(this.dataR.GetZdarzenia());
            ObservableCollection<Zdarzenie> zWyk = new ObservableCollection<Zdarzenie>();
            foreach(var d in all)
            {
                if (d.Wykaz.Equals(a)) zWyk.Add(d);
            }
            return (IEnumerable<Zdarzenie>)zWyk;
        }
        public IEnumerable<OpisStanu> OpisKatalogu(Katalog m)
        {
            List<OpisStanu> all = this.dataR.GetAllOpis().ToList<OpisStanu>();
            List<OpisStanu> oKatalog = new List<OpisStanu>();
            foreach(var t in all)
            {
                if (t.Katalog.Equals(m)) oKatalog.Add(t);
            }
            return (IEnumerable<OpisStanu>)oKatalog;
        }
        #endregion
        #region dodawanie
        public void DodajOpis(OpisStanu z) => this.dataR.AddOpis(z);
        public void DodajKatalog(Katalog l) => this.dataR.AddKatalog(l);
        public void DodajWykaz(Wykaz a) => this.dataR.AddWykaz(a);
        public void DodajZdarzenie(Zdarzenie q) => this.dataR.AddZdarzenie(q);
        #endregion
        #region stworz
        public void DodajOpis(Katalog katalog, DateTimeOffset data_zakupu, int ilosc, float cena) => this.dataR.AddOpis(new OpisStanu(katalog,data_zakupu,ilosc,cena));
        public void DodajKatalog(string idKatalogu, string tytul, string autor, string rok, float cena) => this.dataR.AddKatalog(new Katalog(idKatalogu,tytul,autor,rok,cena));
        public void DodajWykaz(string id, string nazwa) => this.dataR.AddWykaz(new Wykaz(id, nazwa));
        public void DodajZdarzenie(OpisStanu opis_stanu, Wykaz wykaz) => this.dataR.AddZdarzenie(new Zdarzenie(opis_stanu, wykaz));
        #endregion
       
        #region menagerZdarzen
        public Zdarzenie DodajZdarzenieM(OpisStanu a, Wykaz b)
        {
            return new Zdarzenie(a, b);
        }
        public void UsunZdarzenie(OpisStanu a, Wykaz b)
        {
            ObservableCollection<Zdarzenie> all = new ObservableCollection<Zdarzenie>(this.dataR.GetZdarzenia());
            foreach(var t in all)
            {
                if (t.Opis_Stanu.Equals(a) && t.Wykaz.Equals(b)) this.dataR.DeleteZdarzenie(t);
            }
        }
        #endregion
    }
}
