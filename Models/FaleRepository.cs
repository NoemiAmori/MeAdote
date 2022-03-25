using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Meadote.Models
{
    public class FaleRepository
    {
        //objetivo: criar as funcionalides/métodos que manipulam os atributos da classe Voluntário
        //C-Cadastrar/Create, R-Read/Listar, U-Update/Editar, D-Delete/Excluir(CRUD)

        //obter as credencias do BD
        private const string DadosConexao = "Database=Meadote; Data Source=localhost; User Id=root;";

        public Fale BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para listagem: select
            String Query = "select * from Fale where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",Id);

            //objeto Reader irá receber o registro executados no BD em (Comando.ExecuteReader())
            MySqlDataReader Reader = Comando.ExecuteReader();

            Fale flEncontrado = new Fale();
            if(Reader.Read())
            {
                //se for encontrado algum registro, devemos atribuir para o objeto faleEncontrado
                flEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    flEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    flEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Mensagem")))
                    flEncontrado.Mensagem = Reader.GetString("Mensagem");
            }

            Conexao.Close();//fecha o BD

            return flEncontrado;//retornando o fale localizado
        }

        public List<Fale> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para listagem: select
            String Query = "select * from Fale";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //objeto Reader irá receber todos os registros executados no BD em (Comando.ExecuteReader())
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Fale> lista = new List<Fale>();//criando uma lista da classe Fale vazia

            //percursos nos registros do BD - é preciso usar uma estrutura de repetição
            while(Reader.Read())
            {   
                Fale flEncontrado = new Fale();
                flEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    flEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Mensagem")))
                    flEncontrado.Mensagem = Reader.GetString("Mensagem");

                lista.Add(flEncontrado);
            }

            Conexao.Close();//fecha o BD

            return lista;//retornando a lista de fale
        }

        public void Cadastrar (Fale fl)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para Inserir: insert into
            String Query = "insert into Fale (Nome, Email, Mensagem) values (@Nome, @Email, @Mensagem)";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Nome",fl.Nome);
            Comando.Parameters.AddWithValue("@Email",fl.Email);
            Comando.Parameters.AddWithValue("@Mensagem",fl.Mensagem);
            
            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecha o BD
        }

        public void Editar(Fale fl)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre o BD

            //query em SQL para Editar/Atualizar: update
            String Query = "update Fale set Nome=@Nome, Email=@Email, Mensagem=@Mensagem where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",fl.Id);
            Comando.Parameters.AddWithValue("@Nome",fl.Nome);
            Comando.Parameters.AddWithValue("@Email",fl.Email);
            Comando.Parameters.AddWithValue("@Mensagem",fl.Mensagem);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecha o BD
        }

        public void Excluir(Fale fl)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();//abre a conexao com o BD

            //query em SQL para Exclusão: delete
            String Query = "delete from Fale where Id=@Id";

            //preparando o SQL(Query) para o objeto de conexao(Conexao)
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            //tratamento para SQL Injection
            Comando.Parameters.AddWithValue("@Id",fl.Id);

            Comando.ExecuteNonQuery();//executa a query no BD

            Conexao.Close();//fecho a conexao com o BD
        }
    }
}
