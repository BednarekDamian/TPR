namespace Zadanie1.Data
{
    public class Wykaz
    {
        public int idKlienta { get; set; }
        public string nazwaKlienta { get; set; }

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
