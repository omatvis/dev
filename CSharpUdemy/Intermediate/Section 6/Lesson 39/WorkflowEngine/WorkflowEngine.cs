public class WorkflowEngine
{
    public static void Run(Workflow workflow)
    {
        foreach (var activity in workflow)
        {
            activity.Execute();
        }
    }
}
