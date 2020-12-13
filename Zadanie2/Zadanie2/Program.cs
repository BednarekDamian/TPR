using System;
using System.IO;
using System.Runtime.Serialization;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            int mode;
            Console.WriteLine("Choose:");
            Console.WriteLine("[1]Xml");
            Console.WriteLine("[2]Custom");
            Console.WriteLine("[other]Exit");
            mode = Console.Read()- 48;
            Console.WriteLine(mode);
            DataFill filerdata = new DataFill();
            DataRepository dataRepository = new DataRepository();
            filerdata.fill(dataRepository);
       
                switch (mode)
                {
                    case 1:
                        Console.WriteLine("XML");
                        XmlSerialize write_to_XML = new XmlSerialize();
                        write_to_XML.writeAll(dataRepository);
                        Console.WriteLine("done");
                        DataRepository data_from_XML = write_to_XML.readALL();
                        Console.WriteLine("done");
                        break;
                    case 2:
                        Console.WriteLine("CUSTOM");
                        CustomFormatter formatter = new CustomFormatter();
                        using (Stream stream = new FileStream("../../../custom.xml", FileMode.Create))
                        {

                            formatter.Serialize(stream, dataRepository);
                        }
                        Console.WriteLine("done");
                        using (Stream reader = new FileStream("../../../custom.xml", FileMode.Open))
                        {

                            DataRepository data_from_custom = (DataRepository)formatter.Deserialize(reader);
                            Console.WriteLine("done");
                        }
                        break;
                    default:
                        Console.WriteLine("exit");
                        return;
                }
            }
  
        }
    }

