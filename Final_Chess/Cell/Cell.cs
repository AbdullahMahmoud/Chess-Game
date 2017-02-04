using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Final_Chess
{
    public partial class Cell : UserControl
    {
        private int x;
        private int y;
        private Piece pce;
        public Cell(int y=-1 , int x=-1 , Piece pce = null)
        {
            this.x = x;
            this.y = y;
            this.pce = pce;
        }
        public Cell(Cell obj)
        {
            this.x = obj.x;
            this.y = obj.y;
            if (obj.pce == null)
                this.pce = null;
            else if (obj.pce.GetType() == typeof(Final_Chess.Pawn))
                this.pce = new Pawn(obj.pce);
            else if (obj.pce.GetType() == typeof(Final_Chess.Bishop))
                this.pce = new Bishop(obj.pce);
            else if (obj.pce.GetType() == typeof(Final_Chess.King))
                this.pce = new King(obj.pce);
            else if (obj.pce.GetType() == typeof(Final_Chess.Knight))
                this.pce = new Knight(obj.pce);
            else if (obj.pce.GetType() == typeof(Final_Chess.Queen))
                this.pce = new Queen(obj.pce);
            else if (obj.pce.GetType() == typeof(Final_Chess.Rook))
                this.pce = new Rook(obj.pce);
        }
        public bool CellOccupied()
        { return (pce!=null); }
        public Piece Get_Piece()
        { return pce; }
        public int x_property
        {
            get { return x; }
            set { x = value; }
        }
        public int y_property
        {
            get { return y; }
            set { y = value; }
        }
        public Piece pce_property
        {
            get { return pce; }
            set { pce = value; }
        }
    }
}