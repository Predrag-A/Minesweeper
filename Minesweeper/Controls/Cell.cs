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
        
        Data.Panel _p;
        int _i;
        int _j;
        int clickCount = 0;
        string respath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        Cell[,] _parentMatrix;

        public Data.Panel Panel { get => _p; set => _p = value; }
        public Cell[,] ParentMatrix { get => _parentMatrix; set => _parentMatrix = value; }
        public int XCoord { get => _i; set => _i = value; }
        public int YCoord { get => _j; set => _j = value; }

        public Cell()
        {
            InitializeComponent();
            this.Size = new Size(25, 25);
        }

        public void SetField()
        {
            if (_p.Type == Data.Type.Empty)
                this.BackgroundImage = null;
            else if (_p.Type == Data.Type.Mine)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\mine.png");
            else if (_p.Type == Data.Type.Number)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\" + _p.Value.ToString() + ".png");
        }

        public void Reveal()
        {
            btn.Visible = false;
        }

        //Some long shit
        public List<Cell> GetNeighbors(int xDim, int yDim)
        {            
            List<Cell> list = new List<Cell>();

            if (_i == 0 && _j == 0)
            {
                list.Add(_parentMatrix[_i, _j + 1]);                
                list.Add(_parentMatrix[_i + 1, _j]);
                list.Add(_parentMatrix[_i + 1, _j + 1]);
            }
            else if (_i == 0 && _j == yDim - 1)
            {
                list.Add(_parentMatrix[_i + 1, _j]);
                list.Add(_parentMatrix[_i + 1, _j - 1]);
                list.Add(_parentMatrix[_i, _j - 1]);
            }
            else if (_i == xDim - 1 && _j == 0)
            {
                list.Add(_parentMatrix[_i - 1, _j]);
                list.Add(_parentMatrix[_i - 1, _j + 1]);
                list.Add(_parentMatrix[_i, _j + 1]);
            }
            else if (_i == xDim - 1 && _j == yDim - 1)
            {
                list.Add(_parentMatrix[_i - 1, _j - 1]);
                list.Add(_parentMatrix[_i, _j - 1]);
                list.Add(_parentMatrix[_i - 1, _j]);
            }
            else
            {
                if (_i == 0)
                {
                    list.Add(_parentMatrix[_i, _j - 1]);
                    list.Add(_parentMatrix[_i, _j + 1]);

                    list.Add(_parentMatrix[_i + 1, _j - 1]);
                    list.Add(_parentMatrix[_i + 1, _j]);
                    list.Add(_parentMatrix[_i + 1, _j + 1]);
                }
                else if (_i == xDim - 1)
                {
                    list.Add(_parentMatrix[_i - 1, _j - 1]);
                    list.Add(_parentMatrix[_i - 1, _j]);
                    list.Add(_parentMatrix[_i - 1, _j + 1]);

                    list.Add(_parentMatrix[_i, _j - 1]);
                    list.Add(_parentMatrix[_i, _j + 1]);                    
                }
                else if (_j == 0)
                {
                    list.Add(_parentMatrix[_i - 1, _j]);
                    list.Add(_parentMatrix[_i - 1, _j + 1]);
                    
                    list.Add(_parentMatrix[_i, _j + 1]);
                    
                    list.Add(_parentMatrix[_i + 1, _j]);
                    list.Add(_parentMatrix[_i + 1, _j + 1]);
                }
                else if (_j == yDim - 1)
                {

                    list.Add(_parentMatrix[_i - 1, _j - 1]);
                    list.Add(_parentMatrix[_i - 1, _j]);

                    list.Add(_parentMatrix[_i, _j - 1]);

                    list.Add(_parentMatrix[_i + 1, _j - 1]);
                    list.Add(_parentMatrix[_i + 1, _j]);
                }
                else
                {
                    list.Add(_parentMatrix[_i - 1, _j - 1]);
                    list.Add(_parentMatrix[_i - 1, _j]);
                    list.Add(_parentMatrix[_i - 1, _j + 1]);

                    list.Add(_parentMatrix[_i, _j - 1]);
                    list.Add(_parentMatrix[_i, _j + 1]);

                    list.Add(_parentMatrix[_i + 1, _j - 1]);
                    list.Add(_parentMatrix[_i + 1, _j]);
                    list.Add(_parentMatrix[_i + 1, _j + 1]);
                }
            }
            return list;
        }


        private void btn_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && clickCount == 0)
            {
                this.Controls[0].Visible = false;
                //TODO: Reveal everything
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (clickCount == 0)
                {
                    this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\flag.png");
                }
                else if (clickCount == 1)
                {
                    this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\q.png");
                    ((MainForm)(this.ParentForm)).Flagcount++;
                    
                }
                else
                {
                    this.btn.BackgroundImage = Image.FromFile(respath + "\\res\\empty.png");
                    ((MainForm)(this.ParentForm)).Flagcount--;
                    clickCount = -1;
                }

                clickCount++;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                //TODO: Reveal all adjacent 
            }
        }
    }
}
