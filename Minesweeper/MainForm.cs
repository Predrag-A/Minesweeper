using Minesweeper.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using System.Diagnostics;

namespace Minesweeper
{
    public partial class MainForm : Form
    {

        /*
         * TODO:
         * Custom size support
         * XML Serialization
         * Format regions
         */
        int _x;
        int _y;
        int _minecount;
        Cell[,] _matrix;
        List<Cell> _mineList;
        int _flagCount;
        bool _firstClick;
        DateTime _time;

        public int FlagCount { get => _flagCount; set => _flagCount = value; }
        public int X { get => _x; }
        public int Y { get => _y; }
        public bool FirstClick { get => _firstClick; set => _firstClick = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public int Minecount { get => _minecount;}

        public MainForm()
        {
            InitializeComponent();
            DrawField(9, 9, 10);
        }

        void DrawField(int x, int y, int minecount)
        {
            _matrix = new Cell[x, y];
            _x = x;
            _y = y;
            _minecount = minecount;
            _mineList = new List<Cell>();
            _flagCount = 0;
            _firstClick = true;
            lblTime.Text = "00:00:00";
            lblFlag.Text = Minecount.ToString();
            timer.Stop();

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    Cell btn = new Cell();
                    btn.Size = new Size(25, 25);
                    btn.Location = new Point(i * 25, j * 25 + 24);
                    btn.Panel = new Data.Panel();
                    btn.XCoord = i;
                    btn.YCoord = j;
                    btn.ParentMatrix = _matrix;
                    
                    btn.SetField();
                    
                    this.Controls.Add(btn);
                    _matrix[i, j] = btn;
                }
            lblTime.Location = new Point(0, y * 25 + 24);
            lblFlag.Location = new Point(x * 21, y * 25 + 24);
            PopulateMines();
            PopulateNumbers();
        }

        void ClearField()
        {
            var count = this.Controls.Count;
            for(var i=0; i<count; i++)
                if(this.Controls[i] is Cell)
                {
                    this.Controls.RemoveAt(i);
                    i--;
                    count--;
                }
            _matrix = null;
        }

        void PopulateMines()
        {
            Random rnd = new Random();
            int x, y;
            int counter = 0;
            while (counter < Minecount)
            {
                x = rnd.Next(0, X);
                y = rnd.Next(0, Y);
                if(_matrix[x,y].Panel.Type != Data.Type.Mine)
                {
                    _matrix[x, y].Panel.Type = Data.Type.Mine;
                    _matrix[x, y].SetField();
                    counter++;
                    _mineList.Add(_matrix[x, y]);
                }
            }
        }
        
        void PopulateNumbers()
        {
            for(int i=0; i<X;i++)
                for(int j=0; j < Y; j++)                
                    if(_matrix[i,j].Panel.Type != Data.Type.Mine)
                    {
                        int counter = 0;

                        List<Cell> list = _matrix[i, j].GetNeighbors();
                        foreach (var c in list)
                            if (c.Panel.Type == Data.Type.Mine)
                                counter++;
                        
                        if (counter > 0)
                        {
                            _matrix[i, j].Panel.Type = Data.Type.Number;
                            _matrix[i, j].Panel.Value = counter;
                            _matrix[i, j].SetField();
                        }
                    } 
        }

        public List<Cell> CheckEndState()
        {
            foreach (var m in _mineList)
                if (!m.Flagged)
                    return null;
            if ((_flagCount - _minecount) != 0)
                return null;
            return _mineList;
        }
        
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
            lblTime.Text = DateTime.Now.Subtract(_time).ToString("hh\\:mm\\:ss");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearField();
            DrawField(_x, _y, Minecount);
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _matrix[0, 0].RevealAll();
            timer.Stop();
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new SizeForm();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                ClearField();
                DrawField(frm.XResult, frm.YResult, frm.MineResult);
            }
        }
    }
}
