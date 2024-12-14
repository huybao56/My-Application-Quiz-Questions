using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1551_Part_1
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            FormExtensions.FixedPosition(this, new Point(450, 170));    // Set Fixed Position
            timeLoading.Start();                                        // Start time to open
        }

        // Method Start the time
        private void timeLoading_Tick(object sender, EventArgs e)
        {
            barLoading.Width += 20;         //Increase width
            if(barLoading.Width >= 850)     //To Open Form
            {
                timeLoading.Stop();         //Stop Timer
                Quiz Home = new Quiz();     //Pass object to Form
                FormExtensions.OpenForm(this, Home, new Point(450, 170));   //Open Form Home
            }
        }
    }
}
