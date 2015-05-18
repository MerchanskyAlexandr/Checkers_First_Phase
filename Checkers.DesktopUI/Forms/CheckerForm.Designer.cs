namespace Checkers.DesktopUI
{
    partial class CheckerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newtGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.multyplayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucDesk = new Checkers.DesktopUI.Controls.ucDesk();
            this.gameInfoUI = new Checkers.DesktopUI.Controls.ucGameInfo();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtGameToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newtGameToolStripMenuItem
            // 
            this.newtGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePlayerToolStripMenuItem,
            this.toolStripMenuItem2,
            this.multyplayerToolStripMenuItem});
            this.newtGameToolStripMenuItem.Name = "newtGameToolStripMenuItem";
            this.newtGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newtGameToolStripMenuItem.Text = "New  Game";
            // 
            // singlePlayerToolStripMenuItem
            // 
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.singlePlayerToolStripMenuItem.Text = "SinglePlayer";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.singlePlayerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
            // 
            // multyplayerToolStripMenuItem
            // 
            this.multyplayerToolStripMenuItem.Name = "multyplayerToolStripMenuItem";
            this.multyplayerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.multyplayerToolStripMenuItem.Text = "MultyPlayer";
            this.multyplayerToolStripMenuItem.Click += new System.EventHandler(this.multyPlayerToolStripMenuItem_Click);
            // 
            // ucDesk
            // 
            this.ucDesk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDesk.GameInfo = null;
            this.ucDesk.LastRemoteCheckerPanel = null;
            this.ucDesk.Location = new System.Drawing.Point(0, 24);
            this.ucDesk.Name = "ucDesk";
            this.ucDesk.Size = new System.Drawing.Size(500, 497);
            this.ucDesk.TabIndex = 4;
            this.ucDesk.TheGame = null;
            // 
            // gameInfoUI
            // 
            this.gameInfoUI.DeskUI = null;
            this.gameInfoUI.Dock = System.Windows.Forms.DockStyle.Right;
            this.gameInfoUI.Location = new System.Drawing.Point(500, 24);
            this.gameInfoUI.Name = "gameInfoUI";
            this.gameInfoUI.Size = new System.Drawing.Size(150, 497);
            this.gameInfoUI.TabIndex = 3;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // CheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 521);
            this.Controls.Add(this.ucDesk);
            this.Controls.Add(this.gameInfoUI);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(666, 559);
            this.MinimumSize = new System.Drawing.Size(666, 559);
            this.Name = "CheckerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECKERS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newtGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem multyplayerToolStripMenuItem;
        private Controls.ucGameInfo gameInfoUI;
        private Controls.ucDesk ucDesk;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

