using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Data;
using Minesweeper.Controls;
using Panel = Data.Panel;
using Type = Data.Type;

namespace Minesweeper
{
    public partial class MainForm : Form
    {       

        #region Fields

        Cell[,] _matrix;
        List<Cell> _mineList;

        #endregion

        #region Properties

        public int FlagCount { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public bool FirstClick { get; set; }

        public DateTime Time { get; set; }

        public int Minecount { get; private set; }

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            //Default option is 9x9 with 10 mines.
            DrawField(9, 9, 10);
        }

        #endregion

        #region Methods


        //Initializes matrix of Cell UserControls and places them inside the WinForm.
        void DrawField(int x, int y, int minecount)
        {
            _matrix = new Cell[x, y];
            X = x;
            Y = y;
            Minecount = minecount;
            _mineList = new List<Cell>();
            FlagCount = 0;
            FirstClick = true;
            lblTime.Text = "00:00:00";
            lblFlag.Text = Minecount.ToString();
            timer.Stop();

            for (var i = 0; i < x; i++)
                for (var j = 0; j < y; j++)
                {
                    var btn = new Cell();
                    btn.Size = new Size(25, 25);
                    btn.Location = new Point(i * 25, j * 25 + 24);
                    btn.Panel = new Panel();
                    btn.XCoord = i;
                    btn.YCoord = j;
                    btn.ParentMatrix = _matrix;
                    
                    btn.SetField();
                    
                    Controls.Add(btn);
                    _matrix[i, j] = btn;
                }
            lblTime.Location = new Point(0, y * 25 + 24);
            lblFlag.Location = new Point(x * 21, y * 25 + 24);
        }

        //Deletes all Cell UserControls from the WinForm.
        void ClearField()
        {
            var count = Controls.Count;
            for(var i=0; i<count; i++)
                if(Controls[i] is Cell)
                {
                    Controls.RemoveAt(i);
                    i--;
                    count--;
                }
            _matrix = null;
        }

        //Adds mines to the matrix of cells.
        public void PopulateMines(int i, int j)
        {
            var rnd = new Random();
            int x, y;
            var counter = 0;

            //Max mines correction
            if (Minecount > (X - 1) * (Y - 1))
                Minecount = (X - 1) * (Y - 1);

            //If there is a low enough number of mines to enable the first click to be an empty space
            if (Minecount < (X - 1) * (Y - 1) - 8)
            {
                var n = _matrix[i, j].GetNeighbors();
                while (counter < Minecount)
                {
                    x = rnd.Next(0, X);
                    y = rnd.Next(0, Y);
                    
                    if (n.Contains(_matrix[x,y]) || x == i && j == y)
                        continue;
                    if (_matrix[x, y].Panel.Type != Type.Mine)
                    {
                        _matrix[x, y].Panel.Type = Type.Mine;
                        _matrix[x, y].SetField();
                        counter++;
                        _mineList.Add(_matrix[x, y]);
                    }
                }
            }
            //If there isn't the first click will most likely be a number. Either way, a mine will not be placed
            //on the cell which has been clicked.
            else
            {
                while (counter < Minecount)
                {
                    x = rnd.Next(0, X);
                    y = rnd.Next(0, Y);
                    if (x == i && j == y)
                        continue;
                    if (_matrix[x, y].Panel.Type != Type.Mine)
                    {
                        _matrix[x, y].Panel.Type = Type.Mine;
                        _matrix[x, y].SetField();
                        counter++;
                        _mineList.Add(_matrix[x, y]);
                    }
                }
            }
        }
        
        //After mines have been set, the rest of the cells are filled with numbers if there are any mines around them.
        public void PopulateNumbers()
        {
            for(var i=0; i<X;i++)
                for(var j=0; j < Y; j++)                
                    if(_matrix[i,j].Panel.Type != Type.Mine)
                    {
                        var list = _matrix[i, j].GetNeighbors();
                        var counter = list.Count(c => c.Panel.Type == Type.Mine);

                        if (counter <= 0) continue;
                        _matrix[i, j].Panel.Type = Type.Number;
                        _matrix[i, j].Panel.Value = counter;
                        _matrix[i, j].SetField();
                    } 
        }

        //If all the mines are flagged, the game is over.
        public List<Cell> CheckEndState()
        {
            if (_mineList.Any(m => !m.Panel.Flagged))
            {
                return null;
            }
            return FlagCount - Minecount != 0 ? null : _mineList;
        }

        //Sets the background image and label depending on the cell type, used only for deserialization.
        public void SetAll()
        {
            for (var i = 0; i < X; i++)
                for (var j = 0; j < Y; j++)
                    _matrix[i, j].SetField();
        }

        #endregion

        #region Events

        private void easy9x9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearField();
            DrawField(9, 9, 10);
        }

        private void medium16x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearField();
            DrawField(16, 16, 40);
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearField();
            DrawField(16, 30, 99);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.Subtract(Time).ToString("hh\\:mm\\:ss");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearField();
            DrawField(X, Y, Minecount);
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _matrix[0, 0].RevealAll();
            timer.Stop();
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new SizeForm();
            if (frm.ShowDialog() != DialogResult.OK) return;
            ClearField();
            DrawField(frm.XResult, frm.YResult, frm.MineResult);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Serialization
            if (sfd.ShowDialog() != DialogResult.OK) return;
            var f = new SerializableField(X, Y, Minecount) {FirstClick = FirstClick};
            for (var i = 0; i < X; i++)
            for (var j = 0; j < Y; j++)
                f.Matrix[i, j] = _matrix[i, j].Panel;
            var xmlserializer = new XmlSerializer(typeof(SerializableField));

            using (var fileWriter = new FileStream(sfd.FileName, FileMode.Create))
            {
                xmlserializer.Serialize(fileWriter, f);
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Deserialization
            if (ofd.ShowDialog() != DialogResult.OK) return;
            SerializableField f;
            var serializer = new XmlSerializer(typeof(SerializableField));

            using (var reader = XmlReader.Create(ofd.FileName))
            {
                f = (SerializableField)serializer.Deserialize(reader);
            }
            FirstClick = f.FirstClick;
            ClearField();
            DrawField(f.X, f.Y, f.Minecount);
            for (var i = 0; i < X; i++)
            for (var j = 0; j < Y; j++)
                _matrix[i, j].Panel = f.Matrix[i, j];
            SetAll();
        }

        #endregion

    }
}
