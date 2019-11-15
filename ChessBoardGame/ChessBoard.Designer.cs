namespace ChessBoardGame
{
    partial class ChessBoard
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
            this.BlackWins = new System.Windows.Forms.Label();
            this.WhiteWins = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BlackWins
            // 
            this.BlackWins.AutoSize = true;
            this.BlackWins.BackColor = System.Drawing.Color.Transparent;
            this.BlackWins.Font = new System.Drawing.Font("Microsoft Himalaya", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackWins.Location = new System.Drawing.Point(210, 264);
            this.BlackWins.Name = "BlackWins";
            this.BlackWins.Size = new System.Drawing.Size(371, 96);
            this.BlackWins.TabIndex = 0;
            this.BlackWins.Text = "Black Wins!";
            this.BlackWins.Visible = false;
            // 
            // WhiteWins
            // 
            this.WhiteWins.AutoSize = true;
            this.WhiteWins.BackColor = System.Drawing.Color.Transparent;
            this.WhiteWins.Font = new System.Drawing.Font("Microsoft Himalaya", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteWins.Location = new System.Drawing.Point(202, 264);
            this.WhiteWins.Name = "WhiteWins";
            this.WhiteWins.Size = new System.Drawing.Size(379, 96);
            this.WhiteWins.TabIndex = 1;
            this.WhiteWins.Text = "White Wins!";
            this.WhiteWins.Visible = false;
            // 
            // ChessBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 801);
            this.Controls.Add(this.WhiteWins);
            this.Controls.Add(this.BlackWins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChessBoard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BlackWins;
        private System.Windows.Forms.Label WhiteWins;
    }
}

