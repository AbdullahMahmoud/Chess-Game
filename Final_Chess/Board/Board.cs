using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Final_Chess
{
    public partial class Board : Form
    {
        private static Game TmpGameObj;
        public static Cell[,] board;
        private int[,] table;
        private List<pair> possible_moves;
        public static bool IsPressedBefore;
        public static int I, J;
        private PictureBox InformationImage;
        private PictureBox PlayerTurn;
        public void Load_Color()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (table[i, j])
                    {
                        case 00: board[i, j] = new Cell(i, j); break;
                        case 01:
                            {
                                Pawn pwn = new Pawn(i, j, "Black");
                                board[i, j] = new Cell(i, j, pwn);
                                break;
                            }
                        case 02:
                            {
                                Rook Rk = new Rook(i, j, "Black");
                                board[i, j] = new Cell(i, j, Rk);
                                break;
                            }
                        case 03:
                            {
                                Knight knf = new Knight(i, j, "Black");
                                board[i, j] = new Cell(i, j, knf);
                                break;
                            }
                        case 04:
                            {
                                Bishop bsp = new Bishop(i, j, "Black");
                                board[i, j] = new Cell(i, j, bsp);
                                break;
                            }
                        case 05:
                            {
                                Queen qun = new Queen(i, j, "Black");
                                board[i, j] = new Cell(i, j, qun);
                                break;
                            }
                        case 06:
                            {
                                King kng = new King(i, j, "Black");
                                board[i, j] = new Cell(i, j, kng);
                                break;
                            }
                        case 11:
                            {
                                Pawn pwn = new Pawn(i, j, "White");
                                board[i, j] = new Cell(i, j, pwn);
                                break;
                            }
                        case 12:
                            {
                                Rook Rk = new Rook(i, j, "White");
                                board[i, j] = new Cell(i, j, Rk);
                                break;
                            }
                        case 13:
                            {
                                Knight knf = new Knight(i, j, "White");
                                board[i, j] = new Cell(i, j, knf);
                                break;
                            }
                        case 14:
                            {
                                Bishop bsp = new Bishop(i, j, "White");
                                board[i, j] = new Cell(i, j, bsp);
                                break;
                            }
                        case 15:
                            {
                                Queen qun = new Queen(i, j, "White");
                                board[i, j] = new Cell(i, j, qun);
                                break;
                            }
                        case 16:
                            {
                                King kng = new King(i, j, "White");
                                board[i, j] = new Cell(i, j, kng);
                                break;
                            }
                    }
                    board[i, j].Parent = this;
                    board[i, j].Location = new Point(50 + j * 90, 50 + i * 90);
                    board[i, j].Size = new Size(90, 90);
                    board[i, j].Click += new EventHandler(NewClick);
                    if (i % 2 == 0)
                        if (j % 2 == 0)
                            board[i, j].BackColor = Color.DarkSlateGray;
                        else
                            board[i, j].BackColor = Color.LightSteelBlue;
                    else
                        if (j % 2 == 0)
                            board[i, j].BackColor = Color.LightSteelBlue;
                        else
                            board[i, j].BackColor = Color.DarkSlateGray;
                    board[i, j].BackgroundImageLayout = ImageLayout.Center;
                }
            }
        } 
        public void Load_Pieces()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (table[i, j])
                    {
                        case 00: board[i, j].BackgroundImage = null; break;
                        case 01: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BPawn.gif"); break;
                        case 02: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BRook.gif"); break;
                        case 03: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BKnight.gif"); break;
                        case 04: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BBishop.gif"); break;
                        case 05: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BQueen.gif"); break;
                        case 06: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\BKing.gif"); break;
                        case 11: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\WPawn.gif"); break;
                        case 12: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\WRook.gif"); break;
                        case 13: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\WKnight.gif"); break;
                        case 14: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\WBishop.gif"); break;
                        case 15: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\WQueen.gif"); break;
                        case 16: board[i, j].BackgroundImage = System.Drawing.Image.FromFile("Image\\WKing.gif"); break;
                    }
                }
            }
        }
        public Board()
        {
            InitializeComponent();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Chess Game";
            TmpGameObj = new Game();
            this.BackgroundImage = System.Drawing.Image.FromFile("Image\\New_BackGround.jpg");
            InformationImage = new PictureBox();
            InformationImage.Location = new Point(800, 375);
            InformationImage.Size = new Size(480, 80);
            InformationImage.BackColor = Color.Transparent;
            PlayerTurn = new PictureBox();
            PlayerTurn.Location = new Point(30, 30);
            PlayerTurn.Size = new Size(700, 700);
            PlayerTurn.BackColor = Color.White;
            IsPressedBefore = false;
            possible_moves = new List<pair>();
            board = new Cell[8, 8];
            table = new int[8, 8]
            {
                {02, 03, 04, 05, 06, 04, 03, 02},
                {01, 01, 01, 01, 01, 01, 01, 01},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {11, 11, 11, 11, 11, 11, 11, 11},
                {12, 13, 14, 15, 16, 14, 13, 12},
            };
            Load_Color();
            Load_Pieces();
            Controls.Add(PlayerTurn);
            Controls.Add(InformationImage);
        } 
        public void NewClick(object sender, EventArgs e)
        {
            int i = (sender as Cell).y_property;
            int j = (sender as Cell).x_property;
            if (board[i, j].CellOccupied() == true && IsPressedBefore == false && ((board[i, j].pce_property.Color_property == "White" && Game.player % 2 == 0) || (board[i, j].pce_property.Color_property == "Black" && Game.player % 2 == 1)))
            {
                I = i;
                J = j;
                possible_moves = new List<pair>(board[i, j].pce_property.Get_Possible_moves(board[i, j]));
                if (possible_moves.Count() != 0)
                {
                    possible_moves = new List<pair>(TmpGameObj.Filter_The_Possible_Moves(new Cell(board[I, J])));
                    if (possible_moves.Count != 0)
                    {
                        HighLight(possible_moves);
                        IsPressedBefore = true;
                    }
                }
            }
            else if (IsPressedBefore == true && I == i && J == j)
            {
                UnHighLight(possible_moves);
                IsPressedBefore = false;
            }
            else if (IsPressedBefore)
            {
                bool check = false;
                for (int k = 0; k < possible_moves.Count; k++)
                {
                    if (i == possible_moves[k].y_property && j == possible_moves[k].x_property)
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    var sound = new System.Media.SoundPlayer("Sound\\move.wav");
                    sound.Play();
                    UnHighLight(possible_moves);
                    Change_Possition(I, J, i, j);
                    IsPressedBefore = false;
                    Game.player++;
                    if (Game.player % 2 == 0)
                        PlayerTurn.BackColor = Color.White;
                    else if(Game.player % 2 == 1)
                        PlayerTurn.BackColor = Color.Red;
                }
            }
        }
        public void HighLight(List<pair> possible_moves)
        {
            for (int k = 0; k < possible_moves.Count; k++)
            {
                int a = possible_moves[k].y_property;
                int b = possible_moves[k].x_property;
                board[a, b].BackColor = Color.LightSeaGreen;
            }
        }
        public void UnHighLight(List<pair> possible_moves)
        {
            for (int k = 0; k < possible_moves.Count; k++)
            {
                int a = possible_moves[k].y_property;
                int b = possible_moves[k].x_property;
                if (a % 2 == 0)
                    if (b % 2 == 0)
                        board[a, b].BackColor = Color.DarkSlateGray;
                    else
                        board[a, b].BackColor = Color.LightSteelBlue;
                else
                    if (b % 2 == 0)
                        board[a, b].BackColor = Color.LightSteelBlue;
                    else
                        board[a, b].BackColor = Color.DarkSlateGray;
            }
        }
        public void Change_Possition(int i1, int j1, int i2, int j2)
        {
            if (board[i2, j2].BackgroundImage != null)
            {
                DrawDeadPiece(i2, j2);
            }
            board[i2, j2].BackgroundImage = board[i1, j1].BackgroundImage;
            board[i1, j1].BackgroundImage = null;
            board[i1, j1].pce_property.y_property = i2;
            board[i1, j1].pce_property.x_property = j2;
            board[i1, j1].pce_property.IsNotMovedBefore_property = false;
            board[i2, j2].pce_property = board[i1, j1].pce_property;
            board[i1, j1].pce_property = null;
            if ((board[i2, j2].pce_property.GetType() == typeof(Final_Chess.Pawn) && Game.player % 2 == 0 && i2 == 0) || (board[i2, j2].pce_property.GetType() == typeof(Final_Chess.Pawn) && Game.player % 2 == 1 && i2 == 7))
            {
                Promote TmpObj = new Promote(i2, j2);
                TmpObj.ShowDialog();
            }
            if (board[i2, j2].pce_property.GetType() == typeof(Final_Chess.King) && Math.Abs(j2 - j1) == 2)
            {
                Swap(i2, j2);
            }
            InformationImage.Image = null;
            Game.CheckMode = TmpGameObj.Check_If_Check(board[i2, j2].pce_property.Get_Possible_moves(board[i2, j2]));
            if (Game.CheckMode)
            {
                if (TmpGameObj.Check_If_CheckMate())
                {
                    var sound = new System.Media.SoundPlayer("Sound\\game_over.wav");
                    sound.Play();
                    InformationImage.Image = Image.FromFile("Image\\CheckMate.png");
                    Game.player = -2;
                }
                else
                {
                    var sound = new System.Media.SoundPlayer("Sound\\check.wav");
                    sound.Play();
                    InformationImage.Image = Image.FromFile("Image\\Check.png");
                }
            }
            if (Game.WhiteDeadPieces == 15 && Game.BlackDeadPieces == 15)
            {
                var sound = new System.Media.SoundPlayer("Sound\\game_over.wav");
                sound.Play();
                InformationImage.Image = Image.FromFile("Image\\Draw.png");
                Game.player = -2;
            }
        }
        public void Swap(int i, int j)
        {
            if (j > Board.J)
            {
                Change_Possition(i, 7, i, j - 1);
            }
            else
            {
                Change_Possition(i, 0, i, j + 1);
            }
        }
        public void DrawDeadPiece(int i, int j)
        {
            PictureBox TmpImage = new PictureBox();
            if (Game.player % 2 == 0)
            {
                if (Game.BlackDeadPieces < 8)
                {
                    TmpImage.Location = new Point(793 + 90 * Game.BlackDeadPieces, 613);
                    TmpImage.Size = new Size(90, 90);
                }
                else
                {
                    TmpImage.Location = new Point(793 + 90 * (Game.BlackDeadPieces % 8), 703);
                    TmpImage.Size = new Size(90, 90);
                }
                Game.BlackDeadPieces++;
            }
            else
            {
                if (Game.WhiteDeadPieces < 8)
                {
                    TmpImage.Location = new Point(793 + 90 * Game.WhiteDeadPieces, 73);
                    TmpImage.Size = new Size(90, 90);
                }
                else
                {
                    TmpImage.Location = new Point(793 + 90 * (Game.WhiteDeadPieces % 8), 163);
                    TmpImage.Size = new Size(90, 90);
                }
                Game.WhiteDeadPieces++;
            }
            TmpImage.Image = board[i, j].BackgroundImage;
            TmpImage.BackColor = Color.Transparent;
            this.Controls.Add(TmpImage);
        }
    }
}