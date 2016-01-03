namespace TeamLichTestAutomation.Utilities
{
    using System;
    using System.Text;

    public class RandomStringGenerator
    {
        private Random generator;

        public RandomStringGenerator()
        {
            this.generator = new Random();
        }

        public string GetString(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int randomSeed = generator.Next(97, 123);
                char currentChar = (char)randomSeed;
                stringBuilder.Append(currentChar);
            }

            return stringBuilder.ToString();
        }
    }
}