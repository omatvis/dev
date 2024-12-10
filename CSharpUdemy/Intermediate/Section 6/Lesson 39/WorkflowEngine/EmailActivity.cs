
/// <summary>
/// Upload a video to a cloud storage
/// </summary>
/// <param name="video"></param>

/// <summary>
/// Call a web service provided by a third-party video encoding service to tell them you have a
/// </summary>
/// <param name="video"></param>
/// <summary>
/// Send an email to the owner of the video notifying them that the video started processing.
/// </summary>
/// <param name="message"></param>
public class EmailActivity(string message) : IActivity
{
    private readonly string _message = message;

    public void Execute()
    {
        Console.WriteLine($"Sending a message to the owner of a video {_message}");
    }
}
