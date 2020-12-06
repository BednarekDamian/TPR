using System;
using System.IO;
using System.Runtime.Serialization;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataFill filerdata = new DataFill();
            DataRepository dataRepository = new DataRepository();
            filerdata.fill(dataRepository);
            XmlSerialize write_to_XML = new XmlSerialize();           
            write_to_XML.writeAll(dataRepository);

            DataRepository data_from_XML = write_to_XML.readALL();
            Console.WriteLine("done");

          

            CustomFormatter formater = new CustomFormatter();
            formater.writeAll(dataRepository);
            DataRepository import_custom= formater.readALL();
            Console.WriteLine("done");
        }
    }
}
