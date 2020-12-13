﻿using System;
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

          

            CustomFormatter formatter = new CustomFormatter();
            using (Stream stream = new FileStream("../../../custom.xml", FileMode.Create))
            {
               
                formatter.Serialize(stream, dataRepository);
            }
            Console.WriteLine("done");
            using (Stream reader = new FileStream("../../../custom.xml",FileMode.Open))
            {
             
              DataRepository data_from_custom = (DataRepository)formatter.Deserialize(reader);
                Console.WriteLine("done");
            }
           
        }
    }
}
