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
        public void CFormatterTest()
        {

            DataFill filerdata = new DataFill();
            DataRepository dataRepositoryTest = new DataRepository();
            filerdata.fill(dataRepositoryTest);
            DataRepository dataAfterCustomTest = new DataRepository();
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
            if (!dataAfterCustomTest.GetWykaz(0).ToString().Equals(new Wykaz(0, "Damian").ToString())) Assert.Fail();
            if (!dataAfterCustomTest.GetWykaz(1).ToString().Equals(new Wykaz(1, "Michal").ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetWykaz(1).ToString().Equals(new Wykaz(0, "cokolwiek").ToString())) Assert.Fail();

            if (!dataAfterCustomTest.GetKatalog(0).ToString().Equals(new Katalog(0, "wiedzmin", "Adnrzej Sapkowski", "1993", (float)25.0).ToString())) Assert.Fail();
            if (!dataAfterCustomTest.GetKatalog(1).ToString().Equals(new Katalog(1, "Harry Potter", "JKK Rowling", "1995", (float)33.0).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetKatalog(0).ToString().Equals(new Katalog(1, "nie", "cos", "tak", (float)33.0).ToString())) Assert.Fail();

        }
        [TestMethod]
        public void CFormatterTestExt()
        {
            DataRepository dataRepositoryTest = new DataRepository();
            DataRepository dataAfterCustomTest = new DataRepository();
            dataRepositoryTest.AddWykaz(new Wykaz(0, "Bendzamin"));
            dataRepositoryTest.AddKatalog(new Katalog(0, "Chlopi", "Wladyslaw Reymont", "1904", (float)42.0));
            dataRepositoryTest.AddOpisStanu(new OpisStanu(0, dataRepositoryTest.GetKatalog(0), 5));
            dataRepositoryTest.AddZdarzenie(new Sprzedaz(0, dataRepositoryTest.GetOpisStanu(0), dataRepositoryTest.GetWykaz(0), DateTimeOffset.Now, 4));
            CustomFormatter formatter = new CustomFormatter();
            using (Stream stream = new FileStream("../../../custom.xml", FileMode.Create))
            {
                formatter.Serialize(stream, dataRepositoryTest);
            }
            using (Stream reader = new FileStream("../../../custom.xml", FileMode.Open))
            {
                dataAfterCustomTest = (DataRepository)formatter.Deserialize(reader);
            }

            if (!dataAfterCustomTest.GetWykaz(0).ToString().Equals(new Wykaz(0, "Bendzamin").ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetWykaz(0).ToString().Equals(new Wykaz(0, "cokolwiek").ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetWykaz(0).ToString().Equals(new Wykaz(1, "Bendzamin").ToString())) Assert.Fail();
            if (!dataAfterCustomTest.GetKatalog(0).ToString().Equals(new Katalog(0, "Chlopi", "Wladyslaw Reymont", "1904", (float)42.0).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetKatalog(0).ToString().Equals(new Katalog(0, "Harry Potter", "JKK Rowling", "1995", (float)33.0).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetKatalog(0).ToString().Equals(new Katalog(1, "nie", "cos", "tak", (float)33.0).ToString())) Assert.Fail();
            if (!dataAfterCustomTest.GetOpisStanu(0).ToString().Equals(new OpisStanu(0, dataAfterCustomTest.GetKatalog(0), 5).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetOpisStanu(0).ToString().Equals(new OpisStanu(20, dataAfterCustomTest.GetKatalog(0), 5).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetOpisStanu(0).ToString().Equals(new OpisStanu(0, dataAfterCustomTest.GetKatalog(0), 15).ToString())) Assert.Fail();
            if (!dataAfterCustomTest.GetZdarzenie(0).ToString().Equals(new Sprzedaz(0, dataAfterCustomTest.GetOpisStanu(0), dataAfterCustomTest.GetWykaz(0), DateTimeOffset.Now, 4).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetZdarzenie(0).ToString().Equals(new Sprzedaz(4, dataAfterCustomTest.GetOpisStanu(0), dataAfterCustomTest.GetWykaz(0), DateTimeOffset.Now, 4).ToString())) Assert.Fail();
            if (dataAfterCustomTest.GetZdarzenie(0).ToString().Equals(new Sprzedaz(0, dataAfterCustomTest.GetOpisStanu(00), dataAfterCustomTest.GetWykaz(0), DateTimeOffset.Now, 5).ToString())) Assert.Fail();
        }
    }
}






