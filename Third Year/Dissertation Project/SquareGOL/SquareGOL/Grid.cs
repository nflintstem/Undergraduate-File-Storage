using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace SquareGOL
{
    public class Grid
    {
        public static List<Cell> cellList = new List<Cell>();
        public int rows;
        public int columns;
        public List<PointF> vertices;

        public Grid(int row, int column)
        {
            this.rows = row;
            this.columns = column;
        }

        public int NeighCheck(Cell cell)
        {
            int liveNeighbours = 0;
            foreach(Cell neigh in cell.Neighbours)
            {
                if (neigh.isAlive) liveNeighbours++;
            }
            return liveNeighbours;
        }


        public void NeighbourAppender(Cell cell,string neiType, int radius)
        {
            List<int> values = new List<int>();
            int CellIndex = ((int)cell.Ypos * this.columns) + (int)cell.Xpos;
            int startIndex = CellIndex - (radius*this.columns) - radius;
            startIndex = (startIndex < 0) ? 0 : startIndex;
            int endIndex = CellIndex + (radius*this.columns + (radius+1));
            endIndex = (endIndex > (Grid.cellList.Count - 1)) ? Grid.cellList.Count - 1 : endIndex;
            for(int i =1; i < radius+1; i++){
                values.Add(i);
            }
            switch (neiType)
            {
                case "Moore":
                    {
                        int mooreMax = radius + 1;
                        for (int x = startIndex; x < endIndex; x++)
                        {
                            if (Math.Abs(cell.Xpos - Grid.cellList[x].Xpos) < mooreMax && Math.Abs(cell.Ypos - Grid.cellList[x].Ypos) < mooreMax)
                            {
                                if (cell.Location != Grid.cellList[x].Location)
                                {
                                    cell.Neighbours.Add(Grid.cellList[x]);
                                }
                            }
                        }
                    }
                    break;
                case "von Neumann":
                    {
                        for (int x = startIndex; x < endIndex; x++)
                        {
                            if ((Math.Abs(cell.Xpos - Grid.cellList[x].Xpos) == 0 && values.Contains((int)Math.Abs(cell.Ypos - Grid.cellList[x].Ypos))) || 
                                (Math.Abs(cell.Ypos - Grid.cellList[x].Ypos) == 0 && values.Contains((int)Math.Abs(cell.Xpos - Grid.cellList[x].Xpos))))
                            {
                                if (cell.Location != Grid.cellList[x].Location)
                                {
                                    cell.Neighbours.Add(Grid.cellList[x]);
                                }
                            }
                        }
                    }
                    break;
                case "Diagonals":
                    {
                        for (int x = startIndex; x < endIndex; x++)
                        {
                            if (values.Contains((int)Math.Abs(cell.Xpos - Grid.cellList[x].Xpos)) && values.Contains((int)Math.Abs(cell.Ypos - Grid.cellList[x].Ypos)))
                            if (Math.Abs(cell.Xpos - Grid.cellList[x].Xpos) == 1 && Math.Abs(cell.Ypos - Grid.cellList[x].Ypos) == 1)
                            {
                                if (cell.Location != Grid.cellList[x].Location)
                                {
                                    cell.Neighbours.Add(Grid.cellList[x]);
                                }
                            }
                        }
                    }
                    break;
                default:
                    {
                        int mooreMax = radius + 1;
                        for (int x = startIndex; x < endIndex; x++)
                        {
                            if (Math.Abs(cell.Xpos - Grid.cellList[x].Xpos) < mooreMax && Math.Abs(cell.Ypos - Grid.cellList[x].Ypos) < mooreMax)
                            {
                                if (cell.Location != Grid.cellList[x].Location)
                                {
                                    cell.Neighbours.Add(Grid.cellList[x]);
                                }
                            }
                        }
                    }
                    break;
            }
        }

    }

}
