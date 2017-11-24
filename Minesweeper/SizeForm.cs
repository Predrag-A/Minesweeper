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
    public partial class SizeForm : Form
    {

        #region Properties

        public int XResult
        {
            get;
            set;
        }

        public int YResult
        {
            get;
            set;
        }

        public int MineResult
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public SizeForm()
        {
            InitializeComponent();
            XResult = 9;
            YResult = 9;
            MineResult = 10;
        }

        #endregion

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbarWidth_ValueChanged(object sender, EventArgs e)
        {
            txtWidth.Text = tbarWidth.Value.ToString();
            txtMines.Text = tbarMines.Value.ToString();
            tbarMines.Maximum = (tbarHeight.Value - 1) * (tbarWidth.Value - 1);
            XResult = tbarWidth.Value;
        }

        private void tbarHeight_ValueChanged(object sender, EventArgs e)
        {
            txtHeight.Text = tbarHeight.Value.ToString();
            txtMines.Text = tbarMines.Value.ToString();
            tbarMines.Maximum = (tbarHeight.Value - 1) * (tbarWidth.Value - 1);
            YResult = tbarHeight.Value;
        }

        private void tbarMines_ValueChanged(object sender, EventArgs e)
        {
            if (tbarMines.Value > ((tbarHeight.Value - 1) * (tbarWidth.Value - 1)))
                tbarMines.Value = (tbarHeight.Value - 1) * (tbarWidth.Value - 1);
            txtMines.Text = tbarMines.Value.ToString();
            MineResult = tbarMines.Value;
        }

        #endregion

    }
}
