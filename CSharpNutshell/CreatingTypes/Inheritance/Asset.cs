public class Asset
{
    public string Name = "";
    public virtual decimal Liability => 0; // Expression-bodied property

    public virtual Asset Clone() => new() { Name = Name };
}
