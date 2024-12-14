namespace COMP1551_Part_1
{
    partial class TypeOfQuestions
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
            label1 = new Label();
            tbQuestion = new TextBox();
            btnCreate = new Button();
            btnBack = new Button();
            lblContent = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15F);
            label1.Location = new Point(153, 77);
            label1.Name = "label1";
            label1.Size = new Size(228, 28);
            label1.TabIndex = 0;
            label1.Text = "Questions Content:";
            // 
            // tbQuestion
            // 
            tbQuestion.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbQuestion.Location = new Point(118, 108);
            tbQuestion.Name = "tbQuestion";
            tbQuestion.Size = new Size(670, 34);
            tbQuestion.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.PaleGreen;
            btnCreate.Font = new Font("Arial", 13.8F, FontStyle.Bold);
            btnCreate.ForeColor = Color.Black;
            btnCreate.Location = new Point(223, 388);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(124, 50);
            btnCreate.TabIndex = 10;
            btnCreate.Text = "Save";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 204, 204);
            btnBack.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(12, 67);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 50);
            btnBack.TabIndex = 18;
            btnBack.Text = "Return";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = SystemColors.ActiveBorder;
            lblContent.Font = new Font("Arial", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblContent.ForeColor = Color.White;
            lblContent.Location = new Point(12, 9);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(285, 40);
            lblContent.TabIndex = 19;
            lblContent.Text = "Multiple Choices";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Universe_themed_background_for_a_quiz_game;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(815, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // TypeOfQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 245, 255);
            ClientSize = new Size(802, 453);
            Controls.Add(lblContent);
            Controls.Add(btnBack);
            Controls.Add(btnCreate);
            Controls.Add(tbQuestion);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "TypeOfQuestions";
            Text = "Questions";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbQuestion;
        private Button btnCreate;
        private Button btnBack;
        private Label lblContent;
        private PictureBox pictureBox1;
    }
}