using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardGame
{
    abstract class ChessPiece
    {
        protected bool color { get; set; }
        protected Point location { get; set; }
        protected List<Point> possibleMoves = new List<Point>();
        protected Image image { get; set; }

        public bool getColor()
        {
            return color;
        }

        public Point getLocation()
        {
            return location;
        }

        public void setLocation(Point newLocation)
        {
            location = newLocation;
        }

        public Image getImage()
        {
            return image;
        }

        public virtual List<Point> CalculateMoves(List<ChessPiece> chessPieces)
        {
            return null;
        }

        public virtual void setHasMoved(bool newSetting)
        {
            return;
        }

        protected ChessPiece findChessPiece(Point location, List<ChessPiece> chessPieces)
        {
            foreach (ChessPiece chessPiece in chessPieces)
            {
                if (chessPiece.getLocation() == location)
                    return chessPiece;
            }
            return null;
        }

        protected void canMoveHorizontally(List<ChessPiece> chessPieces)
        {

            Point temp = new Point(location.X,location.Y);
            ChessPiece tempChessPiece;
            temp.X++;

            while (temp.X < 8 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.Y++;

            while (temp.Y < 8 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.Y++;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X--;

            while (temp.X >= 0 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.Y--;

            while (temp.Y >= 0 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.Y--;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }
        }

        protected void canMoveDiagonally(List<ChessPiece> chessPieces)
        {

            Point temp = new Point(location.X, location.Y);
            ChessPiece tempChessPiece;


            temp.X++;
            temp.Y++;
            while (temp.X < 8 && temp.Y < 8 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
                temp.Y++;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X--;
            temp.Y++;
            
            while (temp.X >= 0 && temp.Y < 8 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
                temp.Y++;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X++;
            temp.Y--;

            while (temp.X < 8 && temp.Y >= 0 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X++;
                temp.Y--;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }


            temp = location;
            temp.X--;
            temp.Y--;

            while (temp.X >= 0 && temp.Y >= 0 && findChessPiece(temp, chessPieces) == null)
            {
                possibleMoves.Add(temp);
                temp.X--;
                temp.Y--;
            }
            tempChessPiece = findChessPiece(temp, chessPieces);
            if (tempChessPiece != null && tempChessPiece.getColor() != this.getColor())
            {
                possibleMoves.Add(temp);
            }
        }
    }
}
