namespace Zadanie1.Data
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

        public string toString()
        {
            return opis_stanu.toString() +"\t"+ wykaz.toString();
        }
    }
}
