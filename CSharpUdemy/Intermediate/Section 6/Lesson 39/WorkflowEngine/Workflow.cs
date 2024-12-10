using System.Collections;

public class Workflow: IEnumerable<IActivity>
{
    private readonly IList<IActivity> _activities = [];

    public IEnumerator<IActivity> GetEnumerator()
    {
        return _activities.GetEnumerator();
    }

    public void RegisterActivity(IActivity activity)
    {
        _activities.Add(activity);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_activities).GetEnumerator();
    }
}
