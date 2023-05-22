using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace SquareGOL
{
    #region Parent Class
    public class Cell
    {
        public List<Cell> Neighbours = new List<Cell>();
        public Point Location;
        public Size CellSize;
        public float Xpos, Ypos;
        public Boolean isAlive;
        public Boolean nextState;
        public int Index;
        public Rectangle cellDisplay;

        public Cell(Point location, int X, int Y)
        {
            this.Location = location;
            this.Xpos = X;
            this.Ypos = Y;
            int cSize = (X == 0) ? 0 : Location.X / X;
            this.CellSize = new Size(cSize, cSize);
            this.cellDisplay = new Rectangle(this.Location, this.CellSize);
        }

        public Cell(int X, int Y, int cSize)
        {
            this.Location = new Point(X * cSize, Y * cSize);
            this.Xpos = X;
            this.Ypos = Y;
            this.CellSize = new Size(cSize, cSize);
            this.cellDisplay = new Rectangle(this.Location, new Size(cSize - 1, cSize - 1));
        }

        public void setIndex(Grid grid)
		{
			this.Index = ((int)this.Ypos * grid.columns) + (int)Xpos;
		}

        public override string ToString()
        {
            return $"X:{this.Xpos}, Y:{this.Ypos}, Loc (X,Y):{this.Location.X},{this.Location.Y}, Status: {this.stateToStr()}";
        }

        private string stateToStr()
        {
            if (isAlive) return "Alive";
            else return "Dead";
        }

        public string stateToFile()
        {
            if (isAlive) return "1";
            else return "0";
        }

        public void FiletoState(char i)
        {
            if (i == '1')
            {
                isAlive = true;
            }
            else isAlive = false;
        }
    }
    #endregion

}
