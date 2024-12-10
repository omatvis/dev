
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
/// <summary>
/// Change the status of the video record in the database to “Processing”.
/// </summary>
/// <param name="video"></param>
public class VideoStatusActivity(string video) : IActivity
{
    private readonly string _video = video;

    public void Execute()
    {
        Console.WriteLine($"The status of the {video} in db is changed to \"Processing\"");
    }
}
