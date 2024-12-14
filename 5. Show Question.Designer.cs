namespace COMP1551_Part_1
{
    partial class ShowQuestion
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
            listBoxQuestions = new ListBox();
            lblContent = new Label();
            btnResert = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnBack = new Button();
            btnFilter = new Button();
            listViewFilter = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnRefresh = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBoxQuestions
            // 
            listBoxQuestions.BackColor = Color.White;
            listBoxQuestions.BorderStyle = BorderStyle.None;
            listBoxQuestions.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxQuestions.FormattingEnabled = true;
            listBoxQuestions.ItemHeight = 23;
            listBoxQuestions.Location = new Point(12, 114);
            listBoxQuestions.Margin = new Padding(5);
            listBoxQuestions.Name = "listBoxQuestions";
            listBoxQuestions.Size = new Size(774, 276);
            listBoxQuestions.TabIndex = 8;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = SystemColors.ActiveBorder;
            lblContent.Font = new Font("Arial", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblContent.ForeColor = Color.White;
            lblContent.Location = new Point(12, 9);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(242, 40);
            lblContent.TabIndex = 11;
            lblContent.Text = "Question List:";
            // 
            // btnResert
            // 
            btnResert.BackColor = Color.LightSkyBlue;
            btnResert.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResert.Location = new Point(687, 67);
            btnResert.Name = "btnResert";
            btnResert.Size = new Size(99, 39);
            btnResert.TabIndex = 13;
            btnResert.Text = "Resert";
            btnResert.UseVisualStyleBackColor = false;
            btnResert.Click += btnResert_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightSkyBlue;
            btnDelete.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(182, 398);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 50);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.LightSkyBlue;
            btnEdit.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(12, 398);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 50);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 204, 204);
            btnBack.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(12, 61);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 50);
            btnBack.TabIndex = 14;
            btnBack.Text = "Return";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(204, 255, 204);
            btnFilter.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.Location = new Point(341, 398);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(124, 50);
            btnFilter.TabIndex = 16;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // listViewFilter
            // 
            listViewFilter.Alignment = ListViewAlignment.Left;
            listViewFilter.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewFilter.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listViewFilter.Location = new Point(341, 454);
            listViewFilter.Name = "listViewFilter";
            listViewFilter.Size = new Size(445, 187);
            listViewFilter.TabIndex = 17;
            listViewFilter.UseCompatibleStateImageBehavior = false;
            listViewFilter.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "";
            columnHeader1.Text = "Type of Questions";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Quantity";
            columnHeader2.Width = 100;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(204, 255, 204);
            btnRefresh.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(662, 398);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(124, 50);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Universe_with_a_pen_marker;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(805, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // ShowQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 245, 255);
            ClientSize = new Size(802, 653);
            Controls.Add(btnRefresh);
            Controls.Add(listViewFilter);
            Controls.Add(btnFilter);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnResert);
            Controls.Add(lblContent);
            Controls.Add(listBoxQuestions);
            Controls.Add(pictureBox1);
            Name = "ShowQuestion";
            Text = "Show Question";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxQuestions;
        private Label lblContent;
        private Button btnResert;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnBack;
        private Button btnFilter;
        private ListView listViewFilter;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnRefresh;
        private PictureBox pictureBox1;
    }
}