
namespace Chess_Game
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnTwoPlayer = new Guna.UI2.WinForms.Guna2Button();
            this.btnPlayWithAi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnTwoPlayer
            // 
            this.btnTwoPlayer.BorderRadius = 25;
            this.btnTwoPlayer.BorderThickness = 2;
            this.btnTwoPlayer.CheckedState.Parent = this.btnTwoPlayer;
            this.btnTwoPlayer.CustomImages.Parent = this.btnTwoPlayer;
            this.btnTwoPlayer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(149)))), ((int)(((byte)(86)))));
            this.btnTwoPlayer.Font = new System.Drawing.Font("Showcard Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwoPlayer.ForeColor = System.Drawing.Color.White;
            this.btnTwoPlayer.HoverState.Parent = this.btnTwoPlayer;
            this.btnTwoPlayer.Location = new System.Drawing.Point(53, 44);
            this.btnTwoPlayer.Name = "btnTwoPlayer";
            this.btnTwoPlayer.ShadowDecoration.Parent = this.btnTwoPlayer;
            this.btnTwoPlayer.Size = new System.Drawing.Size(154, 56);
            this.btnTwoPlayer.TabIndex = 0;
            this.btnTwoPlayer.Text = "Two Player";
            this.btnTwoPlayer.Click += new System.EventHandler(this.btnTwoPlayer_Click);
            // 
            // btnPlayWithAi
            // 
            this.btnPlayWithAi.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayWithAi.BorderRadius = 25;
            this.btnPlayWithAi.BorderThickness = 2;
            this.btnPlayWithAi.CheckedState.Parent = this.btnPlayWithAi;
            this.btnPlayWithAi.CustomImages.Parent = this.btnPlayWithAi;
            this.btnPlayWithAi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.btnPlayWithAi.Font = new System.Drawing.Font("Showcard Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayWithAi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlayWithAi.HoverState.Parent = this.btnPlayWithAi;
            this.btnPlayWithAi.Location = new System.Drawing.Point(53, 132);
            this.btnPlayWithAi.Name = "btnPlayWithAi";
            this.btnPlayWithAi.ShadowDecoration.Parent = this.btnPlayWithAi;
            this.btnPlayWithAi.Size = new System.Drawing.Size(154, 56);
            this.btnPlayWithAi.TabIndex = 1;
            this.btnPlayWithAi.Text = "Play with Ai";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 25;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button1.Font = new System.Drawing.Font("Showcard Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(53, 223);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(154, 56);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Follow Me x";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 291);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnPlayWithAi);
            this.Controls.Add(this.btnTwoPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTwoPlayer;
        private Guna.UI2.WinForms.Guna2Button btnPlayWithAi;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}