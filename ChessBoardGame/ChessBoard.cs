using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGame
{
    public partial class ChessBoard : Form
    {
    
        private const int panelSize = 100;
        private const int gridSize = 8;
        private Panel[,] chessPanels = new Panel[gridSize, gridSize];
        private List<ChessPiece> chessPieces = new List<ChessPiece>();
        List<Point> potentialMoves = new List<Point>();
        private bool whiteTurn = false;
        private int turnCounter = 0;
        ChessPiece selectedPiece;

        private List<Point> possibleMoves;

        public ChessBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int column = 0; column < gridSize; column++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(panelSize, panelSize),
                        Location = new Point(panelSize * column, panelSize * row),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    this.Controls.Add(newPanel);

                    chessPanels[column, row] = newPanel;
                }
            }

            foreach(Control c in this.Controls)
            {
                if (c is Panel)
                    c.Click += panelClick;
            }

            setUpBoard();

            redrawBoard();

        }


        void setUpBoard()
        {
            //empty out chess pieces
            chessPieces.Clear();


            //add black pieces

            chessPieces.Add(new Rook(new Point(0, 0), false));
            chessPieces.Add(new Knight(new Point(0, 1), false));
            chessPieces.Add(new Bishop(new Point(0, 2), false));
            chessPieces.Add(new Queen(new Point(0, 3), false));
            chessPieces.Add(new King(new Point(0, 4), false));
            chessPieces.Add(new Bishop(new Point(0, 5), false));
            chessPieces.Add(new Knight(new Point(0, 6), false));
            chessPieces.Add(new Rook(new Point(0, 7), false));
            for (int x = 0; x < 8; x++)
            {
                chessPieces.Add(new Pawn(new Point(1, x), false));
            }

            //add white pieces

            chessPieces.Add(new Rook(new Point(7, 0), true));
            chessPieces.Add(new Knight(new Point(7, 1), true));
            chessPieces.Add(new Bishop(new Point(7, 2), true));
            chessPieces.Add(new Queen(new Point(7, 4), true));
            chessPieces.Add(new King(new Point(7, 3), true));
            chessPieces.Add(new Bishop(new Point(7, 5), true));
            chessPieces.Add(new Knight(new Point(7, 6), true));
            chessPieces.Add(new Rook(new Point(7, 7), true));

            for (int x = 0; x < 8; x++)
            {
                chessPieces.Add(new Pawn(new Point(6, x), true));
            }


        }


        void panelClick(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            redrawBoard();

            Point panelLocation = findPanel(panel);

            if (panelLocation == null)
            {
                Console.WriteLine("ERROR_EMPTY PANELLOC");
                return;
            }
            //check if square is highlighted and if is, moves selected piece
            if (potentialMoves != null)
            {
                if (potentialMoves.Contains(panelLocation))
                {
                    movePiece(panelLocation);
                    potentialMoves.Clear();
                }
            }

            //check if has unselected piece
            ChessPiece chessPiece = findChessPiece(panelLocation);
            if(chessPiece == null)
            {
                Console.WriteLine("Empty panel");
                selectedPiece = null;
                if (potentialMoves != null)
                    potentialMoves.Clear();
                return;
            }
            selectedPiece = chessPiece;

            //colors in selected panel and calculates potential moves
            if (chessPiece.getColor() == this.whiteTurn)
            {
                if (panelLocation.Y % 2 == 0)
                    chessPanels[panelLocation.X, panelLocation.Y].BackColor = panelLocation.X % 2 != 0 ? Color.Blue : Color.LightBlue;
                else
                    chessPanels[panelLocation.X, panelLocation.Y].BackColor = panelLocation.X % 2 != 0 ? Color.LightBlue : Color.Blue;
                potentialMoves = chessPiece.CalculateMoves(chessPieces);
            }
            else
            { //clears potential moves if wrong color is selected
                if (potentialMoves != null)
                {
                    potentialMoves.Clear();
                }
            }
            // colors in potential panels
            if (potentialMoves != null)
            {
                foreach (Point point in potentialMoves)
                {
                    Console.WriteLine(point);
                    if (point.Y % 2 == 0)
                        chessPanels[point.X, point.Y].BackColor = point.X % 2 != 0 ? Color.Blue : Color.LightBlue;
                    else
                        chessPanels[point.X, point.Y].BackColor = point.X % 2 != 0 ? Color.LightBlue : Color.Blue;
                }
            }
        }

        void movePiece(Point panelLocation)
        {
            chessPanels[selectedPiece.getLocation().X, selectedPiece.getLocation().Y].BackgroundImage = null;

            //move to empty square
            if (findChessPiece(panelLocation) == null)
            {
                chessPanels[panelLocation.X, panelLocation.Y].BackgroundImage = selectedPiece.getImage();
                selectedPiece.setLocation(panelLocation);
                whiteTurn = !whiteTurn;


                if (selectedPiece is Pawn)
                {
                    selectedPiece.setHasMoved(true);
                }
            }
            //move to occupied sqaure
            else
            {
                if (findChessPiece(panelLocation) is King)
                {
                    if (findChessPiece(panelLocation).getColor() == true)
                        this.BlackWins.Visible = true;
                    else
                        this.WhiteWins.Visible = true;
                }
                chessPieces.Remove(findChessPiece(panelLocation));
                chessPanels[panelLocation.X, panelLocation.Y].BackgroundImage = selectedPiece.getImage();
                selectedPiece.setLocation(panelLocation);

                whiteTurn = !whiteTurn;

                if (selectedPiece is Pawn)
                {
                    selectedPiece.setHasMoved(true);
                }
            }
        }

        //utility function for finding chess piece
        ChessPiece findChessPiece(Point location)
        {
            foreach (ChessPiece chessPiece in chessPieces)
            {
                if (chessPiece.getLocation() == location)
                    return chessPiece;
            }
            return null;
        }
        // draws the board after every action
        void redrawBoard()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int column = 0; column < gridSize; column++)
                {
                    if (row % 2 == 0)
                        chessPanels[column, row].BackColor = column % 2 != 0 ? Color.LightGray : Color.White;
                    else
                        chessPanels[column, row].BackColor = column % 2 != 0 ? Color.White : Color.LightGray;
                }
            }

            foreach (ChessPiece chessPiece in chessPieces)
            {
                chessPanels[chessPiece.getLocation().X, chessPiece.getLocation().Y].BackgroundImage = chessPiece.getImage();
            }
        }
        //utility for finding a specific panel
        Point findPanel(Panel panel)
        {
            Point point = new Point();
            for (int row = 0; row < gridSize; row++)
            {
                for (int column = 0; column < gridSize; column++)
                {
                    if (chessPanels[row, column] == panel)
                    {
                        point.X = row;
                        point.Y = column;
                        return point;
                    }
                }
            }
            return point;
        }

    }
}
