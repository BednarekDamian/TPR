using System;
using System.Xml.Serialization;

namespace Zadanie2
{
    [XmlInclude(typeof(Sprzedaz)), XmlInclude(typeof(Zakup))]
    public  class Zdarzenie
    {
        public int idZdarzenie { get; set; }
         public OpisStanu opis_Stanu { get; set; }
        public Wykaz wykaz { get; set; }
        public DateTimeOffset data_zakupu { get; set; }
        public int ilosc_zakupionych {get; set; }
        public float cena_calkowita { get; set; }
        public Zdarzenie()
        {

        }
        public String toString()
        {
            return idZdarzenie + opis_Stanu.toString() + "\t" + wykaz.toString() + data_zakupu + ilosc_zakupionych + cena_calkowita;
        }
    }
}
