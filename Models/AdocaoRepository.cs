using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Meadote.Models
{
    public class AdocaoRepository
    {
        //objetivo: criar as funcionalides/métodos que manipulam os atributos da classe Voluntário
        //C-Cadastrar/Create, R-Read/Listar, U-Update/Editar, D-Delete/Excluir(CRUD)

        //obter as credencias do BD
        private const string DadosConexao = "Database=Meadote; Data Source=localhost; User Id=root;";

        public Adocao BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para listagem: select
            String Query = "select * from Adocao where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",Id);

            //objeto Reader irá receber o registro executados no BD em (Comando.ExecuteReader())
            MySqlDataReader Reader = Comando.ExecuteReader();

            Adocao adEncontrado = new Adocao();
            if(Reader.Read())
            {
                //se for encontrado algum registro, devemos atribuir para o objeto adEncontrado
                adEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    adEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    adEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    adEncontrado.Telefone = Reader.GetString("Telefone");

                adEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Endereco")))
                adEncontrado.Endereco = Reader.GetString("Endereco");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Cidade")))
                adEncontrado.Cidade = Reader.GetString("Cidade");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Estado")))
                adEncontrado.Estado = Reader.GetString("Estado");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Cep")))
                adEncontrado.Cep = Reader.GetString("Cep");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Animal")))
                adEncontrado.Animal = Reader.GetString("Animal");
            }

            Conexao.Close();//fecha o BD

            return adEncontrado;//retornando a adoção localizado
        }

        public List<Adocao> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para listagem: select
            String Query = "select * from Adocao";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //objeto Reader irá receber todos os registros executados no BD em (Comando.ExecuteReader())
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Adocao> lista = new List<Adocao>();//criando uma lista da classe Adocao vazia

            //percursos nos registros do BD - é preciso usar uma estrutura de repetição
            while(Reader.Read())
            {   
                Adocao adEncontrado = new Adocao();
                adEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    adEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    adEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    adEncontrado.Telefone = Reader.GetString("Telefone");

                adEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Endereco")))
                    adEncontrado.Endereco = Reader.GetString("Endereco");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Cidade")))
                    adEncontrado.Cidade = Reader.GetString("Cidade");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Estado")))
                    adEncontrado.Estado = Reader.GetString("Estado");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Cep")))
                    adEncontrado.Cep = Reader.GetString("Cep");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Animal")))
                    adEncontrado.Animal = Reader.GetString("Animal");

                lista.Add(adEncontrado);
            }

            Conexao.Close();//fecha o BD

            return lista;//retornando a lista de adoção
        }

        public void Cadastrar (Adocao ad)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para Inserir: insert into
            String Query = "insert into Adocao (Nome, Email, Telefone, DataNascimento, Endereco, Cidade, Estado, Cep, Animal) values (@Nome, @Email, @Telefone,@DataNascimento, @Endereco, @Cidade, @Estado, @Cep, @Animal)";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Nome",ad.Nome);
            Comando.Parameters.AddWithValue("@Email",ad.Email);
            Comando.Parameters.AddWithValue("@Telefone",ad.Telefone);
            Comando.Parameters.AddWithValue("@DataNascimento",ad.DataNascimento);
            Comando.Parameters.AddWithValue("@Endereco",ad.Endereco);
            Comando.Parameters.AddWithValue("@Cidade",ad.Cidade);
            Comando.Parameters.AddWithValue("@Estado",ad.Estado);
            Comando.Parameters.AddWithValue("@Cep",ad.Cep);
            Comando.Parameters.AddWithValue("@Animal",ad.Animal);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecha o BD
        }

        public void Editar(Adocao ad)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para Editar/Atualizar: update
            String Query = "update Adocao set Nome=@Nome, Email=@Email, Telefone=@Telefone, DataNascimento=@DataNascimento, Endereco=@Endereco, Cidade=@Cidade, Estado=@Estado, Cep=@Cep, Animal=@Animal where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",ad.Id);
            Comando.Parameters.AddWithValue("@Nome",ad.Nome);
            Comando.Parameters.AddWithValue("@Email",ad.Email);
            Comando.Parameters.AddWithValue("@Telefone",ad.Telefone);
            Comando.Parameters.AddWithValue("@DataNascimento",ad.DataNascimento);
            Comando.Parameters.AddWithValue("@Endereco",ad.Endereco);
            Comando.Parameters.AddWithValue("@Cidade",ad.Cidade);
            Comando.Parameters.AddWithValue("@Estado",ad.Estado);
            Comando.Parameters.AddWithValue("@Cep",ad.Cep);
            Comando.Parameters.AddWithValue("@Animal",ad.Animal);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecha o BD
        }

        public void Excluir(Adocao ad)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre a conexao com o BD

            //query em SQL para Exclusão: delete
            String Query = "delete from Adocao where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",ad.Id);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecho a conexao com o BD
        }
    }
}


