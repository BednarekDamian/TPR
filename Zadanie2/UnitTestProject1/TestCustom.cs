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
    public class CustomTest
    {
        [TestMethod]
        public void CFormatterTest()
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
            CustomFormatter formater = new CustomFormatter();
            formater.writeAll(dataRepository);
            DataRepository dataRepositoryTest = formater.readALL();

            //Testy przesylu
            for (int i = 0; i < dataRepository.GetAllWykaz().Count(); i++)
            {
                if (!dataRepository.GetWykaz(i).ToString().Equals(dataRepositoryTest.GetWykaz(i).ToString())) Assert.Fail();
            }

            for (int i = 0; i < dataRepository.GetAllKatalog().Count(); i++)
            {
                if (!dataRepository.GetKatalog(i).ToString().Equals(dataRepositoryTest.GetKatalog(i).ToString())) Assert.Fail();
            }

            for (int i = 0; i < dataRepository.GetAllOpisStanu().Count(); i++)
            {
                if (!dataRepository.GetOpisStanu(i).ToString().Equals(dataRepositoryTest.GetOpisStanu(i).ToString())) Assert.Fail();
            }

            for (int i = 0; i < dataRepository.GetAllZdarzenie().Count(); i++)
            {
                if (dataRepository.GetZdarzenie(i).ToString().Equals(dataRepositoryTest.GetZdarzenie(i).ToString())) Assert.Fail();

            }

            //testy wybiórcze
            if (!dataRepository.GetWykaz(0).ToString().Equals(new Wykaz(0, "Damian").ToString())) Assert.Fail();
            if (!dataRepository.GetWykaz(1).ToString().Equals(new Wykaz(0, "Michal").ToString())) Assert.Fail();
            if (dataRepository.GetWykaz(1).ToString().Equals(new Wykaz(0, "cokolwiek").ToString())) Assert.Fail();

            if (!dataRepository.GetKatalog(0).ToString().Equals(new Katalog(0, "wiedzmin", "Adnrzej Sapkowski", "1993", (float)25.0).ToString())) Assert.Fail();
            if (!dataRepository.GetKatalog(1).ToString().Equals(new Katalog(1, "Harry Potter", "JKK Rowling", "1995", (float)33.5).ToString())) Assert.Fail();
            if (dataRepository.GetWykaz(0).ToString().Equals(new Katalog(1, "nie", "cos", "tak", (float)33.5).ToString())) Assert.Fail();

        }
    }
}
