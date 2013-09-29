using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Maksim Ustionv
 * CMPE 285 - Software Engineering Process
 * LAB 3 - Exceptions & Events
 * 10/02/2013
 * */
namespace Assignment2_WindowsFormClaculator
{
    public partial class Form1 : Form
    {
        Timer _timer; // Timer for the label to disappear

        public Form1()
        {
            InitializeComponent();
        }

        private void calc(object sender, EventArgs e)
        {
            this.lblErrorMsg.Text = "";             // reset error label
            this.txtVal1.BackColor = Color.White;   // reset text box 1 background color
            this.txtVal2.BackColor = Color.White;   // reset text box 2 background color

            Button btnClicked = (Button)sender;     // create a variable of a button that was clicked 

            Double val1 = 0;
            Double val2 = 0;

            try
            {
                val1 = Double.Parse(txtVal1.Text);
            }
            /**
             * Exception to catch Null argument in the text box
             **/
            catch (ArgumentNullException anEx)
            {
                this.lblErrorMsg.Text = "Text Box 1. Argument Null Excepiton";
                this.txtVal1.BackColor = Color.Red;
                this.txtVal1.Focus();
                return;
            }
            /**
             * Exception to catch not formatted number in a text box
             * For example it will catch this error when a text will be entere
             * instead of a number
             * */
            catch (FormatException fEx)
            {
                this.lblErrorMsg.Text = "Text Box 1. Format Exception";
                this.txtVal1.BackColor = Color.Red;
                this.txtVal1.Focus();
                return;
            }
            /**
             * Exception to catch a buffer overflow. This might happen when a user
             * will enter a value in the box that is more than 64bits (size of Double in C#) 
             * */
            catch (OverflowException oEx)
            {
                this.lblErrorMsg.Text = "Text Box 1. Overflow Excepiton.";
                this.txtVal1.BackColor = Color.Red;
                this.txtVal1.Focus();
                return;
            }
            /**
             * Excpetion that will catch any other (general) exception that might happen
             * during the execution
             * */
            catch (Exception ex)
            {
                this.lblAnswer.Text = "Text Box 1. Unknown Excepiton. " + ex.StackTrace;
                this.txtVal1.BackColor = Color.Red;
                this.txtVal1.Focus();
                return;
            }

            // try-catch block for a second text box
            try
            {
                val2 = Double.Parse(txtVal2.Text);

                /**
                 * Thrown an exception if second text box contains zero 
                 * during devision procedure
                 * */
                if (val2 == 0 && btnClicked.Equals(btnDivide))
                {
                    throw new DivideByZeroException();
                }
            }
            /**
             * Exception to catch Null argument in the text box
             **/
            catch (ArgumentNullException anEx)
            {
                this.lblErrorMsg.Text = "Text Box 2. Argument Null Excepiton";
                this.txtVal2.BackColor = Color.Red;
                this.txtVal2.Focus();
                return;
            }
            /**
             * Exception to catch not formatted number in a text box
             * For example it will catch this error when a text will be entere
             * instead of a number
             * */
            catch (FormatException fEx)
            {
                this.lblErrorMsg.Text = "Text Box 2. Format Exception";
                this.txtVal2.BackColor = Color.Red;
                txtVal2.Focus();
                return;
            }
            /**
             * Exception to catch a buffer overflow. This might happen when a user
             * will enter a value in the box that is more than 64bits (size of Double in C#) 
             * */
            catch (OverflowException oEx)
            {
                this.lblErrorMsg.Text = "Text Box 2. Overflow Excepiton.";
                this.txtVal2.BackColor = Color.Red;
                txtVal2.Focus();
                return;
            }
            /**
             * Excpetion that will catch division by zero (zero in a second text box)
             * */
            catch (DivideByZeroException dbzEx)
            {
                this.lblErrorMsg.Text = "Text Box 2. Can't divide by 0.";
                this.txtVal2.BackColor = Color.Red;
                txtVal2.Focus();
                return;
            }
            /**
             * Excpetion that will catch any other (general) exception that might happen
             * during the execution
             * */
            catch (Exception ex)
            {
                this.lblErrorMsg.Text = "Text Box 2. Unknown Excepiton. " + ex.StackTrace;
                this.txtVal2.BackColor = Color.Red;
                txtVal1.Focus();
                return;
            }

            if (btnClicked.Equals(btnAdd))
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

                try
                {
                    Double divVal = val1 / val2;

                    lblAnswer.Text = Convert.ToString(divVal);

                }
                /**
                 * Excpetion that will catch any other (general) exception that might happen
                 * during the execution, just in case :)
                 * */
                catch (Exception ex)
                {
                    lblErrorMsg.Text = ex.StackTrace;
                }
            }
            else
            {
                lblSymbol.Text = "";
                lblErrorMsg.Text = "Unknown button was clicked!";
            }
        }

        /**
         * This method is for Text Boxes. I will work only for the key press event
         * */
        private void keyPressInTxtBox(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (sender as TextBox);
            txt.BackColor = Color.White;

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
            if (e.KeyChar == '.' && txt.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            // only allow 
            // 1. negative symbol AND
            // 2. must be only the first
            if (e.KeyChar == '-' && txt.Text.IndexOf('-') > -1 && txt.Text.IndexOf('-') == 0)
            {
                e.Handled = true;
            }
        }


        /**
         * Form closing listener to make sure that the user is ready to close this window
         * */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;

            dialogResult = MessageBox.Show("Do you really want to close?", "App name", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
                this.eventInfoLbl.Text = "Canceled form closing.";

                _timer = new Timer(); 
                // Set up timer for 3 seconds
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

        Color prevColor; // previous color

        /**
         * Listener for a mouse to hover over the a button
         * */
        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            Button btnObj = (Button)sender;

            prevColor = btnObj.BackColor;

            btnObj.BackColor = Color.Coral;
        }

        /**
         * Listener for a mouse to leave from a button
         * */
        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            Button btnObj = (Button)sender;

            btnObj.BackColor = prevColor;
        }

        /**
         * Listener for a mouse to hover over a text box
         * */
        private void txtVal1_MouseEnter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            prevColor = tb.BackColor;

            tb.BackColor = Color.Coral;

        }

        /**
         * Listener for a mouse to leave from a text box
         * */
        private void txtVal1_MouseLeave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = prevColor;
        }
    }
}
