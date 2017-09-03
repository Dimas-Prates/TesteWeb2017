using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class consulta_pesquisa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["editActive"] = null;
        Conexao conexaobd = new Conexao();
        conexaobd.command.CommandText = "SELECT id_product,cod_product,type_product,nm_product,qtde_product,preco_product,type_business FROM tb_merchandise ORDER BY id_product DESC";
        rptDados.DataSource = conexaobd.consultarBD(conexaobd.command);
        rptDados.DataBind();
    }


    protected void btnBusca_Click1(object sender, EventArgs e)
    {
        string buscar = txtBuscar.Text.Trim();
        if (buscar == null || buscar == "" || buscar == " ")
        {
            Conexao conexaobd = new Conexao();
            conexaobd.command.CommandText = "SELECT id_product,cod_product,type_product,nm_product,qtde_product,preco_product,type_business FROM tb_merchandise ORDER BY id_product DESC";
            rptDados.DataSource = conexaobd.consultarBD(conexaobd.command);
            rptDados.DataBind();
        }
        else
        {
            Conexao conexaobd = new Conexao();
            conexaobd.command.CommandText = "SELECT * FROM tb_merchandise WHERE cod_product LIKE @codigo OR type_product LIKE @tipo OR nm_product LIKE @nome OR preco_product LIKE @preco OR type_business LIKE @negocio ORDER BY id_product DESC";
            conexaobd.command.Parameters.AddWithValue("@codigo", "%" + buscar + "%");
            conexaobd.command.Parameters.AddWithValue("@tipo", "%" + buscar + "%");
            conexaobd.command.Parameters.AddWithValue("@nome", "%" + buscar + "%");
            conexaobd.command.Parameters.AddWithValue("@preco", "%" + buscar + "%");
            conexaobd.command.Parameters.AddWithValue("@negocio", "%" + buscar + "%");
            rptDados.DataSource = conexaobd.consultarBD(conexaobd.command);
            rptDados.DataBind();
        }
    }
}