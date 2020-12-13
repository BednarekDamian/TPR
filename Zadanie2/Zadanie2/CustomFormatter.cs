using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Zadanie2
{
    public  class CustomFormatter : Formatter 
    {
        public CustomFormatter()
        {

        }

        private List<XElement> values = new List<XElement>();
        private List<XElement> values2 = new List<XElement>();
       
        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable _data = (ISerializable)graph;
            SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext _context = new StreamingContext(StreamingContextStates.File);
            _data.GetObjectData(_info, _context);
            
            foreach (SerializationEntry _item in _info)
            {
                this.WriteMember(_item.Name, _item.Value);
            }

            using (StreamWriter writer = new StreamWriter(serializationStream))
            {
                writer.Write(new XElement("DataRepository",values));         
            }
        }

        public override object Deserialize(Stream serializationStream)
        {
            DataRepository data = new DataRepository();
            using (StreamReader reader = new StreamReader(serializationStream))
            {
                string line = reader.ReadLine();
                int first, last, wykazy = 1, katalogi = 0, opisy = 0;
               
                while (line != null)
                {
                    if (line.Contains("<IdKlienta>"))
                    {
                        first = line.IndexOf("<IdKlienta>") + "<IdKlienta>".Length;
                        last = line.IndexOf("</");
                        int IdKlienta = Int32.Parse(line.Substring(first, last - first));
                        line = reader.ReadLine();
                        first = line.IndexOf("<NazwaKlienta>") + "<NazwaKlienta>".Length;
                        last = line.IndexOf("</");
                        string name = line.Substring(first, last - first);
                        data.AddWykaz(new Wykaz(IdKlienta, name));
                        wykazy++;
                    }

                    if (line.Contains("<IdKatalogu>"))
                    {
                        first = line.IndexOf("<IdKatalogu>") + "<IdKatalogu>".Length;
                        last = line.IndexOf("</");
                        int IdKatalogu = Int32.Parse(line.Substring(first, last - first));
                        line = reader.ReadLine();
                        first = line.IndexOf("<tytul>") + "<tytul>".Length;
                        last = line.IndexOf("</");
                        string tytul = line.Substring(first, last - first);
                        line = reader.ReadLine();
                        first = line.IndexOf("<autor>") + "<autor>".Length;
                        last = line.IndexOf("</");
                        string autor = line.Substring(first, last - first);
                        line = reader.ReadLine();
                        first = line.IndexOf("<rok>") + "<rok>".Length;
                        last = line.IndexOf("</");
                        string rok = line.Substring(first, last - first);
                        line = reader.ReadLine();
                        first = line.IndexOf("<cena>") + "<cena>".Length;
                        last = line.IndexOf("</");
                        float cena = float.Parse(line.Substring(first, last - first));
                        data.AddKatalog(new Katalog(IdKatalogu, tytul, autor, rok, cena));
                        katalogi++;
                    }

                    if (line.Contains("<idOpis>"))
                    {
                        first = line.IndexOf("<idOpis>") + "<idOpis>".Length;
                        last = line.IndexOf("</");
                        int IdOpis = Int32.Parse(line.Substring(first, last - first));
                        line = reader.ReadLine();
                        first = line.IndexOf("<katalog>") + "<katalog>".Length;
                        last = line.IndexOf("</");
                        int katalog = Int32.Parse(line.Substring(first, last - first)) - wykazy;
                        line = reader.ReadLine();
                        first = line.IndexOf("<ilosc>") + "<ilosc>".Length;
                        last = line.IndexOf("</");
                        int ilosc = Int32.Parse(line.Substring(first, last - first));
                        data.AddOpisStanu(new OpisStanu(IdOpis, data.GetKatalog(katalog), ilosc));
                        opisy++;
                    }

                    if (line.Contains("<idZdarzenia>"))
                    {
                        first = line.IndexOf("<idZdarzenia>") + "<idZdarzenia>".Length;
                        last = line.IndexOf("</");
                        int Idzdarzenie = Int32.Parse(line.Substring(first, last - first));
                        line = reader.ReadLine();
                        first = line.IndexOf("<opis_stanu>") + "<opis_stanu>".Length;
                        last = line.IndexOf("</");
                        int opis = Int32.Parse(line.Substring(first, last - first)) - (wykazy + katalogi);
                        line = reader.ReadLine();
                        first = line.IndexOf("<wykaz>") + "<wykaz>".Length;
                        last = line.IndexOf("</");
                        int wykaz = Int32.Parse(line.Substring(first, last - first)) - 1;
                        line = reader.ReadLine();
                        first = line.IndexOf("<data_zakupu>") + "<data_zakupu>".Length;
                        last = line.IndexOf("</");
                        DateTimeOffset date = DateTimeOffset.Parse(line.Substring(first, last - first));
                        line = reader.ReadLine();
                        first = line.IndexOf("<ilosc_zakupionych>") + "<ilosc_zakupionych>".Length;
                        last = line.IndexOf("</");
                        int ilosc_zakup = Int32.Parse(line.Substring(first, last - first));
                        line = reader.ReadLine();
                        first = line.IndexOf("<cena_calkowita>") + "<cena_calkowita>".Length;
                        last = line.IndexOf("</");
                        int cena_calk = Int32.Parse(line.Substring(first, last - first));
                        data.AddZdarzenie(new Sprzedaz(Idzdarzenie, data.GetOpisStanu(opis), data.GetWykaz(wykaz), date, ilosc_zakup));
                    }
                    line = reader.ReadLine();
                }
                return data;
            }
        }

        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            values2.Add(new XElement(name, val));
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType != typeof(String))
            {
                bool fristTime;
                m_idGenerator.GetId(obj, out fristTime);

                if (fristTime)
                {
                    ISerializable _data2 = (ISerializable)obj;
                    SerializationInfo _info2 = new SerializationInfo(obj.GetType(), new FormatterConverter());
                    StreamingContext _context2 = new StreamingContext(StreamingContextStates.File);
                    _data2.GetObjectData(_info2, _context2);

                    foreach (SerializationEntry _item in _info2)
                    {
                        this.WriteMember(_item.Name, _item.Value);
                    }
                    values.Add(new XElement(name, values2));
                    values2.Clear();
                }
                else
                {
                    values2.Add(new XElement(name, m_idGenerator.GetId(obj, out fristTime)));
                }

            }
            else
            {
                values2.Add(new XElement(name, obj));
            }   
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            values2.Add(new XElement(name, val));
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            values2.Add(new XElement(name, obj));
        }
    }
}

