<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="row form-group">
        <div class="col-sm-3 col-md-3">
            <asp:Label ID="lblCursos" runat="server" Text="Selecione um Curso: " CssClass="lblSelectCurso"></asp:Label>
        </div>
        <div class="col-sm-3 col-md-3">
            <asp:DropDownList ID="ddlCursos" runat="server" CssClass="form-control  text-center" OnSelectedIndexChanged="ddlCursos_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>

    </div>
    <div class="table-responsive">
        <asp:GridView ID="gdvPesqPrincipal" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="anosemestre" HeaderText="Semestre/Ano" />
                <asp:BoundField DataField="emp_nomefantasia" HeaderText="Empresa" />
                <asp:BoundField DataField="psq_contato" HeaderText="Contato" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
</asp:Content>

