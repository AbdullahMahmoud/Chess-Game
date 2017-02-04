using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Chess
{
   public abstract class Piece
   {
       protected int x;
       protected int y;
       protected string Color;
       protected List<pair> possible_moves;
       protected bool IsNotMovedBefore;

       public bool IsNotMovedBefore_property
       {
           get { return IsNotMovedBefore; }
           set { IsNotMovedBefore = value; }
       }
       public Piece(int y , int x , string color , bool IsNotMovedBefore = true )
       {
           this.x = x;
           this.y = y;
           this.Color = color;
           this.IsNotMovedBefore = IsNotMovedBefore;
           possible_moves=new List<pair>();
       }
       public Piece(Piece obj)
       {
           this.x = obj.x;
           this.y = obj.y;
           this.Color = obj.Color;
           this.IsNotMovedBefore = obj.IsNotMovedBefore;
           possible_moves = new List<pair>();
       }
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
       public string Color_property
       {
           get { return Color; }
           set { Color = value; }
       }
       public virtual List<pair> Get_Possible_moves(Cell obj)
       {
           return possible_moves;
       }
   }
}
