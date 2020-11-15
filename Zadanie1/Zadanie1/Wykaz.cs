namespace Zadanie1
{
    public class Wykaz
    {
        private string idKlienta;
        private string nazwaKlienta;

        public Wykaz(string id, string nazwa)
        {
            this.idKlienta = id;
            this.nazwaKlienta = nazwa;
        }

        public string IdKlienta { get => idKlienta; set => idKlienta = value; }
        public string NazwaKlienta { get => nazwaKlienta; set => nazwaKlienta = value; }
        public string ALL { get => idKlienta + " " + nazwaKlienta; }

        public string toString()
        {
            return "Id klienta: " + idKlienta + " , Nazwa klienta: " + nazwaKlienta;
        }

    }
}
