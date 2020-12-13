using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Zadanie2
{
    [XmlInclude(typeof(Sprzedaz)), XmlInclude(typeof(Zakup))]
    public  class Zdarzenie : ISerializable
    {
        public int idZdarzenie { get; set; }
         public OpisStanu opis_Stanu { get; set; }
        public Wykaz wykaz { get; set; }
        public DateTimeOffset data_zakupu { get; set; }
        public int ilosc_zakupionych {get; set; }
        public float cena_calkowita { get; set; }
       
        public Zdarzenie()
        {

        }
        public override string ToString()

        {
            return idZdarzenie + "_" + opis_Stanu.ToString() + "_" + wykaz.ToString() + "_" + data_zakupu + "_" + ilosc_zakupionych + "_" + cena_calkowita;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("idZdarzenia", idZdarzenie);
            info.AddValue("opis_stanu", opis_Stanu, typeof(OpisStanu));
            info.AddValue("wykaz", wykaz, typeof(Wykaz));
            info.AddValue("data_zakupu", data_zakupu);
            info.AddValue("ilosc_zakupionych", ilosc_zakupionych);
            info.AddValue("cena_calkowita", cena_calkowita);
        }
    }
}
