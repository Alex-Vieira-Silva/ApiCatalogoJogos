using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Exceptions
{
    public class JogoNaoCadastradoExeption : Exception
    {
        public JogoNaoCadastradoExeption() 
        {
            : base("Este jogo não esta cadastrado.");
        }
    }
}
