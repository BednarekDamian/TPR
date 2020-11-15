using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Zdarzenie
    {
        private OpisStanu opis_stanu;
        private Wykaz wykaz;

        public Zdarzenie(OpisStanu opis_stanu, Wykaz wykaz)
        {
            this.opis_stanu = opis_stanu;
           this.wykaz = wykaz;
        }
        public OpisStanu Opis_Stanu { get => opis_stanu; set => opis_stanu = value; }
        public Wykaz Wykaz { get => wykaz; set => wykaz = value; }

        public string ALL { get => this.Opis_Stanu.ALL + " " + this.Wykaz.ALL; }
        public string toString()
        {
            return opis_stanu.toString() +"\t"+ wykaz.toString();
        }
    }
}
