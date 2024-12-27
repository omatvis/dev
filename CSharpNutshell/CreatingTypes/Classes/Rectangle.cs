class Rectangle(float width, float height)
{
    public readonly float Width = width;
    public readonly float Height = height;

    public void Deconstruct(out float width, out float height)
    {
        width = Width;
        height = Height;
    }

    public virtual double Area()
    {
        return Width * Height;
    }
}
