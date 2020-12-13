using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Zadanie2
{
   public class XmlSerialize
    {
        public XmlSerialize()
        {
        }
        #region WRITE
        public void writeAll(DataRepository data)
        {

            writeWykaz(data.GetAllWykaz());
            writeKatalog(data.GetAllKatalog());
            writeOpisStanu(data.GetAllOpisStanu());
            writeZdarzenie(data.GetAllZdarzenie());
        }
        public void writeWykaz(IEnumerable<Wykaz> wykazy)
        {
            TextWriter writer = new StreamWriter("../../../wykaz.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Wykaz>));
            serializer.Serialize(writer, wykazy);
            writer.Close();
        }

        public void writeKatalog(IEnumerable<Katalog> katalogi)
        {
            TextWriter writer = new StreamWriter("../../../katalog.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Katalog>));
            serializer.Serialize(writer, katalogi);
            writer.Close();
        }

        public void writeOpisStanu(IEnumerable<OpisStanu> opisyStanu)
        {
            TextWriter writer = new StreamWriter("../../../opisStanu.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<OpisStanu>));
            serializer.Serialize(writer, opisyStanu);
            writer.Close();
        }

        public void writeZdarzenie(IEnumerable<Zdarzenie> zdarzenie)
        {
            TextWriter writer = new StreamWriter("../../../zdarzenia.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Zdarzenie>));
            serializer.Serialize(writer, zdarzenie);
            writer.Close();
        }
        #endregion
        #region READ
        public DataRepository readALL()
        {
            DataRepository import_data = new DataRepository();
            readWykaz(import_data);
            readKatalog(import_data);
            readOpisStanu(import_data);
            readZdarzenie(import_data);
            return import_data;
        }
        public void readWykaz(DataRepository data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Wykaz>));
            FileStream fs = new FileStream("../../../wykaz.xml", FileMode.Open);
            List<Wykaz> import_wykaz = (List<Wykaz>)serializer.Deserialize(fs);
            foreach (Wykaz wykaz in import_wykaz)
            {
                data.AddWykaz(wykaz);

            }
            fs.Close();
        }
        public void readKatalog(DataRepository data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Katalog>));
            FileStream fs = new FileStream("../../../katalog.xml", FileMode.Open);
            List<Katalog> import_katalog = (List<Katalog>)serializer.Deserialize(fs);
            foreach (Katalog katalog in import_katalog)
            {
                data.AddKatalog(katalog);

            }
        }
        public void readOpisStanu(DataRepository data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<OpisStanu>));
            FileStream fs = new FileStream("../../../opisStanu.xml", FileMode.Open);
            List<OpisStanu> import_opis = (List<OpisStanu>)serializer.Deserialize(fs);
            foreach (OpisStanu opis in import_opis)
            {
                data.AddOpisStanu(opis);

            }
        }
        public void readZdarzenie(DataRepository data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Zdarzenie>));
            FileStream fs = new FileStream("../../../zdarzenia.xml", FileMode.Open);
            ObservableCollection<Zdarzenie> import_zdarzenie = (ObservableCollection<Zdarzenie>)serializer.Deserialize(fs);
            foreach (Zdarzenie zdarzenie in import_zdarzenie)
            {
                data.AddZdarzenie(zdarzenie);

            }
        }
        #endregion
    }
}
