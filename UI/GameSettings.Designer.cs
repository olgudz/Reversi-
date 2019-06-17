namespace UI
{
    public partial class GameSettings 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonOnePlayer = new System.Windows.Forms.Button();
            this.buttonTwoPlayers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBoardSize.Location = new System.Drawing.Point(41, 21);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(451, 51);
            this.buttonBoardSize.TabIndex = 0;
            this.buttonBoardSize.Text = "Board Size: 6X6 (click to increase)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonOnePlayer
            // 
            this.buttonOnePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOnePlayer.Location = new System.Drawing.Point(41, 92);
            this.buttonOnePlayer.Name = "buttonOnePlayer";
            this.buttonOnePlayer.Size = new System.Drawing.Size(211, 55);
            this.buttonOnePlayer.TabIndex = 1;
            this.buttonOnePlayer.Text = "Play against the computer";
            this.buttonOnePlayer.UseVisualStyleBackColor = true;
            this.buttonOnePlayer.Click += new System.EventHandler(this.buttonOnePlayer_Click);
            // 
            // buttonTwoPlayers
            // 
            this.buttonTwoPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTwoPlayers.Location = new System.Drawing.Point(258, 92);
            this.buttonTwoPlayers.Name = "buttonTwoPlayers";
            this.buttonTwoPlayers.Size = new System.Drawing.Size(234, 55);
            this.buttonTwoPlayers.TabIndex = 2;
            this.buttonTwoPlayers.Text = "Play against your friend";
            this.buttonTwoPlayers.UseVisualStyleBackColor = true;
            this.buttonTwoPlayers.Click += new System.EventHandler(this.buttonTwoPlayers_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(538, 177);
            this.Controls.Add(this.buttonTwoPlayers);
            this.Controls.Add(this.buttonOnePlayer);
            this.Controls.Add(this.buttonBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonOnePlayer;
        private System.Windows.Forms.Button buttonTwoPlayers;
    }
}