namespace Checkers.DesktopUI.Controls
{
    partial class ucGameInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbWhite = new System.Windows.Forms.PictureBox();
            this.pbBlack = new System.Windows.Forms.PictureBox();
            this.lbWhiteCount = new System.Windows.Forms.Label();
            this.lbBlackCount = new System.Windows.Forms.Label();
            this.chboxSound = new System.Windows.Forms.CheckBox();
            this.pboxCurrentPlayer = new System.Windows.Forms.PictureBox();
            this.lblGameType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCurrentPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWhite
            // 
            this.pbWhite.Image = global::Checkers.DesktopUI.Properties.Resources.yellow_checkers;
            this.pbWhite.Location = new System.Drawing.Point(17, 48);
            this.pbWhite.Name = "pbWhite";
            this.pbWhite.Size = new System.Drawing.Size(30, 30);
            this.pbWhite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWhite.TabIndex = 0;
            this.pbWhite.TabStop = false;
            // 
            // pbBlack
            // 
            this.pbBlack.Image = global::Checkers.DesktopUI.Properties.Resources.black_checkers;
            this.pbBlack.Location = new System.Drawing.Point(17, 95);
            this.pbBlack.Name = "pbBlack";
            this.pbBlack.Size = new System.Drawing.Size(30, 30);
            this.pbBlack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBlack.TabIndex = 1;
            this.pbBlack.TabStop = false;
            // 
            // lbWhiteCount
            // 
            this.lbWhiteCount.AutoSize = true;
            this.lbWhiteCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWhiteCount.Location = new System.Drawing.Point(65, 53);
            this.lbWhiteCount.Name = "lbWhiteCount";
            this.lbWhiteCount.Size = new System.Drawing.Size(34, 25);
            this.lbWhiteCount.TabIndex = 2;
            this.lbWhiteCount.Text = "12";
            // 
            // lbBlackCount
            // 
            this.lbBlackCount.AutoSize = true;
            this.lbBlackCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlackCount.Location = new System.Drawing.Point(65, 100);
            this.lbBlackCount.Name = "lbBlackCount";
            this.lbBlackCount.Size = new System.Drawing.Size(34, 25);
            this.lbBlackCount.TabIndex = 3;
            this.lbBlackCount.Text = "12";
            // 
            // chboxSound
            // 
            this.chboxSound.AutoSize = true;
            this.chboxSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chboxSound.Location = new System.Drawing.Point(17, 282);
            this.chboxSound.Name = "chboxSound";
            this.chboxSound.Size = new System.Drawing.Size(91, 21);
            this.chboxSound.TabIndex = 5;
            this.chboxSound.Text = "Sound On";
            this.chboxSound.UseVisualStyleBackColor = true;
            this.chboxSound.CheckedChanged += new System.EventHandler(this.chboxSound_CheckedChanged);
            // 
            // pboxCurrentPlayer
            // 
            this.pboxCurrentPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxCurrentPlayer.Location = new System.Drawing.Point(17, 163);
            this.pboxCurrentPlayer.Name = "pboxCurrentPlayer";
            this.pboxCurrentPlayer.Size = new System.Drawing.Size(82, 75);
            this.pboxCurrentPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxCurrentPlayer.TabIndex = 6;
            this.pboxCurrentPlayer.TabStop = false;
            // 
            // lblGameType
            // 
            this.lblGameType.AutoSize = true;
            this.lblGameType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGameType.Location = new System.Drawing.Point(17, 14);
            this.lblGameType.Name = "lblGameType";
            this.lblGameType.Size = new System.Drawing.Size(0, 20);
            this.lblGameType.TabIndex = 7;
            // 
            // ucGameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblGameType);
            this.Controls.Add(this.pboxCurrentPlayer);
            this.Controls.Add(this.chboxSound);
            this.Controls.Add(this.lbBlackCount);
            this.Controls.Add(this.lbWhiteCount);
            this.Controls.Add(this.pbBlack);
            this.Controls.Add(this.pbWhite);
            this.Name = "ucGameInfo";
            this.Size = new System.Drawing.Size(130, 323);
            ((System.ComponentModel.ISupportInitialize)(this.pbWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCurrentPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWhite;
        private System.Windows.Forms.PictureBox pbBlack;
        private System.Windows.Forms.Label lbWhiteCount;
        private System.Windows.Forms.Label lbBlackCount;
        private System.Windows.Forms.CheckBox chboxSound;
        private System.Windows.Forms.PictureBox pboxCurrentPlayer;
        private System.Windows.Forms.Label lblGameType;
    }
}
