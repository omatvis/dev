namespace StopWatch;

public class StopWatch
{
    private DateTime _startDateTime;
    private DateTime _stopDateTime;
    private bool counting = false;

    public TimeSpan Duration
    {
        get
        {
            if (counting)
            {
                return TimeSpan.FromSeconds(0);
            }
            return _stopDateTime - _startDateTime;
        }
    }

    public void Start()
    {
        if (counting)
        {
            throw new InvalidOperationException(
                "Cannot invoke Start() again, StopWatch counting the duration."
            );
        }
        _startDateTime = DateTime.Now;
        counting = true;
    }

    public void Stop()
    {
        if (!counting)
        {
            throw new InvalidOperationException(
                "Cannot invoke Stop(), StopWatch is not counting the duration."
            );
        }
        _stopDateTime = DateTime.Now;
        counting = false;
    }
}
