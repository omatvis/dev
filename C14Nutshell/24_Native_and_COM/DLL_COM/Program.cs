using System.Runtime.InteropServices;

namespace DLL_COM
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {            
            var task = ShowMessageBoxAsync("Please pay attention!", "Attention", 0);
            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration {i}");
            }
            Console.WriteLine(task.Result);
        }

        [DllImport("user32.dll")]
        static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        static Task<int> ShowMessageBoxAsync(string text, string caption, uint type)
        {
            return Task.Run(() => MessageBox(IntPtr.Zero, text, caption, type));
        }
    }
}
