namespace Convertor;

public class UnitConverter(int unitRatio)
{
    readonly int ratio = unitRatio; // Field

    public int Convert(int unit) // Method
    {
        return unit * ratio;
    }
}
