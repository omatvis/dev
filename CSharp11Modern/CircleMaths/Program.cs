namespace CircleMaths;

class Program
{
    static void Main(string[] args)
    {
        string[] students = ["Jenna", "Ayesha", "Carlos", "Viktor"];

        DisplayStudents(students);
        DisplayStudents(["Robert", "Vanya"]);

        static void DisplayStudents(string[] students)
        {
            foreach (string student in students)
            {
                Console.Write($"{student}, ");
            }
            Console.WriteLine();
        }

        PrintCircleArea(12);

        static void PrintCircleArea(int radius)
        {
            double pi = 3.14159;
            double area = pi * (radius * radius);
            Console.WriteLine($"Area = {area}");
        }
    }
}
