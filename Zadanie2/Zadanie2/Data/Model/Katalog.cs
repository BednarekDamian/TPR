using System.Runtime.Serialization;

namespace Zadanie2
{
    public class Katalog : ISerializable
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

        public override string ToString()
        {
            return idKatalogu +"_"+ tytul + "_" + autor + "_" + rok + "_" + cena;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IdKatalogu", idKatalogu);
            info.AddValue("tytul", tytul);
            info.AddValue("autor", autor);
            info.AddValue("rok", rok);
            info.AddValue("cena", cena);
        }
    }
}
