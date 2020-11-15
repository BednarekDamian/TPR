using System;

namespace Zadanie1
{
    class WypelnienieStalymi : DataFiller
    {
        public WypelnienieStalymi(){ }
        public void Filling(DataContext cont)
        {
            cont.wykazy.Add(new Wykaz("1","Mariusz"));
            cont.wykazy.Add(new Wykaz("2", "Malik"));
            cont.wykazy.Add(new Wykaz("3", "Eustachy"));
            cont.wykazy.Add(new Wykaz("4", "Andrzej"));
            cont.wykazy.Add(new Wykaz("5", "Maciek"));
            cont.wykazy.Add(new Wykaz("6", "Pawel"));
            cont.wykazy.Add(new Wykaz("7", "Mariusz"));
            cont.wykazy.Add(new Wykaz("8", "Piotr"));

            cont.katalogi.Add(1,new Katalog("1","Basnie","Grim","1894", (float)34.7));
            cont.katalogi.Add(2,new Katalog("2", "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            cont.katalogi.Add(3,new Katalog("3", "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            cont.katalogi.Add(4,new Katalog("4", "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            cont.katalogi.Add(5,new Katalog("5", "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            cont.katalogi.Add(6,new Katalog("6", "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            cont.katalogi.Add(7,new Katalog("7", "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            cont.katalogi.Add(8,new Katalog("8", "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));

            for (int i = 0; i < 8; i++)
            {
                cont.opisyStanu.Add(new OpisStanu(cont.katalogi[i], DateTimeOffset.Now, i+1, cont.katalogi[i].Cena));
            }
            for(int i = 0; i < 8; i++)
            {
                cont.zdarzenia.Add(new Zdarzenie(cont.opisyStanu[i], cont.wykazy[i]));
            }

            for (int i = 0; i < 3; i++)
            {
                cont.zdarzenia.Add(new Zdarzenie(cont.opisyStanu[3], cont.wykazy[i]));
            }
        }
    }
}
