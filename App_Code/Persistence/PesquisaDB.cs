using PIxEmpresas.App_Code.Classes;
using System;
using System.Data;

/// <summary>
/// Summary description for PesquisaDB
/// </summary>
namespace PIxEmpresas.App_Code.Persistence
{
    public class PesquisaDB
    {
        public static int Insert(Pesquisa pesquisa)
        {
            int resultStatus = 0;
            string query = "INSERT INTO psq_pesquisa" +
                "(psq_tipo, psq_implementacao, emp_codigo, cur_codigo, ans_codigo, psq_descricao, psq_contato) " +
                "VALUES(?psq_tipo, ?psq_implementacao, ?emp_codigo, ?cur_codigo, ?ans_codigo, ?psq_descricao, ?psq_contato);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?psq_tipo", pesquisa.Tipo);
                dbHelper.AddParameter("?psq_implementacao", pesquisa.Implementacao);
                dbHelper.AddParameter("?emp_codigo", pesquisa.Empresa.Codigo);
                dbHelper.AddParameter("?cur_codigo", pesquisa.Curso.Codigo);
                dbHelper.AddParameter("?ans_codigo", pesquisa.Anosemestre.codigo);
                dbHelper.AddParameter("?psq_descricao", pesquisa.Descricao);
                dbHelper.AddParameter("?psq_contato", pesquisa.Contato);

                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int InsertPSA(int codigopesquisa, int ra)
        {
            int resultStatus = 0;
            string query = "INSERT INTO psa_pesquisa_aluno" +
                "(psq_codigo, alu_ra) " +
                "VALUES(?psq_codigo, ?alu_ra);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?psq_codigo", codigopesquisa);
                dbHelper.AddParameter("?alu_ra", ra);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int InsertPSP(int codigopesquisa, string matricula)
        {
            int resultStatus = 0;
            string query = "INSERT INTO psp_pesquisa_professor" +
                "(psq_codigo, pro_matricula) " +
                "VALUES(?psq_codigo, ?pro_matricula);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?psq_codigo", codigopesquisa);
                dbHelper.AddParameter("?pro_matricula", matricula);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static DataSet SelectAll()
        {
            string query = "SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM psq_pesquisa LEFT JOIN emp_empresa USING(emp_codigo) LEFT JOIN ans_anosemestre USING(ans_codigo) LEFT JOIN cur_cursos USING(cur_codigo) ORDER BY psq_codigo;";

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

        public static DataSet SelectByCurso(int codigo)
        {
            string query = "SELECT *, CONCAT(ans_semestre,' - ',ans_ano) as anosemestre FROM psq_pesquisa LEFT JOIN emp_empresa USING(emp_codigo) LEFT JOIN ans_anosemestre USING(ans_codigo) LEFT JOIN cur_cursos USING(cur_codigo) WHERE cur_codigo = ?codigo ORDER BY anosemestre DESC;";

            DataSet dataSet = new DataSet();
            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
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

        public static int SelectLastInsertCod()
        {
            string query = "SELECT psq_codigo FROM psq_pesquisa ORDER BY psq_codigo DESC limit 1;";
            int psq_codigo = 0;  
            DBHelper dbHelper;
            IDataReader reader;

            try
            {
                dbHelper = new DBHelper(query);
                reader = dbHelper.Command.ExecuteReader();
                while (reader.Read())
                {
                    psq_codigo = Convert.ToInt32(reader["psq_codigo"]);
                }
                dbHelper.Dispose();
            }
            catch
            {
                psq_codigo = -2;
            }

            return psq_codigo;
        }
    }
}