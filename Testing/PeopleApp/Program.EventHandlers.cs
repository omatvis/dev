using Packt.Shared;

namespace PeopleApp;

partial class Program
{
    // a method to handle the Shout event received by the harry object
    static void Harry_Shout(object? sender, EventArgs e)
    {
        if (sender is null)
            return;
        if (sender is not Person p)
            return;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel1}.");
    }

    // another method to handle the Shout event received by the harry object
    static void Harry_Shout2(object? sender, EventArgs e)
    {
        if (sender is null)
            return;
        if (sender is not Person p)
            return;
        WriteLine($"Stop it!");
    }
}
