using System;


namespace Zadanie1.Data
{
   public class WypelnienieStalymi : DataFiller
    {
        public WypelnienieStalymi(){ }
        public void Filling(IDataRepo dataRepo)
        {
            dataRepo.AddWykaz(new Wykaz(1,"Mariusz"));
            dataRepo.AddWykaz(new Wykaz(2, "Malik"));
            dataRepo.AddWykaz(new Wykaz(3, "Eustachy"));
            dataRepo.AddWykaz(new Wykaz(4, "Andrzej"));
            dataRepo.AddWykaz(new Wykaz(5, "Maciek"));
            dataRepo.AddWykaz(new Wykaz(6, "Pawel"));
            dataRepo.AddWykaz(new Wykaz(7, "Mariusz"));
            dataRepo.AddWykaz(new Wykaz(8, "Piotr"));

            dataRepo.AddKatalog(new Katalog(1,"Basnie","Grim","1894", (float)34.7));
            dataRepo.AddKatalog(new Katalog(2, "Harry Pota", "J.K. Rowling", "1999", (float)24.4));
            dataRepo.AddKatalog(new Katalog(3, "Chłopcy z Placu Broni", "Ferenc Molnar", "1913", (float)24.0));
            dataRepo.AddKatalog(new Katalog(4, "Kamienie na szaniec", "Aleksander Kaminski", "1945", (float)42.0));
            dataRepo.AddKatalog(new Katalog(5, "Wesele", "Stanislaw Wyspianski", "1901", (float)21.3));
            dataRepo.AddKatalog(new Katalog(6, "Wiedzmin", "Andrzej Sapkowski", "1993", (float)15.0));
            dataRepo.AddKatalog(new Katalog(7, "Dziady", "Adam Mickiewicz", "1822", (float)18.2));
            dataRepo.AddKatalog(new Katalog(8, "Sen srebny Salomei", "Juliusz Slowacki", "1900", (float)11.2));

            for (int i = 0; i <7; i++)
            {
               dataRepo.AddOpisStanu(new OpisStanu(i, dataRepo.GetKatalog(i+1), i));
            }
            for (int i = 0; i < 7; i++)
            {
               dataRepo.AddZdarzenie(new Zdarzenie(i,dataRepo.GetOpisStanu(i), dataRepo.GetWykaz(i),DateTimeOffset.Now,i));
            }

            for (int i = 0; i < 3; i++)
            {
                dataRepo.AddZdarzenie(new Zdarzenie(i, dataRepo.GetOpisStanu(3), dataRepo.GetWykaz(i), DateTimeOffset.Now, i));
            }
        }
    }
}
