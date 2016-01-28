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
                            JOIN LineConnection lr1 ON lr1.Id_route = c1.Id_route
                            JOIN Line l1 ON l1.Id_line = lr1.Id_line
                            WHERE l1.Line_number = " + lineNumber + @"
                            ORDER BY lr1.Stop_number;";

            return GetOneColumnData(query, "Name");
        }

        public List<String> GetLinesFromStop(String stopName)
        {
            String query = @"SELECT DISTINCT l.Line_number
                            FROM Line l
                            JOIN LineConnection lr ON lr.Id_line = l.Id_line
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

            query = @"INSERT INTO Users (Id_user, Username, Mail, User_password, User_status, Verification_Code) VALUES
            (" + ID + @", '" + user.Username + @"', '" + user.Mail + @"', '" + user.Password + @"', " + user.UserStatus + @", " + user.VerificationCode + @" );";
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

        public bool IsCodeInDB(int verificationCode)
        {
            String query = @"SELECT COUNT(*) FROM USERS WHERE Verification_Code = @code;";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@code", verificationCode);
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

        public String getUsersPassword(String Username)
        {
            String query = @"SELECT User_password FROM USERS WHERE Username = '"+Username+@"';";
            List<String> res = GetOneColumnData(query, "User_password");
            return res[0];
        }

        public int getUserStatus(String Username)
        {
            String query = @"SELECT User_status FROM USERS WHERE Username = '" + Username + @"';";
            List<String> res = GetOneColumnData(query, "User_status");
            return int.Parse(res[0]);
        }

        public int getUserVerificationCode(String Username)
        {
            String query = @"SELECT Verification_Code FROM USERS WHERE Username = '" + Username + @"';";
            List<String> res = GetOneColumnData(query, "Verification_Code");
            return int.Parse(res[0]);
        }

        public String getUserEmail(String Username)
        {
            String query = @"SELECT Mail FROM USERS WHERE Username = '" + Username + @"';";
            List<String> res = GetOneColumnData(query, "Mail");
            return res[0];
        }

        public void confirmUser(String Username)
        {
            String query = @"UPDATE USERS SET User_status = 1 WHERE Username = '" + Username + @"';";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.ExecuteNonQuery();
        }

        public List<String> getUserStatistics(String Username)
        {
            List<String> items = new List<String>();
            String query = @"SELECT Avg_time,Fav_line FROM UserStatistics WHERE Id_user IN(SELECT Id_user FROM USERS WHERE Username = '" + Username + @"');";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    items.Add(Convert.ToString(rdr["Avg_time"]) +"|"+ Convert.ToString(rdr["Fav_line"]));
                }
            }
            return items;
        }

        public List<String> getStartingTimes(int linenumber, int direction)
        {
            List<String> items = new List<String>();
            String query = @"SELECT Starting_time,DayWeek FROM LINEDETAILS WHERE Line_number = " + linenumber + @" AND Direction = "+direction+@" ORDER BY Starting_time ASC;";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    items.Add(Convert.ToString(rdr["Starting_time"])+"|"+ Convert.ToString(rdr["DayWeek"]));
                }
            }
            return items;
        }

        public List<String> getArrivalTime(String stopname,int linenumber,String startTime, int direction)
        {
            List<String> items = new List<String>();
            String query = @"exec CZAS_DO_PRZYSTANKU @NAZWA_P ='"+stopname+@"', @LINIA='"+linenumber+@"', @START_TIME = '"+startTime+@"', @DIRECTION = "+direction+";";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    items.Add(Convert.ToString(rdr.GetValue(0)));
                }
            }
            return items;
        }

    }
}