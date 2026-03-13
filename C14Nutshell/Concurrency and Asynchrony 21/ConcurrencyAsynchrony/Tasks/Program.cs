namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hot Start
            Task.Run(() => Console.WriteLine("Hot start. Task is running"));

            // Cold Start
            var task = new Task(() => Console.WriteLine("Cold start. Task is running"));
            task.Start();

            // Blocks the main thread and wait for task completion: equivalent of Thread.Join
            task.Wait();

            // Long Running Task
            var longRunningTask = new Task(() => 
            {
                Console.WriteLine("Long running task started.");
                Thread.Sleep(5000); // Simulate work
                Console.WriteLine("Long running task completed.");
            }, TaskCreationOptions.LongRunning);
            longRunningTask.Start();

            // Returning Values from Task
            Task<bool> tsk = Task.Run<bool>(() => { Thread.Sleep(10000); return true; });
            bool boolResult = tsk.Result; // this blocks main thread execution till tsk thread is completed
            Console.WriteLine("Main Thread is blocked until tsk execution is completed");

            // Start a Task that throws a NullReferenceException:
            task = Task.Run(() => { throw null; });
            try
            {
                task.Wait();
            }
            catch (AggregateException aex)
            {
                if (aex.InnerException is NullReferenceException)
                    Console.WriteLine("Null!");
                else
                    throw;
            }
        }
    }
}
