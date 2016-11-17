using PIxEmpresas.App_Code.Classes;
using System;
using System.Data;

/// <summary>
/// Summary description for EmpresaDB
/// </summary>
namespace PIxEmpresas.App_Code.Persistence
{
    public class EmpresaDB
    {
        public static int Insert(Empresa empresa)
        {
            int resultStatus = 0;
            string query = "INSERT INTO emp_empresa "+
                "(emp_nomefantasia, emp_telefone1, emp_telefone2, emp_endereco, emp_cidade, emp_estado, emp_bairro, emp_cep, emp_email) "+
                "VALUES (?nomefantasia, ?telefone1, ?telefone2, ?endereco, ?cidade, ?estado, ?bairro, ?cep, ?email);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nomefantasia", empresa.NomeFantasia);
                dbHelper.AddParameter("?telefone1", empresa.Telefone1);
                dbHelper.AddParameter("?telefone2", empresa.Telefone2);
                dbHelper.AddParameter("?endereco", empresa.Endereco);
                dbHelper.AddParameter("?cidade", empresa.Cidade);
                dbHelper.AddParameter("?estado", empresa.Estado);
                dbHelper.AddParameter("?bairro", empresa.Bairro);
                dbHelper.AddParameter("?cep", empresa.Cep);
                dbHelper.AddParameter("?email", empresa.Email);

                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static DataSet SelectEmpresas()
        {
            string query = "SELECT * FROM emp_empresa ORDER BY emp_nomefantasia;";

            DataSet dataSet = new DataSet();
            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                adapter = dbHelper.Adapter;
                adapter.Fill(dataSet);
                dbHelper.Dispose();
            }
            catch
            {
                dataSet = null;
            }

            return dataSet;
        }

        public static Empresa SelectByCodigo(int codigo)
        {
            string query = "SELECT * FROM emp_empresa WHERE emp_codigo = ?codigo;";

            DataSet dataSet = new DataSet();
            DBHelper dbHelper;
            Empresa empresa = new Empresa();
            IDataReader reader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                reader = dbHelper.Command.ExecuteReader();
                while (reader.Read())
                {
                    empresa.Codigo = Convert.ToInt32(reader["emp_codigo"]);
                    empresa.NomeFantasia = Convert.ToString(reader["emp_nomefantasia"]);
                    empresa.Telefone1 = Convert.ToString(reader["emp_telefone1"]);
                    empresa.Telefone2 = Convert.ToString(reader["emp_telefone2"]);
                    empresa.Endereco = Convert.ToString(reader["emp_endereco"]);
                    empresa.Cidade = Convert.ToString(reader["emp_cidade"]);
                    empresa.Estado = Convert.ToString(reader["emp_estado"]);
                    empresa.Bairro = Convert.ToString(reader["emp_bairro"]);
                    empresa.Cep = Convert.ToString(reader["emp_cep"]);
                    empresa.Email = Convert.ToString(reader["emp_email"]);
                }
                dbHelper.Dispose();
            }
            catch
            {
                empresa = null;
            }

            return empresa;
        }
    }
}