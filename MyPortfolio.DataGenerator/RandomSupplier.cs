using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DataGenerator
{
    internal static class RandomSupplier
    {
        internal static string BuyOrSell()
        {
            Random random = new Random();
            var num = random.Next();
            if (num % 2 == 0)
            {
                return "Buy";
            }
            else
            {
                return "Sell";
            }
        }

        internal static int Quantity()
        {
            Random random = new Random();
            return random.Next(1, 150);
        }

        internal static decimal Price()
        {
            Random random = new Random();
            return (decimal)(random.Next(1000, 10000) / 100.00);
        }
    }
}
