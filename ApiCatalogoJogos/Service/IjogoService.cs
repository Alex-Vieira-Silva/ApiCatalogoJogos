using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Service
{
    public interface IjogoService : IDisposable
    {
        Task<List<JogoViewModel>> obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoViewModel jogo);
        Task Atualizar(Guid id, JogoViewModel jogo);
        Task Atualizar(Guid id, int preco);
        Task Remover(Guid id);
        Task obter(object pagina, object quantidade);
        Task obter(int idJogo);
        Task Inserir(JogoInputModel jogoInputModel);
    }
}
