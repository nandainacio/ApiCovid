using CovidDados.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using CovidDados.Interface;

namespace CovidDados.Repository
{
    public class PessoaRepository: IPessoaRepository
    {
        public string _concectionString = "Server=DESKTOP-ESVFVOM\\SQLEXPRESS;Database=AquiCovid;Trusted_Connection=True;";

        public List<Pessoa> Listar()
        {
            string query = @"SELECT [Id]
                                ,[Nome]
                                ,[CPF]
                      FROM[dbo].[Pessoa]";

            SqlConnection connection = new SqlConnection(_concectionString);
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

            SqlConnection connection = new SqlConnection(_concectionString);
            connection.Open();
            return connection.QueryFirstOrDefault<Pessoa>(query, new { Id });
        }
    }
}
