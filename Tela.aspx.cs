using Crudnow_MVC;
using Crudnow_MVC.controle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class Tela : System.Web.UI.Page
    { 
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Crudnow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        Gerenciador gerenciador;
        protected void Page_Load(object sender, EventArgs e)
        {
            gerenciador = new Gerenciador(BancoDeDados.Simulador);
        }

        protected void btnInsira_Click(object sender, EventArgs e) // cadastrar
        {
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.Cpf = txtCPF.Text;
            p.Telefones = txtTelefone.Text + txtTipoTelefone.Text;
            string endereco = txtLogradouro.Text + txtNumeroLogradouro.Text + txtBairro.Text + txtCEP.Text + txtCidade.Text + txtUF.Text;
            p.Endereco = endereco;
            gerenciador.dao.insira(p);
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtNumeroLogradouro.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";

            string sql =
           "INSERT INTO PESSOA (NOME, CPF, ENDERECO) "
               + "VALUES ('"
               + txtNome.Text + "', '"
               + txtCPF.Text + "', '"
              
               + "');";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Seu cadastro foi realizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnConsulte_Click(object sender, ImageClickEventArgs e) // consultar
        {
            List<Pessoa> pessoas;
            if (txtNome.Text.Equals(""))
            {
                pessoas = gerenciador.dao.consulte(txtCPF.Text);
            }
            else
            {
                pessoas = gerenciador.dao.consulte(txtCPF.Text);
            }

            string sql = "SELECT * FROM bdcadastro WHERE ID=" + txtBuscarPeloCPF.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNome.Focus();
                    txtNome.Text = reader[1].ToString();
                    txtCPF.Text = reader[2].ToString();
                  //  txtDDD.Text = reader[3].ToString();
                    txtTelefone.Text = reader[4].ToString();
                    txtTipoTelefone.Text = reader[5].ToString();
                    txtLogradouro.Text = reader[6].ToString();
                    txtNumeroLogradouro.Text = reader[7].ToString();
                    txtBairro.Text = reader[8].ToString();
                    txtCEP.Text = reader[9].ToString();
                    txtCidade.Text = reader[10].ToString();
                    txtUF.Text = reader[11].ToString();
                }
                else
                    Console.WriteLine("ID não encontrado, verifique o número do ID que você pesquisou");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            txtBuscarPeloCPF.Text = "";
        }

        protected void btnAltere_Click(object sender, ImageClickEventArgs e) // editar
        {
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.Cpf = txtCPF.Text;
            string telefones = txtTelefone.Text + txtTipoTelefone.Text;
            p.Telefones = telefones;
            string endereco = txtLogradouro.Text + txtNumeroLogradouro.Text + txtBairro.Text + txtCEP.Text + txtCidade.Text + txtUF.Text;
            p.Endereco = endereco;
            gerenciador.dao.altere(p);

            string sql =
          "UPDATE bdcadastro SET NOME='" + txtNome.Text +
          "', CPF= '" + txtCPF.Text +
          // "', DDD='" + txtDDD.Text +
          "', TELEFONE='" + txtTelefone.Text +
          "', TIPO_TELEFONE='" + txtTipoTelefone.Text +
          "', ENDERECO= '" + txtLogradouro.Text +
          "', NUMERO='" + txtNumeroLogradouro.Text +
          "', BAIRRO='" + txtBairro.Text +
          "', CEP='" + txtCEP.Text +
          "', CIDADE= '" + txtCidade.Text +
          "', UF='" + txtUF.Text +
          "' WHERE ID=" + txtBuscarPeloCPF.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con); // recebe a instrução sql e a conexão com o BD
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Seus dados foram atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnExclua_Click(object sender, ImageClickEventArgs e) // excluir
        {
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.Cpf = txtCPF.Text;
            string telefones = txtTelefone.Text + txtTipoTelefone.Text;
            p.Telefones = telefones;
            string endereco = txtLogradouro.Text + txtNumeroLogradouro.Text + txtBairro.Text + txtCEP.Text + txtCidade.Text + txtUF.Text;
            p.Endereco = endereco;
            gerenciador.dao.exclua(p);

            string sql = "DELETE FROM bdcadastro WHERE ID=" + txtBuscarPeloCPF.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtNumeroLogradouro.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
        }
    }
}