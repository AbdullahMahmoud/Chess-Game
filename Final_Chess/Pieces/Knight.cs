using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Chess
{
    public class Knight : Piece
    {
        public Knight(int y = 0 , int x = 0 , string color = "" , bool IsNotMovedBefore = true)
            : base(y, x, color , IsNotMovedBefore)
        {
        }
        public Knight(Piece obj)
            : base(obj)
        {

        }
        public override List<pair> Get_Possible_moves(Cell obj)
        {
            possible_moves.Clear();
            int i = obj.pce_property.y_property, j = obj.pce_property.x_property;
            for (int k = 0; k < 8; k++)
            {
                switch (k)
                {
                    case 0:
                        {
                            int a = i + 2, b = j + 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 1:
                        {
                            int a = i + 2, b = j - 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 2:
                        {
                            int a = i + 1, b = j + 2;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 3:
                        {
                            int a = i - 1, b = j + 2;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 4:
                        {
                            int a = i + 1, b = j - 2;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 5:
                        {
                            int a = i - 1, b = j - 2;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 6:
                        {
                            int a = i - 2, b = j - 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 7:
                        {
                            int a = i - 2, b = j + 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                }
            }
            return possible_moves;
        }
    }
}
