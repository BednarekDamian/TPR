using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
   public class Sprzedaz : Zdarzenie
    {
        public Sprzedaz()
        {

        }
        public Sprzedaz(int id, OpisStanu opis_stanu, Wykaz wykaz, DateTimeOffset time, int ilosc)
        {
            this.idZdarzenie = id;
            opis_stanu.ilosc -= ilosc;
            this.opis_Stanu = opis_stanu;
            this.wykaz = wykaz;
            this.data_zakupu = time;
            this.ilosc_zakupionych = ilosc;
            this.cena_calkowita = ilosc * opis_stanu.katalog.cena;

        }
    }
}
