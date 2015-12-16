using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace NetMPK
{
    public class DatabaseConnection
    {
        private SqlConnection sqlConnection;
        private static DatabaseConnection databaseConnection;

        private DatabaseConnection() { }

        public static DatabaseConnection getInstance()
        {
            if (databaseConnection == null)
            {
                databaseConnection = new DatabaseConnection();
            }
            return databaseConnection;
        }

        public bool OpenConnection(String connection = "MPKDB")
        {
            try
            {
                sqlConnection = new SqlConnection(@WebConfigurationManager.ConnectionStrings[connection].ToString());
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                }
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        private List<String> GetOneColumnData(String query, String columnName)
        {
            List<String> values = new List<string>();

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    values.Add(Convert.ToString(rdr[columnName]));
                }
            }

            return values;
        }

        public List<String> GetLinesNumbers()
        {
            return GetOneColumnData("Select Line_number FROM Line", "Line_number");
        }

        public List<String> GetLinesStopNames()
        {
            return GetOneColumnData("Select Name FROM LineStop", "Name");
        }

        public List<String> GetStopsFromLine(int lineNumber)
        {
            String query = @"SELECT ls.Name FROM LineStop ls
                            WHERE ls.Id_stop IN (
	                            (SELECT c.From_stop_id
	                            FROM Connection c
	                            WHERE c.Id_route IN (
			                            SELECT lr.Id_route
			                            FROM LineRoute lr
			                            WHERE Id_line IN (
				                            SELECT l.Id_line
				                            FROM Line l
				                            WHERE Line_number = " + lineNumber + @"
			                            )
			
		                            ))
	                            UNION ALL
	                            (SELECT c.To_stop_id
	                            FROM Connection c
	                            WHERE c.Id_route IN (
			                            SELECT lr.Id_route
			                            FROM LineRoute lr
			                            WHERE Id_line IN (
				                            SELECT l.Id_line
				                            FROM Line l
				                            WHERE Line_number =  " + lineNumber + @"
			                            )
			
		                            ))
	                            )";

            return GetOneColumnData(query, "Name");
        }

        public List<String> GetLinesFromStop(String stopName)
        {
            String query = @"SELECT DISTINCT l.Line_number
                            FROM Line l
                            JOIN LineRoute lr ON lr.Id_line = l.Id_line
                            JOIN Connection c ON c.Id_route = lr.Id_route
                            WHERE c.From_stop_id IN (
	                            SELECT ls.Id_stop
	                            FROM LineStop ls
	                            WHERE Name = " + stopName + @"
                            )
                            OR
                            c.To_stop_id IN (
	                            SELECT ls.Id_stop
	                            FROM LineStop ls
	                            WHERE Name = " + stopName + @"
                            )";
            return GetOneColumnData(query, "Line_number");
        }

    }
}