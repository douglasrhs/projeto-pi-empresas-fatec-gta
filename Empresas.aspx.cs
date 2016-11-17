using PIxEmpresas.App_Code.Classes;
using PIxEmpresas.App_Code.Persistence;
using System;
using System.Collections.Generic;

public partial class Empresas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        CarregarGridEmpresas();
    }

    protected void ddlEstado_Load(object sender, EventArgs e)
    {
        CarregarDropDownList();
    }

    private List<Estado> RetornaLista()
    {
        //Instância da Lista 
        List<Estado> lista = new List<Estado>();

        //Crio novo Estado e adciono á lista 
        Estado uf1 = new Estado();
        uf1.sigla = "AC";
        uf1.estado = "Acre";
        lista.Add(uf1);
        //Crio novo Estado e adciono á lista 
        Estado uf2 = new Estado();
        uf2.sigla = "AL";
        uf2.estado = "Alagoas";
        lista.Add(uf2);
        //Crio novo Estado e adciono á lista 
        Estado uf3 = new Estado();
        uf3.sigla = "AP";
        uf3.estado = "Amapá";
        lista.Add(uf2);
        //Crio novo Estado e adciono á lista 
        Estado uf4 = new Estado();
        uf4.sigla = "AM";
        uf4.estado = "Amazonas";
        lista.Add(uf4);
        //Crio novo Estado e adciono á lista 
        Estado uf5 = new Estado();
        uf5.sigla = "BA";
        uf5.estado = "Bahia";
        lista.Add(uf5);
        //Crio novo Estado e adciono á lista 
        Estado uf6 = new Estado();
        uf6.sigla = "CE";
        uf6.estado = "Ceará";
        lista.Add(uf6);
        //Crio novo Estado e adciono á lista 
        Estado uf7 = new Estado();
        uf7.sigla = "DF";
        uf7.estado = "Distrito Federal";
        lista.Add(uf7);
        //Crio novo Estado e adciono á lista 
        Estado uf8 = new Estado();
        uf8.sigla = "ES";
        uf8.estado = "Espiríto Santo";
        lista.Add(uf8);
        //Crio novo Estado e adciono á lista 
        Estado uf9 = new Estado();
        uf9.sigla = "GO";
        uf9.estado = "Goiás";
        lista.Add(uf9);
        //Crio novo Estado e adciono á lista 
        Estado uf10 = new Estado();
        uf10.sigla = "MA";
        uf10.estado = "Maranhão";
        lista.Add(uf10);
        //Crio novo Estado e adciono á lista 
        Estado uf11 = new Estado();
        uf11.sigla = "MT";
        uf11.estado = "Mato Grosso";
        lista.Add(uf11);
        //Crio novo Estado e adciono á lista 
        Estado uf12 = new Estado();
        uf12.sigla = "MS";
        uf12.estado = "Mato Grosso do Sul";
        lista.Add(uf12);
        //Crio novo Estado e adciono á lista 
        Estado uf13 = new Estado();
        uf13.sigla = "MG";
        uf13.estado = "Minas Gerais";
        lista.Add(uf13);
        //Crio novo Estado e adciono á lista 
        Estado uf14 = new Estado();
        uf14.sigla = "PA";
        uf14.estado = "Pará";
        lista.Add(uf14);
        //Crio novo Estado e adciono á lista 
        Estado uf15 = new Estado();
        uf15.sigla = "PB";
        uf15.estado = "Paraíba";
        lista.Add(uf15);
        //Crio novo Estado e adciono á lista 
        Estado uf16 = new Estado();
        uf16.sigla = "PR";
        uf16.estado = "Paraná";
        lista.Add(uf16);
        //Crio novo Estado e adciono á lista 
        Estado uf17 = new Estado();
        uf17.sigla = "PE";
        uf17.estado = "Pernambuco";
        lista.Add(uf17);
        //Crio novo Estado e adciono á lista 
        Estado uf18 = new Estado();
        uf18.sigla = "PI";
        uf18.estado = "Piauí";
        lista.Add(uf2);
        //Crio novo Estado e adciono á lista 
        Estado uf19 = new Estado();
        uf19.sigla = "RJ";
        uf19.estado = "Rio de Janeiro";
        lista.Add(uf19);
        //Crio novo Estado e adciono á lista 
        Estado uf20 = new Estado();
        uf20.sigla = "RN";
        uf20.estado = "Rio Grande do Norte";
        lista.Add(uf20);
        //Crio novo Estado e adciono á lista 
        Estado uf21 = new Estado();
        uf21.sigla = "RS";
        uf21.estado = "Rio Grande do Sul";
        lista.Add(uf21);
        //Crio novo Estado e adciono á lista 
        Estado uf22 = new Estado();
        uf22.sigla = "RO";
        uf22.estado = "Rondônia";
        lista.Add(uf22);
        //Crio novo Estado e adciono á lista 
        Estado uf23 = new Estado();
        uf23.sigla = "RR";
        uf23.estado = "Roraima";
        lista.Add(uf23);
        //Crio novo Estado e adciono á lista 
        Estado uf24 = new Estado();
        uf24.sigla = "SC";
        uf24.estado = "Santa Catarina";
        lista.Add(uf24);
        //Crio novo Estado e adciono á lista 
        Estado uf25 = new Estado();
        uf25.sigla = "SP";
        uf25.estado = "São Paulo";
        lista.Add(uf25);
        //Crio novo Estado e adciono á lista 
        Estado uf26 = new Estado();
        uf26.sigla = "SE";
        uf26.estado = "Sergipe";
        lista.Add(uf26);
        //Crio novo Estado e adciono á lista 
        Estado uf27 = new Estado();
        uf27.sigla = "TO";
        uf27.estado = "Tocantins";
        lista.Add(uf27);


        //retorno a lista 
        return lista;
    }

    private void CarregarDropDownList()
    {
        ddlEstado.DataSource = RetornaLista();
        ddlEstado.DataValueField = "estado";
        ddlEstado.DataTextField = "sigla";
        ddlEstado.DataBind();
    }
    
    private void CarregarGridEmpresas()
    {
        gdvEmpresas.DataSource = EmpresaDB.SelectEmpresas();
        gdvEmpresas.DataBind();
    }

    protected void btnSetView2_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
    }

    protected void btnSetView1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Empresa emp = new Empresa();

        emp.NomeFantasia = txbNomeFantasia.Text;
        emp.Endereco = txbEndereco.Text;
        emp.Bairro = txbBairro.Text;
        emp.Cidade = txbCidade.Text;
        emp.Estado = ddlEstado.SelectedItem.Text;
        emp.Telefone1 = txbTel1.Text;
        emp.Telefone2 = txbTel2.Text;
        emp.Cep = txbCep.Text;
        emp.Email = txbEmail.Text;
        
        if(EmpresaDB.Insert(emp) == -2)
        {
            Response.Write("DEU RUIM");
        }

        txbNomeFantasia.Text = "";
        txbEndereco.Text = "";
        txbBairro.Text = "";
        txbCidade.Text = "";
        txbTel1.Text = "";
        txbTel2.Text = "";
        txbCep.Text = "";
        txbEmail.Text = "";

        CarregarGridEmpresas();


    }
}