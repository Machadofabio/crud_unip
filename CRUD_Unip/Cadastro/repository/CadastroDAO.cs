using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class CadastroDAO : PessoaDAO
    {
        private static SqlConnection con;

        public CadastroDAO()
        {
            if(con == null)
            {
                try
                {
                    SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                    cs.DataSource = "CADSTR_CLIENT";
                    cs.InitialCatalog = "Pessoa";
                    cs.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                    cs.TrustServerCertificate = true;

                    con = new SqlConnection(cs.ConnectionString);
                    con.Open();
                }
                catch (SqlException e)
                {
                    Console.Error.WriteLine("Ocorreu uma exceção de BD" + e.Message);
                    throw new ApplicationException("Ocorreu uma exceção de BD" + e.Message);
                }
            }
        }

        void PessoaDAO.altere(Pessoa p)
        {
            throw new NotImplementedException();
        }

        Pessoa PessoaDAO.consulte(long cpf)
        {
            throw new NotImplementedException();
        }

        void PessoaDAO.exclua(Pessoa p)
        {
            throw new NotImplementedException();
        }

        void PessoaDAO.insira(Pessoa p)
        {
            insertDataTabelaPessoa(p);
            insertDataTabelaEndereco(p);
            insertEnderecoTabelaPessoa();
            insertDataTabelaTelefone(p);
            insertDataTabelaPessoaTelefone();
        }

        void insertDataTabelaPessoa(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Pessoa (nome, cpf) " +
                "VALUES ('" + p.nome + "', " + p.cpf + "); ";
            cmd.ExecuteNonQuery();
        }
        void insertEnderecoTabelaPessoa()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Pessoa (endereco) " +
                " SELECT (Id) FROM Endereco"; 
            cmd.ExecuteNonQuery();
        }
        void insertDataTabelaEndereco(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Endereco (logradouro, numero, cep, bairro, cidade, estado) " +
                 "VALUES ('" + p.endereco.logradouro + "', " + p.endereco.numero + ", " + p.endereco.cep +
                 ", " + p.endereco.bairro + ", " + p.endereco.cidade + ", " + p.endereco.estado + ");";
            cmd.ExecuteNonQuery();
        }
        void insertDataTabelaTelefone(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Telefone (numero, ddd, tipo) " +
                "VALUES ('" + p.telefone.numero + "', " + p.telefone.ddd + ", " + p.telefone.tipo + ");";
            cmd.ExecuteNonQuery();
        }
        void insertDataTabelaPessoaTelefone()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Pessoa_Telefone(id_pessoa, id_telefone) " +
                "SELECT (Id) FROM Pessoa AND SELECT (Id) FROM Telefone";
            cmd.ExecuteNonQuery();
        }

    }
}
