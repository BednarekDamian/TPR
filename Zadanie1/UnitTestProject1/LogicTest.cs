using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zadanie1.Data;
using Zadanie1.logic;

namespace UnitTestProject1
{
    [TestClass]
    public class LogicYTest
    {
        [TestMethod]
        public void WyszukajTest()
        {
            DataContext context_plik = new DataContext();
            WypelnienieStalymi plik = new WypelnienieStalymi();
            DataRepository data_plik = new DataRepository(context_plik, plik);
            DataService dataService = new DataService(data_plik);
            data_plik.FillerStatic();
            List<Wykaz> wykaz = dataService.WyszukajWykaz("1 Mariusz");
            if (wykaz[0].toString() != "1 Mariusz") Assert.Fail(wykaz[0].toString());
            Dictionary<int, Katalog> katalog = dataService.SzukajKatalog("Wiedzmin");
            Katalog katalogtest = new Katalog("6", "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0);
            if (katalog[0].toString() != katalogtest.toString()) Assert.Fail();
            List<OpisStanu> opisStanu = dataService.znajdzOpis(25, 35);
            if (opisStanu[0].toString() != data_plik.GetOpisStanu(0).toString()) Assert.Fail();
            ObservableCollection<Zdarzenie> zdarzenie = dataService.SzukajZdarzenie(DateTime.Parse("25.03.2020"), DateTime.Parse("25.03.2021"));
            if (zdarzenie.Count() == 0) Assert.Fail();
        }
        [TestMethod]
        public void Test2()
        {

            DataContext context_plik = new DataContext();
            WypelnienieStalymi plik = new WypelnienieStalymi();
            DataRepository data_plik = new DataRepository(context_plik, plik);
            DataService dataService = new DataService(data_plik);
             Katalog kat= new Katalog("1", "Basnie", "Grim", "1894", (float)34.7);
            dataService.DodajOpis(new OpisStanu(kat, DateTimeOffset.Now, 1, (float)25.0));
            if (data_plik.GetOpisStanu(0).toString() != dataService.znajdzOpis(20, 26)[0].toString()) Assert.Fail();
            dataService.DodajKatalog(kat);

            if (data_plik.GetAllKatalog().Count() == 0) Assert.Fail(); ;

            Wykaz wykaz = new Wykaz("1", "Mariusz");
            dataService.DodajWykaz(wykaz);
            if (dataService.WyszukajWykaz("Mariusz")[0].toString() != wykaz.toString()) Assert.Fail();
        }
 
    }
}