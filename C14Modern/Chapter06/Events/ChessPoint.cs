using System;

namespace Events
{
    public record ChessPoint
    {
        public enum File { A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8 }
        public enum Rank { One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8 }

        public File Col { get; }
        public Rank Row { get; }

        public ChessPoint(File col, Rank row)
        {
            if ((int)col < 1 || (int)col > 8) throw new ArgumentOutOfRangeException(nameof(col));
            if ((int)row < 1 || (int)row > 8) throw new ArgumentOutOfRangeException(nameof(row));

            Col = col;
            Row = row;
        }

        public override string ToString()
        {
            // Format like "A1"
            char fileChar = (char)('A' + ((int)Col - 1));
            int rankNum = (int)Row;
            return $"{fileChar}{rankNum}";
        }

        public void Deconstruct(out File col, out Rank row)
        {
            col = Col;
            row = Row;
        }

        public static bool TryParse(string s, out ChessPoint? point)
        {
            point = null;
            if (string.IsNullOrWhiteSpace(s)) return false;

            s = s.Trim();
            if (s.Length != 2) return false;

            char fileChar = char.ToUpperInvariant(s[0]);
            char rankChar = s[1];

            if (fileChar < 'A' || fileChar > 'H') return false;
            if (rankChar < '1' || rankChar > '8') return false;

            var file = (File)((fileChar - 'A') + 1);
            var rank = (Rank)(rankChar - '0');

            point = new ChessPoint(file, rank);
            return true;
        }

        public static ChessPoint Parse(string s)
        {
            if (TryParse(s, out var p) && p is not null) return p;
            throw new FormatException($"Invalid chess point: '{s}'. Expected format like 'E4'.");
        }
    }
}
