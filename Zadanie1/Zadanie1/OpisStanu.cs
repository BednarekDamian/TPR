using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class OpisStanu
    {
        private Katalog katalog;
        private DateTimeOffset data_zakupu;
        private int ilosc;
        private float cenaCalosc;

        public OpisStanu(Katalog katalog, DateTimeOffset data_zakupu, int ilosc, float cena)
        {
            this.katalog = katalog;
            this.data_zakupu = data_zakupu;
            this.ilosc = ilosc;
            this.cenaCalosc = cena;
        }

        public Katalog Katalog { get { return katalog; } set => katalog = value; }
        public DateTimeOffset Data_zakupu { get => data_zakupu; set => data_zakupu = value; }
        public int Ilosc { get => ilosc; set => ilosc = value; }
        public float Cena { get => cenaCalosc; set => cenaCalosc = value; }
        public string ALL { get => katalog + " " + data_zakupu + " " + ilosc + " " + cenaCalosc; }
        public string toString()
        {
            return katalog.ToString() + " " + data_zakupu + " " + ilosc + " " + cenaCalosc;
        }
    }
}
