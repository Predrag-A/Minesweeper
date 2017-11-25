using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Minesweeper.Controls
{
    public partial class Cell : UserControl
    {

        #region Attributes

        Data.Panel _p;
        int _i;
        int _j;
        int clickCount = 0;
        Cell[,] _parentMatrix;
        List<Cell> _mines;
        string respath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();

        #endregion

        #region Properties

        public Data.Panel Panel { get { return _p; } set { _p = value; } }
        public Cell[,] ParentMatrix { get { return _parentMatrix; } set { _parentMatrix = value; } }
        public int XCoord { get { return _i; } set { _i = value; } }
        public int YCoord { get { return _j; } set { _j = value; } }

        #endregion

        #region Constructors

        //Main UserControl used to represent a single Minesweeper cell.
        public Cell()
        {
            InitializeComponent();
            this.Size = new Size(25, 25);
            lblValue.Location = new Point(0, 0);
        }

        #endregion

        #region Methods

        //Returns a color depending on the number of mines around a cell. The color is used for the number label.
        Color getColor()
        {
            switch (this.Panel.Value)
            {
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.DarkGreen;
                case 3:
                    return Color.Red;
                case 4:
                    return Color.DarkBlue;
                case 5:
                    return Color.DarkRed;
                case 6:
                    return Color.Teal;
                case 7:
                    return Color.Purple;
                case 8:
                    return Color.Gray;
                default:
                    return Color.Black;
            }
            
        }

        //Sets the background and/or label of a cell.
        public void SetField()
        {
            if (_p.Type == Data.Type.Empty)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\emptyBG.png");
            else if (_p.Type == Data.Type.Mine)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\mine.png");
            else if (_p.Type == Data.Type.Number)
            {
                lblValue.Text = this.Panel.Value.ToString();
                lblValue.ForeColor = getColor();
            }
            if (_p.Revealed)
            {
                btn.Visible = false;
                if (_p.Value > 0)
                    lblValue.Visible = true;
            }
            if (_p.Flagged)
            {
                this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\flag.png");
                Panel.Flagged = true;
                ((MainForm)(this.ParentForm)).FlagCount++;
                ((MainForm)(this.ParentForm)).lblFlag.Text = (((MainForm)(this.ParentForm)).Minecount - ((MainForm)(this.ParentForm)).FlagCount).ToString();
                clickCount++;
            }

        }

        //Reveals a cell, sets the label to visible if the cell type is Number.
        public void Reveal()
        {
            btn.Visible = false;
            this.Panel.Revealed = true;
            if (this.Panel.Type == Data.Type.Number)
                lblValue.Visible = true;
        }

        //Returns a list of all neighbors of a cell.
        public List<Cell> GetNeighbors()
        {
            int xDim = ((MainForm)this.ParentForm).X;
            int yDim = ((MainForm)this.ParentForm).Y;
            List<Cell> list = new List<Cell>();

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                {
                    if (i + XCoord < 0 || i + XCoord > xDim - 1 || j + YCoord < 0 || j + YCoord > yDim - 1)
                        continue;
                    list.Add(_parentMatrix[i + XCoord, j + YCoord]);
                }

            return list;
        }

        //Function that gets called recursively if a cell is empty or stops if it is a number.
        void RevealEmpty(Cell c)
        {
            List<Cell> list = c.GetNeighbors();
            foreach (var cell in list)
            {
                if (cell.Panel.Type == Data.Type.Empty && !cell.Panel.Flagged)
                {
                    if (!cell.Panel.Revealed)
                    {
                        cell.Reveal();
                        RevealEmpty(cell);
                    }
                }
                else if (cell.Panel.Type == Data.Type.Number && !cell.Panel.Flagged)
                    cell.Reveal();
            }
        }

        //Reveals all cells. Gets used when the game ends.
        public void RevealAll()
        {
            for (int i = 0; i < ((MainForm)this.ParentForm).X; i++)
                for (int j = 0; j < ((MainForm)this.ParentForm).Y; j++)
                    if (!_parentMatrix[i, j].Panel.Revealed)
                    {
                        if (_parentMatrix[i, j].Panel.Type == Data.Type.Mine)
                        {
                            if (!_parentMatrix[i, j].Panel.Flagged)
                                _parentMatrix[i, j].Reveal();
                            else
                                _parentMatrix[i, j].btn.Enabled = false;
                        }
                        else if (_parentMatrix[i, j].Panel.Flagged)
                        {
                            _parentMatrix[i, j].BackgroundImage = Image.FromFile(respath + "\\res\\mineWrong.png");
                            _parentMatrix[i, j].Reveal();
                            _parentMatrix[i, j].lblValue.Visible = false;
                        }
                        else
                            _parentMatrix[i, j].Reveal();


                    }
        }

        //Sets the value of a cell to the number of mines surrounding it.
        int setValue()
        {
            int count = 0;
            var list = this.GetNeighbors();
            foreach (var cell in list)
                if (cell.Panel.Type == Data.Type.Mine)
                    count++;
            if (count == 0)
                this.Panel.Type = Data.Type.Empty;
            this.Panel.Value = count;
            return count;
        }

        #endregion

        #region Events

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            //If it is the first click of the game, add the mines, numbers and start the timer.
            if (((MainForm)this.ParentForm).FirstClick)
            {
                ((MainForm)this.ParentForm).PopulateMines(_i, _j);
                ((MainForm)this.ParentForm).PopulateNumbers();

                ((MainForm)this.ParentForm).Time = DateTime.Now;
                ((MainForm)this.ParentForm).timer.Start();
            }
            //If the left click is used and the cell is not flagged or has a question mark.
            if (e.Button == MouseButtons.Left && clickCount == 0)
            {
                ((MainForm)this.ParentForm).FirstClick = false;
                Reveal();
                if (this.Panel.Type == Data.Type.Empty)
                    RevealEmpty(this);
                if (this.Panel.Type == Data.Type.Mine)
                {
                    ((MainForm)(this.ParentForm)).timer.Stop();
                    this.BackgroundImage = Image.FromFile(respath + "\\res\\mineExploded.png");
                    RevealAll();
                }
            }
            //If the right click is used cycle between no flag, flag and question mark.
            else if (e.Button == MouseButtons.Right)
            {

                if (clickCount == 0)
                {
                    this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\flag.png");
                    Panel.Flagged = true;
                    ((MainForm)(this.ParentForm)).FlagCount++;
                    ((MainForm)(this.ParentForm)).lblFlag.Text = (((MainForm)(this.ParentForm)).Minecount - ((MainForm)(this.ParentForm)).FlagCount).ToString();
                }
                else if (clickCount == 1)
                {
                    this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\q.png");
                    Panel.Flagged = false;
                    ((MainForm)(this.ParentForm)).FlagCount--;
                    ((MainForm)(this.ParentForm)).lblFlag.Text = (((MainForm)(this.ParentForm)).Minecount - ((MainForm)(this.ParentForm)).FlagCount).ToString();
                }
                else
                {
                    this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\empty.png");
                    clickCount = -1;
                }

                clickCount++;
            }

                _mines = ((MainForm)this.ParentForm).CheckEndState();

                if (_mines != null)
                {
                    ((MainForm)this.ParentForm).timer.Stop();
                    RevealAll();
                }
            }       

        }    

        #endregion
}
