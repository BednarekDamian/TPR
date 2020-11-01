namespace Zadanie1
{
    public class Wykaz
    {
        private int idKlienta;
        private string nazwaKlienta;

        public Wykaz(int id, string nazwa)
        {
            this.idKlienta = id;
            this.nazwaKlienta = nazwa;
        }

        public int getId() 
        {
            return this.idKlienta;
        }
        public string getNazwa()
        {
            return this.nazwaKlienta;
        }
    }
}
