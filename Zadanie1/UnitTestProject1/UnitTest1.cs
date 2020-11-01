using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestProject1
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void CreateDataContext()
        {
            Wykaz klient = new Wykaz(1, "Damian Bednarek");
            Katalog ksiazka = new Katalog(1, "Lalka", "Boleslaw Prus", "1889 rok", 20);
            
        }
    }
}
