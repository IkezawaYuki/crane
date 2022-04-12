using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crane
{
    class Apple
    {
        public static void Main()
        {
            double a = 3;
            double b = 4;
            Console.WriteLine($"{a}{b}", a, b);
            Console.WriteLine($"{CalculateHypotenuse(a, b)}");
            double CalculateHypotenuse(double leg1, double leg2) => Math.Sqrt(leg1 * leg1 + leg2 * leg2);

            var xs = new int[] { 1, 2, 7, 9 };
            var ys = new int[] { 7, 9, 12 };
            Console.WriteLine($"{string.Join("/", xs)}");

        }

        static void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                //log.Add(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                //log.Add(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                }
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }    
            }
        }

        public static void TraverseTree(string root)
        {
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                foreach(string file in files)
                {
                    try
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                }
            }
        }
    }
    
    //class Apple
    //{
    //    public static void Main(string[] arg)
    //    {
    //        Coffee cup = PourCoffee();
    //        var eggs = FryEgg(2);
    //        var bacon = FryBacon(3);
    //        var toastTask = MakeToastWithButterAndJamAsync(2);

    //        var breakfastTasks = new List<Task> { eggs, bacon, toastTask };

    //        while (breakfastTasks.Count > 0)
    //        {
    //            Task finishedTask = Task.WhenAny(breakfastTasks);
    //            if (finishedTask == eggs)
    //            {
    //                Console.WriteLine("eggs are ready");
    //            }
    //            else if (finishedTask == bacon)
    //            {
    //                Console.WriteLine("bacon is ready");
    //            }
    //            else if (finishedTask == toastTask)
    //            {
    //                Console.WriteLine("toast is ready");
    //            }
    //            breakfastTasks.Remove(finishedTask);
    //        }    

    //    }

    //    private static Coffee PourCoffee()
    //    {
    //        return new Coffee();
    //    }

    //    private static async Task<Egg> FryEgg(int howMany)
    //    {
    //        await Task.Delay(3000);
    //        Console.WriteLine("cooking the eggs ...");
    //        return new Egg();
    //    }

    //    private static async Task<Bacon> FryBacon(int slices)
    //    {
    //        await Task.Delay(4000);
    //        return new Bacon();
    //    }

    //    static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    //    {
    //        var toast = await ToastBreadAsync(number);
    //        ApplyButter(toast);
    //        ApplyJam(toast);
    //        return toast;
    //    }

    //    private static void ApplyJam(Toast toast) =>
    //        Console.WriteLine("Putting jam on the toast");

    //    private static void ApplyButter(Toast toast) =>
    //        Console.WriteLine("Putting butter on the toast");

    //    private static async Task<Toast> ToastBreadAsync(int slices)
    //    {
    //        await Task.Delay(3000);
    //        return new Toast();
    //    }
    //}

    class Coffee { }
    class Egg { }
    class Bacon { }
    class Toast { }
}
