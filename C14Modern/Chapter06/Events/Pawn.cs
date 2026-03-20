using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Events
{
    internal class Pawn
    {
        public required FigureColour Colour { get; init; }
        public required ChessPoint Position { get; set; }

        public event EventHandler? Move;

        public void MoveForward()
        {
            var newRow = Colour switch
            {
                FigureColour.White => Position.Row + 1,
                FigureColour.Black => Position.Row - 1,
                _ => Position.Row
            };

            // Prevent moving off the board
            if ((int)newRow < 1 || (int)newRow > 8) return; // or throw

            // Use the constructor so ChessPoint's validation runs
            Position = new ChessPoint(Position.Col, newRow);

            // Notify listeners
            Move?.Invoke(this, EventArgs.Empty);
        }
    }
}
