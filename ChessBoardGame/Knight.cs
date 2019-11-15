using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    class Knight : ChessPiece
    {
        public Knight(Point location, bool color)
        {
            this.color = color;
            if (color == false)
            { image = Properties.Resources.BlackKnight; }
            if (color == true)
            { image = Properties.Resources.WhiteKnight; }

            this.location = location;
        }


        public override List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
            Point temp = new Point(location.X, location.Y);
            ChessPiece tempChessPiece;


            temp = location;
            temp.X += 1;
            temp.Y += 2;
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
            temp.X += 1;
            temp.Y -= 2;

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
            temp.X -= 1;
            temp.Y += 2;
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
            temp.X -= 1;
            temp.Y -= 2;
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


            temp = location;
            temp.X += 2;
            temp.Y += 1;
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
            temp.X += 2;
            temp.Y -= 1;

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
            temp.X -= 2;
            temp.Y += 1 ;
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
            temp.X -= 2;
            temp.Y -= 1;
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
