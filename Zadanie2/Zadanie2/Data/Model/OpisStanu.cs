
using System.Runtime.Serialization;

namespace Zadanie2
{
    public class OpisStanu : ISerializable
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
        public override string ToString()
        {
            return idOpis + "_" + katalog.ToString() + "_" + ilosc;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("idOpis", idOpis);
            info.AddValue("katalog", katalog,typeof(Katalog));
            info.AddValue("ilosc", ilosc);

        }
    }
}
