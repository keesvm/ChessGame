using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    class Pawn : ChessPiece
    {

        private bool hasMoved;

        public Pawn(Point location, bool color)
        {
            this.color = color;
            if (color == false)
            { image = Properties.Resources.BlackPawn; }
            if (color == true)
            { image = Properties.Resources.WhitePawn; }

            this.location = location;
            hasMoved = false;
        }

        public override List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            possibleMoves.Clear();
           
            
            Console.WriteLine(hasMoved + " " + color);

            if (hasMoved == false && color == true)
            {
                if (location.X - 1 >= 0 && this.findChessPiece(new Point(location.X - 1, location.Y), chessPieces) == null)
                {
                    possibleMoves.Add(new Point(location.X- 1, location.Y));
                    if (location.X - 2 >= 0 && this.findChessPiece(new Point(location.X - 2, location.Y), chessPieces) == null)
                    {
                        possibleMoves.Add(new Point(location.X - 2, location.Y));
                    }
                }
             }
            if (hasMoved == true && color == true)
            {
                if (location.X - 1 >= 0 && this.findChessPiece(new Point(location.X - 1, location.Y), chessPieces) == null)
                {
                    possibleMoves.Add(new Point(location.X - 1, location.Y));
                }
            }
            //check if can take enemy
            if (color == true)
            {
                ChessPiece possibleTarget = this.findChessPiece(new Point(location.X - 1, location.Y + 1), chessPieces);
                if (location.X - 1 >= 0 && location.Y + 1 < 8 && possibleTarget != null && possibleTarget.getColor() == false)
                {
                    possibleMoves.Add(new Point(location.X - 1, location.Y + 1));
                }
                possibleTarget = this.findChessPiece(new Point(location.X - 1, location.Y - 1), chessPieces);
                if (location.X - 1 >= 0 && location.Y - 1 >= 0 && possibleTarget != null && possibleTarget.getColor() == false)
                {
                    possibleMoves.Add(new Point(location.X - 1, location.Y - 1));
                }
            }



            if (hasMoved == false && color == false)
            {
                if (location.X + 1 < 8 && this.findChessPiece(new Point(location.X + 1, location.Y), chessPieces) == null)
                {
                    possibleMoves.Add(new Point(location.X + 1, location.Y));
                    if (location.X + 2 < 8 && this.findChessPiece(new Point(location.X + 2, location.Y), chessPieces) == null)
                    {
                        possibleMoves.Add(new Point(location.X + 2, location.Y));
                    }
                }
            }

            if (hasMoved == true && color == false)
            {
                if (location.X + 1 < 8 && this.findChessPiece(new Point(location.X + 1, location.Y), chessPieces) == null)
                {
                    possibleMoves.Add(new Point(location.X + 1, location.Y));
                }
            }
            //check if can take enemy
            if (color == false)
            {
                ChessPiece possibleTarget = this.findChessPiece(new Point(location.X + 1, location.Y + 1), chessPieces);
                if (location.X + 1 < 8 && location.Y + 1 < 8 && possibleTarget != null && possibleTarget.getColor() == true)
                {
                    possibleMoves.Add(new Point(location.X + 1, location.Y + 1));
                }
                possibleTarget = this.findChessPiece(new Point(location.X + 1, location.Y - 1), chessPieces);
                if (location.X + 1 < 8 && location.Y - 1 >= 0 && possibleTarget != null && possibleTarget.getColor() == true)
                {
                    possibleMoves.Add(new Point(location.X + 1, location.Y - 1));
                }
            }

            return possibleMoves;
        }

        public override void setHasMoved(bool newSetting)
        {
            hasMoved = newSetting;
        }


    }
}
