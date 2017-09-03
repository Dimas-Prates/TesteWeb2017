using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Bibliotecas BD
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


public class Conexao
{

    private SqlConnection conexao;
    public SqlCommand command = new SqlCommand();
    public string query_sql;

    #region String de conexão
    //Ambiente GearHost
    private static string strConexao = "Server=mssql6.gear.host;DataBase=testeweb2017;user id=testeweb2017;password=TesteWeb2017!";

    //Ambiente local
    //private static string strConexao = "Server=localhost;DataBase=dbTestValemobi;user id=sa;password=12345";
    #endregion

    private bool abrirConexao()
    {
        conexao = new SqlConnection(strConexao);

        try
        {
            conexao.Open();
            command.Connection = conexao;
            return true;
        }
        catch (Exception ex)
        {
            return false;
            throw ex;
        }
    }

    private void fecharConexao()
    {
        conexao.Close();
        conexao = null;
        command = null;
    }
    public DataSet consultarBD(SqlCommand comando)
    {
        DataSet dt = new DataSet();
        if (abrirConexao() == true)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(dt);
                adapter.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fecharConexao();
            }
        }
        return dt;
    }

    public DataSet consultarBD()
    {
        DataSet dt = new DataSet();
        if (abrirConexao() == true)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query_sql, conexao);
                adapter.Fill(dt);
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fecharConexao();
            }
        }
        return dt;
    }

    public bool executaBD(SqlCommand comando)
    {
        bool status = false;
        if (abrirConexao() == true)
        {
            try
            {
                comando.Connection = conexao;
                comando.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                throw ex;
            }
            finally
            {
                fecharConexao();
                comando.Parameters.Clear();
            }
        }
        return status;
    }
}