using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    class Bishop : ChessPiece
    {
        public Bishop(Point location, bool color)
        {
            this.color = color;
            if (color == false)
            { image = Properties.Resources.BlackBishop; }
            if (color == true)
            { image = Properties.Resources.WhiteBishop; }

            this.location = location;
        }

        public override List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            canMoveDiagonally(chessPieces);
            return possibleMoves;
        }

    }
}
