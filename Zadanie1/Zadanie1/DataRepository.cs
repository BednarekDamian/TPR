using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext context;
        private DataFiller filler;

        public DataRepository(DataContext context, DataFiller filler)
        {
            this.context = context;
            this.filler = filler;
        }

        public void FillerStatic() => filler.Filling(context);

        public void AddWykaz(Wykaz z)
        {
            context.wykazy.Add(z);
        }
        public Wykaz GetWykaz(string id)
        {
            foreach(Wykaz x in context.wykazy)
            {
                if(x.IdKlienta == id)
                {
                    return x;
                }
            }
            throw new Exception("Brak wykazu");
        }
             
        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return context.wykazy;
        }

        public void DeleteWykaz(Wykaz z)
        {
            foreach(Zdarzenie x in context.zdarzenia)
            {
                if (x.Wykaz == z) throw new Exception("Nie mozna usunac, czytelnik posiada wypozyczenie");
            }
            context.wykazy.Remove(z);
        }

        public void DeleteWykaz(string Wid)
        {
            Wykaz x = GetWykaz(Wid);
            foreach(Zdarzenie y in context.zdarzenia)
            {
                if (y.Wykaz == x) throw new Exception("Nie mozna usunac, czytelnik posiada wypozyczenie");
            }
            context.wykazy.Remove(x);
        }

        private int CountKat = 0;
        public int CountKat1 { get => CountKat; set => CountKat = value; }
        
        public void AddKatalog(Katalog kat)
        {
            context.katalogi.Add(CountKat, kat);
            CountKat = CountKat + 1;
        }

        public Katalog GetKatalog(int s)
        {
            return context.katalogi[s];
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return context.katalogi.Values;
        }

        public void DeleteKatalog(int b)
        {
            foreach(OpisStanu l in context.opisyStanu)
            {
                if (l.Katalog.Equals(context.katalogi[b])) throw new Exception("Obiekt jest w uzyci, nie mozna go usunac");
            }
            context.katalogi.Remove(b);
        }
        public void DeleteKatalog(Katalog z)
        {
            foreach(OpisStanu l in context.opisyStanu)
            {
                if (l.Katalog == z) throw new Exception("Obiekt jest w uzyci, nie mozna go usunac");
            }
            for(int i=0;i<context.katalogi.Count;i++)
            {
                if(context.katalogi[i].Equals(z))
                {
                    context.katalogi.Remove(i);
                    return;
                }
            }
        }

        public void AddZdarzenie(Zdarzenie z)
        {
            context.zdarzenia.Add(z);
        }
        public Zdarzenie GetZdarzenie(int x)
        {
            return context.zdarzenia[x];
        }
        public IEnumerable<Zdarzenie> GetZdarzenia()
        {
            return context.zdarzenia;
        }
        public void DeleteZdarzenie(Zdarzenie v)
        {
            foreach(Zdarzenie w in context.zdarzenia)
            {
                if(v.Equals(w))
                {
                    context.zdarzenia.Remove(v);
                    return;
                }
            }
            throw new Exception("Brak podanego zdarzenia");
        }
        public void DeleteZdarzenie(int d)
        {
            if (d >= context.zdarzenia.Count()) throw new Exception("Brak podanego zdarzenia");
            context.zdarzenia.Remove(context.zdarzenia[d]);
        }

    
        public void AddOpis(OpisStanu p)
        {
            context.opisyStanu.Add(p);
        }
        public OpisStanu GetOpisStanu(int d)
        {
            return context.opisyStanu[d];
        }
        public IEnumerable<OpisStanu> GetAllOpis()
        {
            return context.opisyStanu;
        }
        public void DeleteOpis(OpisStanu q)
        {
            foreach(Zdarzenie t in context.zdarzenia)
            {
                if (t.Opis_Stanu.Equals(q))
                {
                    throw new Exception("Opis w uzyciu");
                }
            }
            context.opisyStanu.Remove(q);
        }

        public void DeleteOpis(int g)
        {
            OpisStanu a = GetOpisStanu(g);
            foreach(Zdarzenie e in context.zdarzenia)
            {
                if (e.Opis_Stanu.Equals(a))
                {
                    throw new Exception("Opis w uzyciu");
                }
            }
            context.opisyStanu.Remove(a);
        }
    }

}
