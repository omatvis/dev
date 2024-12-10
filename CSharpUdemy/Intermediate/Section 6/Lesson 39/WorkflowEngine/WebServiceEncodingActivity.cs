
/// <summary>
/// Upload a video to a cloud storage
/// </summary>
/// <param name="video"></param>
/// <summary>
/// Call a web service provided by a third-party video encoding service to tell them you have a
/// </summary>
/// <param name="video"></param>
public class WebServiceEncodingActivity(string video) : IActivity
{
    private readonly string video = video;

    public void Execute()
    {
        Console.WriteLine("Video is ReadOnlyMemory for recording...");
    }
}
