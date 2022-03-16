using System;
using System.Data;
using System.Data.SqlClient;

namespace Reload.Data
{
    public class AutoTable : DataTable
    {
        public string ConnectionString { get; set; }
        public SqlCommand Command = new SqlCommand();
        public void Execute()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                Command.Connection = connection;
                this.Load(Command.ExecuteReader());
            }
        }

        public string Query { get { return Command.CommandText; } set { Command.CommandText = value; } }

        public void AddParameter<T>(string name, T value)
        {
            Command.Parameters.Add(new SqlParameter(name, value));
        }
    }
}
