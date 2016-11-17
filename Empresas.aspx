<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Empresas.aspx.cs" Inherits="Empresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="nav nav-tabs">
        <li role="presentation" class="active">
            <asp:Button ID="btnSetView1" runat="server" Text="Cadastrar" OnClick="btnSetView1_Click" CssClass="btn" /></li>
        <li role="presentation">
            <asp:Button ID="btnSetView2" runat="server" Text="Consultar" OnClick="btnSetView2_Click" CssClass="btn" /></li>
    </ul>
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <%--view 1 - CADASTRAR EMPRESA --%>
        <asp:View ID="View1" runat="server">
            <div>
                <h2>Cadastrar Empresa</h2>
                <br />
                <div class="row">
                    <div class="form-group col-lg-5">
                        <asp:Label ID="lblNomeFantasia" runat="server" Text="Nome Fantasia"></asp:Label>
                        <asp:TextBox ID="txbNomeFantasia" runat="server" CssClass="form-control" placeholder="Nome da Empresa"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-5">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                        <asp:TextBox ID="txbEmail" runat="server" CssClass="form-control" placeholder="exemplo@exemplo.com" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-2">
                        <asp:Label ID="lblCep" runat="server" Text="CEP"></asp:Label>
                        <asp:TextBox ID="txbCep" runat="server" CssClass="form-control" placeholder="00000-000"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-6">
                        <asp:Label ID="lblEndereco" runat="server" Text="Endereço"></asp:Label>
                        <asp:TextBox ID="txbEndereco" runat="server" CssClass="form-control" placeholder="Rua , Av, ..."></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-3">
                        <asp:Label ID="lblBairro" runat="server" Text="Bairro"></asp:Label>
                        <asp:TextBox ID="txbBairro" runat="server" CssClass="form-control" placeholder="Bairro"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-3">
                        <asp:Label ID="lblCidade" runat="server" Text="Cidade"></asp:Label>
                        <asp:TextBox ID="txbCidade" runat="server" CssClass="form-control" placeholder="Cidade"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-1">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" OnLoad="ddlEstado_Load"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-3">
                        <asp:Label ID="lblTel1" runat="server" Text="Telefone 1"></asp:Label>
                        <asp:TextBox ID="txbTel1" runat="server" CssClass="form-control" placeholder="(00) 00000-0000"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-3">
                        <asp:Label ID="lblTel2" runat="server" Text="Telefone 2"></asp:Label>
                        <asp:TextBox ID="txbTel2" runat="server" CssClass="form-control" placeholder="(00) 00000-0000"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-lg-6">
                        <asp:Button ID="btnEnviar" runat="server" Text="Confirmar" CssClass="btn btn-primary btn-block" OnClick="btnEnviar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default btn-block" />
                    </div>
                </div>

            </div>
        </asp:View>
        <%--view 2 - EMPRESAS CADASTRADAS--%>
        <asp:View ID="View2" runat="server">
            <h2>Empresas Cadastradas</h2>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="gdvEmpresas" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="emp_codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="emp_nomefantasia" HeaderText="Nome Fantasia" />
                        <asp:BoundField DataField="emp_email" HeaderText="E-mail" />
                        <asp:BoundField DataField="emp_cidade" HeaderText="Cidade" />
                        <asp:BoundField DataField="emp_estado" HeaderText="Estado" />
                        <asp:BoundField DataField="emp_cep" HeaderText="Cep" />
                        <asp:BoundField DataField="emp_endereco" HeaderText="Endereço" />
                        <asp:BoundField DataField="emp_bairro" HeaderText="Bairro" />
                        <asp:BoundField DataField="emp_telefone1" HeaderText="Telefone 1" />
                        <asp:BoundField DataField="emp_telefone2" HeaderText="Telefone 2" />
                    </Columns>
                </asp:GridView>
            </div>

        </asp:View>
    </asp:MultiView>




</asp:Content>

