namespace Zadanie1
{
    public class Katalog
    {
        private int idKsiazki;
        private string tytul;
        private string autor;
        private string rok;
        private float cena;

        public Katalog(int idKsiazki, string tytul, string autor, string rok, float cena)
        {
            this.idKsiazki = idKsiazki;
            this.tytul = tytul;
            this.autor = autor;
            this.rok = rok;
            this.cena = cena;
        }
        public string getTytul() 
        {
            return this.tytul;
        }
        public string getAutor()
        {
            return this.autor;
        }
        public string getRok()
        {
            return this.rok;
        }
        public float getCena()
        {
            return this.cena;
        }

    }
}
