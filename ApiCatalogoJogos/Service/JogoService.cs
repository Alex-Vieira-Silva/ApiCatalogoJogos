using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Repositorio;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Service
{
    public class JogoService : IjogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IjogoService jogoRepository) 
        {
            _jogoRepository = (IJogoRepository)jogoRepository;

        }
        public Task Atualizar(Guid id, JogoViewModel jogo)
        {
            var EntidadeJogo =  _jogoRepository.Obter(id);

            if(EntidadeJogo == null) 
            {
                throw new JogoNaoCadastradoExeption();
            }

            EntidadeJogo Preco = preco;

            await _jogoRepository.Atualizar(EntidadeJogo);
        }

        public Task Atualizar(Guid id, int preco)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> Inserir(JogoViewModel jogo)
        {
            var EntidadeJogo = await _jogoRepository.Obter(jogo.nome, jogo.produtora);

            if(EntidadeJogo.Count > 0) 
            {
                throw new JogoCadastradoExeption();
            }

            var jogoInsert = new Jogo
            {
                id = Guid.NewGuid(),
                nome = jogo.nome,
                produto = jogo.produtora,
                preco = jogo.preco

            };

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoInputModel
            {
                id = jogoInsert.id,
                nome = jogo.nome,
                produtora = jogo.produtora,
                preco = jogo.preco
            };
            
        }

        public Task Inserir(JogoInputModel jogoInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JogoViewModel>> obter(int pagina, int quantidade)
        {
            var jogos =  _jogoRepository.Obter(pagina, quantidade);

            jogos.Select(jogo-> new JogoViewModel
            {
                id = jogo.id,
                nome = jogo.nome,
                produto = jogo.produto,
                preco = jogo.preco
            }).ToList();

        }



        public Task<JogoViewModel> Obter(Guid id)
        {
            var jogo =  _jogoRepository.Obter(id);

            if(jogo == null) 
            {
                return null;
            }

            return new JogoInputModel
            {
                id = jogo.id,
                nome = jogo.nome,
                produtora = jogo.produto,
                preco = jogo.preco
            };
        }

        public Task obter(object pagina, object quantidade)
        {
            throw new NotImplementedException();
        }

        public Task obter(int idJogo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JogoViewModel>> obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);
        }

        public Task Remover(Guid id)
        {
            var EntidadeJogo = _jogoRepository.Obter(id);

            if(jogo == null) 
            {
                throw new JogoNaoCadastradoExeption();

            }

            await _jogoRepository.Remover(id);
        }

        public void Dispose() 
        {
            _jogoRepository.Dispose();
        }
    }
}
