using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Zadanie2;

namespace UnitTestProject1
{
    [TestClass]
    public class WRTest
    {
        [TestMethod]
        public void WriteTest()
        {
            DataRepository dataRepository = new DataRepository();
            dataRepository.AddWykaz(new Wykaz(0, "Damian"));
            dataRepository.AddWykaz(new Wykaz(0, "Michal"));
            dataRepository.AddKatalog(new Katalog(0, "wiedzmin", "Adnrzej Sapkowski", "1993", (float)25.0));
            dataRepository.AddKatalog(new Katalog(1, "Harry Potter", "JKK Rowling", "1995", (float)33.5));
            dataRepository.AddOpisStanu(new OpisStanu(0, dataRepository.GetKatalog(0), 10));
            dataRepository.AddOpisStanu(new OpisStanu(1, dataRepository.GetKatalog(1), 10));
            dataRepository.AddZdarzenie(new Sprzedaz(0, dataRepository.GetOpisStanu(0), dataRepository.GetWykaz(0), DateTimeOffset.Now, 2));
            dataRepository.AddZdarzenie(new Sprzedaz(1, dataRepository.GetOpisStanu(1), dataRepository.GetWykaz(0), DateTimeOffset.Now, 2));
            dataRepository.AddZdarzenie(new Sprzedaz(2, dataRepository.GetOpisStanu(0), dataRepository.GetWykaz(1), DateTimeOffset.Now, 2));
            XmlSerialize write_to_XML = new XmlSerialize();
            write_to_XML.writeAll(dataRepository);


        }
    }
}
