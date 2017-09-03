using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Bibliotecas importadas
using System.Data;
using System.Globalization;

public partial class consulta : System.Web.UI.Page
{
    int idProduto;
    protected void Page_Load(object sender, EventArgs e)
    {
        //verifica parametro da url
        if (Request.QueryString["Prod"] != null)
        {
            //comparando com o ultimo produto
            Conexao conexaobd = new Conexao();
            conexaobd.command.CommandText = "SELECT MAX(id_product) AS ultimoProd FROM tb_merchandise";
            int ultimoProd = Convert.ToInt32(conexaobd.consultarBD(conexaobd.command).Tables[0].DefaultView[0].Row["ultimoProd"]);

            idProduto = Convert.ToInt32(Request.QueryString["Prod"]);
            if (idProduto > 0 && idProduto <= ultimoProd)
            {
                if (!Page.IsPostBack)
                {
                    carregaInfo();
                }
                if (Session["editActive"] != null)
                {
                    if (Convert.ToBoolean(Session["editActive"]))
                    {

                        habilitaComponentes();
                    }
                    else
                    {

                        desabilitaComponentes();
                    }
                }
                else
                {

                    desabilitaComponentes();
                }

            }
            else
            {
                Response.Redirect("consulta-pesquisa.aspx");
            }

        }
        else
        {
            Response.Redirect("consulta-pesquisa.aspx");
        }
    }

    private void habilitaComponentes()
    {
        divCampoCodigo.Visible = false;

        txtNome.Enabled = true;
        txtTipo.Enabled = true;
        cbQuantidade.Enabled = true;
        txtPreco.Enabled = true;
        ddlNegocio.Enabled = true;
        //Botões
        btnEditar.Visible = false;
        btnEditar.Enabled = false;

        btnSalvar.Visible = true;
        btnSalvar.Enabled = true;

        btnCancel.Visible = true;
        btnCancel.Enabled = true;

        //recolocando classes 
        txtCodigo.CssClass = "form-control";
        txtNome.CssClass = "form-control";
        txtTipo.CssClass = "form-control";
        cbQuantidade.CssClass = "form-control";
        txtPreco.CssClass = "form-control";
        ddlNegocio.CssClass = "form-control";
    }

    private void desabilitaComponentes()
    {
        divCampoCodigo.Visible = true;

        txtNome.Enabled = false;
        txtTipo.Enabled = false;
        cbQuantidade.Enabled = false;
        txtPreco.Enabled = false;
        ddlNegocio.Enabled = false;
        //Botões
        btnEditar.Visible = true;
        btnEditar.Enabled = true;

        btnSalvar.Visible = false;
        btnSalvar.Enabled = false;

        btnCancel.Visible = false;
        btnCancel.Enabled = false;

        //recolocando classes 
        txtCodigo.CssClass = "form-control";
        txtNome.CssClass = "form-control";
        txtTipo.CssClass = "form-control";
        cbQuantidade.CssClass = "form-control";
        txtPreco.CssClass = "form-control";
        ddlNegocio.CssClass = "form-control";
    }

    private void carregaInfo()
    {
        Conexao conexao = new Conexao();
        conexao.command.CommandText = "SELECT cod_product,type_product,nm_product,qtde_product,preco_product,type_business FROM tb_merchandise WHERE id_product = @idProduto";
        conexao.command.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;

        DataSet dt = new DataSet();
        dt = conexao.consultarBD(conexao.command);

        txtCodigo.Text = dt.Tables[0].DefaultView[0].Row["cod_product"].ToString();
        txtTipo.Text = dt.Tables[0].DefaultView[0].Row["type_product"].ToString();
        txtNome.Text = dt.Tables[0].DefaultView[0].Row["nm_product"].ToString();
        cbQuantidade.Text = dt.Tables[0].DefaultView[0].Row["qtde_product"].ToString();
        txtPreco.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:c}", Convert.ToDecimal(dt.Tables[0].DefaultView[0].Row["preco_product"]));
        ddlNegocio.Text = dt.Tables[0].DefaultView[0].Row["type_business"].ToString();

    }

    private bool atualizaInfo()
    {
        Conexao conexao = new Conexao();
        conexao.command.CommandText = "UPDATE tb_merchandise SET type_product = @tipo, nm_product = @nome, qtde_product = @qtde, preco_product = @preco, type_business = @negocio WHERE id_product = @idProduto ";
        conexao.command.Parameters.Add("@tipo", SqlDbType.VarChar).Value = txtTipo.Text.Trim();
        conexao.command.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtNome.Text.Trim();
        conexao.command.Parameters.Add("@qtde", SqlDbType.Int).Value = Convert.ToInt32(cbQuantidade.Text.Trim());
        conexao.command.Parameters.AddWithValue("@preco", Convert.ToDecimal(txtPreco.Text.Trim().Replace("R$", "")));
        conexao.command.Parameters.Add("@negocio", SqlDbType.VarChar).Value = ddlNegocio.SelectedValue.Trim();
        conexao.command.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;
        bool resultado = conexao.executaBD(conexao.command);

        return resultado;
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        Session["editActive"] = true;
        Response.Redirect("consulta.aspx?Prod=" + idProduto);
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string msg;
        if (atualizaInfo())
        {
            msg = "Atualização realizada com sucesso.";
        }
        else
        {
            msg = "Não foi possível efetuar a atualização.";
        }
        Session["editActive"] = false;
        Response.Write("<script language=javascript>alert('" + msg + "');window.location.href='consulta.aspx?Prod=" + idProduto + "';</script>");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["editActive"] = false;
        Response.Redirect("consulta.aspx?Prod=" + idProduto);
    }
}