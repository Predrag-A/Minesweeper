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

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        int _x;
        int _y;
        int _minecount;
        Cell[,] _matrix;
        int _flagcount;

        public int Flagcount { get => _flagcount; set => _flagcount = value; }

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
            Flagcount = 0;

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
            while (counter < _minecount)
            {
                x = rnd.Next(0, _x);
                y = rnd.Next(0, _y);
                if(_matrix[x,y].Panel.Type != Data.Type.Mine)
                {
                    _matrix[x, y].Panel.Type = Data.Type.Mine;
                    _matrix[x, y].SetField();
                    counter++;
                }
            }
        }
        
        
        void PopulateNumbers()
        {
            for(int i=0; i<_x;i++)
                for(int j=0; j < _y; j++)                
                    if(_matrix[i,j].Panel.Type != Data.Type.Mine)
                    {
                        int counter = 0;

                        List<Cell> list = _matrix[i, j].GetNeighbors(_x, _y);
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
    }
}
