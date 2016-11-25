using PIxEmpresas.App_Code.Persistence;
using System;
using Alunos;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PIxEmpresas.App_Code.Classes;
using System.Text;
using System.Data;

public partial class Pesquisas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregarDDLs();
        }
        MultiView1.SetActiveView(View1);
        CarregarGridPesquisas();
    }

    private void CarregarDDLs()
    {
        CarregarDDLEmpresas();
        CarregarDDLCursos();
        CarregarDDLAnoSemestre();
    }

    private void CarregarDDLEmpresas()
    {
        ddlEmpresa.DataSource = EmpresaDB.SelectEmpresas();
        ddlEmpresa.DataValueField = "emp_codigo";
        ddlEmpresa.DataTextField = "emp_nomefantasia";
        ddlEmpresa.DataBind();
    }
    
    private void CarregarDDLCursos()
    {
        ddlCurso.DataSource = Curso2DB.SelectAll();
        ddlCurso.DataValueField = "cur_codigo";
        ddlCurso.DataTextField = "cur_sigla";
        ddlCurso.DataBind();
    }
    
    private void CarregarDDLAnoSemestre()
    {
        ddlAnoSemestre.DataSource = AnosemestreDB.SelectAnoSemestre();
        ddlAnoSemestre.DataValueField = "codigo";
        ddlAnoSemestre.DataTextField = "anosemestre";
        ddlAnoSemestre.DataBind();
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        Pesquisa pesquisa = new Pesquisa();

        pesquisa.Tipo = Convert.ToString(rblTipo.SelectedItem.Value);
        pesquisa.Implementacao = Convert.ToString(rblImplementacao.SelectedItem.Value);
        pesquisa.Descricao = txbProposta.Text;
        pesquisa.Contato = txbContato.Text;

        Empresa emp = new Empresa();
        emp.Codigo = Convert.ToInt32(ddlEmpresa.SelectedValue);
        pesquisa.Empresa = emp;

        Curso2 cur = new Curso2();
        cur.Codigo = Convert.ToInt32(ddlCurso.SelectedValue);
        pesquisa.Curso = cur;

        Anosemestre ans = new Anosemestre();
        ans.codigo = Convert.ToInt32(ddlAnoSemestre.SelectedValue);
        pesquisa.Anosemestre = ans;

        if (PesquisaDB.Insert(pesquisa) == -2)
        {
            Response.Write("<script>alert('Falha ao realizar o procedimento \nVerifique a causa do erro e tente novamente');</script>"); 
        }
        else
        {
            

            pesquisa.Codigo = PesquisaDB.SelectLastInsertCod();
            int resultOperation = 0;
            //Checando a lista de Alunos e Adicionando no Banco
            foreach (ListItem item in LBAlunosOk.Items)
            {
                Aluno2 aluno = new Aluno2();
                aluno.RA = Convert.ToInt32(item.Value);
                aluno.Nome = item.Text;
                if(Aluno2DB.Exists(aluno.RA) == false)
                    resultOperation += Aluno2DB.Insert(aluno);

                resultOperation += PesquisaDB.InsertPSA(pesquisa.Codigo, aluno.RA);
            }

            foreach (ListItem item in LBProfOk.Items)
            {
                Professor2 prof = new Professor2();
                prof.Matricula = item.Value;
                prof.Nome = item.Text;
                if (Professor2DB.Exists(prof.Matricula) == false)
                    resultOperation += Professor2DB.Insert(prof);

                resultOperation += PesquisaDB.InsertPSP(pesquisa.Codigo, prof.Matricula);                  
            }
        }


        //limpando os campos após envio dos dados

        txbProposta.Text = "";
        txbContato.Text = "";
        rblImplementacao.ClearSelection();
        rblTipo.ClearSelection();
        LBAlunosOk.Items.Clear();
        LBProcAlunos.Items.Clear();
        LBProcProf.Items.Clear();
        LBProfOk.Items.Clear();

        Response.Redirect("/Home.aspx");
        Response.Write("<script>alert('Sucesso ao realizar o procedimento \nProssiga!');</script>");


    }

    protected void btnSetView1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }

    protected void btnSetView2_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
    }

    private void CarregarGridPesquisas()
    {
        gdvPesquisas.DataSource = PesquisaDB.SelectAll();
        gdvPesquisas.DataBind();
    }

    protected void txbProcAluno_TextChanged(object sender, EventArgs e)
    {
        string nome = txbProcAluno.Text;
        if (nome == "")
            return;
        DataSet ds = new DataSet();
        ds = Aluno.SelecionarPorNome(nome);

        LBProcAlunos.Items.Clear();
        LBProcAlunos.DataValueField = "RA";
        LBProcAlunos.DataTextField = "Nome";
        LBProcAlunos.DataSource = ds;
        LBProcAlunos.DataBind();
    }

   

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (LBProcAlunos.SelectedIndex != -1)
        {
            LBAlunosOk.Items.Add(LBProcAlunos.SelectedItem);
            LBAlunosOk.ClearSelection();
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (LBAlunosOk.SelectedIndex != -1)
        {
            LBAlunosOk.Items.RemoveAt(LBAlunosOk.SelectedIndex);
        }
    }

    protected void txbProcProf_TextChanged(object sender, EventArgs e)
    {
        string nome = txbProcProf.Text;
        if (nome == "")
            return;
        DataSet ds = new DataSet();
        ds = Professor.SelecionarPorNome(nome);

        LBProcProf.Items.Clear();
        LBProcProf.DataValueField = "Matricula";
        LBProcProf.DataTextField = "Nome";
        LBProcProf.DataSource = ds;
        LBProcProf.DataBind();
    }

    protected void btnAddProf_Click(object sender, EventArgs e)
    {
        if (LBProcProf.SelectedIndex != -1)
        {
            LBProfOk.Items.Add(LBProcProf.SelectedItem);
            LBProfOk.ClearSelection();
        }
    }

    protected void btnRemoveProf_Click(object sender, EventArgs e)
    {
        if (LBProfOk.SelectedIndex != -1)
        {
            LBProfOk.Items.RemoveAt(LBProfOk.SelectedIndex);
        }
    }
}