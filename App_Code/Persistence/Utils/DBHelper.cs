using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PIxEmpresas.App_Code.Persistence
{
    public class DBHelper
    {
        private IDbConnection connection;
        private IDbCommand command;

        public DBHelper(string query)
        {
            connection = Mapped.Connection();
            command = Mapped.Command(query, connection);
        }

        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return command;
            }

        }

        public IDbDataAdapter Adapter
        {
            get{
                return Mapped.Adapter(command);
            }
        }

        public void AddRangeParameter(IDbDataParameter[] parameters)
        {
            foreach(IDbDataParameter parameter in parameters)
                AddParameter(parameter);
        }

        public void AddParameter(string name, object value)
        {
            AddParameter(Mapped.Parameter(name, value));
        }

        public void AddParameter(IDbDataParameter parameter)
        {
            command.Parameters.Add(parameter);
        }

        public void Dispose()
        {
            command.Dispose();
            connection.Dispose();
            connection.Close();
        }
    }
}