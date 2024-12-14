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

namespace COMP1551_Part_1
{
    public partial class Ranking : Form
    {
        private Quiz home;
        SqlConnection myConnection;
        String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MYDATABASE;" +
            "Trusted_Connection=True; Trust Server Certificate=True; Integrated Security=True;" +
            "User Id=admin;Password=...";
        public Ranking(Quiz Home)
        {
            InitializeComponent();
            FormExtensions.FixedPosition(this, new Point(450, 170));    //Set fixed position
            home = Home;                                                //Set the reference
            ShowPlayer();                                               //Show Players
        }
        public void ShowPlayer()
        {
            int index = 1;                                  //Set index to respectively
            listBoxPlayer.Font = new Font("Consolas", 10);  //Set the font listBox
            listBoxPlayer.Items.Clear();                    //Refresh the list
            myConnection = new SqlConnection(connectionString); //Set the reference SqlConnection
            myConnection.Open();                                //Open the DB
            SqlCommand sqlCommand = new SqlCommand("SELECT PlayerName, CorrectAnswer, PlayerTime FROM Player ORDER BY CorrectAnswer Desc, PlayerTime ASC", myConnection);   //Select Player
            SqlDataReader result = sqlCommand.ExecuteReader();  //Execute the reader
            try
            {
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        TimeSpan playerTime = (TimeSpan)result["PlayerTime"];   // Get the PlayerTime as a TimeSpan
                        string formattedTime = $"{playerTime.Hours:D2}:{playerTime.Minutes:D2}:{playerTime.Seconds:D2}.{playerTime.Milliseconds:D3}";   // Format the TimeSpan with 3 decimal milliseconds
                        listBoxPlayer.Items.Add($"{index}. {result[0],-15} Correct: {result[1],-3}. Time: {formattedTime}");    //result[0]: PlayerName, result[1]: CorrectAnswer
                        index++;    //Increase respectively
                    }
                }
                else
                {
                    listBoxPlayer.Items.Add("There is no player here!");    //Show no players
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");    //Check the error
            }
            finally
            {
                result.Close();  // Alway close for another command.
            }

        }

        //Method to get Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormExtensions.OpenForm(this, home, new Point(450, 170));  //Open the form Home
        }

        //Method to resert the rankings
        private void btnResert_Click(object sender, EventArgs e)
        {
            myConnection = new SqlConnection(connectionString); //Set the reference SqlConnection
            myConnection.Open();                                //Open the DB
            SqlCommand sqlCommand = new SqlCommand("SELECT PlayerName, CorrectAnswer, PlayerTime FROM Player ORDER BY CorrectAnswer Desc, PlayerTime ASC", myConnection);   //Select Player
            SqlDataReader result = sqlCommand.ExecuteReader();  //Execute the reader
            if (result.HasRows)
            {
                var click = MessageBox.Show("Do u want to resert all players?", "Confirm to resert", MessageBoxButtons.YesNo);

                if (click == DialogResult.Yes)
                {
                    myConnection = new SqlConnection(connectionString); //Set the reference SqlConnection
                    myConnection.Open();                                //Open the DB
                    SqlCommand cmd = new SqlCommand("TRUNCATE TABLE Player", myConnection);
                    SqlDataReader check = cmd.ExecuteReader();
                    ShowPlayer();
                    MessageBox.Show("You have reserted top players");
                }
                else
                {
                    ShowPlayer();
                }
            }
            else
            {
                MessageBox.Show("You don't have any player to resert");
            }
        }
    }
}
