using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace COMP1551_Part_1
{
    // The class function for encapsulation
    public static class FormExtensions
    {
        // Method to open the new form
        public static void OpenForm(Form currentForm, Form newForm, Point position)
        {
            newForm.StartPosition = FormStartPosition.Manual;   // Starting the location
            newForm.Location = position;                        // Set The Location
            newForm.Show();                                     // Show the new form
            currentForm.Hide();                                 // Hide the current form (optional based on your requirements)
        }

        // Method to fixed the position of form
        public static void FixedPosition(this Form currentForm, Point position)
        {
            currentForm.StartPosition = FormStartPosition.Manual;   // Starting the location
            currentForm.Location = position;                        // Set The Location
        }
    }

}
