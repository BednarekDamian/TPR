using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zadanie1.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class Datatest
    {
        [TestMethod]
        public void WykazTest()
        {
            DataContext context = new DataContext();
            WypelnienieStalymi stale = new WypelnienieStalymi();
            DataRepository data = new DataRepository(context, stale);
            
            Wykaz wykaz = new Wykaz("1", "Mariusz");
            data.AddWykaz(wykaz);
            if (wykaz.toString() != data.GetWykaz("1").toString()) Assert.Fail(wykaz.toString()+" : "+ data.GetWykaz("1").toString());
            data.AddWykaz(new Wykaz("2", "Malik"));
            data.AddWykaz(new Wykaz("3", "Eustachy"));
   
            data.DeleteWykaz("1");
            if (data.GetAllWykaz().Count() != 2) Assert.Fail();

        }
        [TestMethod]
        public void KatalogTest()
        {
            DataContext context = new DataContext();
            WypelnienieStalymi stale = new WypelnienieStalymi();
            DataRepository data = new DataRepository(context, stale);
            Katalog katalog1 = new Katalog("1", "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            data.AddKatalog(katalog1);
            if (data.GetKatalog(0).toString() != katalog1.toString()) Assert.Fail();
            data.AddKatalog(new Katalog("2", "Harry Pota", "J.K. Rowling", "1999", (float)24.0));
            data.DeleteKatalog(0);
            if (data.GetAllKatalog().Count() != 1) Assert.Fail();
        }

        [TestMethod]
        public void OpisStanuTest()
        {
            DataContext context = new DataContext();
            WypelnienieStalymi stale = new WypelnienieStalymi();
            DataRepository data = new DataRepository(context, stale);

            Katalog katalog1 = new Katalog("1", "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStanu = new OpisStanu(katalog1, DateTime.Now, 3, (float)32.5);

            data.AddOpis(opisStanu);
            if (data.GetOpisStanu(0).toString() != opisStanu.toString()) Assert.Fail();
            data.AddOpis(new OpisStanu(katalog1, DateTime.Now, 5,(float)53.5));
            data.AddOpis(new OpisStanu(katalog1, DateTime.Now, 6, (float)23.5));
            data.DeleteOpis(0);
            if (data.GetAllOpis().Count() != 2) Assert.Fail();
        }
        [TestMethod]
        public void ZdarzenieTest()
        {
            DataContext context = new DataContext();
            WypelnienieStalymi stale = new WypelnienieStalymi();
            DataRepository data = new DataRepository(context, stale);

            Katalog katalog1 = new Katalog("1", "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStanu = new OpisStanu(katalog1, DateTime.Now, 3, (float)32.5);
            Wykaz wykaz = new Wykaz("1", "Mariusz");

            Zdarzenie zdarzenie = new Zdarzenie(opisStanu, wykaz);
            data.AddZdarzenie(zdarzenie);
            if (data.GetZdarzenie(0).toString() != zdarzenie.toString()) Assert.Fail();

            Katalog katalog2 = new Katalog("1", "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStan2 = new OpisStanu(katalog1, DateTime.Now, 3, (float)32.5);
            Wykaz wykaz2 = new Wykaz("1", "Mariusz");

            Zdarzenie zdarzenie2 = new Zdarzenie(opisStanu, wykaz);
            data.AddZdarzenie(zdarzenie2);
            Katalog katalog3 = new Katalog("1", "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStanu3 = new OpisStanu(katalog1, DateTime.Now, 3, (float)32.5);
            Wykaz wykaz3 = new Wykaz("1", "Mariusz");

            Zdarzenie zdarzenie3 = new Zdarzenie(opisStanu, wykaz);
            data.AddZdarzenie(zdarzenie3);

            data.DeleteZdarzenie(0);
            if (data.GetZdarzenia().Count() != 2) Assert.Fail();
                }
        [TestMethod()]
        public void WypelnienieWykazdTest()
        {
            DataContext context_plik = new DataContext();
            WypelnienieStalymi plik = new WypelnienieStalymi();
            DataRepository data_plik = new DataRepository(context_plik, plik);
            data_plik.FillerStatic();

            List<Wykaz> kopia = new List<Wykaz>();
            kopia.Add(new Wykaz("1", "Mariusz"));
            kopia.Add(new Wykaz("2", "Malik"));
            kopia.Add(new Wykaz("3", "Eustachy"));
            kopia.Add(new Wykaz("4", "Andrzej"));
            kopia.Add(new Wykaz("5", "Maciek"));
            kopia.Add(new Wykaz("6", "Pawel"));
            kopia.Add(new Wykaz("7", "Mariusz"));
            kopia.Add(new Wykaz("8", "Piotr"));

            for (int i = 0; i < kopia.Count; i++)
            {
                if (!kopia[i].toString().Equals(data_plik.GetWykaz((i + 1).ToString()).toString()))
                { Assert.Fail(kopia[i].toString() + " : " + data_plik.GetWykaz((i + 1).ToString()).toString()); }

            }

        }

        [TestMethod()]
        public void WypelnienieKatalogTest()
        {
            DataContext context_plik = new DataContext();
            WypelnienieStalymi plik = new WypelnienieStalymi();
            DataRepository data_plik = new DataRepository(context_plik, plik);
            data_plik.FillerStatic();

            IEnumerable<Katalog> stala = data_plik.GetAllKatalog();
            Dictionary<int, Katalog> nowa = stala.ToDictionary(x => Int32.Parse(x.IdKatalogu) - 1, x => x);

            Dictionary<int, Katalog> test = new Dictionary<int, Katalog>();
            test.Add(0, new Katalog("1", "Basnie", "Grim", "1894", (float)34.7));
            test.Add(1, new Katalog("2", "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            test.Add(2, new Katalog("3", "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            test.Add(3, new Katalog("4", "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            test.Add(4, new Katalog("5", "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            test.Add(5, new Katalog("6", "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            test.Add(6, new Katalog("7", "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            test.Add(7, new Katalog("8", "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));

            for (int i = 0; i < 7; i++)
            {
                if (!(test[i].toString() == nowa[i].toString()))
                { Assert.Fail(test[i].toString() + " : " + nowa[i].toString() + ": i= " + i); }
            }
        }

        [TestMethod()]
        public void WypelnienieOpisStanuTest()
        {
            DataContext context_plik = new DataContext();
            WypelnienieStalymi plik = new WypelnienieStalymi();
            DataRepository data_plik = new DataRepository(context_plik, plik);
            data_plik.FillerStatic();

            IEnumerable<OpisStanu> stala = data_plik.GetAllOpis();
            List<OpisStanu> nowa = stala.ToList<OpisStanu>();

            List<OpisStanu> test = new List<OpisStanu>();

            Dictionary<int, Katalog> test2 = new Dictionary<int, Katalog>();
            test2.Add(0, new Katalog("1", "Basnie", "Grim", "1894", (float)34.7));
            test2.Add(1, new Katalog("2", "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            test2.Add(2, new Katalog("3", "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            test2.Add(3, new Katalog("4", "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            test2.Add(4, new Katalog("5", "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            test2.Add(5, new Katalog("6", "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            test2.Add(6, new Katalog("7", "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            test2.Add(7, new Katalog("8", "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));



            test.Add(new OpisStanu(test2[0], DateTimeOffset.Now, 1, (float)34.7));
            test.Add(new OpisStanu(test2[1], DateTimeOffset.Now, 2, (float)24.4));
            test.Add(new OpisStanu(test2[2], DateTimeOffset.Now, 3, (float)24.0));
            test.Add(new OpisStanu(test2[3], DateTimeOffset.Now, 4, (float)42.0));
            test.Add(new OpisStanu(test2[4], DateTimeOffset.Now, 5, (float)21.3));
            test.Add(new OpisStanu(test2[5], DateTimeOffset.Now, 6, (float)15.0));
            test.Add(new OpisStanu(test2[6], DateTimeOffset.Now, 7, (float)18.2));
            for (int i = 0; i < 7; i++)
            {
                if (!(test[i].toString() == nowa[i].toString())) Assert.Fail(test[i].toString() + " : " + nowa[i].toString());
            }
        }

        [TestMethod()]
        public void WypelnienieZdarzenieTest()
        {
            DataContext context_plik = new DataContext();
            WypelnienieStalymi plik = new WypelnienieStalymi();
            DataRepository data_plik = new DataRepository(context_plik, plik);
            data_plik.FillerStatic();

            IEnumerable<Zdarzenie> stala = data_plik.GetZdarzenia();
            ObservableCollection<Zdarzenie> nowa = new ObservableCollection<Zdarzenie>(stala);

            ObservableCollection<Zdarzenie> test = new ObservableCollection<Zdarzenie>();
            List<OpisStanu> test1 = new List<OpisStanu>();

            Dictionary<int, Katalog> test2 = new Dictionary<int, Katalog>();
            test2.Add(0, new Katalog("1", "Basnie", "Grim", "1894", (float)34.7));
            test2.Add(1, new Katalog("2", "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            test2.Add(2, new Katalog("3", "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            test2.Add(3, new Katalog("4", "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            test2.Add(4, new Katalog("5", "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            test2.Add(5, new Katalog("6", "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            test2.Add(6, new Katalog("7", "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            test2.Add(7, new Katalog("8", "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));




            test1.Add(new OpisStanu(test2[0], DateTimeOffset.Now, 1, (float)34.7));
            test1.Add(new OpisStanu(test2[1], DateTimeOffset.Now, 2, (float)24.4));
            test1.Add(new OpisStanu(test2[2], DateTimeOffset.Now, 3, (float)24.0));
            test1.Add(new OpisStanu(test2[3], DateTimeOffset.Now, 4, (float)42.0));
            test1.Add(new OpisStanu(test2[4], DateTimeOffset.Now, 5, (float)21.3));
            test1.Add(new OpisStanu(test2[5], DateTimeOffset.Now, 6, (float)15.0));
            test1.Add(new OpisStanu(test2[6], DateTimeOffset.Now, 7, (float)18.2));

            List<Wykaz> kopia = new List<Wykaz>();
            kopia.Add(new Wykaz("1", "Mariusz"));
            kopia.Add(new Wykaz("2", "Malik"));
            kopia.Add(new Wykaz("3", "Eustachy"));
            kopia.Add(new Wykaz("4", "Andrzej"));
            kopia.Add(new Wykaz("5", "Maciek"));
            kopia.Add(new Wykaz("6", "Pawel"));
            kopia.Add(new Wykaz("7", "Mariusz"));
            kopia.Add(new Wykaz("8", "Piotr"));


            test.Add(new Zdarzenie(test1[0], kopia[0]));
            test.Add(new Zdarzenie(test1[1], kopia[1]));
            test.Add(new Zdarzenie(test1[2], kopia[2]));
            test.Add(new Zdarzenie(test1[3], kopia[3]));
            test.Add(new Zdarzenie(test1[4], kopia[4]));
            test.Add(new Zdarzenie(test1[5], kopia[5]));

            for (int i = 0; i < 6; i++)
            {
                if (!(test[i].toString() == nowa[i].toString())) Assert.Fail(test[i].toString() + " : " + nowa[i].toString());
            }
        }
    }
}
