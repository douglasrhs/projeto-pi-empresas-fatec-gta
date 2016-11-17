using System;
using System.Data;
using PIxEmpresas.App_Code.Classes;

/// <summary>
/// Summary description for Curso2DB
/// </summary>
namespace PIxEmpresas.App_Code.Persistence
{
    public class Curso2DB
    {
        public static DataSet SelectAll()
        {
            string query = "SELECT * FROM cur_cursos;";

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

        public static Curso2 SelectByCodigo(int codigo)
        {
            string query = "SELECT * FROM cur_cursos WHERE cur_codigo = ?codigo;";

            DataSet dataSet = new DataSet();
            DBHelper dbHelper;
            Curso2 curso = new Curso2();
            IDataReader reader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                reader = dbHelper.Command.ExecuteReader();
                while (reader.Read())
                {
                    curso.Codigo = Convert.ToInt32(reader["cur_codigo"]);
                    curso.Nome = Convert.ToString(reader["cur_nome"]);
                    curso.Sigla = Convert.ToString(reader["cur_sigla"]);
                    
                }
                dbHelper.Dispose();
            }
            catch
            {
                curso = null;
            }

            return curso;
        }
    }
}