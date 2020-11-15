namespace Zadanie1
{
    public class Katalog
    {
        private string idKatalogu;
        private string tytul;
        private string autor;
        private string rok;
        private float cena;

        public Katalog(string idKatalogu, string tytul, string autor, string rok, float cena)
        {
            this.idKatalogu = idKatalogu;
            this.tytul = tytul;
            this.autor = autor;
            this.rok = rok;
            this.cena = cena;
        }

        public string IdKatalogu { get => idKatalogu; set => idKatalogu = value; }
        public string Tytul { get => tytul; set => tytul = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Rok { get => rok; set => rok = value; }
        public float Cena { get => cena; set => cena = value; }
        public string ALL { get => idKatalogu + " " + tytul + " " + autor + " " + rok + " " + cena; }

        public string toString()
        {
            return "Id Katalogu: " + idKatalogu + " , Tytul: " + tytul + " , autor: " + autor + " , Rok: " + rok + " , Cena: " + cena + "\n";
        }
    }
}
