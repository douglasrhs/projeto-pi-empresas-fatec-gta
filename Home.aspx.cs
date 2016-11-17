using System;
using System.Data;
using System.Web.UI;
using Alunos;
using System.Web.UI.WebControls;
using PIxEmpresas.App_Code.Persistence;
using System.Text;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            CarregarDDLCursos();
            CarregarGridPrincipal(Convert.ToInt32(ddlCursos.SelectedItem.Value));
            
        }
    }

    private void CarregarGridPrincipal(int codigo)
    {
        gdvPesqPrincipal.DataSource = PesquisaDB.SelectByCurso(codigo);
        gdvPesqPrincipal.DataBind();
        
    }



    private void CarregarDDLCursos()
    {
        ddlCursos.DataSource = Curso2DB.SelectAll();
        ddlCursos.DataValueField = "cur_codigo";
        ddlCursos.DataTextField = "cur_sigla";
        ddlCursos.DataBind();
    }

    
    protected void ddlCursos_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregarGridPrincipal(Convert.ToInt32(ddlCursos.SelectedValue));
    }

    protected void btnIr_Click(object sender, EventArgs e)
    {
        CarregarGridPrincipal(Convert.ToInt32(ddlCursos.SelectedItem.Value));
    }
}