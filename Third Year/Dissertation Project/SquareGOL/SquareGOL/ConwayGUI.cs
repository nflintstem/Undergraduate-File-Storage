using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquareGOL
{
    public partial class ConwayGUI : Form
    {
        private Boolean Running;
        private Boolean Prop;
        Grid GridCell;
        string NType;
        int marginX,marginY;
        int radi;
        #region GUI
        public ConwayGUI()
        {
            InitializeComponent();
        }

        private void gamePlay_Click(object sender, EventArgs e)
        {
            Running = !Running;
            gamePlay.Text = Running ? "Stop" : "Play";
            while (Running)
            {
                NextState();
                gameInc.Enabled = false;
                Application.DoEvents();
            }
            if (!Running)
            {
                gameInc.Enabled = true;
            }
        }
        private void Clearer_Click(object sender, EventArgs e)
        {
            CreateGridSurface(false);
        }

        private void gameInc_Click(object sender, EventArgs e)
        {
            NextState();
        }

        private void Resetter_Click(object sender, EventArgs e)
        {
            CreateGridSurface(true);
        }

        private void ConwayGUI_Load(object sender, EventArgs e)
        {
            this.marginX = this.Width - GoLBox.Width;
            this.marginY = this.Height - GoLBox.Height;
            ShapeNamer.SelectedItem = "Moore";
            this.radi = 1;
            this.Prop = false;
            this.NType = (string)ShapeNamer.SelectedItem;
            CreateGridSurface(true);
        }
        
        private void ConwayGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Running = false;
            Application.Exit();
        }

        private void ShapeNamer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NType = (string)ShapeNamer.SelectedItem;
            if (Running)
            {
                Running = !Running;
                gamePlay.Enabled = false;
                if (gameInc.Enabled)
                {
                    gameInc.Enabled = false;
                }
            }
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            radi = (int)numericUpDown1.Value;
        }

        private void GoLBox_MouseClick(object sender, MouseEventArgs e)
        {
            Size CellSize = Grid.cellList[0].CellSize;
            int cellIndex = indexLocator(e,CellSize);
            Grid.cellList[cellIndex].isAlive = !Grid.cellList[cellIndex].isAlive;
            Update(GridCell);
        }

        private void savePNG_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GoLBox.Image.Save(saveFileDialog.FileName);
                }
            }
        } 
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Prop = !this.Prop;
        }
        
        private void saveTXT_Click(object sender, EventArgs e)
        {
            string OutputFile;
            SaveFileDialog savetext = new SaveFileDialog();
            savetext.Filter = "Text Files(*txt)|*.txt";
            savetext.DefaultExt = "txt";
            savetext.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (savetext.ShowDialog() == DialogResult.OK)
            {
                OutputFile = savetext.FileName;
                SaveFile(OutputFile);
            }
            
        }
        
        private void loadF_Click(object sender, EventArgs e)
        {
            string InputFile;
            OpenFileDialog opentext = new OpenFileDialog();
            opentext.Filter = "Text Files(*txt)|*.txt";
            opentext.DefaultExt = "txt";
            opentext.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (opentext.ShowDialog() == DialogResult.OK)
            {
                InputFile = opentext.FileName;
                LoadFile(InputFile);
            }
        }
        private void ConwayGUI_Resize(object sender, EventArgs e)
        {
            GoLBox.Width = this.Width - marginX;
            GoLBox.Height = this.Height - marginY;
            GoLBox.Refresh();
            CreateGridSurface(true);
        }

        #endregion

        #region Grid Update
        private void Update(Grid grid)
        {
            using(Bitmap bmp = new Bitmap(GoLBox.Width, GoLBox.Height))
            using (Graphics grp = Graphics.FromImage(bmp))
            using (SolidBrush cellBrush = new SolidBrush(Color.Gold))
            {
                grp.Clear(Color.Black);
                foreach (Cell cell in Grid.cellList)
                {
                    if (cell.isAlive)
                    {
                        grp.FillRectangle(cellBrush, cell.cellDisplay);
                    }
                }
                if (GoLBox.Image != null) GoLBox.Image.Dispose();
                GoLBox.Image = (Bitmap)bmp.Clone();
            }
           
        }

        private int indexLocator(MouseEventArgs e, Size size)
        {
            int xLoc = (int)(e.X / size.Width);
            int yLoc = (int)(e.Y / size.Width);
            return (yLoc * GridCell.columns) + xLoc;
        }

        private void NextState()
        {
            foreach(Cell cell in Grid.cellList)
            {
                if(Prop)
                 {
                    int LiveCount = GridCell.NeighCheck(cell);
                    if (cell.isAlive)
                    {
                        if (LiveCount < (2*radi) || LiveCount > (3*radi)) cell.nextState = false;
                        else cell.nextState = true;
                    }
                    else
                    {
                        if (LiveCount == (3*radi)) cell.nextState = true;
                    }
                 }
                else{
                    int LiveCount = GridCell.NeighCheck(cell);
                    if (cell.isAlive)
                    {
                        if (LiveCount < 2 || LiveCount > 3) cell.nextState = false;
                        else cell.nextState = true;
                    }
                    else
                    {
                        if (LiveCount == 3) cell.nextState = true;
                    }
                }
            }
            foreach (Cell cell in Grid.cellList)
            {
                cell.isAlive = cell.nextState;
            }

             Update(GridCell);
        }

        #endregion

        #region GridCreate
        private void CreateGridSurface(bool RandomCells)
        {
            Cell newCell;
            Random rand = new Random();
            int percentAlive = (int)(percentageCheck.Value);
            int rows = (int)(GoLBox.Height/sizeCounter.Value);
            int cols = (int)(GoLBox.Width / sizeCounter.Value);
            GridCell = new Grid(rows, cols);
            using (Bitmap bmp = new Bitmap(GoLBox.Width, GoLBox.Height))
            using (Graphics grp = Graphics.FromImage(bmp))
            using (SolidBrush cellBrush = new SolidBrush(Color.Gold))
            {
                grp.Clear(Color.Black);
                GoLBox.Image = (Bitmap)bmp.Clone();
                Grid.cellList.Clear();
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        newCell = new Cell(x, y, (int)sizeCounter.Value);
                        newCell.setIndex(GridCell);
                        if (RandomCells) newCell.isAlive = (rand.Next(100) < percentAlive) ? true : false;
                        else newCell.isAlive = false;
                        Grid.cellList.Add(newCell);
                    }
                }

                Grid.cellList = Grid.cellList.OrderBy(c => c.Xpos).OrderBy(c => c.Ypos).ToList();
                foreach(Cell c in Grid.cellList)
                {
                    GridCell.NeighbourAppender(c, NType,radi);
                }
                Update(GridCell);
            }
        }

        
        #endregion

        #region FileManaging
        private void SaveFile(string FileName)
        {
            int yCheck = 0;
            string fileLine = "";
            string newFile = FileName;
            string temp = newFile.Replace("YNATEST.", "");

            using (StreamWriter picFile = new StreamWriter(temp))
            {
                foreach(Cell cell in Grid.cellList)
                {
                    if((int)cell.Ypos != yCheck)
                    {
                        picFile.WriteLine(fileLine);
                        fileLine = "";
                        yCheck = (int)cell.Ypos;
                    }
                    fileLine += cell.stateToFile();
                }
                picFile.Close();
            }
        }

        

        private void LoadFile(string FileName)
        {
            int Cols = GridCell.columns;
            int currIndex = 0;
            string convertLine = "";
            string loadedFile = FileName;
            int lineCount = 0;
            string temp = loadedFile.Replace("YNATEST.", "");
            CreateGridSurface(false);
            using(StreamReader readFile = new StreamReader(temp))
            {
                string line;
                while((line = readFile.ReadLine()) != null)
                {
                    if(line.Length < Cols)
                    {
                        for (int i = line.Length; i < Cols; i++)
                        {
                            line += "0";
                        }
                    }
                    convertLine += line;
                    lineCount += 1;
                }
                readFile.Close();
                if (lineCount < GridCell.rows)
                {
                    for(int i = lineCount; i < GridCell.rows; i++)
                    {
                        string newLine = "";
                        for (int j = 0; j < GridCell.columns; j++)
                        {
                            newLine += "0";
                        }
                        convertLine += newLine;
                    }
                }
                foreach (char c in convertLine)
                {
                    Grid.cellList[currIndex].FiletoState(c);
                    Update(GridCell);
                    currIndex++;
                }
                LoadBox.Text = $"Loaded {loadedFile} successfully";
                
            }
        }



        #endregion

       
    }

}
