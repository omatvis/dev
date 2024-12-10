
/// <summary>
/// Upload a video to a cloud storage
/// </summary>
/// <param name="video"></param>
public class UploadVideoActivity(string video) : IActivity
{
    private readonly string _video = video;

    public void Execute()
    {
        Console.WriteLine("Uploading a video to a cloud storage...");
    }
}
