using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DatabaseManager
/// </summary>
public class DatabaseManager
{
    private static string _ConnectionString;

    public DatabaseManager()
    {
        _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"] != null ?
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString : string.Empty;
    }

    public static void ExecuteCommand(string commandString)
    {
        using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
        {
            SqlCommand SQLCommand = new SqlCommand(commandString, sqlConnection);
            SQLCommand.Connection.Open();
            SQLCommand.ExecuteNonQuery();
        }
    }

    public static List<string> ExecuteQuery(string queryString)
    {
        using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
        {
            List<string> QueryResult = new List<string>();

            SqlCommand SQLCommand = new SqlCommand(queryString, sqlConnection);
            SQLCommand.Connection.Open();

            using (SqlDataReader sqlDataReader = SQLCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    string RowValues = string.Empty;
                    int FieldCount = sqlDataReader.FieldCount;

                    for (int column = 0; column < FieldCount; column++)
                        RowValues += sqlDataReader[column].ToString() + "\t";

                    QueryResult.Add(RowValues);
                }
            }

            return QueryResult;
        }
    }
}
