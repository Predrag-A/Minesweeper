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

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DrawField(16, 16);
        }


        void DrawField(int x, int y)
        {
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    Cell btn = new Cell();
                    btn.Size = new Size(25, 25);
                    btn.Location = new Point(i * 25, j * 25 + 24);
                    this.Controls.Add(btn);
                }
            lblTime.Location = new Point(0, y * 25 + 24);
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
        }
    }
}
