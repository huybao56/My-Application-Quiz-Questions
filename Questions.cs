using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace COMP1551_Part_1
{
    // The Main Class
    public abstract class Questions
    {
        // Fields
        public int Id { get; set; }                                     // Primary key
        public string questionText { get; set; }                        // The question text
        public abstract string QuestionType { get; }                    // Three type of quesions: MultipleChoices, OpenEnded, TrueFalse
        // Method
        public abstract void SaveToDatabase(SqlConnection connection);  // Save question to the database
    }
    // The SubClasses
    public class MultipleChoices : Questions
    {
        // Fields
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        // Polymorphism
        public override string QuestionType => "MultipleChoices";
        public override void SaveToDatabase(SqlConnection connection)
        {
            string query = @"
            INSERT INTO Questions (QuestionText, QuestionType, OptionA, OptionB, OptionC, OptionD, CorrectOptionIndex)
            VALUES (@QuestionText, @QuestionType, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectOptionIndex)";

            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@QuestionText", questionText);
                command.Parameters.AddWithValue("@QuestionType", QuestionType);
                command.Parameters.AddWithValue("@OptionA", Options[0]);
                command.Parameters.AddWithValue("@OptionB", Options[1]);
                command.Parameters.AddWithValue("@OptionC", Options[2]);
                command.Parameters.AddWithValue("@OptionD", Options[3]);
                command.Parameters.AddWithValue("@CorrectOptionIndex", CorrectOptionIndex);
                command.ExecuteNonQuery();
            }
        }
    }
    public class TrueFalse : Questions
    {
        //public bool IsTrue { get; set; }
        public override string QuestionType => "TrueFalse";
        public bool IsTrue { get; set; }

        public override void SaveToDatabase(SqlConnection connection)
        {
            string query = "INSERT INTO Questions (QuestionText, QuestionType, IsTrue) " +
                           "VALUES (@QuestionText, @QuestionType, @IsTrue)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@QuestionText", questionText);
                command.Parameters.AddWithValue("@QuestionType", QuestionType);
                command.Parameters.AddWithValue("@IsTrue", IsTrue);
                command.ExecuteNonQuery();
            }
        }
    }
    public class OpenEnded : Questions
    {
        //public string Answer { get; set; }
        public override string QuestionType => "OpenEnded";
        public string Answer { get; set; }

        public override void SaveToDatabase(SqlConnection connection)
        {
            string query = "INSERT INTO Questions (QuestionText, QuestionType, Answer) " +
                           "VALUES (@QuestionText, @QuestionType, @Answer)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@QuestionText", questionText);
                command.Parameters.AddWithValue("@QuestionType", QuestionType);
                command.Parameters.AddWithValue("@Answer", Answer);
                command.ExecuteNonQuery();
            }
        }
    }
}
