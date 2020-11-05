using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADOLibrary
{
    public class Connection
    {
        internal string connectionString { get; set; }

        public Connection(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;
            return c;
        }

        public SqlCommand CreateCommand(Command mcmd, SqlConnection connection)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd = connection.CreateCommand();
            SqlCmd.CommandText = mcmd.Query;
            SqlCmd.CommandType = mcmd.IsStoredProcedure ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;
            if(mcmd.Parameters != null)
            {
                foreach (KeyValuePair<string, object> item in mcmd.Parameters)
                {
                    SqlParameter parameter = SqlCmd.CreateParameter();
                    parameter.ParameterName = item.Key;
                    parameter.Value = item.Value;

                    SqlCmd.Parameters.Add(parameter);
                }
            }
            return SqlCmd;
        }

        public int ExecuteNonQuery(Command command)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand cmd = CreateCommand(command, c))
                {
                    c.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(Command command)
        {
            using (SqlConnection c = CreateConnection())
            {
                using(SqlCommand cmd = CreateCommand(command, c))
                {
                    c.Open();
                    object t = cmd.ExecuteScalar();
                    return (t is DBNull) ? null : t;
                }
            }
        }

        public IEnumerable<T> ExecuteReader<T>(Command command, Func<SqlDataReader, T> convert)
        {
            using (SqlConnection c = CreateConnection())
            {
                using(SqlCommand cmd = CreateCommand(command, c))
                {
                    c.Open();
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return convert(dr);
                        }
                    }
                }
            }
        }
    }
}
