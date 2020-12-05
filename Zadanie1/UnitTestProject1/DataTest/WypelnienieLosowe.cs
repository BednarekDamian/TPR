using System;
using System.Linq;

namespace Zadanie1.Data
{
    class WypelnienieLosowe : DataFiller
    {
        public WypelnienieLosowe() { }

        public static int lenght = 50;
        float myFloat;
        int myInt;
        private static Random rnd = new Random();
        // System.Random rnd = new System.Random();

        private static Random radomia = new Random();
        public static string RandomWord(int size)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(letters, size)
              .Select(s => s[radomia.Next(s.Length)]).ToArray());
        }
        public static string RandomNumber(int size)
        {
            const string letters = "0123456789";
            return new string(Enumerable.Repeat(letters, size)
              .Select(s => s[radomia.Next(s.Length)]).ToArray());
        }
        float GenerateFloat()
        {
            myInt = rnd.Next(1, 200);
            myFloat = (myInt / 10) + 10.5f;
            return myFloat;
        }
  

        public void Filling(DataContext dataContext)
        {
            for (int i = 0; i < 50; i++)
            {
                dataContext.wykazy.Add(new Wykaz(Int32.Parse(RandomNumber(3)), RandomWord(6)));
            }
            for (int i = 0; i < 50; i++)
            {
                dataContext.katalogi.Add(i,new Katalog(Int32.Parse(RandomNumber(4)), RandomWord(10), RandomWord(25), RandomNumber(4), GenerateFloat()));
            }

            for (int i = 0; i < 50; i++)
            {
                dataContext.opisyStanu.Add(new OpisStanu(Int32.Parse(RandomNumber(3)), dataContext.katalogi[i],i));
            }
            for (int i = 0; i < 8; i++)
            {
                dataContext.zdarzenia.Add(new Sprzedaz(Int32.Parse(RandomNumber(5)),dataContext.opisyStanu[i],dataContext.wykazy[i],DateTimeOffset.Now,i));
            }
        }
    }
}
