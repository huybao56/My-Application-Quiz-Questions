namespace COMP1551_Part_1
{
    public partial class Create : Form
    {
        //Set initially form
        private Quiz home;
        private ShowQuestion showQuestion;
        public Create(Quiz main)
        {
            InitializeComponent();
            FormExtensions.FixedPosition(this, new Point(450, 170));    //Set fixed position
            lblError.Text = "";
            home = main;           //pass reference
            cbTypeQuestion.Text = "Multiple Choices";   //Set initially
        }

        //Return Home Quiz
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormExtensions.OpenForm(this, home, new Point(450, 170));
        }

        //Method Check the type of question
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Switch case for three type of combobox
            switch (cbTypeQuestion.Text.ToLower())
            {
                case "multiple choices":
                    CreateTypeQuetions(typeof(MultipleChoices));
                    break;

                case "true / false":
                    CreateTypeQuetions(typeof(TrueFalse));
                    break;

                case "open-ended":
                    CreateTypeQuetions(typeof(OpenEnded));
                    break;

                default:
                    lblError.Text = "Your selection is not valid.";
                    break;
            }
        }
        private void CreateTypeQuetions(Type type)
        {
            TypeOfQuestions createQuestion = new TypeOfQuestions(type, home, showQuestion, this, null);       //Instance of TypeOfQuestion
            FormExtensions.OpenForm(this, createQuestion, new Point(450, 170));                         //Open Form TypeOfQuestions
            lblError.Text = ""; //Set empty after the action of not valid
        }
    }
}
