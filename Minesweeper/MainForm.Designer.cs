namespace Minesweeper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easy9x9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medium16x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.easy9x9ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.medium16x16ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expert16x30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFlag = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easy9x9ToolStripMenuItem,
            this.medium16x16ToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // easy9x9ToolStripMenuItem
            // 
            this.easy9x9ToolStripMenuItem.Name = "easy9x9ToolStripMenuItem";
            this.easy9x9ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.easy9x9ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.easy9x9ToolStripMenuItem.Text = "Easy 9x9";
            this.easy9x9ToolStripMenuItem.Click += new System.EventHandler(this.easy9x9ToolStripMenuItem_Click);
            // 
            // medium16x16ToolStripMenuItem
            // 
            this.medium16x16ToolStripMenuItem.Name = "medium16x16ToolStripMenuItem";
            this.medium16x16ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.medium16x16ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.medium16x16ToolStripMenuItem.Text = "Medium 16x16";
            this.medium16x16ToolStripMenuItem.Click += new System.EventHandler(this.medium16x16ToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.expertToolStripMenuItem.Text = "Expert 16x30";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.customToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.customToolStripMenuItem.Text = "Custom";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(13, 296);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(88, 24);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "00:00:00";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem1});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(271, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem1
            // 
            this.gameToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.endToolStripMenuItem,
            this.toolStripMenuItem1,
            this.easy9x9ToolStripMenuItem1,
            this.medium16x16ToolStripMenuItem1,
            this.expert16x30ToolStripMenuItem,
            this.customToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem1});
            this.gameToolStripMenuItem1.Name = "gameToolStripMenuItem1";
            this.gameToolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem1.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.endToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.endToolStripMenuItem.Text = "End";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // easy9x9ToolStripMenuItem1
            // 
            this.easy9x9ToolStripMenuItem1.Name = "easy9x9ToolStripMenuItem1";
            this.easy9x9ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.easy9x9ToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.easy9x9ToolStripMenuItem1.Text = "Easy 9x9";
            this.easy9x9ToolStripMenuItem1.Click += new System.EventHandler(this.easy9x9ToolStripMenuItem_Click);
            // 
            // medium16x16ToolStripMenuItem1
            // 
            this.medium16x16ToolStripMenuItem1.Name = "medium16x16ToolStripMenuItem1";
            this.medium16x16ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.medium16x16ToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.medium16x16ToolStripMenuItem1.Text = "Medium 16x16";
            this.medium16x16ToolStripMenuItem1.Click += new System.EventHandler(this.medium16x16ToolStripMenuItem_Click);
            // 
            // expert16x30ToolStripMenuItem
            // 
            this.expert16x30ToolStripMenuItem.Name = "expert16x30ToolStripMenuItem";
            this.expert16x30ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.expert16x30ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.expert16x30ToolStripMenuItem.Text = "Expert 16x30";
            this.expert16x30ToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem1
            // 
            this.customToolStripMenuItem1.Name = "customToolStripMenuItem1";
            this.customToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.customToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.customToolStripMenuItem1.Text = "Custom";
            this.customToolStripMenuItem1.Click += new System.EventHandler(this.customToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // lblFlag
            // 
            this.lblFlag.AutoSize = true;
            this.lblFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlag.Location = new System.Drawing.Point(238, 288);
            this.lblFlag.Name = "lblFlag";
            this.lblFlag.Size = new System.Drawing.Size(21, 24);
            this.lblFlag.TabIndex = 3;
            this.lblFlag.Text = "0";
            // 
            // sfd
            // 
            this.sfd.Filter = "XML files (*.xml)|*.txt|All files (*.*)|*.*";
            // 
            // ofd
            // 
            this.ofd.Filter = "XML files (*.xml)|*.txt|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(271, 321);
            this.Controls.Add(this.lblFlag);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Minesweeper";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easy9x9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medium16x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem easy9x9ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem medium16x16ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem expert16x30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.Label lblFlag;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}

