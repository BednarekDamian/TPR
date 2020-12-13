using System.Runtime.Serialization;

namespace Zadanie2
{
    public class Wykaz : ISerializable
    {
        public int idKlienta { get; set; }
        public string nazwaKlienta { get; set; }
       
        public Wykaz()
        {

        }
        public Wykaz(int id, string nazwa)
        {
            this.idKlienta = id;
            this.nazwaKlienta = nazwa;
        }
        public override string ToString()
        {
            return  idKlienta + "_" + nazwaKlienta;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           
            info.AddValue("IdKlienta", idKlienta);
            info.AddValue("NazwaKlienta", nazwaKlienta);
          
           
        }
    }
}
