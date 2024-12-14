using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace COMP1551_Part_1
{
    public partial class Play : Form
    {
        private Stopwatch totalQuizAnswer = new Stopwatch();
        private List<Questions> questions;
        private Quiz home;
        private int score = 0;
        private int currentQuestion = 0;
        SqlConnection myConnection;
        String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MYDATABASE;" +
            "Trusted_Connection=True; Trust Server Certificate=True; Integrated Security=True;" +
            "User Id=admin;Password=...";
        public Play(Quiz homeForm, List<Questions> List)
        {
            InitializeComponent();
            myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            FormExtensions.FixedPosition(this, new Point(450, 170));
            home = homeForm;
            questions = List;
            LoadQuestionsFromDatabase();
            totalQuizAnswer.Start();
            DisplayQuestions();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormExtensions.OpenForm(this, home, new Point(450, 170));
        }
        private void LoadQuestionsFromDatabase()
        {
            string query = "SELECT QuestionID, QuestionType, QuestionText, CorrectAnswer, IsTrue, OptionA, OptionB, OptionC, OptionD, CorrectOption FROM Questions";
            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();
            questions = new List<Questions>(); // Initialize the questions list
            try
            {
                while (reader.Read())
                {
                    int questionID = reader.GetInt32(0); // QuestionID
                    string questionType = reader["QuestionType"].ToString();
                    string questionText = reader["QuestionText"].ToString();

                    if (questionType == "MultipleChoices")
                    {
                        // Read options and correct option
                        string OptionA = reader.GetString(5).ToString();
                        string OptionB = reader.GetString(6).ToString();
                        string OptionC = reader.GetString(7).ToString();
                        string OptionD = reader.GetString(8).ToString();
                        int correctOptionIndex = reader.GetInt32(9); // Assuming the correct option is stored as an index (0-based)

                        var question = new MultipleChoices
                        {
                            Id = questionID,
                            questionText = questionText,
                            // Retrieve Options and CorrectOptionIndex from DB
                            Options = new List<string> { OptionA, OptionB, OptionC, OptionD },
                            CorrectOptionIndex = correctOptionIndex
                        };
                        this.questions.Add(question);
                    }
                    else if (questionType == "TrueFalse")
                    {
                        var question = new TrueFalse
                        {
                            Id = questionID,
                            questionText = questionText,
                            IsTrue = true // Set this based on DB
                        };
                        this.questions.Add(question);
                    }
                    else if (questionType == "OpenEnded")
                    {
                        string answer = reader.GetString(3);
                        var question = new OpenEnded
                        {
                            Id = questionID,
                            questionText = questionText,
                            Answer = answer // Set this based on DB
                        };
                        this.questions.Add(question);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading questions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    private void DisplayQuestions()
        {
            if (currentQuestion < questions.Count)
            {
                Questions q = questions[currentQuestion];
                lblQuestion.Text = $"{currentQuestion + 1}. {q.questionText}";

                pnlAnswerOptions.Controls.Clear();

                if (q is MultipleChoices MCQ)
                {
                    char[] optionLetters = { 'A', 'B', 'C', 'D' };
                        
                    for (int i = 0; i < MCQ.Options.Count; i++)
                    {
                        RadioButton rb = new RadioButton
                        {
                            Text = $"{optionLetters[i]}. {MCQ.Options[i].ToString()}",
                            Tag = i,
                            Location = new Point(20, i * 55),
                            AutoSize = true
                        };
                        pnlAnswerOptions.Controls.Add(rb);
                    }
                }
                else if (q is TrueFalse TF)
                {
                    var trueFalseOptions = new List<string> { "True", "False" };
                    for (int i = 0; i < trueFalseOptions.Count; i++)
                    {
                        RadioButton rb = new RadioButton
                        {
                            Text = trueFalseOptions[i],
                            Tag = i == 0,
                            AutoSize = true,
                            Location = new Point(20, i * 60)
                        };
                        pnlAnswerOptions.Controls.Add(rb);
                    }
                }
                else if (q is OpenEnded OE)
                {
                    TextBox tbAnswer = new TextBox { Name = "tbAnswer", Width = 650, Location = new Point(20,60) };
                    tbAnswer.Text = "Your Answer"; // Default text
                    tbAnswer.ForeColor = Color.Gray; // The color of placeholder
                    // Event handlers for the correct index TextBox
                    tbAnswer.Enter += (s, e) =>
                    {
                        if (tbAnswer.Text == "Your Answer")     // Check for placeholder
                        {
                            tbAnswer.Text = "";
                            tbAnswer.ForeColor = Color.Black;   // Change text color to black
                        }
                    };
                    tbAnswer.Leave += (s, e) =>
                    {
                        if (string.IsNullOrWhiteSpace(tbAnswer.Text))
                        {
                            tbAnswer.Text = "Your Answer";      // Set placeholder again if empty
                            tbAnswer.ForeColor = Color.Gray;    // Change text color to gray
                        }
                    };
                    pnlAnswerOptions.Controls.Add(tbAnswer);
                }
            }
            else
            {
                totalQuizAnswer.Stop();
                btnSubmit.Visible = false;
                TimeSpan totalTimeTaken = totalQuizAnswer.Elapsed;
                double roundedMilliseconds = Math.Round(totalTimeTaken.TotalMilliseconds);  // Round milliseconds
                TimeSpan roundedTime = TimeSpan.FromMilliseconds(roundedMilliseconds);      // Create a new TimeSpan with the rounded milliseconds
                TheEnd(totalTimeTaken);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(currentQuestion < questions.Count)
            {
                Questions q = questions[currentQuestion];
                bool isCorrect = CheckAnswer(q);
                if(isCorrect)
                {
                    score++;
                }

                currentQuestion++;
                DisplayQuestions();
            }
        }
        private bool CheckAnswer(Questions q)
        {
            if (q is MultipleChoices MCQ)
            {
                RadioButton selected = pnlAnswerOptions.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                return selected != null && (int)selected.Tag == MCQ.CorrectOptionIndex;
            }
            else if (q is TrueFalse TF)
            {
                RadioButton selected = pnlAnswerOptions.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                return selected != null && (bool)selected.Tag == TF.IsTrue;
            }
            else if(q is OpenEnded OE)
            {
                TextBox tbAnswer = pnlAnswerOptions.Controls.OfType<TextBox>().FirstOrDefault();
                return tbAnswer != null && tbAnswer.Text.Equals(OE.Answer, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        private void btnRetryQuiz_Click()
        {
            currentQuestion = 0;         // Reset the question index
            score = 0;                   // Reset the score
            totalQuizAnswer.Reset();     // Reset the timer
            totalQuizAnswer.Start();
            btnSubmit.Visible = true;
            DisplayQuestions();          // Restart the quiz
        }
        public void InsertPlayer(string playerName, int correctAnswer, TimeSpan playerTime)
        {
            string query = "INSERT INTO Player (PlayerName, CorrectAnswer, PlayerTime) VALUES (@PlayerName, @CorrectAnswer, @PlayerTime)";
                SqlCommand command = new SqlCommand(query, myConnection);
                command.Parameters.AddWithValue("@PlayerName", playerName);
                command.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                command.Parameters.AddWithValue("@PlayerTime", playerTime);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery(); // Executes the query
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Player: '{playerName}' inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No data was inserted. Please check your inputs.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        
        }

        private void TheEnd(TimeSpan totalTimeTaken)
        {
            lblQuestion.Text = "Quiz Summary";
            // Round milliseconds
            double roundedMilliseconds = Math.Round(totalTimeTaken.TotalMilliseconds);

            // Create a new TimeSpan with the rounded milliseconds
            TimeSpan roundedTime = TimeSpan.FromMilliseconds(roundedMilliseconds);

            Label completed = new Label
            {
                Text = $"Quiz Completed!\nYour final score: {score}/{questions.Count}\nTotal Time Answered: {totalTimeTaken.TotalSeconds:F2} seconds.\n",
                Location = new Point(20, 20),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Button btnShowAnswer = new Button
            {
                Text = "Show Answer",
                Location = new Point(50, 150),
                AutoSize = true
            };
            btnShowAnswer.Click += (s, e) =>
            {
                currentSummaryIndex = 0;
                DisplaySummary();
            };
            Button btnRetry = new Button
            {
                Text = "Retry",
                Location = new Point(270, 150),
                AutoSize = true
            };
            btnRetry.Click += (s, e) =>
            {
                btnRetryQuiz_Click();
            };
            Label enterName = new Label
            {
                Text = $"Enter your name:",
                Location = new Point(510,70),
                AutoSize = true
            };
            TextBox insertname = new TextBox
            {
                Location = new Point(450,100),
                Width = 300,
            };
            Button btnInsertPlayer = new Button
            {
                Text = "Insert Players",
                Location = new Point(510, 150),
                AutoSize = true
            };
            btnInsertPlayer.Click += (s, e) =>
            {
                if(insertname.Text != null)
                {
                    InsertPlayer(insertname.Text, score, roundedTime);
                    FormExtensions.OpenForm(this, home, new Point(450, 170));
                }
                else
                {
                    MessageBox.Show($"Please enter your name");
                }
            };
            pnlAnswerOptions.Controls.Clear();
            pnlAnswerOptions.Controls.Add(completed);
            pnlAnswerOptions.Controls.Add(btnShowAnswer);
            pnlAnswerOptions.Controls.Add(btnRetry);
            pnlAnswerOptions.Controls.Add(enterName);
            pnlAnswerOptions.Controls.Add(insertname);
            pnlAnswerOptions.Controls.Add(btnInsertPlayer);

        }
        private int currentSummaryIndex = 0; // To track the current question in the summary
        private void DisplaySummary()
        {

            // Create navigation buttons
            Button btnPrevious = new Button
            {
                Text = "Previous",
                Location = new Point(50, 170),
                AutoSize = true
            };
            btnPrevious.Click += (s, e) =>
            {
                if (currentSummaryIndex > 0)
                {
                    currentSummaryIndex--;
                    ShowSummaryQuestion();
                }
            };

            Button btnNext = new Button
            {
                Text = "Next",
                Location = new Point(320, 170),
                AutoSize = true
            };
            btnNext.Click += (s, e) =>
            {
                if (currentSummaryIndex < questions.Count - 1)
                {
                    currentSummaryIndex++;
                    ShowSummaryQuestion();
                }
            };

            Button btnRetry = new Button
            {
                Text = "Retry",
                Location = new Point(200, 170),
                AutoSize = true
            };
            btnRetry.Click += (s, e) =>
            {
                btnRetryQuiz_Click();
            };
            // Add buttons to panel once (to avoid clearing them repeatedly)
            pnlAnswerOptions.Controls.Clear();
            pnlAnswerOptions.Controls.Add(btnPrevious);
            pnlAnswerOptions.Controls.Add(btnNext);
            pnlAnswerOptions.Controls.Add(btnRetry);
            // Display the first question initially
            ShowSummaryQuestion();
        }

        private void ShowSummaryQuestion()
        {
            // Clear all controls except navigation buttons
            var navigationButtons = pnlAnswerOptions.Controls.OfType<Button>().ToList();
            pnlAnswerOptions.Controls.Clear();
            foreach (var button in navigationButtons)
            {
                pnlAnswerOptions.Controls.Add(button);
            }

            // Check if the current question index is valid
            if (currentSummaryIndex >= 0 && currentSummaryIndex < questions.Count)
            {
                Questions q = questions[currentSummaryIndex];

                // Display question text
                Label lblQuestionText = new Label
                {
                    Text = $"{currentSummaryIndex + 1}. {q.questionText}",
                    AutoSize = true,
                    Location = new Point(20, 20)
                };
                pnlAnswerOptions.Controls.Add(lblQuestionText);

                // Display correct answer and user answer based on question type
                if (q is MultipleChoices MCQ)
                {
                    char[] optionLetters = { 'A', 'B', 'C', 'D' };
                    string correctOption = $"{optionLetters[MCQ.CorrectOptionIndex]}. {MCQ.Options[MCQ.CorrectOptionIndex]}";

                    // Display correct answer
                    Label lblCorrectAnswer = new Label
                    {
                        Text = $"Correct Answer: {correctOption}",
                        ForeColor = Color.Green,
                        AutoSize = true,
                        Location = new Point(40, 60)
                    };
                    pnlAnswerOptions.Controls.Add(lblCorrectAnswer);
                }
                else if (q is TrueFalse TF)
                {
                    string correctAnswer = TF.IsTrue ? "True" : "False";

                    // Display correct answer
                    Label lblCorrectAnswer = new Label
                    {
                        Text = $"Correct Answer: {correctAnswer}",
                        ForeColor = Color.Green,
                        AutoSize = true,
                        Location = new Point(40, 60)
                    };
                    pnlAnswerOptions.Controls.Add(lblCorrectAnswer);
                }
                else if (q is OpenEnded OE)
                {
                    // Display correct answer
                    Label lblCorrectAnswer = new Label
                    {
                        Text = $"Correct Answer: {OE.Answer}",
                        ForeColor = Color.Green,
                        AutoSize = true,
                        Location = new Point(40, 60)
                    };
                    pnlAnswerOptions.Controls.Add(lblCorrectAnswer);
                }
            }
            // Update button states
            UpdateNavigationButtons();
        }

        private void UpdateNavigationButtons()
        {
            // Enable or disable buttons based on the current question index
            foreach (var button in pnlAnswerOptions.Controls.OfType<Button>())
            {
                if (button.Text == "Previous")
                    button.Enabled = currentSummaryIndex > 0;
                else if (button.Text == "Next")
                    button.Enabled = currentSummaryIndex < questions.Count - 1;
            }
        }
    }
}
