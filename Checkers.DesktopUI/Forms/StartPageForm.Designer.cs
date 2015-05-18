namespace Checkers.DesktopUI
{
    partial class StartPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPageForm));
            this.btnSinglePlayer = new System.Windows.Forms.Button();
            this.btnMultyPlayer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.Font = new System.Drawing.Font("Microsoft MHei", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSinglePlayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSinglePlayer.Location = new System.Drawing.Point(138, 101);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.Size = new System.Drawing.Size(195, 48);
            this.btnSinglePlayer.TabIndex = 0;
            this.btnSinglePlayer.Text = "Single Player";
            this.btnSinglePlayer.UseVisualStyleBackColor = true;
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            // 
            // btnMultyPlayer
            // 
            this.btnMultyPlayer.Font = new System.Drawing.Font("Microsoft MHei", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMultyPlayer.Location = new System.Drawing.Point(138, 181);
            this.btnMultyPlayer.Name = "btnMultyPlayer";
            this.btnMultyPlayer.Size = new System.Drawing.Size(195, 48);
            this.btnMultyPlayer.TabIndex = 1;
            this.btnMultyPlayer.Text = "Multi Player";
            this.btnMultyPlayer.UseVisualStyleBackColor = true;
            this.btnMultyPlayer.Click += new System.EventHandler(this.btnMultyPlayer_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft MHei", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(138, 263);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(195, 48);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // StartPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Checkers.DesktopUI.Properties.Resources.Checkers_Start_2;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMultyPlayer);
            this.Controls.Add(this.btnSinglePlayer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECKERS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSinglePlayer;
        private System.Windows.Forms.Button btnMultyPlayer;
        private System.Windows.Forms.Button btnExit;
    }
}