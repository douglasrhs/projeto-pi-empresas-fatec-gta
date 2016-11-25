using PIxEmpresas.App_Code.Classes;
using System;
using System.Data;

/// <summary>
/// Summary description for AnosemestreDB
/// </summary>
namespace PIxEmpresas.App_Code.Persistence
{
    public class AnosemestreDB
    {
        public static DataSet SelectAnoSemestre()
        {
            string query = "SELECT ans_codigo as codigo, ans_semestre as semestre, ans_ano as ano, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM ans_anosemestre ORDER BY codigo DESC;";

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

        public static Anosemestre SelectByCodigo(int codigo)
        {
            string query = "SELECT * FROM ans_anosemestre WHERE ans_codigo = ?codigo;";

            DataSet dataSet = new DataSet();
            DBHelper dbHelper;
            Anosemestre anosemestre = new Anosemestre();
            IDataReader reader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                reader = dbHelper.Command.ExecuteReader();
                while (reader.Read())
                {
                    anosemestre.codigo = Convert.ToInt32(reader["ans_codigo"]);
                    anosemestre.ano = Convert.ToInt32(reader["ans_ano"]);
                    anosemestre.semestre = Convert.ToInt32(reader["ans_semestre"]);
                }
                dbHelper.Dispose();
            }
            catch
            {
                anosemestre = null;
            }

            return anosemestre;
        }
    }
}