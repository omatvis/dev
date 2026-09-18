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

            // declare local delegate variable
            Action? Multi = null;
            void MultiMethod1() => Console.WriteLine("Multi method 1");
            void MultiMethod2() => Console.WriteLine("Multi method 2");
            Multi += MultiMethod1;
            Multi += MultiMethod2;
            Multi?.Invoke();

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
