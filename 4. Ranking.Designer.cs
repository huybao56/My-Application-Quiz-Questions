namespace COMP1551_Part_1
{
    partial class Ranking
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
            listBoxPlayer = new ListBox();
            lblContent = new Label();
            btnBack = new Button();
            btnResert = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBoxPlayer
            // 
            listBoxPlayer.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxPlayer.FormattingEnabled = true;
            listBoxPlayer.ItemHeight = 27;
            listBoxPlayer.Location = new Point(12, 123);
            listBoxPlayer.Name = "listBoxPlayer";
            listBoxPlayer.Size = new Size(776, 301);
            listBoxPlayer.TabIndex = 0;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = SystemColors.ActiveBorder;
            lblContent.Font = new Font("Arial", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblContent.ForeColor = Color.White;
            lblContent.Location = new Point(12, 9);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(209, 40);
            lblContent.TabIndex = 7;
            lblContent.Text = "Top Players";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 204, 204);
            btnBack.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(12, 67);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 50);
            btnBack.TabIndex = 9;
            btnBack.Text = "Return";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnResert
            // 
            btnResert.BackColor = Color.DodgerBlue;
            btnResert.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResert.ForeColor = Color.White;
            btnResert.Location = new Point(689, 78);
            btnResert.Name = "btnResert";
            btnResert.Size = new Size(99, 39);
            btnResert.TabIndex = 11;
            btnResert.Text = "Resert";
            btnResert.UseVisualStyleBackColor = false;
            btnResert.Click += btnResert_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Universe_with_alien_friendly_at_top_players;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(815, 455);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // Ranking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 245, 255);
            ClientSize = new Size(802, 453);
            Controls.Add(btnResert);
            Controls.Add(btnBack);
            Controls.Add(lblContent);
            Controls.Add(listBoxPlayer);
            Controls.Add(pictureBox1);
            Name = "Ranking";
            Text = "Top Ranking";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxPlayer;
        private Label lblContent;
        private Button btnBack;
        private Button btnResert;
        private PictureBox pictureBox1;
    }
}