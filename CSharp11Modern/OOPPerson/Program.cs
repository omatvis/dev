namespace OOPPerson;

class Program
{
    static void Main(string[] args)
    {
        Employee john = new()
        {
            Name = "John Jones",
            DateOfBirth = new DateTime(1990, 7, 28)
        };
        john.WriteToConsole();

        john.EmployeeCode = "JJ001";
        john.HireDate = new DateTime(2014, 11, 23);
        Console.WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

        Console.WriteLine(john.ToString());
    }

}
