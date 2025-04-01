namespace OOPPerson;

public class Employee : Person
{
    public string? EmployeeCode { get; set; }
    public DateTime HireDate { get; set; }

    public new void WriteToConsole()
    {
        Console.WriteLine(
            "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
            Name,
            DateOfBirth,
            HireDate
        );
    }

    public override string ToString() {
        return $"{Name} is a {base.ToString()}";
    }
}
