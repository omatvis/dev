using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions; // add this at file top

namespace HttpClientSample
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            Stopwatch sw = new();
            sw.Start();

            Task<string?> htmlTask = GetSiteContent(@"http://linqpad.net");
            Console.WriteLine($"Time taken 2: {sw.ElapsedMilliseconds} ms");
            string? html = await htmlTask;
            Console.WriteLine(html ?? "[no content]");
            sw.Stop();
            Console.WriteLine($"Total Time taken: {sw.ElapsedMilliseconds} ms");

            string? contentFromTwoSites = await GetSiteContentFromTwoSites(@"http://linqpad.net", @"http://www.microsoft.com");
            Console.WriteLine(contentFromTwoSites ?? "[one or both requests failed]");

            var cancelRequest = GetAsyncCancelledRequest(@"http://linqpad.net");
            Console.WriteLine(await cancelRequest);

            var responseMessage = await GetAsyncResponseMessage(@"http://google.com");
            if (responseMessage != null)
            {
                string? content = await GetAsyncString(responseMessage);
                Console.WriteLine(content ?? "[no content]");
            }
        }

        async static Task<string?> GetSiteContent(string url)
        {
            using var client = new HttpClient();
            Console.WriteLine("Before getting string content");
            try
            {
                string content = await client.GetStringAsync(url);
                Console.WriteLine("After getting string content");
                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                return null;
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request timed out or was canceled.");
                return null;
            }
        }

        async static Task<string?> GetSiteContentFromTwoSites(string url1, string url2)
        {
            using var client = new HttpClient();
            Console.WriteLine("Before getting string content from two sites");

            Task<string> t1 = client.GetStringAsync(url1);
            Task<string> t2 = client.GetStringAsync(url2);

            try
            {
                // Await both; Task.WhenAll will throw if any task faults/cancels
                string[] results = await Task.WhenAll(t1, t2);
                Console.WriteLine("After getting string content from two sites");
                return results[0] + string.Concat(Enumerable.Repeat("\r\n", 10)) + results[1];
            }
            catch (Exception ex)
            {
                // Handle partial success: inspect task statuses and use completed results
                Console.WriteLine($"One or more requests failed: {ex.Message}");
                string? r1 = t1.IsCompletedSuccessfully ? t1.Result : null;
                string? r2 = t2.IsCompletedSuccessfully ? t2.Result : null;

                if (r1 == null && r2 == null)
                    return null;

                return (r1 ?? string.Empty) + string.Concat(Enumerable.Repeat("\r\n", 10)) + (r2 ?? string.Empty);
            }
        }

        async static Task<HttpRequestMessage?> GetAsyncCancelledRequest(string url)
        {
            using var client = new HttpClient();
            var cts = new CancellationTokenSource();
            cts.CancelAfter(1); // Cancel after 1 millisecond. Testing cancellation of the request by timeout.
            try
            {
                HttpResponseMessage response = await client.GetAsync(url, cts.Token);
                response.EnsureSuccessStatusCode();
                return response.RequestMessage; // may be null in rare cases
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Request was canceled.");
                return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                return null;
            }
        }

        async static Task<HttpResponseMessage?> GetAsyncResponseMessage(string url)
        {
            try
            { 
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                return response;                
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                return null;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                return null;
            }
        }

        async static Task<string> GetAsyncString(HttpResponseMessage responseObj)
        {
            ArgumentNullException.ThrowIfNull(responseObj, nameof(responseObj));
            responseObj.EnsureSuccessStatusCode();
            return await responseObj.Content.ReadAsStringAsync();
        }
    }
}
