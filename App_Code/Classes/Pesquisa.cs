using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alunos;

/// <summary>
/// Summary description for Pesquisa
/// </summary>
namespace PIxEmpresas.App_Code.Classes
{
    public class Pesquisa
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Implementacao { get; set; }
        public Empresa Empresa { get; set; }
        public string Contato { get; set; }
        public Curso2 Curso { get; set; }
        public Anosemestre Anosemestre { get; set; }
        public string Descricao { get; set; }
        public IList<Aluno2> Alunos { get; set; }
        public IList<Professor2> Professores { get; set; }

    }
}