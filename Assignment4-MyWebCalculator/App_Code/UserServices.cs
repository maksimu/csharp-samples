using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

/// <summary>
/// Summary description for UserServices
/// </summary>
public class UserServices
{
    DbConnUtils dbConnUtils = new DbConnUtils();

	public UserServices()
	{
	
	}

    public bool authenticateUser(string loginName, string password)
    {
        bool isAuthenticated = false;

        string userAuthSQL = "SELECT COUNT(*) " +
                              " FROM [dbo].[Users] as u " +
                              " WHERE u.username LIKE '" + loginName + "' " +
                              " AND u.passwordTxt LIKE '" + password + "'";


        SqlConnection con = dbConnUtils.getSqlConnection();

        try
        {
            con.Open();
            using (SqlCommand command = new SqlCommand(userAuthSQL, con))
            {
                int countOfRows = (int)command.ExecuteScalar();

                if (countOfRows > 0)
                {
                    isAuthenticated = true;
                }

            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
        finally
        {
            con.Close();
        }




        return isAuthenticated;
    }

    public string getRoles(string username)
    {
        // Lookup code omitted for clarity
        // This code would typically look up the role list from a database
        // table.
        // If the user was being authenticated against Active Directory,
        // the Security groups and/or distribution lists that the user
        // belongs to may be used instead

        // This GetRoles method returns a pipe delimited string containing
        // roles rather than returning an array, because the string format
        // is convenient for storing in the authentication ticket /
        // cookie, as user data

        // string[] roles = authTicket.UserData.Split(new char[]{'|'});
        return "Senior Manager|Manager|Employee";
    }


    /* ****
     * 
CREATE TABLE Users
(
id int IDENTITY(1,1) PRIMARY KEY,
lastName varchar(255) NOT NULL,
firstName varchar(255),
username varchar(255),
passwordtxt varchar(255),
Address varchar(255),
city varchar(255)
)
     * 
     * 
     * 
     * 
     */

}