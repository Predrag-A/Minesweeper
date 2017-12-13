using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Panel = Data.Panel;
using Type = Data.Type;

namespace Minesweeper.Controls
{
    public partial class Cell : UserControl
    {

        #region Fields

        int clickCount;
        List<Cell> _mines;
        readonly string _respath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();

        #endregion

        #region Properties

        public Panel Panel { get; set; }

        public Cell[,] ParentMatrix { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        #endregion

        #region Constructors

        //Main UserControl used to represent a single Minesweeper cell.
        public Cell()
        {
            InitializeComponent();
            Size = new Size(25, 25);
            lblValue.Location = new Point(0, 0);
        }

        #endregion

        #region Methods

        //Returns a color depending on the number of mines around a cell. The color is used for the number label.
        Color getColor()
        {
            switch (Panel.Value)
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
            switch (Panel.Type)
            {
                case Type.Empty:
                    BackgroundImage = Image.FromFile(_respath + "\\res\\emptyBG.png");
                    break;
                case Type.Mine:
                    BackgroundImage = Image.FromFile(_respath + "\\res\\mine.png");
                    break;
                case Type.Number:
                    lblValue.Text = Panel.Value.ToString();
                    lblValue.ForeColor = getColor();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (Panel.Revealed)
            {
                btn.Visible = false;
                if (Panel.Value > 0)
                    lblValue.Visible = true;
            }
            if (!Panel.Flagged) return;
            btn.BackgroundImage = Image.FromFile(_respath + "\\res\\flag.png");
            Panel.Flagged = true;
            ((MainForm)ParentForm).FlagCount++;
            ((MainForm)ParentForm).lblFlag.Text = (((MainForm)ParentForm).Minecount - ((MainForm)ParentForm).FlagCount).ToString();
            clickCount++;
        }

        //Reveals a cell, sets the label to visible if the cell type is Number.
        public void Reveal()
        {
            btn.Visible = false;
            Panel.Revealed = true;
            if (Panel.Type == Type.Number)
                lblValue.Visible = true;
        }

        //Returns a list of all neighbors of a cell.
        public List<Cell> GetNeighbors()
        {
            var xDim = ((MainForm)ParentForm).X;
            var yDim = ((MainForm)ParentForm).Y;
            var list = new List<Cell>();

            for (var i = -1; i < 2; i++)
                for (var j = -1; j < 2; j++)
                {
                    if (i + XCoord < 0 || i + XCoord > xDim - 1 || j + YCoord < 0 || j + YCoord > yDim - 1)
                        continue;
                    list.Add(ParentMatrix[i + XCoord, j + YCoord]);
                }

            return list;
        }

        //Function that gets called recursively if a cell is empty or stops if it is a number.
        static void RevealEmpty(Cell c)
        {
            var list = c.GetNeighbors();
            foreach (var cell in list)
            {
                if (cell.Panel.Type == Type.Empty && !cell.Panel.Flagged)
                {
                    if (!cell.Panel.Revealed)
                    {
                        cell.Reveal();
                        RevealEmpty(cell);
                    }
                }
                else if (cell.Panel.Type == Type.Number && !cell.Panel.Flagged)
                    cell.Reveal();
            }
        }

        //Reveals all cells. Gets used when the game ends.
        public void RevealAll()
        {
            for (var i = 0; i < ((MainForm)ParentForm).X; i++)
                for (var j = 0; j < ((MainForm)ParentForm).Y; j++)
                    if (!ParentMatrix[i, j].Panel.Revealed)
                    {
                        if (ParentMatrix[i, j].Panel.Type == Type.Mine)
                        {
                            if (!ParentMatrix[i, j].Panel.Flagged)
                                ParentMatrix[i, j].Reveal();
                            else
                                ParentMatrix[i, j].btn.Enabled = false;
                        }
                        else if (ParentMatrix[i, j].Panel.Flagged)
                        {
                            ParentMatrix[i, j].BackgroundImage = Image.FromFile(_respath + "\\res\\mineWrong.png");
                            ParentMatrix[i, j].Reveal();
                            ParentMatrix[i, j].lblValue.Visible = false;
                        }
                        else
                            ParentMatrix[i, j].Reveal();


                    }
        }

        #endregion

        #region Events

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            //If it is the first click of the game, add the mines, numbers and start the timer.
            if (((MainForm)ParentForm).FirstClick)
            {
                ((MainForm)ParentForm).PopulateMines(XCoord, YCoord);
                ((MainForm)ParentForm).PopulateNumbers();

                ((MainForm)ParentForm).Time = DateTime.Now;
                ((MainForm)ParentForm).timer.Start();
            }
            //If the left click is used and the cell is not flagged or has a question mark.
            if (e.Button == MouseButtons.Left && clickCount == 0)
            {
                ((MainForm)ParentForm).FirstClick = false;
                Reveal();
                if (Panel.Type == Type.Empty)
                    RevealEmpty(this);
                if (Panel.Type == Type.Mine)
                {
                    ((MainForm)ParentForm).timer.Stop();
                    BackgroundImage = Image.FromFile(_respath + "\\res\\mineExploded.png");
                    RevealAll();
                }
            }
            //If the right click is used cycle between no flag, flag and question mark.
            else if (e.Button == MouseButtons.Right)
            {
                switch (clickCount)
                {
                    case 0:
                        btn.BackgroundImage = Image.FromFile(_respath + "\\res\\flag.png");
                        Panel.Flagged = true;
                        ((MainForm)ParentForm).FlagCount++;
                        ((MainForm)ParentForm).lblFlag.Text = (((MainForm)ParentForm).Minecount - ((MainForm)ParentForm).FlagCount).ToString();
                        break;
                    case 1:
                        btn.BackgroundImage = Image.FromFile(_respath + "\\res\\q.png");
                        Panel.Flagged = false;
                        ((MainForm)ParentForm).FlagCount--;
                        ((MainForm)ParentForm).lblFlag.Text = (((MainForm)ParentForm).Minecount - ((MainForm)ParentForm).FlagCount).ToString();
                        break;
                    default:
                        btn.BackgroundImage = Image.FromFile(_respath + "\\res\\empty.png");
                        clickCount = -1;
                        break;
                }

                clickCount++;
            }

                _mines = ((MainForm)ParentForm).CheckEndState();

            if (_mines == null) return;
            ((MainForm)ParentForm).timer.Stop();
            RevealAll();
        }       

        }    

        #endregion
}
