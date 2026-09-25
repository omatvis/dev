using System.Net;

namespace AddressesAndPorts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress a1 = new(new byte[] { 127, 0, 0, 1 });
            IPAddress a2 = IPAddress.Parse("127.0.0.1");
            Console.WriteLine(a1.Equals(a2));
            Console.WriteLine($"Address Family: {a1.AddressFamily}");
            IPAddress a3 = IPAddress.Parse("[3EA0:FFFF:198A:E4A3:4FF2:54fA:41BC:8D31]");
            Console.WriteLine(a3.AddressFamily);   // InterNetworkV6
            IPEndPoint ep1 = new(a1, 11000);
            Console.WriteLine(ep1);

            Uri info = new Uri("http://www.domain.com:80/info/");
            Uri page = new Uri("http://www.domain.com/info/page.html");
            Console.WriteLine(info.Host);     // www.domain.com
            Console.WriteLine(info.Port);     // 80
            Console.WriteLine(page.Port);     // 80  (Uri knows the default HTTP port)
            Console.WriteLine(info.IsBaseOf(page));         // True
            Uri relative = info.MakeRelativeUri(page);
            Console.WriteLine(relative.IsAbsoluteUri);       // False
            Console.WriteLine(relative.ToString());          // page.html
        }
    }
}
