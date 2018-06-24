using System;

namespace AddressbookWebTests
{
    public class DataGenerator
    {
        private Random random;
        private ApplicationManager manager;

        public DataGenerator(ApplicationManager manager)
        {
            this.manager = manager;
            random = new Random();
        }

        public Random Random { get => random; set => random = value; }

        public int GetRandomIntBetween(int from, int to)
        {
            return Random.Next(from, to);
        }
    }
}