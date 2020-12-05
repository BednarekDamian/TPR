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
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);
            
            Wykaz wykaz = new Wykaz(1, "Mariusz");
            data.AddWykaz(wykaz);
            if (wykaz.toString() != data.GetWykaz(0).toString()) Assert.Fail(wykaz.toString()+" : "+ data.GetWykaz(0).toString());
            data.AddWykaz(new Wykaz(2, "Malik"));
            data.AddWykaz(new Wykaz(3, "Eustachy"));
   
            data.DeleteWykaz(wykaz);
            if (data.GetAllWykaz().Count() < 2) Assert.Fail();

        }
        [TestMethod]
        public void KatalogTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);
            Katalog katalog1 = new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0);
           
            if (data.GetKatalog(5).toString() != katalog1.toString()) Assert.Fail(data.GetKatalog(5).toString());
           
            if (data.GetAllKatalog().Count() == 1) Assert.Fail();
        }

        [TestMethod]
        public void OpisStanuTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);

            Katalog katalog1 = new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0);
            OpisStanu opisStanu = new OpisStanu(5,katalog1,4);
          
            if (data.GetOpisStanu(5).toString() != opisStanu.toString()) Assert.Fail(data.GetOpisStanu(5).toString());
         
            if (data.GetAllOpisStanu().Count() < 2) Assert.Fail();
        }
        [TestMethod]
        public void ZdarzenieTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);

            Katalog katalog1 = new Katalog(1, "Basnie", "Grim", "1894", (float)34.7);
            OpisStanu opisStanu = new OpisStanu(0,katalog1,5);
            Wykaz wykaz = new Wykaz(1, "Mariusz");

            Zdarzenie zdarzenie = new Sprzedaz(0,opisStanu, wykaz,DateTimeOffset.Now,1);
           
            if (data.GetZdarzenie(0).idZdarzenie !=zdarzenie.idZdarzenie) Assert.Fail(data.GetZdarzenie(0).toString()+": " + zdarzenie.toString());

            Katalog katalog2 = new Katalog(1, "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStan2 = new  OpisStanu(1, katalog1, 1);
            Wykaz wykaz2 = new Wykaz(1, "Mariusz");

            Zdarzenie zdarzenie2 = new Sprzedaz(1,opisStanu, wykaz, DateTimeOffset.Now, 1);
            data.AddZdarzenie(zdarzenie2);
            Katalog katalog3 = new Katalog(1, "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStanu3 = new OpisStanu(2, katalog1, 1);
            Wykaz wykaz3 = new Wykaz(1, "Mariusz");

            Zdarzenie zdarzenie3 = new Sprzedaz(2,opisStanu, wykaz,DateTimeOffset.Now,2);
            data.AddZdarzenie(zdarzenie3);

            data.DeleteZdarzenie(zdarzenie);
            if (data.GetAllZdarzenie().Count() < 2) Assert.Fail();
                }
        [TestMethod()]
        public void WypelnienieWykazdTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);

            List<Wykaz> kopia = new List<Wykaz>();
            kopia.Add(new Wykaz(1, "Mariusz"));
            kopia.Add(new Wykaz(2, "Malik"));
            kopia.Add(new Wykaz(3, "Eustachy"));
            kopia.Add(new Wykaz(4, "Andrzej"));
            kopia.Add(new Wykaz(5, "Maciek"));
            kopia.Add(new Wykaz(6, "Pawel"));
            kopia.Add(new Wykaz(7, "Mariusz"));
            kopia.Add(new Wykaz(8, "Piotr"));

            for (int i = 0; i < kopia.Count; i++)
            {
                if (!kopia[i].toString().Equals(data.GetWykaz((i )).toString()))
                { Assert.Fail(kopia[i].toString() + " : " + data.GetWykaz((i )).toString()); }

            }

        }

        [TestMethod()]
        public void WypelnienieKatalogTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);

            IEnumerable<Katalog> stala = data.GetAllKatalog();
            Dictionary<int, Katalog> nowa = stala.ToDictionary(x => x.idKatalogu - 1, x => x);

            Dictionary<int, Katalog> test = new Dictionary<int, Katalog>();
            test.Add(0, new Katalog(1, "Basnie", "Grim", "1894", (float)34.7));
            test.Add(1, new Katalog(2, "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            test.Add(2, new Katalog(3, "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            test.Add(3, new Katalog(4, "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            test.Add(4, new Katalog(5, "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            test.Add(5, new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            test.Add(6, new Katalog(7, "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            test.Add(7, new Katalog(8, "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));

            for (int i = 0; i < 7; i++)
            {
                if (!(test[i].toString() == nowa[i].toString()))
                { Assert.Fail(test[i].toString() + " : " + nowa[i].toString() + ": i= " + i); }
            }
        }

        [TestMethod()]
        public void WypelnienieOpisStanuTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);

            IEnumerable<OpisStanu> stala = data.GetAllOpisStanu();
            List<OpisStanu> nowa = stala.ToList<OpisStanu>();

            List<OpisStanu> test = new List<OpisStanu>();

            Dictionary<int, Katalog> test2 = new Dictionary<int, Katalog>();
            test2.Add(0, new Katalog(1, "Basnie", "Grim", "1894", (float)34.7));
            test2.Add(1, new Katalog(2, "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            test2.Add(2, new Katalog(3, "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            test2.Add(3, new Katalog(4, "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            test2.Add(4, new Katalog(5, "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            test2.Add(5, new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            test2.Add(6, new Katalog(7, "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            test2.Add(7, new Katalog(8, "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));



            test.Add(new OpisStanu(0,test2[0],4));
            test.Add(new OpisStanu(1, test2[1],4));
            test.Add(new OpisStanu(2,test2[2],4));
            test.Add(new OpisStanu(3, test2[3], 1));
            test.Add(new OpisStanu(4, test2[4], 4));
            test.Add(new OpisStanu(5, test2[5], 4));
            test.Add(new OpisStanu(6, test2[6],4));
            for (int i = 0; i < 7; i++)
            {
                if (!(test[i].toString() == nowa[i].toString())) Assert.Fail(test[i].toString() + " : " + nowa[i].toString());
            }
        }

        [TestMethod()]
        public void WypelnienieZdarzenieTest()
        {
            DataFiller dataFiller = new WypelnienieStalymi();
            DataRepository data = new DataRepository(dataFiller);
            IEnumerable<Zdarzenie> stala = data.GetAllZdarzenie();
            ObservableCollection<Zdarzenie> nowa = new ObservableCollection<Zdarzenie>(stala);

            ObservableCollection<Zdarzenie> test = new ObservableCollection<Zdarzenie>();
            List<OpisStanu> test1 = new List<OpisStanu>();

            Dictionary<int, Katalog> test2 = new Dictionary<int, Katalog>();
            test2.Add(0, new Katalog(1, "Basnie", "Grim", "1894", (float)34.7));
            test2.Add(1, new Katalog(2, "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            test2.Add(2, new Katalog(3, "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            test2.Add(3, new Katalog(4, "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            test2.Add(4, new Katalog(5, "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            test2.Add(5, new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            test2.Add(6, new Katalog(7, "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            test2.Add(7, new Katalog(8, "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));




            test1.Add(new OpisStanu(0, test2[0], 0));
            test1.Add(new OpisStanu(1, test2[1], 1));
            test1.Add(new OpisStanu(2, test2[2], 2));
            test1.Add(new OpisStanu(3, test2[3], 3));
            test1.Add(new OpisStanu(4, test2[4], 4));
            test1.Add(new OpisStanu(5, test2[5], 5));
            test1.Add(new OpisStanu(6, test2[6], 6));

            List<Wykaz> kopia = new List<Wykaz>();
            kopia.Add(new Wykaz(1, "Mariusz"));
            kopia.Add(new Wykaz(2, "Malik"));
            kopia.Add(new Wykaz(3, "Eustachy"));
            kopia.Add(new Wykaz(4, "Andrzej"));
            kopia.Add(new Wykaz(5, "Maciek"));
            kopia.Add(new Wykaz(6, "Pawel"));
            kopia.Add(new Wykaz(7, "Mariusz"));
            kopia.Add(new Wykaz(8, "Piotr"));


            test.Add(new Sprzedaz(0,test1[0], kopia[0],DateTimeOffset.Now,1));
            test.Add(new Sprzedaz(1, test1[1], kopia[1], DateTimeOffset.Now, 1));
            test.Add(new Sprzedaz(2, test1[2], kopia[2], DateTimeOffset.Now, 1));
            test.Add(new Sprzedaz(3, test1[3], kopia[3], DateTimeOffset.Now, 1));
            test.Add(new Sprzedaz(4, test1[4], kopia[4], DateTimeOffset.Now, 1));
            test.Add(new Sprzedaz(5, test1[5], kopia[5], DateTimeOffset.Now, 1));

            for (int i = 0; i < 6; i++)
            {
                if (!(test[i].idZdarzenie == nowa[i].idZdarzenie)) Assert.Fail(test[i].toString() + " : " + nowa[i].toString());
            }
        }
    }
}
