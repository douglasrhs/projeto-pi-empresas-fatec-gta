using PIxEmpresas.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Professor2DB
/// </summary>
/// 

namespace PIxEmpresas.App_Code.Persistence
{
    public class Professor2DB
    {
        public static int Insert(Professor2 professor)
        {
            int resultStatus = 0;
            string query = "INSERT INTO pro_professor" +
                "(pro_matricula, pro_nome) " +
                "VALUES(?matricula, ?nome);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?matricula", professor.Matricula);
                dbHelper.AddParameter("?nome", professor.Nome);

                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static bool Exists(string matricula)
        {
            string query = "SELECT * FROM pro_professor WHERE pro_matricula = ?matricula;";
            
            DBHelper dbHelper;
            bool retorno;
            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?matricula", matricula);
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