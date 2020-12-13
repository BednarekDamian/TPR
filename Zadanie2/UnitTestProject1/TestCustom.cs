using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using Zadanie2;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomTest
    {
        [TestMethod]
        public void CFormatterTestWykaz()
        {
            DataFill filerdata = new DataFill();
            DataRepository dataRepositoryTest = new DataRepository();
            DataRepository dataAfterCustomTest = new DataRepository();
            dataRepositoryTest.AddWykaz(new Wykaz(0, "Damian"));
            dataRepositoryTest.AddWykaz(new Wykaz(0, "Michal"));
            dataRepositoryTest.AddKatalog(new Katalog(0, "wiedzmin", "Adnrzej Sapkowski", "1993", (float)25.0));
            dataRepositoryTest.AddKatalog(new Katalog(1, "Harry Potter", "JKK Rowling", "1995", (float)33.0));
            dataRepositoryTest.AddOpisStanu(new OpisStanu(0, dataRepositoryTest.GetKatalog(0), 10));
            dataRepositoryTest.AddOpisStanu(new OpisStanu(1, dataRepositoryTest.GetKatalog(1), 10));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(0, dataRepositoryTest.GetOpisStanu(0), dataRepositoryTest.GetWykaz(0), DateTimeOffset.Now, 2));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(1, dataRepositoryTest.GetOpisStanu(1), dataRepositoryTest.GetWykaz(0), DateTimeOffset.Now, 2));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(2, dataRepositoryTest.GetOpisStanu(0), dataRepositoryTest.GetWykaz(1), DateTimeOffset.Now, 2));
            Console.WriteLine(dataRepositoryTest.GetOpisStanu(1));
            CustomFormatter formatter = new CustomFormatter();
            using (Stream stream = new FileStream("../../../custom.xml", FileMode.Create))
            {
                formatter.Serialize(stream, dataRepositoryTest);
            }
            using (Stream reader = new FileStream("../../../custom.xml", FileMode.Open))
            {
                dataAfterCustomTest = (DataRepository)formatter.Deserialize(reader);
            }

            //Testy przesylu
            for (int i = 0; i < dataRepositoryTest.GetAllWykaz().Count(); i++)
            {
                if (!dataRepositoryTest.GetWykaz(i).ToString().Equals(dataAfterCustomTest.GetWykaz(i).ToString())) Assert.Fail();
            }

            for (int i = 0; i < dataRepositoryTest.GetAllKatalog().Count(); i++)
            {
                if (!dataRepositoryTest.GetKatalog(i).ToString().Equals(dataAfterCustomTest.GetKatalog(i).ToString())) Assert.Fail();
            }

            for (int i = 0; i < dataRepositoryTest.GetAllOpisStanu().Count(); i++)
            {
                if (!dataRepositoryTest.GetOpisStanu(i).ToString().Equals(dataAfterCustomTest.GetOpisStanu(i).ToString())) Assert.Fail();
            }

            for (int i = 0; i < dataRepositoryTest.GetAllZdarzenie().Count(); i++)
            {
                if (!dataRepositoryTest.GetZdarzenie(i).ToString().Equals(dataAfterCustomTest.GetZdarzenie(i).ToString())) Assert.Fail();
            }



            //testy wybiórcze
            if (!dataRepositoryTest.GetWykaz(0).ToString().Equals(new Wykaz(0, "Damian").ToString())) Assert.Fail();
            if (!dataRepositoryTest.GetWykaz(1).ToString().Equals(new Wykaz(0, "Michal").ToString())) Assert.Fail();
            if (dataRepositoryTest.GetWykaz(1).ToString().Equals(new Wykaz(0, "cokolwiek").ToString())) Assert.Fail();

            if (!dataRepositoryTest.GetKatalog(0).ToString().Equals(new Katalog(0, "wiedzmin", "Adnrzej Sapkowski", "1993", (float)25.0).ToString())) Assert.Fail();
            if (!dataRepositoryTest.GetKatalog(1).ToString().Equals(new Katalog(1, "Harry Potter", "JKK Rowling", "1995", (float)33.0).ToString())) Assert.Fail();
            if (dataRepositoryTest.GetWykaz(0).ToString().Equals(new Katalog(1, "nie", "cos", "tak", (float)33.0).ToString())) Assert.Fail();

        }

    }
}






