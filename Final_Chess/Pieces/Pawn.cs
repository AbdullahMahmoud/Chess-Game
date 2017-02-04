using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Chess
{
    public class Pawn : Piece
    {
        public Pawn(int y = 0, int x = 0, string color = "", bool IsNotMovedBefore = true)
            : base(y, x, color , IsNotMovedBefore)
        {
        }
        public Pawn(Piece obj)
            : base(obj)
        {

        }
        public override List<pair> Get_Possible_moves(Cell obj)
        {
            possible_moves.Clear();
            bool check = true;
            if (obj.pce_property.Color_property == "Black")
            {
                int i = obj.pce_property.y_property + 1;
                int j = obj.pce_property.x_property;
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == false && check)
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                }
                else
                {
                    check = false;
                }
                i = obj.pce_property.y_property + 1;
                j = obj.pce_property.x_property + 1;
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                }
                i = obj.pce_property.y_property + 1;
                j = obj.pce_property.x_property - 1;
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                }
                if (obj.pce_property.y_property == 1 && check)
                {

                    i = obj.pce_property.y_property + 2;
                    j = obj.pce_property.x_property;
                    if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == false)
                    {
                        pair pr = new pair(i, j);
                        possible_moves.Add(pr);
                    }
                }
            }

            else
            {
                int i = obj.pce_property.y_property - 1;
                int j = obj.pce_property.x_property;
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == false && check)
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                }
                else
                {
                    check = false;
                }
                i = obj.pce_property.y_property - 1;
                j = obj.pce_property.x_property + 1;
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                }
                i = obj.pce_property.y_property - 1;
                j = obj.pce_property.x_property - 1;
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == true && Board.board[i, j].pce_property.Color_property != obj.pce_property.Color_property)
                {
                    pair pr = new pair(i, j);
                    possible_moves.Add(pr);
                }
                if (obj.pce_property.y_property == 6 && check)
                {
                    i = obj.pce_property.y_property - 2;
                    j = obj.pce_property.x_property;
                    if (i >= 0 && i < 8 && j >= 0 && j < 8 && Board.board[i, j].CellOccupied() == false)
                    {
                        pair pr = new pair(i, j);
                        possible_moves.Add(pr);
                    }
                }
            }
            return possible_moves;
        }
    }
}
