using System.ComponentModel;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class SizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbarWidth = new System.Windows.Forms.TrackBar();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.tbarHeight = new System.Windows.Forms.TrackBar();
            this.lblMines = new System.Windows.Forms.Label();
            this.tbarMines = new System.Windows.Forms.TrackBar();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtMines = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMines)).BeginInit();
            this.SuspendLayout();
            // 
            // tbarWidth
            // 
            this.tbarWidth.Location = new System.Drawing.Point(12, 25);
            this.tbarWidth.Maximum = 30;
            this.tbarWidth.Minimum = 9;
            this.tbarWidth.Name = "tbarWidth";
            this.tbarWidth.Size = new System.Drawing.Size(216, 45);
            this.tbarWidth.TabIndex = 0;
            this.tbarWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarWidth.Value = 9;
            this.tbarWidth.ValueChanged += new System.EventHandler(this.tbarWidth_ValueChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(12, 9);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(12, 73);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height";
            // 
            // tbarHeight
            // 
            this.tbarHeight.Location = new System.Drawing.Point(12, 89);
            this.tbarHeight.Maximum = 24;
            this.tbarHeight.Minimum = 9;
            this.tbarHeight.Name = "tbarHeight";
            this.tbarHeight.Size = new System.Drawing.Size(216, 45);
            this.tbarHeight.TabIndex = 2;
            this.tbarHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarHeight.Value = 9;
            this.tbarHeight.ValueChanged += new System.EventHandler(this.tbarHeight_ValueChanged);
            // 
            // lblMines
            // 
            this.lblMines.AutoSize = true;
            this.lblMines.Location = new System.Drawing.Point(12, 142);
            this.lblMines.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(35, 13);
            this.lblMines.TabIndex = 5;
            this.lblMines.Text = "Mines";
            // 
            // tbarMines
            // 
            this.tbarMines.Location = new System.Drawing.Point(12, 158);
            this.tbarMines.Maximum = 64;
            this.tbarMines.Minimum = 10;
            this.tbarMines.Name = "tbarMines";
            this.tbarMines.Size = new System.Drawing.Size(216, 45);
            this.tbarMines.TabIndex = 4;
            this.tbarMines.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarMines.Value = 10;
            this.tbarMines.ValueChanged += new System.EventHandler(this.tbarMines_ValueChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.CausesValidation = false;
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(232, 25);
            this.txtWidth.Multiline = true;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(45, 30);
            this.txtWidth.TabIndex = 6;
            this.txtWidth.Text = "9";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(232, 89);
            this.txtHeight.Multiline = true;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(45, 30);
            this.txtHeight.TabIndex = 7;
            this.txtHeight.Text = "9";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMines
            // 
            this.txtMines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMines.Location = new System.Drawing.Point(232, 158);
            this.txtMines.Multiline = true;
            this.txtMines.Name = "txtMines";
            this.txtMines.ReadOnly = true;
            this.txtMines.Size = new System.Drawing.Size(45, 30);
            this.txtMines.TabIndex = 8;
            this.txtMines.Text = "10";
            this.txtMines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "New Game";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMines);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblMines);
            this.Controls.Add(this.tbarMines);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.tbarHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.tbarWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SizeForm";
            this.Text = "Set Size";
            ((System.ComponentModel.ISupportInitialize)(this.tbarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackBar tbarWidth;
        private Label lblWidth;
        private Label lblHeight;
        private TrackBar tbarHeight;
        private Label lblMines;
        private TrackBar tbarMines;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private TextBox txtMines;
        private Button btnOK;
        private Button btnCancel;
    }
}