using System;
using System.Threading.Tasks;

namespace PracticeLib;

public class Bacon { }
public class Coffee { }
public class Egg { }
public class Juice { }
public class Toast { }

public static class AsyncBreakfast
{

    public static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    {
        var toast = await ToastBreadAsync(number);
        ApplyButter(toast);
        ApplyJam(toast);

        return toast;
    }

    public static Juice PourOJ()
    {
        Console.WriteLine($"{DateTime.Now}: Pouring orange juice");
        return new Juice();
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine($"{DateTime.Now}: Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine($"{DateTime.Now}: Putting butter on the toast");

    public static async Task<Toast> ToastBreadAsync(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine($"{DateTime.Now}: Putting a slice of bread in the toaster");
        }
        Console.WriteLine($"{DateTime.Now}: Start toasting...");
        await Task.Delay(3000);
        Console.WriteLine($"{DateTime.Now}: Remove toast from toaster");

        return new Toast();
    }

    public static async Task<Bacon> FryBaconAsync(int slices)
    {
        Console.WriteLine($"{DateTime.Now}: putting {slices} slices of bacon in the pan");
        Console.WriteLine($"{DateTime.Now}: cooking first side of bacon...");
        await Task.Delay(3000);
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine($"{DateTime.Now}: flipping a slice of bacon");
        }
        Console.WriteLine($"{DateTime.Now}: cooking the second side of bacon...");
        await Task.Delay(3000);
        Console.WriteLine($"{DateTime.Now}: Put bacon on plate");

        return new Bacon();
    }

    public static async Task<Egg> FryEggsAsync(int howMany)
    {
        Console.WriteLine($"{DateTime.Now}: Warming the egg pan...");
        await Task.Delay(3000);
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine($"{DateTime.Now}: cooking the eggs ...");
        await Task.Delay(3000);
        Console.WriteLine($"{DateTime.Now}: Put eggs on plate");

        return new Egg();
    }

    public static Coffee PourCoffee()
    {
        Console.WriteLine($"{DateTime.Now}: Pouring coffee");
        return new Coffee();
    }
    public static void LogCurrentDateTime()
    {
        Console.Write($"{DateTime.Now}");
    }
}

