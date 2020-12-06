using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

            DataRepository dataRepositoryTest = new DataRepository();
            dataRepositoryTest.AddWykaz(new Wykaz(0, "Damian"));
            dataRepositoryTest.AddWykaz(new Wykaz(0, "Michal"));
            dataRepositoryTest.AddKatalog(new Katalog(0, "wiedzmin", "Adnrzej Sapkowski", "1993", (float)25.0));
            dataRepositoryTest.AddKatalog(new Katalog(1, "Harry Potter", "JKK Rowling", "1995", (float)33.5));
            dataRepositoryTest.AddOpisStanu(new OpisStanu(0, dataRepositoryTest.GetKatalog(0), 10));
            dataRepositoryTest.AddOpisStanu(new OpisStanu(1, dataRepositoryTest.GetKatalog(1), 10));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(0, dataRepositoryTest.GetOpisStanu(0), dataRepositoryTest.GetWykaz(0), DateTimeOffset.Now, 2));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(1, dataRepositoryTest.GetOpisStanu(1), dataRepositoryTest.GetWykaz(0), DateTimeOffset.Now, 2));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(2, dataRepositoryTest.GetOpisStanu(0), dataRepositoryTest.GetWykaz(1), DateTimeOffset.Now, 2));

            for(int i= 0; i < dataRepository.GetAllWykaz().Count(); i++)
            {
                if(!dataRepository.GetWykaz(i).toString().Equals(dataRepositoryTest.GetWykaz(i).toString())) Assert.Fail();
            }
        }
    }
}
