using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDatabaseWorld1.utils
{
    class DbConnUtils
    {

        String connectionString = "Data Source=MAKSIMUSTIN47B1;Initial Catalog=testdb;Persist Security Info=True;User ID=maksim;Password=zzzzzz";
        SqlConnection con;

        public DbConnUtils()
        {
            con = new SqlConnection(connectionString);
        }

        public Boolean createTable(String tableName)
        {
            Boolean isCreated = false;

            con.Open();
            
            try
            {
                using (SqlCommand command = new SqlCommand("CREATE TABLE " + tableName + " (Weight INT, Name TEXT, Breed TEXT)", con))
                {
                    command.ExecuteNonQuery();
                    isCreated = true;
                }
            }
            catch
            {
                Console.WriteLine("Table not created.");
                isCreated = false;
            }

            con.Close();

            return isCreated;
        }

        public List<String> getAllTables()
        {
            con.Open();
            List<String> allTables = new List<string>();

            String selectAllTablesSQL = "SELECT name FROM sys.tables WHERE name NOT LIKE 'sysdiagrams'";

            using (SqlCommand command = new SqlCommand(selectAllTablesSQL, con))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);  // Name string

                    allTables.Add(name);
                }
            }

            con.Close();
            return allTables;
        }

    }
}
