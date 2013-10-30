using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Diagnostics;

public partial class _Default : System.Web.UI.Page {


    protected void Page_Load(object sender, EventArgs e)
    {

        // Extract the forms authentication cookie
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];

        if (null == authCookie)
        {
            Server.Transfer("Login.aspx", true);
        }

        FormsAuthenticationTicket authTicket = null;
        try
        {
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        }
        catch (Exception ex)
        {
            // Log exception details (omitted for simplicity)
            return;
        }

        if (null == authTicket)
        {
            // Cookie failed to decrypt.
            return;
        }

        Debug.WriteLine(authTicket.ToString());
    }

    public void calc(object sender, EventArgs e)
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
}
