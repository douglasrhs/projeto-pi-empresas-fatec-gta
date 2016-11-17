using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace PIxEmpresas.App_Code.Persistence
{

    public class Mapped
    {

        public static IDbConnection Connection()
        {
            IDbConnection connection = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
            connection.Open();
            return connection;
        }

        public static IDbCommand Command(string query, IDbConnection connection)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            return command;

        }

        public static IDbDataParameter Parameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        public static IDbDataAdapter Adapter(IDbCommand command)
        {
            IDbDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            return adapter;
        }
    }
}