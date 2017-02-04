using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Final_Chess
{
    public class Bishop : Piece
    {
        public Bishop(int y = 0, int x = 0, string color = "", bool IsNotMovedBefore = true)
            : base(y, x, color , IsNotMovedBefore)
        {
        }
        public Bishop(Piece obj)
            : base(obj)
        {

        }
        public override List<pair> Get_Possible_moves(Cell obj)
        {
            possible_moves.Clear();
            int I = obj.pce_property.y_property , J = obj.pce_property.x_property;
            int i = I, j = J;
            while (true)
            {
                i++; j++;
                if (i < 8 && j < 8 && ((Board.board[i, j].CellOccupied() == false) || (Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)))
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                    if ((Board.board[i, j].CellOccupied() == true) && (Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property))
                    {
                        break;
                    }
                }
                else
                    break;
            }
            i = I; j = J;
            while (true)
            {
                i++; j--;
                if (i < 8 && j >= 0 && ((Board.board[i, j].CellOccupied() == false) || (Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)))
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                    if ((Board.board[i, j].CellOccupied() == true) && (Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property))
                    {
                        break;
                    }
                }
                else
                    break;
            }
            i = I; j = J;
            while (true)
            {
                i--; j--;
                if (i >= 0 && j >= 0 && ((Board.board[i, j].CellOccupied() == false) || (Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)))
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                    if ((Board.board[i, j].CellOccupied() == true) && (Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property))
                    {
                        break;
                    }
                }
                else
                    break;
            }
            i = I; j = J;
            while (true)
            {
                i--; j++;
                if (i >= 0 && j < 8 && ((Board.board[i, j].CellOccupied() == false) || (Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)))
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                    if ((Board.board[i, j].CellOccupied() == true) && (Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property))
                    {
                        break;
                    }
                }
                else
                    break;
            }
            return possible_moves;
        }
    }
}
