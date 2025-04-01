using System.Net.NetworkInformation;

namespace BuildEmployeeEmail;

class Program
{
    static void Main(string[] args)
    {
        string[,] corporate =
        {
            { "Robert", "Bavin" },
            { "Simon", "Bright" },
            { "Kim", "Sinclair" },
            { "Aashrita", "Kamath" },
            { "Sarah", "Delucchi" },
            { "Sinan", "Ali" }
        };

        string[,] external =
        {
            { "Vinnie", "Ashton" },
            { "Cody", "Dysart" },
            { "Shay", "Lawrence" },
            { "Daren", "Valdes" }
        };

        for (int i = 0; i < corporate.GetLength(0); i++)
        {
            DisplayEmailAddress(
                firstName: corporate[i, 0],
                lastName: corporate[i, 1],
                domain: "contoso.com"
            );
        }

        for (int i = 0; i < external.GetLength(0); i++)
        {
            DisplayEmailAddress(
                firstName: external[i, 0],
                lastName: external[i, 1]
            );
        }

        static void DisplayEmailAddress(
            string firstName,
            string lastName,
            string domain = "hayworth.com"
        ) {
            string userName = String.Concat(firstName.Substring(0, 2).ToLower(), lastName.ToLower());
            Console.WriteLine($"{userName}@{domain}");
        }
    }
}
