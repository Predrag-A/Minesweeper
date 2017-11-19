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

        public Data.Panel Panel { get => _p; set => _p = value; }
        public Cell[,] ParentMatrix { get => _parentMatrix; set => _parentMatrix = value; }
        public int XCoord { get => _i; set => _i = value; }
        public int YCoord { get => _j; set => _j = value; }

        #endregion

        #region Constructors

        public Cell()
        {
            InitializeComponent();
            this.Size = new Size(25, 25);
        }

        #endregion

        #region Methods

        public void SetField()
        {
            if (_p.Type == Data.Type.Empty)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\emptyBG.png");
            else if (_p.Type == Data.Type.Mine)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\mine.png");
            else if (_p.Type == Data.Type.Number)
                this.BackgroundImage = Image.FromFile(respath + "\\res\\" + _p.Value.ToString() + ".png");
        }

        public void Reveal()
        {
            btn.Visible = false;
            this.Panel.Revealed = true;
        }

        //Some long shit
        public List<Cell> GetNeighbors()
        {
            int xDim = ((MainForm)this.ParentForm).X;
            int yDim = ((MainForm)this.ParentForm).Y;
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

        void RevealEmpty(Cell c)
        {
            List<Cell> list = c.GetNeighbors();
            foreach(var cell in list)
            {
                if (cell.Panel.Type == Data.Type.Empty && !cell.Panel.Flagged) {
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
                        else if(_parentMatrix[i, j].Panel.Flagged)
                        {
                            _parentMatrix[i,j].BackgroundImage = Image.FromFile(respath + "\\res\\mineWrong.png");
                            _parentMatrix[i, j].Reveal();
                        }
                        else
                            _parentMatrix[i, j].Reveal();

                            
                    }
        }
        
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
            if (((MainForm)this.ParentForm).FirstClick)
            {
                ((MainForm)this.ParentForm).Time = DateTime.Now;
                ((MainForm)this.ParentForm).timer.Start();
            }
            if (e.Button == MouseButtons.Left && clickCount == 0)
            {
                if (((MainForm)this.ParentForm).FirstClick && this.Panel.Type == Data.Type.Mine)
                {
                    ((MainForm)this.ParentForm).FirstClick = false;


                    int count = this.setValue();                    

                    if (count == 0)
                    {
                        this.Panel.Type = Data.Type.Empty;
                        this.Panel.Value = 0;
                    }
                    else
                    {
                        this.Panel.Type = Data.Type.Number;
                        this.Panel.Value = count;
                    }
                    this.SetField();

                    var list = this.GetNeighbors();
                    foreach (var c in list)
                    {
                        c.setValue();
                        c.SetField();
                    }
                    if(count == 0)
                        RevealEmpty(this);

                                        
                    int indexX, indexY=0;
                    if (_i == 0 && _j == 0)
                        indexX = 1;

                    else
                        indexX = 0;
                    

                    while (_parentMatrix[indexX, indexY].Panel.Type == Data.Type.Mine)
                    {
                        indexX++;
                        if(indexX >= ((MainForm)this.ParentForm).X)
                        {
                            indexX = 0;
                            indexY++;
                        }
                        if(indexX== _i && indexY == _j)
                        {
                            indexX++;
                            if (indexX >= ((MainForm)this.ParentForm).X)
                            {
                                indexX = 0;
                                indexY++;
                            }
                        }
                    }
                    _parentMatrix[indexX, indexY].Panel.Type = Data.Type.Mine;
                    _parentMatrix[indexX, indexY].Panel.Value = 0;
                    _parentMatrix[indexX, indexY].SetField();

                    var list0 = _parentMatrix[indexX, indexY].GetNeighbors();
                    foreach(var c in list0)
                    {
                        c.setValue();
                        c.SetField();
                    }
                    Reveal(); 
                }

                else
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

            }
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

    #endregion

    }
}
