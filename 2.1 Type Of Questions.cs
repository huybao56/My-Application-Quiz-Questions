using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace COMP1551_Part_1
{
    public partial class TypeOfQuestions : Form
    {
        //Set initially form
        private Type questionType;              //Use type class default
        private Quiz home;                      //Home Form
        private Create create;                  //Create Form
        private ShowQuestion ShowQuestion;      //Show Question Form
        private Questions questionToEdit;       //Use class to Edit
        SqlConnection myConnection;             //Set connection
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MYDATABASE;" +
            "Trusted_Connection=True; Trust Server Certificate=True; Integrated Security=True;" +
            "User Id=admin;Password=...";       //String to connect data source
        //Constructor of form
        public TypeOfQuestions(Type type, Quiz main = null, ShowQuestion Show = null, Create createback = null, Questions question = null)
        {
            InitializeComponent();
            FormExtensions.FixedPosition(this, new Point(450, 170));    //Set fixed position
            myConnection = new SqlConnection(connectionString);         //Set the connection
            myConnection.Open();                                        //Open Database
            create = createback;                                        //The create form
            if (Show != null)           // Set the condition of showQuestion
            {
                ShowQuestion = Show;    // Assuming ShowQuestion has a reference to Quiz
            }
            else if (main != null)      // Set the condition of Home
            {
                home = main;            // Pass reference to home
            }
            //Another exception
            else
            {
                throw new ArgumentException("Either Quiz or ShowQuestion must be provided.");
            }
            questionType = type;            //Check the questionType
            questionToEdit = question;      //Check the valid of question edit or not
            SetUpLayOut();                  //Set up layout depending on options provided
            //Check the question in Home or ShowQuestions in order to edit
            if (questionToEdit != null)
                LoadQuestions();            //LoadQuestion in Show Question
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Check the condtion to go back the initially
            if(ShowQuestion != null)
            {
                ShowQuestion.Show();        //Open Show Question
                this.Close();               //Close this form
            }
            else if(questionToEdit == null)
            {
                FormExtensions.OpenForm(this, create, new Point(450, 170)); //Go back Create Form
            }
            else
            {
                MessageBox.Show("Invalid operation");
            }
        }
        //Load the question existed
        private void LoadQuestions()
        {
            tbQuestion.Text = questionToEdit.questionText;
            //Set the data in form and condition of each type question
            if(questionToEdit is TrueFalse TF)
            {
                CheckBox checkIsTrue = (CheckBox)this.Controls["checkIsTrue"];
                checkIsTrue.Checked = TF.IsTrue;
            }
            else if(questionToEdit is MultipleChoices MCQ)
            {
                char[] optionLetters = { 'A', 'B', 'C', 'D' };

                for (int i = 0; i < optionLetters.Length; i++)
                {
                    TextBox tbAnswer = (TextBox)this.Controls[$"tbAnswer{optionLetters[i]}"];
                    tbAnswer.Text = MCQ.Options[i];
                }
                char correctAnswerLetter = (char)('A' + MCQ.CorrectOptionIndex);
                ((TextBox)this.Controls[$"tbCorrect"]).Text = correctAnswerLetter.ToString();
            }
            else if(questionToEdit is OpenEnded OE)
            {
                TextBox tbAnswer = (TextBox)this.Controls["tbAnswer"];
                tbAnswer.Text = OE.Answer;
            }
        }
        //Set the layout of questions in one form
        private void SetUpLayOut()
        {
            if (questionType == typeof(TrueFalse))
            {
                SetUpTrueFalseLayOut();
                lblContent.Text = "True / False";
            }
            if(questionType == typeof(MultipleChoices))
            {
                SetUpMultipleChoicesLayOut();
                lblContent.Text = "Multiple Choices";
            }
            if (questionType == typeof(OpenEnded))
            {
                SetUpOpenEndedLayOut();
                lblContent.Text = "Open Ended";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Questions question = questionToEdit ?? CreateNewQuestions();    //The same as if else
            string originalQuestionText = question.questionText;            //Avoid the invalid            
            question.questionText = tbQuestion.Text;                        //Fetch question text

            // Set the initially in order to fetch data
            string questionTypeString = "";
            string correctAnswer = null;
            bool? isTrue = null;
            string optionA = null, optionB = null, optionC = null, optionD = null;
            int? correctOption = null;

            //Set the condtion of type question
            if(question is TrueFalse TF && questionType == typeof(TrueFalse))
            {
                TF.IsTrue = ((CheckBox)this.Controls["checkIsTrue"]).Checked;
                questionTypeString = "TrueFalse";
                isTrue = TF.IsTrue;
            }
            else if (question is MultipleChoices MCQ && questionType == typeof(MultipleChoices))
            {
                string tbAnswer = ((TextBox)this.Controls["tbCorrect"]).Text.ToUpper();
                optionA = ((TextBox)this.Controls["tbAnswerA"]).Text;
                optionB = ((TextBox)this.Controls["tbAnswerB"]).Text;
                optionC = ((TextBox)this.Controls["tbAnswerC"]).Text;
                optionD = ((TextBox)this.Controls["tbAnswerD"]).Text;
                if(!string.IsNullOrEmpty(tbAnswer) && tbAnswer.Length == 1 && "ABCD".Contains(tbAnswer))
                {
                    MCQ.Options = new List<string>
                    {optionA,optionB,optionC,optionD };
                    MCQ.CorrectOptionIndex = tbAnswer[0] - 'A';
                    questionTypeString = "MultipleChoices";
                    correctOption = MCQ.CorrectOptionIndex;
                }
                else
                {
                    MessageBox.Show($"Please enter a valid correct answer only (A, B, C or D).");
                    question.questionText = originalQuestionText;
                    return;
                }
            }
            else if(question is OpenEnded OE && questionType == typeof(OpenEnded))
            {
                OE.Answer = ((TextBox)this.Controls["tbAnswer"]).Text;
                questionTypeString = "OpenEnded";
                correctAnswer = OE.Answer;
            }

            // Set the initially query
            string query;
            //Pass the query
            if (questionToEdit == null)
            {
                query = @"
                        INSERT INTO Questions (QuestionType, QuestionText, CorrectAnswer, IsTrue, OptionA, OptionB, OptionC, OptionD, CorrectOption)
                        OUTPUT INSERTED.QuestionID
                        VALUES (@QuestionType, @QuestionText, @CorrectAnswer, @IsTrue, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectOption)";
            }
            else
            {
                // Update existing question
                query = @"
                UPDATE Questions
                SET QuestionType = @QuestionType, 
                    QuestionText = @QuestionText,
                    CorrectAnswer = @CorrectAnswer,
                    IsTrue = @IsTrue,
                    OptionA = @OptionA,
                    OptionB = @OptionB,
                    OptionC = @OptionC,
                    OptionD = @OptionD,
                    CorrectOption = @CorrectOption
                WHERE QuestionID = @QuestionID";
            }
            //Compare the data in order to fetch
            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.Parameters.AddWithValue("@QuestionType", questionTypeString);
            cmd.Parameters.AddWithValue("@QuestionText", question.questionText);
            cmd.Parameters.AddWithValue("@CorrectAnswer", (object)correctAnswer ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsTrue", (object)isTrue ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionA", (object)optionA ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionB", (object)optionB ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionC", (object)optionC ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionD", (object)optionD ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CorrectOption", (object)correctOption ?? DBNull.Value);
            //Using for query second structure else
            if (questionToEdit != null)
            {
                cmd.Parameters.AddWithValue("@QuestionID",questionToEdit.Id);
            }
            try
            {
                // Use the correct SELECT query
                string querySelect = @"
                                    SELECT QuestionID 
                                    FROM Questions
                                    WHERE QuestionType = @QuestionType2 AND QuestionText = @QuestionText2";

                // Create a new command for SELECT
                SqlCommand selectCmd = new SqlCommand(querySelect, myConnection);
                selectCmd.Parameters.AddWithValue("@QuestionType2", questionTypeString);
                selectCmd.Parameters.AddWithValue("@QuestionText2", question.questionText);
                object result = selectCmd.ExecuteScalar(); // Execute the SELECT command to pass object
                //Run string queyr
                cmd.ExecuteNonQuery();
                //Pass to object class
                if (questionToEdit == null)
                {
                    int existQuestionID = Convert.ToInt32(result);
                    question.Id = existQuestionID;      // Set the ID for the new question in your application
                    home.questionsList.Add(question);   // Add to the list only if it's a new question
                    MessageBox.Show("Your question is created.");
                }
                else
                {       
                    // For updating an existing question, just execute the update query
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your question has been updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            //After creating question
            if (home != null)
            {
                home.Show();
                this.Close();
            }
            else if (ShowQuestion != null)
            {
                ShowQuestion.Show();
                ShowQuestion.DisplayQuestions();
                ShowQuestion.FilterType();
                this.Close();
            }
        }
        //Insert question Type
        private Questions CreateNewQuestions()
        {
            //Check the question to return the questionType
            if (questionType == typeof(TrueFalse))
                return new TrueFalse();
            if (questionType == typeof(MultipleChoices))
                return new MultipleChoices();
            return new OpenEnded();
        }
        //Set up layout of three type of question
        private void SetUpMultipleChoicesLayOut()
        {
            char[] optionLetters = { 'A', 'B', 'C', 'D' };
            int i = 0;
            while (i < optionLetters.Length)
            {
                TextBox tbAnswer = new TextBox() { Name = $"tbAnswer{optionLetters[i]}", Location = new Point(118, 160 + (i * 50)), Width = 442, Font = new Font("Arial", 13.8f) };
                Label lblOptions = new Label() { Text = $"{optionLetters[i]}:", Location = new Point(77, 167 + (i * 50)), AutoSize = true, Font = new Font("Arial", 13.8f, FontStyle.Bold) };
                this.Controls.Add(tbAnswer);
                this.Controls.Add(lblOptions);
                i++;
            }
            TextBox tbCorrectOption = new TextBox() { Name = "tbCorrect", Location = new Point(223, 357), Width = 171, Font = new Font("Arial", 9f) };
            Label lblCorrect = new Label() { Text = "Correct Answer:", Location = new Point(79, 357), AutoSize = true, Font = new Font("Arial", 10.2f, FontStyle.Bold) };
            // Add placeholder text to the Correct Option Index TextBox
            if(questionToEdit == null)
            {
                tbCorrectOption.Text = "A, B, C, D";      // Default text or placeholder if needed
                tbCorrectOption.ForeColor = Color.Gray;   // Placeholder color
                // Event handlers for the correct index TextBox
                tbCorrectOption.Enter += (s, e) =>
                {
                    if (tbCorrectOption.Text == "A, B, C, D") // Check for placeholder
                    {
                        tbCorrectOption.Text = "";
                        tbCorrectOption.ForeColor = Color.Black; // Change text color to black
                    }
                };
                tbCorrectOption.Leave += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(tbCorrectOption.Text))
                    {
                        tbCorrectOption.Text = "A, B, C, D"; // Set placeholder again if empty
                        tbCorrectOption.ForeColor = Color.Gray; // Change text color to gray
                    }
                };
            }
            else
            {
                tbCorrectOption.ForeColor = Color.Black;
            }
            this.Controls.Add(tbCorrectOption);
            this.Controls.Add(lblCorrect);
        }
        private void SetUpTrueFalseLayOut()
        {
            // Create a checkbox for True/False question answer
            CheckBox checkIsTrue = new CheckBox() { Name = "checkIsTrue", Location = new Point(170,205), AutoSize = false, Font = new Font("Arial", 24f, FontStyle.Bold)};
            Label labelIsTrue = new Label() { Text = "True:", Location = new Point(77, 200), AutoSize = true, Font = new Font("Arial", 13.8f, FontStyle.Bold) };
            this.Controls.Add(checkIsTrue);
            this.Controls.Add(labelIsTrue);
        }
        private void SetUpOpenEndedLayOut()
        {
            TextBox tbAnswerCorrect = new TextBox() { Name = "tbAnswer", Location = new Point(180, 195), Width = 300, Font = new Font("Arial", 13.8f) };
            Label labelAnswer = new Label() { Text = "Answer:", Location = new Point(77, 200), AutoSize = true, Font = new Font("Arial", 13.8f, FontStyle.Bold) };
            if (questionToEdit == null)
            {
                tbAnswerCorrect.Text = "Your Answer";   // Default text
                tbAnswerCorrect.ForeColor = Color.Gray; // The color of place holder
                // Event handlers for the correct index TextBox
                tbAnswerCorrect.Enter += (s, e) =>
                {
                    if (tbAnswerCorrect.Text == "Your Answer")  // Check for placeholder
                    {
                        tbAnswerCorrect.Text = "";
                        tbAnswerCorrect.ForeColor = Color.Black;// Change text color to black
                    }
                };
                tbAnswerCorrect.Leave += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(tbAnswerCorrect.Text))
                    {
                        tbAnswerCorrect.Text = "Your Answer"; // Set placeholder again if empty
                        tbAnswerCorrect.ForeColor = Color.Gray; // Change text color to gray
                    }
                };
            }
            else
            {
                tbAnswerCorrect.ForeColor = Color.Black;
            }
            this.Controls.Add(tbAnswerCorrect);
            this.Controls.Add(labelAnswer);
        }
    }
}
