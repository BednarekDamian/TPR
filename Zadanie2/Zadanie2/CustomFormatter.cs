using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Zadanie2
{
    public  class CustomFormatter 
    {
        
        public CustomFormatter()
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
            TextWriter writer = new StreamWriter("../../../wykaz.txt");
            foreach(Wykaz wykaz in wykazy)
            {
                writer.WriteLine(wykaz.ToString());
            }
           
            writer.Close();
        }
        public void writeKatalog(IEnumerable<Katalog> katalogi)
        {
            TextWriter writer = new StreamWriter("../../../katalog.txt");
            foreach (Katalog katalog in katalogi)
            {
                writer.WriteLine(katalog.ToString());
            }

            writer.Close();
        }
        public void writeOpisStanu(IEnumerable<OpisStanu> opisyStanu)
        {
            TextWriter writer = new StreamWriter("../../../opisStanu.txt");
            foreach (OpisStanu opis in opisyStanu)
            {
                writer.WriteLine(opis.ToString());
            }

            writer.Close();
        }
        public void writeZdarzenie(IEnumerable<Zdarzenie> zdarzenie)
        {
            TextWriter writer = new StreamWriter("../../../zdarzenia.txt");
            foreach (Zdarzenie zdarzenie1 in zdarzenie)
            {
                writer.WriteLine(zdarzenie1.ToString());
            }

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
            using (StreamReader file = new StreamReader("../../../wykaz.txt"))
            {
                string line;
                int lineNum = 0;
                while ((line = file.ReadLine()) != null)
                {                 
                   string[] elements = line.Split('_');
                   data.AddWykaz(new Wykaz(Int32.Parse(elements[0]), elements[1]));                   
                   lineNum++;

                }
                file.Close();
            }
        }
        public void readKatalog(DataRepository data)
        {
            using (StreamReader file = new StreamReader("../../../katalog.txt"))
            {
                string line;
                int lineNum = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string[] elements = line.Split('_');
                    data.AddKatalog(new Katalog(Int32.Parse(elements[0]),elements[1],elements[2],elements[3],float.Parse(elements[4])));
                    lineNum++;

                }
                file.Close();
            }
        }
        public void readOpisStanu(DataRepository data)
        {
            using (StreamReader file = new StreamReader("../../../opisStanu.txt"))
            {
                string line;
                int lineNum = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string[] elements = line.Split('_');
                    data.AddOpisStanu(new OpisStanu(Int32.Parse(elements[0]), new Katalog(Int32.Parse(elements[1]), elements[2], elements[3], elements[4], float.Parse(elements[5])), Int32.Parse(elements[6])));
                    lineNum++;

                }
                file.Close();
            }
        }
        public void readZdarzenie(DataRepository data)
        {
            using (StreamReader file = new StreamReader("../../../zdarzenia.txt"))
            {
                string line;
                int lineNum = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string[] elements = line.Split('_');
                    data.AddZdarzenie(new Sprzedaz(Int32.Parse(elements[0]), new OpisStanu(Int32.Parse(elements[1]), new Katalog(Int32.Parse(elements[2]), elements[3], elements[4], elements[5], float.Parse(elements[6])), Int32.Parse(elements[7])), new Wykaz(Int32.Parse(elements[8]), elements[9]), DateTimeOffset.Parse(elements[10]), Int32.Parse(elements[11])));
                    lineNum++;

                }
                file.Close();
            }
        }
        #endregion
    }
}

