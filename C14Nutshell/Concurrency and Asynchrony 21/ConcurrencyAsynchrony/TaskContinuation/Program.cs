namespace TaskContinuation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // The new thread is runnung ib background mode 
            // So, if main thread ends up the thread is closed without waiting for the end of the execution
            // So, we should block main thread to wait for result
            Task<int> primeNumberTask = Task.Run(() =>
              Enumerable.Range(2, 3000000).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            var awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);
                Console.WriteLine("The thread is completed!");
            });
            await primeNumberTask;
        }
    }
}
