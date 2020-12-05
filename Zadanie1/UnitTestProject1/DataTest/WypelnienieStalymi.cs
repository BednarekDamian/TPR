using System;


namespace Zadanie1.Data
{
   public class WypelnienieStalymi : DataFiller
    {
        public WypelnienieStalymi(){ }
        public void Filling(DataContext dataContext)
        {
            dataContext.wykazy.Add(new Wykaz(1,"Mariusz"));
            dataContext.wykazy.Add(new Wykaz(2, "Malik"));
            dataContext.wykazy.Add(new Wykaz(3, "Eustachy"));
            dataContext.wykazy.Add(new Wykaz(4, "Andrzej"));
            dataContext.wykazy.Add(new Wykaz(5, "Maciek"));
            dataContext.wykazy.Add(new Wykaz(6, "Pawel"));
            dataContext.wykazy.Add(new Wykaz(7, "Mariusz"));
            dataContext.wykazy.Add(new Wykaz(8, "Piotr"));

            dataContext.katalogi.Add(0,new Katalog(1,"Basnie","Grim","1894", (float)34.7));
            dataContext.katalogi.Add(1,new Katalog(2, "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            dataContext.katalogi.Add(2,new Katalog(3, "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            dataContext.katalogi.Add(3,new Katalog(4, "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            dataContext.katalogi.Add(4,new Katalog(5, "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            dataContext.katalogi.Add(5,new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            dataContext.katalogi.Add(6,new Katalog(7, "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            dataContext.katalogi.Add(7,new Katalog(8, "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));

            for (int i = 0; i <7; i++)
            {
              dataContext.opisyStanu.Add(new OpisStanu(i, dataContext.katalogi[i+1], 5));
            }
            for (int i = 0; i < 7; i++)
            {
                dataContext.zdarzenia.Add(new Sprzedaz(i, dataContext.opisyStanu[i], dataContext.wykazy[i], DateTimeOffset.Now, 1));
            }

            for (int i = 0; i < 3; i++)
            {
                dataContext.zdarzenia.Add(new Sprzedaz(i, dataContext.opisyStanu[3], dataContext.wykazy[i], DateTimeOffset.Now, 1));
            }
        }
    }
}
