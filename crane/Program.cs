using System;
using System.Collections.Generic;
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
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggs, bacon, toastTask };

            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = Task.WhenAny(breakfastTasks);
                if (finishedTask == eggs)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == bacon)
                {

                }
                else if (finishedTask == toastTask)
                {

                }
                breakfastTasks.Remove(finishedTask);
            }    

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

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            await Task.Delay(3000);
            return new Toast();
        }
    }

    class Coffee { }
    class Egg { }
    class Bacon { }
    class Toast { }
}
