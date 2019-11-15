using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    class Rook : ChessPiece
    {
        public Rook(Point location, bool color)
        {
            this.color = color;
            if (color == false)
            { image = Properties.Resources.BlackRook; }
            if (color == true)
            { image = Properties.Resources.WhiteRook; }

            this.location = location;
        }

        public override List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            canMoveHorizontally(chessPieces);
            return possibleMoves;
        }


        }
}
