using PIxEmpresas.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Aluno2DB
/// </summary>
/// 
namespace PIxEmpresas.App_Code.Persistence
{
    public class Aluno2DB
    {
        public static int Insert(Aluno2 aluno)
        {
            int resultStatus = 0;
            string query = "INSERT INTO alu_aluno" +
                "(alu_ra, alu_nome) " +
                "VALUES(?ra, ?nome);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?ra", aluno.RA);
                dbHelper.AddParameter("?nome", aluno.Nome);

                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static bool Exists(int ra)
        {
            string query = "SELECT * FROM alu_aluno WHERE alu_ra = ?ra;";
            
            DBHelper dbHelper;
            bool retorno;
            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?ra", ra);
                retorno = Convert.ToBoolean(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch
            {
                retorno = false;
            }

            return retorno;
        }
    }
}