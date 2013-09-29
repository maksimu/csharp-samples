using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HelloDatabaseWorld1.utils;

namespace HelloDatabaseWorld1
{
    class Program
    {
        static DbConnUtils dbUtils = new DbConnUtils();


        static void Main(string[] args)
        {

            Boolean isCreated = dbUtils.createTable("some_table_name4");

            if (isCreated)
            {
                System.Console.WriteLine("Table was created!!!!!");
                System.Console.WriteLine("Here is a list of all tables for you:");
               
                foreach (String tblName in dbUtils.getAllTables())
                {
                    System.Console.WriteLine("  -> " + tblName);
                }
            }
            else
            {
                System.Console.WriteLine("ERRRRRRR..... Was not able to create a table");
            }

            System.Console.Read();
        }
    }
}
