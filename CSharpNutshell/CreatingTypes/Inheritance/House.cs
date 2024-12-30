public class House : Asset // inherits from Asset
{
    public decimal Mortgage;
    public override decimal Liability => base.Liability + Mortgage;

    public sealed override House Clone() => new() { Name = Name, Mortgage = Mortgage };
}
