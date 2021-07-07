using ApiCatalogoJogos.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorio
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<Guid Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("36F02DEA-8264-49D1-B0FB-B2FB49E12DBD"), new Jogo id = Guid.Parse("36F02DEA-8264-49D1-B0FB-B2FB49E12DBD"), nome = "Luta", produto = "Game", preco = 31.50 },
            {Guid.Parse("ADD313E0-ED4C-4F40-9048-09E96B94B930"), new Jogo id = Guid.Parse("ADD313E0-ED4C-4F40-9048-09E96B94B930"), nome = "Futebol", produto = "Game", preco = 151.50 },
            {Guid.Parse("038D56E8-E362-4792-9C0E-8D5FB7A6299E"), new Jogo id = Guid.Parse("038D56E8-E362-4792-9C0E-8D5FB7A6299E"), nome = "Aventura", produto = "Game", preco = 86.50 },
            {Guid.Parse("F2F18BD1-C4AD-4894-999B-7BC28FD5D5D7"), new Jogo id = Guid.Parse("F2F18BD1-C4AD-4894-999B-7BC28FD5D5D7"), nome = "Guerra", produto = "Game", preco = 301.50 },
            {Guid.Parse("F16FB1FD-AF4B-4A33-84B7-B8D8CB145F4B"), new Jogo id = Guid.Parse("F16FB1FD-AF4B-4A33-84B7-B8D8CB145F4B"), nome = "Live", produto = "Game", preco = 100.50 },
            {Guid.Parse("BF0CAFF5-14EA-4FD9-B403-392C42207F31"), new Jogo id = Guid.Parse("BF0CAFF5-14EA-4FD9-B403-392C42207F31"), nome = "Ação", produto = "Game", preco = 145.50 }

        };
  
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.id] = jogo;

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Esse metódo fechar a conexão com o banco de dados.
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.id, jogo);

            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());

        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id)) 
            {
                return null;
            }

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produto)
        {
            return Task.FromResult(jogos.Values.Where(jogo->jogo.nome.Equals(nome) && jogo.produto.Equals(produto)).ToList();
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produto) 
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values) 
            {
                if(jogo.nome.Equals(nome) && jogo.produto.Equals(produto)) 
                {
                   retorno.Add(jogo);
                }
             }

             return Task.FromResult(retorno);
        }
        public Task Remover(Guid id)
        {
            jogos.Remove(id);

            return Task.CompletedTask;
        }
    }
}
