using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Bibliotecas importadas
using System.Data;
using System.Globalization;

public partial class mercadoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["editActive"] = null;
    }


    protected void btnConfirmar_Click1(object sender, EventArgs e)
    {
        //VARIAVEIS
        string codigo, tipo, nome, negocio;
        int qtde;
        decimal preco;

        //PASSANDO VALORES
        codigo = txtCodigo.Text.Trim();
        tipo = txtTipo.Text.Trim();
        nome = txtNome.Text.Trim();
        qtde = Convert.ToInt32(cbQuantidade.Text.Trim());
        preco = Convert.ToDecimal(txtPreco.Text.Trim().Replace("R$", ""));
        negocio = ddlNegocio.SelectedValue.Trim();

        //VALIDANDO DADOS
        if (validaCampos(codigo, tipo, nome, qtde, preco, negocio) == true)
        {
            //verifica código duplicado
            if (verificaCodigo(codigo) == true)
            {
                Conexao conexaobd = new Conexao();
                conexaobd.command.CommandText = "INSERT INTO tb_merchandise (cod_product,type_product,nm_product,qtde_product,preco_product,type_business) " +
                                                "VALUES (@codigo,@tipo,@nome,@qtde,@preco,@negocio)";
                conexaobd.command.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
                conexaobd.command.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                conexaobd.command.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                conexaobd.command.Parameters.Add("@qtde", SqlDbType.Int).Value = qtde;
                conexaobd.command.Parameters.AddWithValue("@preco", preco);
                conexaobd.command.Parameters.Add("@negocio", SqlDbType.VarChar).Value = negocio;

                //ARMAZENANDO NO BD
                bool situation = conexaobd.executaBD(conexaobd.command);
                if (situation)
                {
                    Response.Write("<script language=javascript>alert('Registro armazenado com sucesso.');window.location.href = 'consulta-pesquisa.aspx';</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Falha ao armazenar o registro.')</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Este código já pertence à uma mercadoria.')</script>");
            }
        }
    }

    private bool verificaCodigo(string codigo)
    {
        Conexao conexaobd = new Conexao();
        conexaobd.command.CommandText = "SELECT COUNT(*) AS resultado FROM tb_merchandise WHERE cod_product LIKE '@codigo'";
        conexaobd.command.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
        int resultado = Convert.ToInt32(conexaobd.consultarBD(conexaobd.command).Tables[0].DefaultView[0].Row["resultado"]);
        if (resultado == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool validaCampos(string codigo, string tipo, string nome, int qtde, decimal preco, string negocio)
    {
        bool status = true;
        if (codigo == null || codigo == "" || codigo.Length < 6 || codigo.IndexOf(" ") > -1)
        {
            Response.Write("<script language=javascript>alert('É necessário que o código tenha 6 ou mais caracteres e não contenha espaços.')</script>");
            status = false;
        }
        if (tipo == null || tipo == "" || tipo.Length < 3)
        {
            Response.Write("<script language=javascript>alert('É necessário que o tipo tenha 3 caracteres ou mais.')</script>");
            status = false;
        }
        if (nome == null || nome == "" || nome.Length < 3)
        {
            Response.Write("<script language=javascript>alert('É necessário que o nome tenha 3 caracteres ou mais.')</script>");
            status = false;
        }
        if (qtde == null || qtde <= 0)
        {
            Response.Write("<script language=javascript>alert('É necessário que a quantidade seja maior que zero.')</script>");
            status = false;
        }
        if (preco == null || preco <= 0)
        {
            Response.Write("<script language=javascript>alert('É necessário que o preço seja maior que zero.')</script>");
            status = false;
        }
        if (negocio == null || negocio == "" || (negocio != "VENDA" && negocio != "COMPRA"))
        {
            Response.Write("<script language=javascript>alert('É necessário selecionar um tipo de negócio válido.')</script>");
            status = false;
        }
        return status;
    }
}