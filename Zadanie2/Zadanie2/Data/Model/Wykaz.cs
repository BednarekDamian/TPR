namespace Zadanie2
{
    public class Wykaz
    {
        public int idKlienta { get; set; }
        public string nazwaKlienta { get; set; }
        public Wykaz()
        {

        }
        public Wykaz(int id, string nazwa)
        {
            this.idKlienta = id;
            this.nazwaKlienta = nazwa;
        }
        public string toString()
        {
            return  idKlienta + " " + nazwaKlienta;
        }

    }
}
