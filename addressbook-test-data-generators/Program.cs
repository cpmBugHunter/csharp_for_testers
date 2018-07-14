using AddressbookWebTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);            
            string format = args[2];
            StreamWriter sw = new StreamWriter($"{type}s.{format}");

            if (type == "group")
            {
                List<GroupData> groups = GenerateGroups(count);
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, sw);
                }
                else if (format == "xml")
                {
                    WriteListToXmlFile(groups, sw);
                }
                else if (format == "json")
                {
                    WriteListToJsonFile(groups, sw);
                }
                else
                {
                    Console.Out.WriteLine($"Unrecognized format: {format}");
                }
            }
            else if (type == "contact")
            {
                List<ContactData> contacts = GenerateContacts(count);
                if (format == "xml")
                {
                    WriteListToXmlFile(contacts, sw);
                }
                else if (format == "json")
                {
                    WriteListToJsonFile(contacts, sw);
                }
                else
                {
                    Console.Out.WriteLine($"Unrecognized format: {format}");
                }
            }
            else
            {
                Console.Out.WriteLine($"Unrecognized type: {type}");
            }
            
            sw.Close();
        }

        private static List<ContactData> GenerateContacts(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            int numbers;

            for (int i = 0; i < count; i++)
            {
                numbers = DataGenerator.GetRandomIntBetween(0, 100);
                contacts.Add(new ContactData()
                {
                    FirstName = DataGenerator.GenerateRandomString(10),
                    LastName = DataGenerator.GenerateRandomString(15),
                    Address = $"{DataGenerator.GenerateRandomString(10)}," +
                    $"{DataGenerator.GenerateRandomString(15)}," +
                    $"b {numbers}, ap.{DataGenerator.GetRandomIntBetween(1, 100)}",
                    HomePhone = $"{numbers}{DataGenerator.GetRandomIntBetween(1, 100)}",
                    WorkPhone = $"{numbers}-{DataGenerator.GetRandomIntBetween(1, 500)}",
                    MobilePhone = $"{numbers}-{numbers}-{DataGenerator.GetRandomIntBetween(1, 1000)}",
                    EMail = DataGenerator.GenerateRandomString(15),
                    EMail2 = DataGenerator.GenerateRandomString(15),
                    EMail3 = DataGenerator.GenerateRandomString(15)
                });
            }
            return contacts;
        }

        private static List<GroupData> GenerateGroups(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(DataGenerator.GenerateRandomString(10))
                {
                    Header = DataGenerator.GenerateRandomString(100),
                    Footer = DataGenerator.GenerateRandomString(100)
                });
            }

            return groups;
        }
                
        static void WriteListToJsonFile<T>(List<T> list, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteListToXmlFile<T>(List<T> list, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<T>)).Serialize(writer, list);
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteLine($"{group.Name},{group.Header},{group.Footer}");
            }
        }
    }
}
