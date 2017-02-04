using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Chess
{
    public class Game
    {
        public static int player , WhiteDeadPieces , BlackDeadPieces;
        public static bool CheckMode;
        public Game()
        {
            CheckMode = false;
            WhiteDeadPieces = 0;
            BlackDeadPieces = 0;
            player = 0;
        }
        public bool Check_If_Check(List<pair> Check_List)
        {
            for (int k = 0 ; k < Check_List.Count(); k++)
            {
                int a = Check_List[k].y_property;
                int b = Check_List[k].x_property;
                if (Board.board[a, b].CellOccupied() && ((Board.IsPressedBefore && ((player % 2 == 0 && Board.board[a, b].pce_property.Color_property == "Black") || (player % 2 == 1 && Board.board[a, b].pce_property.Color_property == "White"))) || (!Board.IsPressedBefore && ((player % 2 == 0 && Board.board[a, b].pce_property.Color_property == "White") || (player % 2 == 1 && Board.board[a, b].pce_property.Color_property == "Black")))) && Board.board[a, b].pce_property.GetType() == typeof(Final_Chess.King))
                {
                    return true;
                }
            }
            return false;
        }
        public List<pair> Filter_The_Possible_Moves(Cell Clicked_Piece)
        {
            List<pair> possible_moves = Board.board[Board.I, Board.J].pce_property.Get_Possible_moves(Board.board[Board.I, Board.J]);
            Board.board[Board.I, Board.J].pce_property = null;
            for (int i = 0; i < possible_moves.Count ; i++)
            {
                int n = possible_moves[i].y_property;
                int m = possible_moves[i].x_property;
                Cell Original_Data = new Cell(Board.board[n, m]);
                Board.board[n, m].pce_property = Clicked_Piece.pce_property;
                Board.board[n, m].pce_property.y_property = n;
                Board.board[n, m].pce_property.x_property = m;
                bool IsLegalMove = true;
                for (int a = 0; a < 8 && IsLegalMove; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if (player % 2 == 0 && Board.board[a, b].CellOccupied() && Board.board[a, b].pce_property.Color_property == "Black")
                        {
                            if (Check_If_Check(Board.board[a, b].pce_property.Get_Possible_moves(Board.board[a, b])))
                            {
                                possible_moves.Remove(possible_moves[i]);
                                --i;
                                IsLegalMove = false;
                                break;
                            }
                        }
                        else if (player % 2 == 1 && Board.board[a, b].CellOccupied() && Board.board[a, b].pce_property.Color_property == "White")
                        {
                            if (Check_If_Check(Board.board[a, b].pce_property.Get_Possible_moves(Board.board[a, b])))
                            {
                                possible_moves.Remove(possible_moves[i]);
                                --i;
                                IsLegalMove = false;
                                break;
                            }
                        }
                    }
                }
                Board.board[n, m].pce_property = Original_Data.pce_property;
            }
            Board.board[Board.I, Board.J].pce_property = Clicked_Piece.pce_property;
            Board.board[Board.I, Board.J].pce_property.y_property = Board.I;
            Board.board[Board.I, Board.J].pce_property.x_property = Board.J;
            return possible_moves;
        }
        public bool Check_If_CheckMate()
        {
            ++player;
            Board.IsPressedBefore = false;
            bool CheckMate = true;
            for (int i = 0; i < 8 && CheckMate; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board.board[i, j].CellOccupied() && player % 2 == 1 && Board.board[i, j].pce_property.Color_property == "Black")
                    {
                        Board.I = i;
                        Board.J = j;
                        List<pair> possible_moves = new List<pair>( Filter_The_Possible_Moves(new Cell(Board.board[i, j])) );
                        if (possible_moves.Count != 0)
                        {
                            CheckMate = false;
                            break;
                        }
                    }
                    else if (Board.board[i, j].CellOccupied() && player % 2 == 0 && Board.board[i, j].pce_property.Color_property == "White")
                    {
                        Board.I = i;
                        Board.J = j;
                        List<pair> possible_moves = new List<pair>(Filter_The_Possible_Moves(new Cell(Board.board[i, j])));
                        if (possible_moves.Count != 0)
                        {
                            CheckMate = false;
                            break;
                        }
                    }
                }
            }
            --player;
            Board.IsPressedBefore = true;
            return CheckMate;
        }
    }
}
