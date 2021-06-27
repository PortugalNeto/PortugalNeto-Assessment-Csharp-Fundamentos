using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Gerenciador.Aniversario.Entity;
using Dapper;

namespace Gerenciador.Aniversario.Repository
{
    public class AmigoRepository : IAmigoRepository
    {
        private string ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = GerenciadorAniversarioDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Amigo> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAllAmigos";

                return connection.Query<Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure).AsList();
            }
        }

        public Amigo GetAmigoById(int idAmigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAmigoById";

                return connection.QueryFirstOrDefault<Amigo>(sql, new { IdAmigo = idAmigo },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public void DeleteAmigo(int idAmigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.DeleteAmigo";

                connection.Execute(sql, new { AmigoId = idAmigo },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void InsertAmigo(Amigo amigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.InsertAmigo";

                connection.Execute(sql,
                    new
                    {
                        nomeAmigo = amigo.Nome,
                        sobrenomeAmigo = amigo.Sobrenome,
                        dataAniversario = amigo.Aniversario
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateAmigo(Amigo amigo, int idAmigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.UpdateAmigo";

                connection.Execute(sql,
                    new
                    {
                        nomeAmigo = amigo.Nome,
                        sobrenomeAmigo = amigo.Sobrenome,
                        dataAniversario = amigo.Aniversario,
                        IdAmigo = idAmigo
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }



    }
}
