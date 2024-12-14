namespace COMP1551_Part_1
{
    partial class Quiz
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblContent = new Label();
            label1 = new Label();
            btnCreateQuestions = new Button();
            btnPlay = new Button();
            btnRanking = new Button();
            btnShowQuestion = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = SystemColors.ActiveBorder;
            lblContent.Font = new Font("Arial", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblContent.ForeColor = Color.White;
            lblContent.Location = new Point(10, 10);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(193, 40);
            lblContent.TabIndex = 0;
            lblContent.Text = "Quiz Game";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DeepSkyBlue;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.GhostWhite;
            label1.Location = new Point(250, 100);
            label1.Name = "label1";
            label1.Size = new Size(280, 32);
            label1.TabIndex = 1;
            label1.Text = "Choose option below:";
            // 
            // btnCreateQuestions
            // 
            btnCreateQuestions.BackColor = Color.DodgerBlue;
            btnCreateQuestions.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreateQuestions.ForeColor = Color.White;
            btnCreateQuestions.Location = new Point(90, 150);
            btnCreateQuestions.Name = "btnCreateQuestions";
            btnCreateQuestions.Size = new Size(300, 50);
            btnCreateQuestions.TabIndex = 3;
            btnCreateQuestions.Text = "Create a question";
            btnCreateQuestions.UseVisualStyleBackColor = false;
            btnCreateQuestions.Click += btnCreateQuestions_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.DodgerBlue;
            btnPlay.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(430, 250);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(300, 50);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play a Game";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnRanking
            // 
            btnRanking.BackColor = Color.DodgerBlue;
            btnRanking.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRanking.ForeColor = Color.White;
            btnRanking.Location = new Point(90, 350);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(300, 50);
            btnRanking.TabIndex = 11;
            btnRanking.Text = "Top Ranking";
            btnRanking.UseVisualStyleBackColor = false;
            btnRanking.Click += btnRanking_Click;
            // 
            // btnShowQuestion
            // 
            btnShowQuestion.BackColor = Color.DodgerBlue;
            btnShowQuestion.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowQuestion.ForeColor = Color.White;
            btnShowQuestion.Location = new Point(430, 450);
            btnShowQuestion.Name = "btnShowQuestion";
            btnShowQuestion.Size = new Size(300, 50);
            btnShowQuestion.TabIndex = 12;
            btnShowQuestion.Text = "Show Question";
            btnShowQuestion.UseVisualStyleBackColor = false;
            btnShowQuestion.Click += btnShowQuestion_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Universe_themed_home_background;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 655);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // Quiz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 245, 255);
            ClientSize = new Size(802, 653);
            Controls.Add(btnShowQuestion);
            Controls.Add(btnRanking);
            Controls.Add(btnPlay);
            Controls.Add(btnCreateQuestions);
            Controls.Add(label1);
            Controls.Add(lblContent);
            Controls.Add(pictureBox1);
            Name = "Quiz";
            Text = "Quiz";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContent;
        private Label label1;
        private Button btnCreateQuestions;
        private Button btnPlay;
        private Button btnRanking;
        private Button btnShowQuestion;
        private PictureBox pictureBox1;
    }
}
