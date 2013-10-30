using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Security.Principal;


public partial class Login : System.Web.UI.Page
{

    private UserServices userServices = new UserServices();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /**
    * 1. Fired before when user presses "Login" button
    */
    protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        System.Console.WriteLine("START LOGIN");
    }


    /**
     * 2. Fired after LogginIn method to perform authentication
     */
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool authenticated = false;

        string userNameTxt = Login1.UserName;
        string passTxt = Login1.Password;

        authenticated = userServices.authenticateUser(userNameTxt, passTxt);

        e.Authenticated = authenticated; // set login status.

        if (authenticated)
        {

            string roles = userServices.getRoles(userNameTxt);

            // Create the authentication ticket
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                                    (1,                             // Version
                                     userNameTxt,                   // User name
                                     DateTime.Now,                  // Creation
                                     DateTime.Now.AddMinutes(60),   // Expiration
                                     false,                         // Persistent
                                     roles);                        // User data

            // Code to create an encrypted string representation of the ticket and store it as data within an HttpCookie object.
            // Now encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            // Create a cookie and add the encrypted ticket to the cookie as data.
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);


            // Add the cookie to the cookies collection returned to the user's browser.
            Response.Cookies.Add(authCookie);

            // Redirect the user to the originally requested page
            // Response.Redirect(FormsAuthentication.GetRedirectUrl(userNameTxt, false));
        }













        // Extract the forms authentication cookie
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie2 = Context.Request.Cookies[cookieName];

        if (null == authCookie2)
        {
            // There is no authentication cookie.
            return;
        }

        //Add the following code to extract and decrypt the authentication ticket from the forms authentication cookie.
        FormsAuthenticationTicket authTicket2 = null;
        try
        {
            authTicket2 = FormsAuthentication.Decrypt(authCookie2.Value);
        }
        catch (Exception ex)
        {
            // Log exception details (omitted for simplicity)
            return;
        }

        if (null == authTicket2)
        {
            // Cookie failed to decrypt.
            return;
        }



        //Add the following code to parse out the pipe separate list of role names attached to the ticket when the user was originally authenticated.
        // When the ticket was created, the UserData property was assigned a
        // pipe delimited string of role names.
        string[] roles2 = authTicket2.UserData.Split(new char[] { '|' });




        //Add the following code to create a FormsIdentity object with the user name obtained from the ticket name and a GenericPrincipal object that contains this identity together with the user's role list.
        // Create an Identity object
        FormsIdentity id = new FormsIdentity(authTicket2);

        // This principal will flow throughout the request.
        GenericPrincipal principal = new GenericPrincipal(id, roles2);
        // Attach the new principal object to the current HttpContext object
        Context.User = principal;


    }


    /**
     * 3a. Fired when user is authenticated.
     */
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        System.Console.WriteLine("LOGED IN");
    }

    /**
     * 3b. Fired when user if failed to be authenticated.
     */
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        System.Console.WriteLine("LOGIN ERRORRRRRRR");
    }
}