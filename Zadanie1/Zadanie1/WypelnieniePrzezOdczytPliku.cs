using System;
namespace Zadanie1.Data
{
    class WypelnieniePrzezOdczytPliku : DataFiller
    {
        public WypelnieniePrzezOdczytPliku(){}

        public void Filling(DataContext contFil)
        {

            string[] line = System.IO.File.ReadAllLines(@"Wykaz.txt");
            foreach(string l in line)
            {
                string[] word = l.Split(';');
                contFil.wykazy.Add(new Wykaz(word[0], word[1]));
            }
            line = System.IO.File.ReadAllLines("@Katalog.txt");
            int q = 0;
            foreach (string l in line)
            {
                string[] word = l.Split(';');
                contFil.katalogi.Add(q, new Katalog(word[0],word[1],word[2],word[3],float.Parse(word[4])));
                q++;
            }
            line = System.IO.File.ReadAllLines("@Opis.txt");
            foreach (string l in line)
            {
                string[] word = l.Split(';');
                foreach (Katalog o in contFil.katalogi.Values)
                    if (o.IdKatalogu == word[0])
                    {
                        contFil.opisyStanu.Add(new OpisStanu(o, DateTimeOffset.Parse(word[1]), Int32.Parse(word[2]), float.Parse(word[2])));     
                    }
            }
            line = System.IO.File.ReadAllLines("@Zdarzenie.txt");
            foreach (string l in line)
            {
                string[] word = l.Split(';');
                Wykaz x = new Wykaz("", "");
                Katalog y = new Katalog("", "", "", "", (float)0.0);
                OpisStanu z = new OpisStanu(y, DateTimeOffset.Now, 0, (float)0.0);
                foreach (OpisStanu z2 in contFil.opisyStanu)
                {
                    if (z2.Katalog.IdKatalogu == y.IdKatalogu && z2.Data_zakupu == DateTimeOffset.Parse(word[0]));
                    {
                        z = z2;
                        break;
                    }
                }
                foreach (Wykaz x2 in contFil.wykazy)
                {
                    if(x2.IdKlienta == word[1])
                    {
                        x = x2;
                        break;
                    }
                }
                contFil.zdarzenia.Add(new Zdarzenie(z, x));
            }            

        }
    }
}

