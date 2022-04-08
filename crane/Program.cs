using System;
using System.Threading.Tasks;

namespace crane
{
    class Apple
    {
        public static void Main()
        {
            Coffee cup = PourCoffee();
            var eggs = FryEgg(2);
            var bacon = FryBacon(3);
        }

        private static Coffee PourCoffee()
        {
            return new Coffee();
        }

        private static async Task<Egg> FryEgg(int howMany)
        {
            await Task.Delay(3000);
            Console.WriteLine("cooking the eggs ...");
            return new Egg();
        }

        private static async Task<Bacon> FryBacon(int slices)
        {
            await Task.Delay(4000);
            return new Bacon();
        }
    }

    class Coffee { }
    class Egg { }
    class Bacon { }
}
