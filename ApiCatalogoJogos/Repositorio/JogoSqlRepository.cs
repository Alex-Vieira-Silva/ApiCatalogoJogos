using ApiCatalogoJogos.Entitys;
using com.sun.tools.doclets.@internal.toolkit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorio
{
    public class JogoSqlRepository : IJogoRepository
    {
        private readonly SqlConnection sqlconnection;

        public JogoSqlRepository(Configuration configuration) 
        {
            sqlconnection = new Sqlconnection(configuration.getConnectionString("Default"));
        }
        public Task Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            sqlconnection.Close();
            sqlconnection.Dispose();
        }

        public Task Inserir(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            var Jogos = new List<Jogos>();
            var comando = $"select * from Jogos order by id offset {((pagina - 1) * quantidade)} rows fecth next {quantidade} rows only";
            await sqlconnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlconnection);
            SqlDataReader sqlDataReader = await SqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                Jogos.Add(new Jogo
                [
                    id = (Guid)sqlDataReader["id"],
                    nome = (string)sqlDataReader["nome"],
                    produto = (string)sqlDataReader["produto"],
                    preco = (double)sqlDataReader["preco"]
                 ]);
                    
            }

            await sqlconnection.CloseAsync();

            return Jogos;
                
        }

        public Task<Jogo> Obter(Guid id)
        {
            Jogo jogo = null;

            var comando = $"select * from Jogos where id = {(id)} ";

            await sqlconnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlconnection);
            SqlDataReader sqlDataReader = await SqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read()) 
            {
                jogo = new Jogo
                {
                    id = (Guid)sqlDataReader["id"],
                    nome = (string)sqlDataReader["nome"],
                    produto = (string)sqlDataReader["produto"],
                    preco = (double)sqlDataReader["preco"]
                };
            }

            await sqlconnection.CloseAsync();

        }

        public Task<List<Jogo>> Obter(string nome, string produto)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            var comando = $"delete from Jogos where id = {(id)}";

            await sqlconnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlconnection);
            SqlCommand.ExecuteNoQuery();

            await sqlconnection.CloseAsync();

        }
    }
}
