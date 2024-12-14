using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace COMP1551_Part_1
{
    public partial class ShowQuestion : Form
    {
        public List<Questions> question { get; private set; } = new List<Questions>();
        private Quiz Home;
        SqlConnection myConnection;
        String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MYDATABASE;" +
            "Trusted_Connection=True; Trust Server Certificate=True; Integrated Security=True;" +
            "User Id=admin;Password=...";
        public ShowQuestion(Quiz homeForm, List<Questions> List)
        {
            InitializeComponent();
            FormExtensions.FixedPosition(this, new Point(450, 170));
            myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            listBoxQuestions.Font = new Font("Consolas", 10); // Use a monospaced font like Consolas or Courier New
            Home = homeForm;
            question = List;
            FilterType();
            DisplayQuestions();
        }
        public void DisplayQuestions()
        {
            listBoxQuestions.Items.Clear();

            string query = @"SELECT QuestionID, QuestionType, QuestionText, CorrectAnswer, IsTrue, OptionA, OptionB, OptionC, OptionD, CorrectOption FROM Questions";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataReader result = cmd.ExecuteReader();

            try
            {
                if (result.HasRows)
                {
                    while (result.Read())
                    {

                        int questionID = result.GetInt32(0); // QuestionID
                        string questionType = result.GetString(1); // QuestionType
                        string questionText = result.GetString(2); // QuestionText

                        if (questionType == "MultipleChoices")
                        {
                            // Read options and correct option
                            string optionA = result.GetString(5);
                            string optionB = result.GetString(6);
                            string optionC = result.GetString(7);
                            string optionD = result.GetString(8);
                            int correctOptionIndex = result.GetInt32(9); // Assuming the correct option is stored as an index (0-based)

                            var question = new MultipleChoices
                            {
                                Id = questionID,
                                questionText = questionText,
                                Options = new List<string> { optionA, optionB, optionC, optionD },
                                CorrectOptionIndex = correctOptionIndex
                            };
                            this.question.Add(question);
                        }
                        else if (questionType == "TrueFalse")
                        {
                            var question = new TrueFalse
                            {
                                Id = questionID,
                                questionText = questionText,
                                IsTrue = true // Set this based on DB
                            };
                            this.question.Add(question);
                        }
                        else if (questionType == "OpenEnded")
                        {
                            string answer = result.GetString(3); // 
                            var question = new OpenEnded
                            {
                                Id = questionID,
                                questionText = questionText,
                                Answer = answer // Set this based on DB
                            };
                            this.question.Add(question);
                        }



                        listBoxQuestions.Items.Add($"{result[0],-3}. [{result[1],-5}] {result[2]}");
                        //index++;
                    }
                }
                else
                {
                    listBoxQuestions.Items.Add($"You don't have the questions to view");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Always close the reader to release the connection for other commands
                result.Close();
            }
        }
        public void FilterType()
        {
            listViewFilter.Items.Clear();

            string query = @"SELECT QuestionType, COUNT(*) AS Quantity
                            FROM Questions
                            WHERE QuestionType IN ('MultipleChoices', 'TrueFalse', 'OpenEnded')
                            GROUP BY questionType;";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataReader result = cmd.ExecuteReader();
            try
            {
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        string questionType = result.GetString(0); // QuestionType
                        ListViewItem item = new ListViewItem(questionType);
                        item.SubItems.Add(result["Quantity"].ToString());
                        listViewFilter.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Always close the reader to release the connection for other commands
                result.Close();
            }
        }
        private void btnResert_Click(object sender, EventArgs e)
        {
            if (question.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete all questions?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string query = "TRUNCATE TABLE Questions";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    SqlDataReader resert = cmd.ExecuteReader();
                    try
                    {
                        MessageBox.Show($"You have reserted the whole data and number!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occured: {ex.Message}");
                    }
                    finally
                    {
                        resert.Close();
                    }

                    question.Clear();  // Clear all items in the list
                    DisplayQuestions();     // Refresh the display
                    FilterType();
                }
            }
            else
            {
                MessageBox.Show("There are no questions to delete. Create a new one");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxQuestions.Text == "You don't have the questions to view")
            {
                MessageBox.Show($"Sorry, You don't have any questions. Please create a new one");
            }
            else if (listBoxQuestions.SelectedIndex != -1)
            {
                string selectedText = listBoxQuestions.SelectedItem.ToString();
                int questionId = int.Parse(selectedText.Split('.')[0]); // Extract the ID before the colon
                Questions q = question.FirstOrDefault(x => x.Id == questionId);
                if (q != null)
                {
                    TypeOfQuestions editForm = new TypeOfQuestions(q.GetType(), null, this, null ,q);
                    editForm.StartPosition = FormStartPosition.Manual;
                    editForm.Location = new Point(450, 170);
                    this.Hide();
                    editForm.ShowDialog();


                    // Update the question in the database
                    UpdateQuestionInDatabase(q);
                }
                else
                {
                    MessageBox.Show("Unable to parse Question ID. Please check the selected question format.");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Please select a question to edit.");
            }
        }
        private void UpdateQuestionInDatabase(Questions q)
        {

            string query = @"
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

            // Determine values based on the type of the question
            string Answer = null;
            int? correctOption = null;
            bool? isTrue = null;

            // Check the type of question and populate fields accordingly
            if (q is MultipleChoices mcq)
            {
                correctOption = mcq.CorrectOptionIndex; // Use CorrectOptionIndex for MultipleChoicesQuestion
            }
            else if (q is OpenEnded openEnded)
            {
                Answer = openEnded.Answer; // Use CorrectAnswer for OpenEndedQuestion
            }
            else if (q is TrueFalse tf)
            {
                isTrue = tf.IsTrue; // Use IsTrue for TrueFalse
            }

            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.Parameters.AddWithValue("@QuestionType", q.GetType().Name);
            cmd.Parameters.AddWithValue("@QuestionText", q.questionText ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CorrectAnswer", Answer ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsTrue", isTrue ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionA", (q as MultipleChoices)?.Options.ElementAtOrDefault(0) ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionB", (q as MultipleChoices)?.Options.ElementAtOrDefault(1) ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionC", (q as MultipleChoices)?.Options.ElementAtOrDefault(2) ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@OptionD", (q as MultipleChoices)?.Options.ElementAtOrDefault(3) ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CorrectOption", correctOption ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@QuestionID", q.Id);
            try
            {
                if (myConnection.State != ConnectionState.Open)
                {
                    myConnection.Open();
                }
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Question updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the question: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Check if an item is selected
            if (listBoxQuestions.Text == "You don't have the questions to view")
            {
                MessageBox.Show($"You don't have any question to delete!");
            }

            else if (listBoxQuestions.SelectedIndex != -1)
            {
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this question?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string selectedText = listBoxQuestions.SelectedItem.ToString();
                        int questionId = int.Parse(selectedText.Split('.')[0]); // Extract the ID before the colon
                        Questions q = question.FirstOrDefault(x => x.Id == questionId);
                        // SQL query to delete the question
                        string query = "DELETE FROM Questions WHERE QuestionID = @QuestionID";
                        SqlCommand cmd = new SqlCommand(query, myConnection);
                        cmd.Parameters.AddWithValue("@QuestionID", q.Id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Remove the question from the list and refresh the display
                            question.RemoveAt(listBoxQuestions.SelectedIndex);
                            DisplayQuestions();
                            FilterType();
                            MessageBox.Show("Question deleted successfully.");

                        }
                        else
                        {
                            MessageBox.Show($"Debug: Attempting to delete QuestionID = {q.Id}");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the question: {ex.Message}");
                    }
                }
            }
            // Check if there are any questions in the list
            else
            {
                MessageBox.Show("Please select a question to delete.");
                return;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormExtensions.OpenForm(this, Home, new Point(450, 170));
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (listViewFilter.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewFilter.SelectedIndices[0];          // First selected index
                string selectedType = listViewFilter.Items[selectedIndex].Text; // Get the item text
                // Call the method to display questions of the selected type
                DisplayFilteredQuestions(selectedType);
            }
            else
            {
                MessageBox.Show("No type of question selected below.");
            }
        }
        public void DisplayFilteredQuestions(string questionType)
        {
            listBoxQuestions.Items.Clear();

            string query = @"SELECT QuestionID, QuestionType, QuestionText, CorrectAnswer, IsTrue, OptionA, OptionB, OptionC, OptionD, CorrectOption 
                            FROM Questions WHERE QuestionType = @QuestionType";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.Parameters.AddWithValue("@QuestionType", questionType); // Use parameterized query to prevent SQL injection
            SqlDataReader result = cmd.ExecuteReader();
            try
            {
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        int questionID = result.GetInt32(0); // QuestionID
                        string questionText = result.GetString(2); // QuestionText
                        listBoxQuestions.Items.Add($"{result[0],-3}. [{result[1],-5}] {result[2]}");
                    }
                }
                else
                {
                    listBoxQuestions.Items.Add($"You don't have the questions to view");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                result.Close(); // Always close the reader to release the connection for other commands
            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (listBoxQuestions.Text == "You don't have the questions to view")
            {
                MessageBox.Show($"You don't have any question to refresh");
            }
            else
            {
                DisplayQuestions();
            }
        }
    }
}
