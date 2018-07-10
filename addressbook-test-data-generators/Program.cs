using AddressbookWebTests;
using System;
using System.IO;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter sw = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                sw.WriteLine($"{DataGenerator.GenerateRandomString(10)}," +
                    $"{DataGenerator.GenerateRandomString(10)}," +
                    $"{DataGenerator.GenerateRandomString(10)}");
            }
            sw.Close();
        }
    }
}
