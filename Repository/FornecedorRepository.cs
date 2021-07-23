using CovidDados.Entity;
using CovidDados.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDados.Repository
{
    public class FornecedorRepository: BaseRepository, IFornecedorRepository
    {
        public FornecedorRepository(IConfiguration configuration) : base(configuration) {}

        public List<Fornecedor> Listar()
        {
            string query = @"SELECT [Id]
                                   ,[Nome]
                                   ,[QtdApli]
                            FROM[dbo].[Fornecedor]";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<Fornecedor>(query).ToList();
        }

        public Fornecedor Obter(int Id)
        {
            string query = @"SELECT [Id]
                                   ,[Nome]
                                   ,[QtdApli]
                            FROM[dbo].[Fornecedor]
                            WHERE [Id] = @id";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QueryFirstOrDefault<Fornecedor>(query, new { Id });
        }

        public Fornecedor ObterPorNome(string Nome)
        {
            string query = @"SELECT [Id]
                                   ,[Nome]
                                   ,[QtdApli]
                            FROM[dbo].[Fornecedor]
                            WHERE [Nome] = @nome";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QueryFirstOrDefault<Fornecedor>(query, new { Nome });

        }

        public void Inserir(Fornecedor fornecedor)
        {
            string query = @"INSERT INTO [dbo].[Fornecedor]
                                        ([Nome]
                                        ,[QtdApli])
                                    VALUES
                                    (@Nome,
                                    @QtdApli)";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute(query, fornecedor);
        }

        public void Atualizar(Fornecedor fornecedor)
        {
            string query = @"UPDATE[dbo].[Fornecedor]
                                SET[Nome] = @Nome
                                  ,[QtdApli] = @QtdApli
                                WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute(query, fornecedor);
        }

        public void Deletar(int Id)
        {
            string query = @"DELETE FROM [dbo].[Fornecedor]
                                    WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute(query, new { Id });
        }
    }
}
