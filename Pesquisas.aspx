<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pesquisas.aspx.cs" Inherits="Pesquisas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="nav nav-tabs">
        <li role="presentation">
            <asp:Button ID="btnSetView1" runat="server" Text="Cadastrar" OnClick="btnSetView1_Click" CssClass="btn" /></li>
        <li role="presentation">
            <asp:Button ID="btnSetView2" runat="server" Text="Consultar" OnClick="btnSetView2_Click" CssClass="btn" /></li>
    </ul>
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <%--view 1 - CADASTRAR PESQUISA--%>
        <asp:View ID="View1" runat="server">
            <h2>Cadastrar Pesquisa/Visita</h2>
            <br />
            <div class="row">
                <div class="form-group col-lg-4">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                    <asp:RadioButtonList ID="rblTipo" runat="server" CssClass="radio">
                        <asp:ListItem Value="Produto">Produto</asp:ListItem>
                        <asp:ListItem Value="Processo">Processo</asp:ListItem>
                        <asp:ListItem Value="S/Classificação">S/ Classificação</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group col-lg-5">
                    <asp:Label ID="lblImplementacao" runat="server" Text="Implementação:"></asp:Label>
                    <asp:RadioButtonList ID="rblImplementacao" runat="server" CssClass="radio">
                        <asp:ListItem Value="Sim">Sim</asp:ListItem>
                        <asp:ListItem Value="Não">Não</asp:ListItem>
                        <asp:ListItem Value="S/Classificação">S/ Classificação</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-md-6">
                    <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:"></asp:Label>
                    <asp:DropDownList ID="ddlEmpresa" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group col-lg-4 col-md-6">
                    <asp:Label ID="lblCadEmpresa" runat="server" Text="Acessar:"></asp:Label><br />
                    <a href="Empresas.aspx">Cadastrar Empresa</a>
                </div>
                
            </div>
            <div class="row">
                <div class="form-group col-lg-4 col-md-6">
                    <asp:Label ID="lblContato" runat="server" Text="Contato:"></asp:Label>
                    <asp:TextBox ID="txbContato" runat="server" CssClass="form-control" placeholder="Contato na Empresa"></asp:TextBox>
                </div>
                <div class="form-group col-lg-2 col-md-6">
                    <asp:Label ID="lblCurso" runat="server" Text="Curso:"></asp:Label>
                    <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group col-lg-2 col-md-6">
                    <asp:Label ID="lblAnoSemestre" runat="server" Text="Semestre / Ano:"></asp:Label>
                    <asp:DropDownList ID="ddlAnoSemestre" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <%--PROCURAR ALUNOS --%>
            <div class="row">
                <div class="form-group col-lg-6">
                    <asp:Label ID="lblProcAluno" runat="server" Text="Buscar Aluno:"></asp:Label>
                    <asp:TextBox ID="txbProcAluno" runat="server" AutoPostBack="true" OnTextChanged="txbProcAluno_TextChanged" placeholder="Nome"></asp:TextBox>
                </div>
                <div class="form-group col-lg-6">
                    <asp:Label ID="lblAlunosOk" runat="server" Text="Integrante(s):"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-lg-5">
                    <asp:ListBox ID="LBProcAlunos" runat="server" Rows="6" SelectionMode="Multiple" CssClass="list-group"></asp:ListBox>
                </div>
                <div class="form-group col-lg-1">
                    <asp:Button ID="btnAdd" runat="server" Text="▶" CssClass="btn btn-block btn-primary" OnClick="btnAdd_Click"/>
                    <asp:Button ID="btnRemove" runat="server" Text="◀" CssClass="btn btn-block btn-danger" OnClick="btnRemove_Click"/>
                </div>
                <div class="form-group col-lg-5">
                    <asp:ListBox ID="LBAlunosOk" runat="server" Rows="6" SelectionMode="Multiple"></asp:ListBox>
                </div>
            </div>

            <%--PROCURAR PROFESSORES --%>
            <div class="row">
                <div class="form-group col-lg-6">
                    <asp:Label ID="lblProcProf" runat="server" Text="Buscar Professor:"></asp:Label>
                    <asp:TextBox ID="txbProcProf" runat="server" AutoPostBack="true" OnTextChanged="txbProcProf_TextChanged" placeholder="Nome"></asp:TextBox>
                </div>
                <div class="form-group col-lg-6">
                    <asp:Label ID="lblProfOk" runat="server" Text="Professor(es):"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-lg-5">
                    <asp:ListBox ID="LBProcProf" runat="server" Rows="6" SelectionMode="Multiple" ></asp:ListBox>
                </div>
                <div class="form-group col-lg-1">
                    <asp:Button ID="btnAddProf" runat="server" Text="▶" CssClass="btn btn-block btn-primary" OnClick="btnAddProf_Click"/>
                    <asp:Button ID="btnRemoveProf" runat="server" Text="◀" CssClass="btn btn-block btn-danger" OnClick="btnRemoveProf_Click"/>
                </div>
                <div class="form-group col-lg-5">
                    <asp:ListBox ID="LBProfOk" runat="server" Rows="6" SelectionMode="Multiple"></asp:ListBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-8">
                    <asp:Label ID="lblProposta" runat="server" Text="Proposta/Descrição:"></asp:Label>
                    <asp:TextBox ID="txbProposta" runat="server" CssClass="form-control" Rows="6" TextMode="MultiLine" placeholder="Descreva sua experiência..."></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-8">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary btn-block" OnClick="btnConfirmar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default btn-block" />
                </div>
            </div>
        </asp:View>
        <%--view 2 - PESQUISAS CADASTRADAS--%>
        <asp:View ID="View2" runat="server">
            <h2>Consultar Pesquisas</h2>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="gdvPesquisas" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="cur_sigla" HeaderText="Curso" />                                              
                        <asp:BoundField DataField="anosemestre" HeaderText="Semestre/Ano" />
                        <asp:BoundField DataField="psq_tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="psq_implementacao" HeaderText="Implementação" />
                        <asp:BoundField DataField="emp_nomefantasia" HeaderText="Empresa" />  
                        <asp:BoundField DataField="psq_descricao" HeaderText="Descrição" />
                        <asp:BoundField DataField="psq_contato" HeaderText="Contato" />
                    </Columns>
                </asp:GridView>
            </div>

        </asp:View>
    </asp:MultiView>

</asp:Content>

