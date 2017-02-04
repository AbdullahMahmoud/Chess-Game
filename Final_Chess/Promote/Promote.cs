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
    public partial class Promote : Form
    {

        private int I , J;
        private Cell[] PromoteCell;
        public Promote(int I, int J)
        {
            this.TopMost = true;
            InitializeComponent();
            this.I = I;
            this.J = J;
            PromoteCell = new Cell[4];
            this.BackgroundImage = System.Drawing.Image.FromFile("Image\\rsz_promote.jpg");
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox=false;
            this.StartPosition = FormStartPosition.CenterScreen;
            Load_Cells();
        }
        public void Load_Cells()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Board.board[I, J].pce_property.Color_property == "Black")
                {
                    switch (i)
                    {

                        case 0:
                            {
                                Rook Rk = new Rook(I, J, "Black");
                                PromoteCell[i] = new Cell(I, J, Rk);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\BRook.gif");
                                break;
                            }
                        case 1:
                            {
                                Knight knf = new Knight(I, J, "Black");
                                PromoteCell[i] = new Cell(I, J, knf);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\BKnight.gif");
                                break;
                            }
                        case 2:
                            {
                                Bishop bsp = new Bishop(I, J, "Black");
                                PromoteCell[i] = new Cell(I, J, bsp);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\BBishop.gif");
                                break;
                            }
                        case 3:
                            {
                                Queen qun = new Queen(I, J, "Black");
                                PromoteCell[i] = new Cell(I, J, qun);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\BQueen.gif");
                                break;
                            }

                    }
                }
                else
                {
                    switch (i)
                    {

                        case 0:
                            {
                                Rook Rk = new Rook(I, J, "White");
                                PromoteCell[i] = new Cell(I, J, Rk);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\WRook.gif");
                                break;
                            }
                        case 1:
                            {
                                Knight knf = new Knight(I, J, "White");
                                PromoteCell[i] = new Cell(I, J, knf);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\WKnight.gif");
                                break;
                            }
                        case 2:
                            {
                                Bishop bsp = new Bishop(I, J, "White");
                                PromoteCell[i] = new Cell(I, J, bsp);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\WBishop.gif");
                                break;
                            }
                        case 3:
                            {
                                Queen qun = new Queen(I, J, "White");
                                PromoteCell[i] = new Cell(I, J, qun);
                                PromoteCell[i].BackgroundImage = System.Drawing.Image.FromFile("Image\\WQueen.gif");
                                break;
                            }
                    }
                }
                PromoteCell[i].Parent = this;
                switch (i)
                {

                    case 0:
                        {
                            PromoteCell[i].Location = new Point(30, 350);
                            break;
                        }
                    case 1:
                        {
                            PromoteCell[i].Location = new Point(90 , 330);
                            break;
                        }
                    case 2:
                        {
                            PromoteCell[i].Location = new Point(160 , 350);
                            break;
                        }
                    case 3:
                        {
                            PromoteCell[i].Location = new Point(220 , 330);
                            break;
                        }
                }
                PromoteCell[i].Size = new Size(50, 50);
                PromoteCell[i].Click += new EventHandler(Promote_Click);
                PromoteCell[i].BackColor = Color.Transparent;
                PromoteCell[i].BackgroundImageLayout = ImageLayout.Center;
            }
        }
        void Promote_Click(object sender, EventArgs e)
        {
            Board.board[I, J].pce_property = (sender as Cell).pce_property;
            Board.board[I, J].BackgroundImage = (sender as Cell).BackgroundImage;
            var sound = new System.Media.SoundPlayer("Sound\\game_over.wav");
            sound.Play();
            this.Close();
        }
    }
}
