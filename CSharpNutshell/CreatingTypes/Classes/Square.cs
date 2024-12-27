class Square : Rectangle
{
    readonly bool isBlack;

    public bool IsBlack
    {
        get => isBlack;
        init => isBlack = true;
    }

    public Square(float side)
        : base(side, side) { }
}
