<%@ Page Title="" Language="C#" MasterPageFile="~/modelo.master" AutoEventWireup="true" CodeFile="consulta.aspx.cs" Inherits="consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Consulta</h3>
    <hr>
    <div class="row">
        <!--Código-->
        <div id="divCampoCodigo" runat="server" class="form-group">
            <label for="txtCodigo" class="col-xs-offset-1 col-xs-11 col-sm-offset-3 col-sm-2 control-label">Código:</label>
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-0 col-sm-4">
                <asp:TextBox ID="txtCodigo" runat="server" required="required" pattern="^[0-9A-Z]{6,}$" class="form-control" placeholder="Exemplo: RR759C" autofocus data-error="Somente letras e números sem espaços (Mínimo 6 caracteres)." disabled></asp:TextBox>

                <div class="help-block with-errors"></div>
            </div>
        </div>
        <!--//Código-->
        <!--Tipo-->
        <div class="form-group">
            <label for="txtTipo" class="col-xs-offset-1 col-xs-11 col-sm-offset-3 col-sm-2 control-label">Tipo:</label>
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-0 col-sm-4">
                <asp:TextBox ID="txtTipo" runat="server" required="required" pattern="[A-Za-zÀ-ú\s]{3,}$" class="form-control" placeholder="Tablet, notebook, etc.." data-error="Digite apenas letras (Mínimo 3 letras)."></asp:TextBox>

                <div class="help-block with-errors"></div>
            </div>
        </div>
        <!--//Tipo-->
        <!--Nome-->
        <div class="form-group">
            <label for="txtNome" class="col-xs-offset-1 col-xs-11 col-sm-offset-3 col-sm-2 control-label">Nome:</label>
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-0 col-sm-4">
                <asp:TextBox ID="txtNome" runat="server" required="required" pattern="[0-9A-Za-zÀ-ú\s]{3,}$" class="form-control" placeholder="Nome da mercadoria" data-error="Digite apenas letras e Números (Mínimo 3)."></asp:TextBox>

                <div class="help-block with-errors"></div>
            </div>
        </div>
        <!--//Nome-->
        <!--Quantidade-->
        <div class="form-group">
            <label for="cbQuantidade" class="col-xs-offset-1 col-xs-11 col-sm-offset-3 col-sm-2 control-label">Quantidade:</label>
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-0 col-sm-4">
                <asp:TextBox ID="cbQuantidade" runat="server" type="number" min="1" required="required" pattern="[0-9]" class="form-control" placeholder="0" data-error="Insira apenas números que sejam maior que zero."></asp:TextBox>

                <div class="help-block with-errors"></div>
            </div>
        </div>
        <!--//Quantidade-->
        <!--Preço-->
        <div class="form-group">
            <label for="txtPreco" class="col-xs-offset-1 col-xs-11 col-sm-offset-3 col-sm-2 control-label">Preço:</label>
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-0 col-sm-4">

                <asp:TextBox ID="txtPreco" runat="server" required="required" pattern="(\R$[0-9]{1,3}\.)?[0-9]{1,3},[0-9]{2}$" class="form-control" placeholder="R$0,00" data-error="Insira apenas números, sem vírgulas ou pontos."></asp:TextBox>

                <div class="help-block with-errors"></div>
            </div>
        </div>
        <!--//Preço-->
        <!--Negócio-->
        <div class="form-group">
            <label for="ddlNegocio" class="col-xs-offset-1 col-xs-11 col-sm-offset-3 col-sm-2 control-label">Négocio:</label>
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-0 col-sm-4">
                <asp:DropDownList ID="ddlNegocio" runat="server" class="form-control" required="required">
                    <asp:ListItem Text="Tipo de Négocio" Value="" Selected="True" />
                    <asp:ListItem Text="Venda" Value="VENDA" />
                    <asp:ListItem Text="Compra" Value="COMPRA" />
                </asp:DropDownList>

                <div class="help-block with-errors"></div>
            </div>
        </div>
        <!--//Negócio-->

        <!--Botão Editar-->
        <div class="form-group">
            <div class="col-xs-offset-1 col-xs-10 col-sm-offset-4 col-sm-4">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-lg btn-primary btn-block" OnClick="btnEditar_Click" />
            </div>
            <div class="col-xs-offset-1 col-xs-5 col-sm-offset-3 col-sm-3">
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" class="btn btn-lg btn-primary btn-block" OnClick="btnCancel_Click" />
            </div>
            <div class="col-xs-5 col-sm-offset-1 col-sm-3">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" class="btn btn-lg btn-primary btn-block" OnClick="btnSalvar_Click" />
            </div>
        </div>
        <!--//Botão Editar-->
    </div>
</asp:Content>

