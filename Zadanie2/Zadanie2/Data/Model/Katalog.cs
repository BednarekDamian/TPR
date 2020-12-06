namespace Zadanie2
{
    public class Katalog
    {
        public int idKatalogu { get; set; }
        public string tytul { get; set; }
        public string autor { get; set; }
        public string rok { get; set; }
        public float cena { get; set; }
        public Katalog()
        {

        }
        public Katalog(int idKatalogu, string tytul, string autor, string rok, float cena)
        {
            this.idKatalogu = idKatalogu;
            this.tytul = tytul;
            this.autor = autor;
            this.rok = rok;
            this.cena = cena;
        }

        public string toString()
        {
            return "Id Katalogu: " + idKatalogu + " , Tytul: " + tytul + " , autor: " + autor + " , Rok: " + rok + " , Cena: " + cena + "\n";
        }
    }
}
