using System;

namespace Zadanie1.Data
{
    public class Zdarzenie
    {
        public int idZdarzenie { get; set; }
        public OpisStanu opis_Stanu { get; set; }
        public Wykaz wykaz { get; set; }
        public DateTimeOffset data_zakupu { get; set; }
        public int ilosc_zakupionych {get; set; }
        public float cena_calkowita { get; set; }
 
        public Zdarzenie(int id, OpisStanu opis_stanu, Wykaz wykaz, DateTimeOffset time, int ilosc)
        {
            this.idZdarzenie = id;
            this.opis_Stanu = opis_stanu;
            this.wykaz = wykaz;
            this.data_zakupu = time;
            this.ilosc_zakupionych = ilosc;
            this.cena_calkowita = ilosc* opis_stanu.katalog.cena;

        }
        public string toString()
        {
            return idZdarzenie+ opis_Stanu.toString() +"\t"+ wykaz.toString()+data_zakupu +ilosc_zakupionych+cena_calkowita;
        }
    }
}
