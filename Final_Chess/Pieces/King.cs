using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Chess
{
    public class King : Piece
    {
        public King(int y = 0, int x = 0, string color = "", bool IsNotMovedBefore = true)
            : base(y , x , color , IsNotMovedBefore)
        {
        }
        public King(Piece obj)
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
                            int a = i + 1, b = j - 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 1:
                        {
                            int a = i + 1, b = j;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 2:
                        {
                            int a = i + 1, b = j + 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 3:
                        {
                            int a = i, b = j + 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 4:
                        {
                            int a = i, b = j - 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 5:
                        {
                            int a = i - 1, b = j + 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 6:
                        {
                            int a = i - 1, b = j;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                    case 7:
                        {
                            int a = i - 1, b = j - 1;
                            if (a >= 0 && a < 8 && b >= 0 && b < 8 && ((Board.board[a, b].CellOccupied() == false) || (Board.board[a, b].pce_property.Color_property != obj.pce_property.Color_property)))
                            {
                                pair pr = new pair(a, b);
                                possible_moves.Add(pr);
                            }
                            break;
                        }
                }
            }
            if (!Game.CheckMode && Board.board[i, j].pce_property.IsNotMovedBefore_property && i == 7 && j == 4 && Board.board[i, j].pce_property.Color_property == "White")
            {
                if(Board.board[7,0].CellOccupied() && Board.board[7,0].pce_property.GetType()==typeof(Final_Chess.Rook) && Board.board[7,0].pce_property.IsNotMovedBefore_property && Board.board[7,0].pce_property.Color_property=="White")
                {
                    bool Empty_Cells=true;
                    for(int k=j-1 ; k>0 && Empty_Cells ; k--)
                    {
                        if(Board.board[i , k].CellOccupied() == true)
                            Empty_Cells=false;
                    }
                    if(Empty_Cells)
                    {
                        pair pr = new pair(i , j-2);
                        possible_moves.Add(pr);
                    }   
                }
                if(Board.board[7,7].CellOccupied() && Board.board[7,7].pce_property.GetType()==typeof(Final_Chess.Rook) && Board.board[7,7].pce_property.IsNotMovedBefore_property && Board.board[7,7].pce_property.Color_property=="White")
                {
                    bool Empty_Cells=true;
                    for(int k=j+1 ; k<7 && Empty_Cells ; k++)
                    {
                        if(Board.board[i , k].CellOccupied() == true)
                            Empty_Cells=false;
                    }
                    if(Empty_Cells)
                    {
                        pair pr = new pair(i , j+2);
                        possible_moves.Add(pr);
                    }   
                }
            }
            else if (!Game.CheckMode && Board.board[i, j].pce_property.IsNotMovedBefore_property && i == 0 && j == 4 && Board.board[i, j].pce_property.Color_property == "Black")
            {
                if (Board.board[0, 0].CellOccupied() && Board.board[0, 0].pce_property.GetType() == typeof(Final_Chess.Rook) && Board.board[0 , 0].pce_property.IsNotMovedBefore_property && Board.board[0, 0].pce_property.Color_property == "Black")
                {
                    bool Empty_Cells = true;
                    for (int k = j - 1 ; k > 0 && Empty_Cells ; k--)
                    {
                        if (Board.board[i, k].CellOccupied() == true)
                            Empty_Cells = false;
                    }
                    if (Empty_Cells)
                    {
                        pair pr = new pair(i, j - 2);
                        possible_moves.Add(pr);
                    }
                }
                if (Board.board[0, 7].CellOccupied() && Board.board[0, 7].pce_property.GetType() == typeof(Final_Chess.Rook) && Board.board[0, 7].pce_property.IsNotMovedBefore_property && Board.board[0, 7].pce_property.Color_property == "Black")
                {
                    bool Empty_Cells = true;
                    for (int k = j + 1; k < 7 && Empty_Cells ; k++)
                    {
                        if (Board.board[i , k].CellOccupied() == true)
                            Empty_Cells = false;
                    }
                    if (Empty_Cells)
                    {
                        pair pr = new pair(i, j + 2);
                        possible_moves.Add(pr);
                    }
                }
            }
            return possible_moves;
        }
    }
}
