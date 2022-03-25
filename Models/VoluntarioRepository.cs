using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Meadote.Models
{
    public class VoluntarioRepository
    {
        //objetivo: criar as funcionalides/métodos que manipulam os atributos da classe Voluntário
        //C-Cadastrar/Create, R-Read/Listar, U-Update/Editar, D-Delete/Excluir(CRUD)

        //obter as credencias do BD
        private const string DadosConexao = "Database=Meadote; Data Source=localhost; User Id=root;";

        public Voluntario BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para listagem: select
            String Query = "select * from Voluntario where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",Id);

            //objeto Reader irá receber o registro executados no BD em (Comando.ExecuteReader())
            MySqlDataReader Reader = Comando.ExecuteReader();

            Voluntario volEncontrado = new Voluntario();
            if(Reader.Read())
            {
                //se for encontrado algum registro, devemos atribuir para o objeto volEncontrado
                volEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    volEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    volEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    volEncontrado.Telefone = Reader.GetString("Telefone");

                    volEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Sexo")))
                    volEncontrado.Sexo = Reader.GetString("Sexo");
            }

            Conexao.Close();//fecha o BD

            return volEncontrado;//retornando o voluntario localizado
        }

        public List<Voluntario> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para listagem: select
            String Query = "select * from Voluntario";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //objeto Reader irá receber todos os registros executados no BD em (Comando.ExecuteReader())
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Voluntario> lista = new List<Voluntario>();//criando uma lista da classe Voluntario vazia

            //percursos nos registros do BD - é preciso usar uma estrutura de repetição
            while(Reader.Read())
            {   
                Voluntario volEncontrado = new Voluntario();
                volEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    volEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    volEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    volEncontrado.Telefone = Reader.GetString("Telefone");

                volEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Sexo")))
                    volEncontrado.Sexo = Reader.GetString("Sexo");
                lista.Add(volEncontrado);
            }

            Conexao.Close();//fecha o BD

            return lista;//retornando a lista de Voluntario
        }

        public void Cadastrar (Voluntario vol)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para Inserir: insert into
            String Query = "insert into Voluntario (Nome, Email, Telefone, DataNascimento, Sexo) values (@Nome, @Email, @Telefone,@DataNascimento, @Sexo)";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Nome",vol.Nome);
            Comando.Parameters.AddWithValue("@Email",vol.Email);
            Comando.Parameters.AddWithValue("@Telefone",vol.Telefone);
            Comando.Parameters.AddWithValue("@DataNascimento",vol.DataNascimento);
            Comando.Parameters.AddWithValue("@Sexo",vol.Sexo);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecha o BD
        }

        public void Editar(Voluntario vol)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para Editar/Atualizar: update
            String Query = "update Voluntario set Nome=@Nome, Email=@Email, Telefone=@Telefone, DataNascimento=@DataNascimento, Sexo=@Sexo where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",vol.Id);
            Comando.Parameters.AddWithValue("@Nome",vol.Nome);
            Comando.Parameters.AddWithValue("@Email",vol.Email);
            Comando.Parameters.AddWithValue("@Telefone",vol.Telefone);
            Comando.Parameters.AddWithValue("@DataNascimento",vol.DataNascimento);
            Comando.Parameters.AddWithValue("@Sexo",vol.Sexo);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecha o BD
        }

        public void Excluir(Voluntario vol)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre a conexao com o BD

            //query em SQL para Exclusão: delete
            String Query = "delete from Voluntario where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",vol.Id);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecho a conexao com o BD
        }
    }
}