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

        public int IdKlienta { get => idKlienta; set => idKlienta = value; }
        public string NazwaKlienta { get => nazwaKlienta; set => nazwaKlienta = value; }

        public string toString()
        {
            return "Id klienta: " + idKlienta + " , Nazwa klienta: " + nazwaKlienta;
        }

    }
}
