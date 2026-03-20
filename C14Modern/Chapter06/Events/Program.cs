namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pawn pawn = new()
            {   
                Colour = FigureColour.White,
                Position = new ChessPoint(ChessPoint.File.E, ChessPoint.Rank.Two),

            };
            pawn.Move += OnMove;
            pawn.MoveForward();

            Console.WriteLine("End of pawn movement!");
        }

        public static void OnMove(object? sender, EventArgs e)
        {
            if (sender is Pawn pawn)
            {
                Console.WriteLine($"{pawn.Colour} pawn moved to {pawn.Position}");
            }
        }
    }
}
