<%@ Page Title="" Language="C#" MasterPageFile="~/modelo.master" AutoEventWireup="true" CodeFile="consulta-pesquisa.aspx.cs" Inherits="consulta_pesquisa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Consulta</h3>
    <hr>
    <!--BARRA DE PESQUISA-->
    <div class="row">
        <div class="col-sm-12">
            <form>
                <div class="input-group">
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-search"></span>
                    </span>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control" placeholder="Pesquise por: Código, tipo, nome, preço e negócio."></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnBusca" runat="server" Text="Buscar" class="btn btn-primary" OnClick="btnBusca_Click1" />
                    </span>
                </div>
            </form>
        </div>
    </div>
    <!--//BARRA DE PESQUISA-->
    <br />
    <!--RETORNO DA PESQUISA-->
    <div class="table-responsive">
        <table class="table-striped table-bordered table-condensed table-hover table-custom">
            <thead>
                <tr class="activer">
                    <th>Código</th>
                    <th>Tipo</th>
                    <th>Nome</th>
                    <th>Quantidade</th>
                    <th>Preço</th>
                    <th>Négocio</th>
                    <th>Visualizar</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptDados" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "cod_product")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "type_product")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "nm_product")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "qtde_product")%></td>
                            <td><%# string.Format("{0:C}", Eval("preco_product")) %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "type_business")%></td>
                            <td><a href="consulta.aspx?Prod=<%# DataBinder.Eval(Container.DataItem, "id_product")%>">Abrir</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <!--//RETORNO DA PESQUISA-->


</asp:Content>

