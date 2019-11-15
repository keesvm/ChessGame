using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    class Queen : ChessPiece
    {
        public Queen(Point location, bool color)
        {
            this.color = color;
            if (color == false)
            { image = Properties.Resources.BlackQueen; }
            if (color == true)
            { image = Properties.Resources.WhiteQueen; }

            this.location = location;
        }

        public override List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            canMoveHorizontally(chessPieces);
            canMoveDiagonally(chessPieces);
            return possibleMoves;
        }
    }
}
