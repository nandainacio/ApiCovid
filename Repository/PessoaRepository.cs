using CovidDados.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using CovidDados.Interface;
using Microsoft.Extensions.Configuration;

namespace CovidDados.Repository
{
    public class PessoaRepository: BaseRepository, IPessoaRepository
    {
        public PessoaRepository(IConfiguration configuration) : base(configuration){}

        public List<Pessoa> Listar()
        {
            string query = @"SELECT [Id]
                                ,[Nome]
                                ,[CPF]
                      FROM[dbo].[Pessoa]";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<Pessoa>(query).ToList();
        }

        public Pessoa Obter(int Id)
        {
            string query = @"SELECT [Id]
                                ,[Nome]
                                ,[CPF]
                      FROM[dbo].[Pessoa]
                      WHERE [Id] = @id" ;

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QueryFirstOrDefault<Pessoa>(query, new { Id });
        }

        public Pessoa ObterPorCpf(string CPF)
        {
            string query = @"SELECT [Id]
                                ,[Nome]
                                ,[CPF]
                      FROM[dbo].[Pessoa]
                      WHERE [CPF] = @CPF";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QueryFirstOrDefault<Pessoa>(query, new { CPF });
        }
        public void Inserir(Pessoa pessoa)
        {
            string query = @"INSERT INTO [dbo].[Pessoa]
                                                ([Nome]
                                                ,[CPF])
                                            VALUES
                                                (@Nome,
                                                @CPF)";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute(query, pessoa);
        }

        public void Atualizar(Pessoa pessoa)
        {
            string query = @"UPDATE [dbo].[Pessoa]
                                SET [Nome] = @Nome
                                    ,[CPF] = @CPF
                                    WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute(query, pessoa);
        }

        public void Deletar (int Id)
        {
            string query = @"DELETE FROM Pessoa WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute(query, new { Id });
        }
    }
}
