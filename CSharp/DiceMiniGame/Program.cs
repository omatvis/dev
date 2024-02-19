using System.Formats.Asn1;

namespace DiceMiniGame;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Random random = new Random();

        Console.WriteLine("Would you like to play? (Y/N)");
        if (ShouldPlay())
        {
            PlayGame();
        }

        void PlayGame()
        {
            var play = true;

            while (play)
            {
                var target = RollTarget();
                var roll = RollUser();

                Console.WriteLine($"Roll a number greater than {target} to win!");
                Console.WriteLine($"You rolled a {roll}");
                Console.WriteLine(WinOrLose(roll, target));
                Console.WriteLine("\nPlay again? (Y/N)");

                play = ShouldPlay();
            }
        }

        bool ShouldPlay()
        {
            string? answer = Console.ReadLine();
            return (answer is not null) ? answer.ToLower().Equals("y"): false;
        }

        string WinOrLose(int roll, int target )
        {
            return (roll > target) ? "You win!": "You lose!";
        }

        int RollTarget()
        {
            return new Random().Next(1, 6);
        }

        int RollUser()
        {
            return new Random().Next(1, 7);
        }
    }
}
