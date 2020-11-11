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

        public int IdKsiazki { get => idKsiazki; set => idKsiazki = value; }
        public string Tytul { get => tytul; set => tytul = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Rok { get => rok; set => rok = value; }
        public float Cena { get => cena; set => cena = value; }


        public string toString()

        {

            return "Id Ksiazki: " + idKsiazki + " , Tytul: " + tytul + " , autor: " + autor + " , Rok: " + rok + " , Cena: " + cena + "\n";

        }


    }
}
