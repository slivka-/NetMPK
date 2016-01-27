using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

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

            try
            {
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        values.Add(Convert.ToString(rdr[columnName]));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
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
                            JOIN Connection c1 ON ls.Id_stop = c1.From_stop_id
                            JOIN LineRoute lr1 ON lr1.Id_route = c1.Id_route
                            JOIN Line l1 ON l1.Id_line = lr1.Id_line
                            WHERE l1.Line_number = " + lineNumber + @"
                            ORDER BY lr1.Stop_number;";

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
	                            WHERE Name =  '" + stopName + @"'

                            )
                            OR
                            c.To_stop_id IN (
	                            SELECT ls.Id_stop
	                            FROM LineStop ls
	                            WHERE Name =  '" + stopName + @"'
                            )";
            return GetOneColumnData(query, "Line_number");
        }

        public void SaveUser(User user)
        {
            String query = @"SELECT MAX(Id_user) Id FROM USERS";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int ID = 0;
            object o = cmd.ExecuteScalar();

            if (o != DBNull.Value)
            {
                ID = Convert.ToInt32(o) + 1;
            }

            query = @"INSERT INTO Users (Id_user, Username, Mail, User_password, User_status) VALUES
            (" + ID + @", '" + user.Username + @"', '" + user.Mail + @"', '" + user.Password + @"', " + (user.UserStatus ? 1 : 0) + @" );";
            cmd = new SqlCommand(query, sqlConnection);
            cmd.ExecuteNonQuery();
        }

        public bool IsMailInDB(String mail)
        {
            String query = @"SELECT COUNT(*) FROM USERS WHERE Mail = @mail;";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@mail", mail);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result > 0;
        }

        public bool IsUsernameInDB(String Username)
        {
            String query = @"SELECT COUNT(*) FROM USERS WHERE Username = @Username;";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Username", Username);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result > 0;
        }

        public int GetStopCount()
        {
            OpenConnection();
            String query = @"SELECT COUNT(*) FROM LineStop";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnection();
            return result;
        }

        public List<int> GetAllStopsID()
        {
            OpenConnection();
            String query = @"SELECT Id_line FROM Line";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            List<int> items = new List<int>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    items.Add(Convert.ToInt32(rdr["Id_line"]));
                }
            }
            CloseConnection();
            return items;
        }

        public List<int> GetAllToStopID(int From_stop_id)
        {
            OpenConnection();
            String query = @"SELECT To_stop_id FROM Connection WHERE From_stop_id = @From_stop_id 
                            AND To_stop_id <> @From_stop_id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@From_stop_id", From_stop_id);
            List<int> items = new List<int>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    items.Add(Convert.ToInt32(rdr["To_stop_id"]));
                }
            }
            CloseConnection();
            return items;
        }

        public int GetTimeFromConnection(int id1, int id2)
        {
            OpenConnection();
            String query = @"SELECT Transfer_time FROM Connection
                            WHERE (From_stop_id = @id1 AND To_stop_id = @id2)
                            OR (From_stop_id = @id2 AND To_stop_id = @id1);";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@id2", id2);
            //DateTime result = Convert.ToDateTime(cmd.ExecuteScalar());
            DateTime result = DateTime.ParseExact(cmd.ExecuteScalar().ToString(),
                "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            CloseConnection();
            return result.Minute;
        }

        public string GetStopNameFromID(int id)
        {
            OpenConnection();
            String query = @"SELECT Name FROM LineStop WHERE Id_stop = @id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);
            string result = Convert.ToString(cmd.ExecuteScalar());
            CloseConnection();
            return result;
        }

        public int GetIDFromStopName(string name)
        {
            OpenConnection();
            String query = @"SELECT Id_stop FROM LineStop WHERE name = @name";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@name", name);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnection();
            return result;
        }

        public bool CheckIfExists(string value)
        {
            OpenConnection();
            String query = @"SELECT COUNT(*) FROM LineStop WHERE Name = @value";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@value", value);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnection();
            return result > 0;
        }
    }
}