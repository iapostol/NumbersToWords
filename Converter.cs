//745.00  => seven hundred and forty five

using System;
using System.Collections.Generic;

namespace NumberToWords
{
    public class Converter
    {
        private static Dictionary<long, string> wordsMap;

        private static IList<OrderOfMagnitude> magnitudes;

        public Converter()
        {
            CreateWordsMap();
            CreateMagnitudes();
        }

        private void CreateMagnitudes()
        {
            magnitudes = new List<OrderOfMagnitude>
            {
                new OrderOfMagnitude { Power = 18, NameFormat = "{0} quintillion"},
                new OrderOfMagnitude { Power = 15, NameFormat = "{0} quadrillion"},
                new OrderOfMagnitude { Power = 12, NameFormat = "{0} trillion"},
                new OrderOfMagnitude { Power = 9,  NameFormat = "{0} billion"},
                new OrderOfMagnitude { Power = 6,  NameFormat = "{0} million"},
                new OrderOfMagnitude { Power = 3,  NameFormat = "{0} thousand"},
                new OrderOfMagnitude { Power = 2,  NameFormat = "{0} hundred"}
            };
        }

        private static void CreateWordsMap()
        {
            wordsMap = new Dictionary<long, string>
            {
                {1,"one"},
                {2,"two"},
                {3,"three"},
                {4,"four"},
                {5,"five"},
                {6,"six"},
                {7,"seven"},
                {8,"eight"},
                {9,"nine"},
                {10,"ten"},
                {11,"eleven"},
                {12,"twelve"},
                {13,"thirteen"},
                {14,"fourteen"},
                {15,"fifteen"},
                {16,"sixteen"},
                {17,"seventeen"},
                {18,"eighteen"},
                {19,"nineteen"},
                {20,"twenty"},
                {30,"thirty"},
                {40,"forty"},
                {50,"fifty"},
                {60,"sixty"},
                {70,"seventy"},
                {80,"eighty"},
                {90,"ninety"}
            };
        }

        public static string WordFor(long number)
        {
            if (number == 0)
                return "zero";

            if (wordsMap.ContainsKey(number))
                return wordsMap[number];

            foreach (var magnitude in magnitudes)
            {
                if (number >= TenToPower(magnitude.Power))
                    return MagnitudeWordFor(number, magnitude);
            }

            return TensWordFor(number);
        }

        private static string MagnitudeWordFor(long number, OrderOfMagnitude magnitude)
        {
            long tenToPower = TenToPower(magnitude.Power);

            var quotient = number / tenToPower;

            var result = string.Format(magnitude.NameFormat, WordFor(quotient));

            var remainder = number % tenToPower;

            if (remainder > 0)
                return string.Format("{0} {1}", result, WordFor(remainder));

            return result;
        }

        private static long TenToPower(int power)
        {
            return Convert.ToInt64(Math.Pow(10, power));
        }

        private static string TensWordFor(long number)
        {
            var remainder = number % 10;
            var decade = number - remainder;

            if (remainder > 0)
                return string.Format("{0}-{1}", wordsMap[decade], wordsMap[remainder]);

            return wordsMap[decade];
        }
    }

    internal class OrderOfMagnitude
    {
        public int Power { get; set; }
        public string NameFormat { get; set; }
    }
}