using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2_WindowsFormClaculator
{
    public partial class Form1 : Form
    {
        Timer _timer; // From System.Timers

        public Form1()
        {
            InitializeComponent();
        }

        private void calc(object sender, EventArgs e)
        {
            if (txtVal1.Text.Length < 0)
            {
                txtVal1.Text = "0";
            }

            if (txtVal2.Text.Length < 0)
            {
                txtVal2.Text = "0";
            }

            String valStr1 = txtVal1.Text;
            String valStr2 = txtVal2.Text;

            Double val1 = 0;
            Double val2 = 0;

            // let's pars the text first
            try
            {
                val1 = Double.Parse(valStr1);
                val2 = Double.Parse(valStr2);

            }
            catch (Exception ex)
            {
                this.lblAnswer.Text = "Error occured!";
            }

            Button btnClicked = (Button)sender;
            
            if(btnClicked.Equals(btnAdd))
            {
                lblSymbol.Text = "+";
                lblAnswer.Text = Convert.ToString(val1 + val2);
            } 
            else if (btnClicked.Equals(btnMin))
            {
                lblSymbol.Text = "-";
                lblAnswer.Text = Convert.ToString(val1 - val2);
            }
            else if (btnClicked.Equals(btnMultiply))
            {
                lblSymbol.Text = "x";
                lblAnswer.Text = Convert.ToString(val1 * val2);
            }
            else if (btnClicked.Equals(btnDivide))
            {
                lblSymbol.Text = "/";
                lblAnswer.Text = Convert.ToString(val1 / val2);
            }
            else
            {
                lblSymbol.Text = "";
                lblAnswer.Text = "Unknown button was clicked!";
            }   
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /**
             * Only allow:
             *  - NUMBERS
             *  - Have decimal point in the number
             *  - NEGATIVE sign in front
             **/
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'
                && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            // only allow negative symbol to be first
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') == 0)
            {
                e.Handled = true;
            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;


            dialogResult = MessageBox.Show("Do you really want to close?", "App name", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
                this.eventInfoLbl.Text = "Canceled close of the form";

                _timer = new Timer(); // Set up the timer for 3 seconds
                // Sets the timer interval to 5 seconds.
                /* Adds the event and the event handler for the method that will 
                    process the timer event to the timer. */
                _timer.Tick += new EventHandler(TimerEventProcessor);
                _timer.Interval = 5000;
                _timer.Start();
                
            }
        }

        /**
         * Method that will be envoked by the timer when time is up. 
         * Simliar to annonymous class in Java
         */
        void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            this.eventInfoLbl.Text = "";
            _timer.Stop();
        }
    }
}
