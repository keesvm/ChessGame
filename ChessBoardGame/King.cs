using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    class King : ChessPiece
    {
        public King(Point location, bool color)
        {
            this.color = color;
            if (color == false)
            { image = Properties.Resources.BlackKing; }
            if (color == true)
            { image = Properties.Resources.WhiteKing; }

            this.location = location;
        }


        public override List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            Point temp = new Point(location.X, location.Y);
            ChessPiece tempChessPiece;

            
            temp.X++;
            if (temp.X < 8)
            {
                tempChessPiece = findChessPiece(temp, chessPieces);

                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }

                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.X--;
            if (temp.X >= 0)
            {
                tempChessPiece = findChessPiece(temp, chessPieces);
                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.Y++;
            tempChessPiece = findChessPiece(temp, chessPieces);

            if (temp.Y < 8)
            {

                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.Y--;
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (temp.Y >= 0)
            {

                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.X++;
            temp.Y++;
            if (temp.X < 8 && temp.Y < 8)
            {

                tempChessPiece = findChessPiece(temp, chessPieces);
                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.X++;
            temp.Y--;

            if (temp.X < 8 && temp.Y >= 0)
            {

                tempChessPiece = findChessPiece(temp, chessPieces);
                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.X--;
            temp.Y++;
            if (temp.X >= 0 && temp.Y < 8)
            {

                tempChessPiece = findChessPiece(temp, chessPieces);
                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }

            temp = location;
            temp.X--;
            temp.Y--;
            if (temp.X >= 0 && temp.Y >= 0)
            {

                tempChessPiece = findChessPiece(temp, chessPieces);
                if (tempChessPiece == null)
                {
                    possibleMoves.Add(temp);
                }
                if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
                {
                    possibleMoves.Add(temp);
                }
            }


            return possibleMoves;
        }
    }
}
