﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Zadanie1.Data;
using Zadanie1.logic;

namespace UnitTestProject1
{
    [TestClass]
    public class LogicYTest
    {
        [TestMethod]
        public void ZdarzenieTest()
        {
            DataContext contex = new DataContext();
            DataRepository data = new DataRepository(contex);
            DataService dataService  = new DataService(data);

            Katalog katalog1 = new Katalog(1, "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStanu = new OpisStanu(0, katalog1, 1);
            Wykaz wykaz = new Wykaz(1, "Mariusz");
            Zdarzenie zdarzenie = new Zdarzenie(0, opisStanu, wykaz, DateTime.Parse("05.03.2020"), 1);
            dataService.DodajZdarzenie(0 , wykaz, opisStanu, DateTime.Parse("05.03.2020"), 1);
             List<Zdarzenie> zdarzenie2 = (List<Zdarzenie>) dataService.ZdarzenieDlaWykazu(wykaz);
            if (zdarzenie2[0].idZdarzenie != zdarzenie.idZdarzenie) Assert.Fail();
        }
        [TestMethod]
        public void ZdarzeniePomiedzydatami()
        {
            DataContext contex = new DataContext();
            DataRepository data = new DataRepository(contex);
            DataService dataService = new DataService(data);

            Katalog katalog1 = new Katalog(1, "Wiedzmin", "Sapkowski", "2000", (float)32.5);
            OpisStanu opisStanu = new OpisStanu(0, katalog1, 1);
            Wykaz wykaz = new Wykaz(1, "Mariusz");
            Zdarzenie zdarzenie = new Zdarzenie(0, opisStanu, wykaz, DateTime.Parse("05.03.2020"), 1);
            dataService.DodajZdarzenie(0, wykaz, opisStanu, DateTime.Parse("05.03.2020"), 1);
           List<Zdarzenie> zdarzenie2= (List<Zdarzenie>)dataService.ZdarazeniePomiedzyDatami(DateTime.Parse("02.03.2020"), DateTime.Parse("09.03.2020"));
            if (zdarzenie2[0].idZdarzenie != zdarzenie.idZdarzenie) Assert.Fail();
        }
 
    }
}