namespace COMP1551_Part_1
{
    partial class Play
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
            lblContent = new Label();
            btnBack = new Button();
            pnlAnswerOptions = new Panel();
            btnSubmit = new Button();
            lblQuestion = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = Color.White;
            lblContent.Font = new Font("Arial", 19.8000011F, FontStyle.Bold);
            lblContent.Location = new Point(12, 9);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(193, 40);
            lblContent.TabIndex = 1;
            lblContent.Text = "Quiz Game";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 204, 204);
            btnBack.Font = new Font("Arial", 13.8F);
            btnBack.Location = new Point(12, 67);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 50);
            btnBack.TabIndex = 2;
            btnBack.Text = "Exit";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pnlAnswerOptions
            // 
            pnlAnswerOptions.BackColor = Color.White;
            pnlAnswerOptions.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlAnswerOptions.Location = new Point(12, 163);
            pnlAnswerOptions.Name = "pnlAnswerOptions";
            pnlAnswerOptions.Size = new Size(776, 222);
            pnlAnswerOptions.TabIndex = 10;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(204, 255, 204);
            btnSubmit.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(330, 390);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(124, 50);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(12, 130);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(168, 23);
            lblQuestion.TabIndex = 11;
            lblQuestion.Text = "Question Content:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.A_darker_universe_themed_picture_with_a_pen_marker;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // Play
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 245, 255);
            ClientSize = new Size(802, 453);
            Controls.Add(lblQuestion);
            Controls.Add(btnSubmit);
            Controls.Add(pnlAnswerOptions);
            Controls.Add(lblContent);
            Controls.Add(btnBack);
            Controls.Add(pictureBox1);
            Name = "Play";
            Text = "Play Questions";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContent;
        private Button btnBack;
        private Panel pnlAnswerOptions;
        private Button btnSubmit;
        private Label lblQuestion;
        private PictureBox pictureBox1;
    }
}