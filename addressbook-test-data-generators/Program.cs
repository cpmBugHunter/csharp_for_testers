using AddressbookWebTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter sw = new StreamWriter(args[1]);
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(DataGenerator.GenerateRandomString(10))
                {
                    Header = DataGenerator.GenerateRandomString(100),
                    Footer = DataGenerator.GenerateRandomString(100)
                });                
            }
            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, sw); 
            }
            else if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, sw); 
            }
            sw.Close();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteLine($"{group.Name},{group.Header},{group.Footer}");
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); 
        }
    }
}
