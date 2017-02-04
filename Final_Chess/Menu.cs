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
    public partial class Menu : Form
    {
        private Button Start;
        private Button Exit;
        public Menu()
        {
            InitializeComponent();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Menu";
            this.BackgroundImage = System.Drawing.Image.FromFile("Image\\191464.jpg");
            Start = new Button();
            Exit = new Button();
            Start.Text = "Start";
            Start.Font = new Font(Start.Font.FontFamily, this.Size.Height / 10, FontStyle.Italic);
            Exit.Text = "Exit";
            Exit.Font = new Font(Exit.Font.FontFamily, this.Size.Height / 10, FontStyle.Italic);
            Start.Parent = this;
            Start.Location = new Point(200, 300);
            Start.Size = new Size(500, 120);
            Start.BackColor = Color.DarkSeaGreen;
            Start.Click += new EventHandler(MenuClick);
            Exit.Parent = this;
            Exit.Location = new Point(200, 430);
            Exit.Size = new Size(500, 120);
            Exit.BackColor = Color.DarkSeaGreen;
            Exit.Click += new EventHandler(MenuClick);
        }
        public void MenuClick(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Start")
            {
                Board obj = new Board();
                obj.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
