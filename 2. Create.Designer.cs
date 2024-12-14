namespace COMP1551_Part_1
{
    partial class Create
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
            lblContent = new Label();
            btnBack = new Button();
            cbTypeQuestion = new ComboBox();
            btnConfirm = new Button();
            lblError = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DeepSkyBlue;
            label1.Font = new Font("Arial", 19.8000011F);
            label1.Location = new Point(142, 78);
            label1.Name = "label1";
            label1.Size = new Size(437, 39);
            label1.TabIndex = 0;
            label1.Text = "Choose Your Type Question:";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = SystemColors.ActiveBorder;
            lblContent.Font = new Font("Arial", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblContent.ForeColor = Color.White;
            lblContent.Location = new Point(12, 9);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(193, 40);
            lblContent.TabIndex = 4;
            lblContent.Text = "Quiz Game";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 204, 204);
            btnBack.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(12, 67);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 50);
            btnBack.TabIndex = 5;
            btnBack.Text = "Return";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // cbTypeQuestion
            // 
            cbTypeQuestion.BackColor = Color.WhiteSmoke;
            cbTypeQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeQuestion.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbTypeQuestion.FormattingEnabled = true;
            cbTypeQuestion.Items.AddRange(new object[] { "Multiple Choices", "True / False", "Open-ended" });
            cbTypeQuestion.Location = new Point(300, 170);
            cbTypeQuestion.Name = "cbTypeQuestion";
            cbTypeQuestion.Size = new Size(278, 40);
            cbTypeQuestion.TabIndex = 6;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.DodgerBlue;
            btnConfirm.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(300, 250);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(124, 50);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.DeepSkyBlue;
            lblError.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.Location = new Point(234, 335);
            lblError.Name = "lblError";
            lblError.Size = new Size(307, 28);
            lblError.TabIndex = 9;
            lblError.Text = "Your Selection is not valid.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Universe_themed_background_for_thinking;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(815, 455);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // Create
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 245, 255);
            ClientSize = new Size(802, 453);
            Controls.Add(lblError);
            Controls.Add(btnConfirm);
            Controls.Add(cbTypeQuestion);
            Controls.Add(btnBack);
            Controls.Add(lblContent);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Create";
            Text = "Create Questions";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblContent;
        private Button btnBack;
        private ComboBox cbTypeQuestion;
        private Button btnConfirm;
        private Label lblError;
        private PictureBox pictureBox1;
    }
}