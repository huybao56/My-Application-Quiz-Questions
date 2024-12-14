using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace COMP1551_Part_1
{
    public partial class Quiz : Form
    {
        public List<Questions> questionsList { get; private set; } = new List<Questions>(); //Get the class
        SqlConnection myConnection; //Set the connection
        String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MYDATABASE;" +
            "Trusted_Connection=True; Trust Server Certificate=True; Integrated Security=True;" +
            "User Id=admin;Password=...";   //The source connection of SSMS
        public Quiz()
        {
            InitializeComponent();
            myConnection = new SqlConnection(connectionString); //Connect SQL
            myConnection.Open();    //Open SQL
            FormExtensions.FixedPosition(this, new Point(450, 170));    //Set fixed position
            DisplayQuestions();                                         // Show questions initially
        }

        // Method Get Questions
        public void DisplayQuestions()
        {
            // SQL query to select all questions
            string query = @"SELECT QuestionID, QuestionType, QuestionText, CorrectAnswer, IsTrue, OptionA, OptionB, OptionC, OptionD, CorrectOption FROM Questions";
            SqlCommand cmd = new SqlCommand(query, myConnection);   //Select Question
            SqlDataReader result = cmd.ExecuteReader();             //Read Data
            try
            {
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        int questionID = result.GetInt32(0);        // QuestionID
                        string questionType = result.GetString(1);  // QuestionType
                        string questionText = result.GetString(2);  // QuestionText

                        // Check the questionType
                        if (questionType == "MultipleChoices")
                        {
                            // Read options and correct option
                            string optionA = result.GetString(5);
                            string optionB = result.GetString(6);
                            string optionC = result.GetString(7);
                            string optionD = result.GetString(8);
                            int correctOptionIndex = result.GetInt32(9); // Store as Index Based 0 - A
                            // Add existing question
                            var question = new MultipleChoices
                            {
                                Id = questionID,
                                questionText = questionText,
                                Options = new List<string> { optionA, optionB, optionC, optionD },
                                CorrectOptionIndex = correctOptionIndex
                            };
                            this.questionsList.Add(question);
                        }
                        else if (questionType == "TrueFalse")
                        {
                            // Add existing question
                            var question = new TrueFalse
                            {
                                Id = questionID,
                                questionText = questionText,
                                IsTrue = true
                            };
                            this.questionsList.Add(question);
                        }
                        else if (questionType == "OpenEnded")
                        {
                            // Add existing question
                            string answer = result.GetString(3);
                            var question = new OpenEnded
                            {
                                Id = questionID,
                                questionText = questionText,
                                Answer = answer
                            };
                            this.questionsList.Add(question);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error SQL
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                result.Close(); // Alway close for another command.
            }
        }

        // Method open Create Form
        private void btnCreateQuestions_Click(object sender, EventArgs e)
        {
            Create createQuestion = new Create(this);                               // Create a new instance of Create Class
            FormExtensions.OpenForm(this, createQuestion, new Point(450, 170));     // Open Form Create
        }

        // Method open Play Form
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (questionsList.Count == 0)                                           //Check the question list.
            {
                MessageBox.Show($"Sorry, You don't have any questions to play");    //Show notifications
            }
            else
            {
                Play playQuestion = new Play(this, questionsList);                 // Create a new instance of Play Class
                FormExtensions.OpenForm(this, playQuestion, new Point(450, 170));  // Open Form Play
            }
        }

        // Method open Ranking Form
        private void btnRanking_Click(object sender, EventArgs e)
        {
            Ranking topPlayer = new Ranking(this);                              // Create a new instance of Ranking Class
            FormExtensions.OpenForm(this, topPlayer, new Point(450, 170));      // Open Form Ranking
        }

        // Method open Show Question Form
        private void btnShowQuestion_Click(object sender, EventArgs e)
        {
            ShowQuestion showQuestion = new ShowQuestion(this, questionsList);     // Create a new instance of Show Question Class
            FormExtensions.OpenForm(this, showQuestion, new Point(450, 170));      // Open Form Show Question
        }
    }
}
