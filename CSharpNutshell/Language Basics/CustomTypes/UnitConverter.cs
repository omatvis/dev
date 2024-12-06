namespace CustomTypes
{
    public class UnitConverter(int unitRatio)
    {
        private int _ratio = unitRatio;

        public int Convert(int unit)
        {
            return _ratio * unit;
        }
    }
}