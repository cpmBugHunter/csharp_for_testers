using System;
using System.Text;

namespace AddressbookWebTests
{
    public class DataGenerator
    {
        private static Random random = new Random();

        public static int GetRandomIntBetween(int from, int to)
        {
            return random.Next(from, to);
        }

        public static string GenerateRandomString(int max)
        {
            StringBuilder sb = new StringBuilder();
            int l = GetRandomIntBetween(0, max);
            for (int i = 0; i < l; i++)
            {
                sb.Append(Convert.ToChar(32 + Convert.ToInt32(random.NextDouble() * 223)));
            }
            return sb.ToString();
        }
    }
}