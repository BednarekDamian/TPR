
namespace Zadanie2
{
    public class OpisStanu
    {
        public int idOpis { get; set; }
        public Katalog katalog { get; set; }       
        public int ilosc { get; set; }
        public OpisStanu()
        {

        }
        public OpisStanu(int id, Katalog katalog, int ilosc)
        {
            this.idOpis = id;
            this.katalog = katalog;           
            this.ilosc = ilosc;
           
        }  
        public string toString()
        {
            return idOpis + katalog.ToString() + " " + ilosc;
        }
    }
}
