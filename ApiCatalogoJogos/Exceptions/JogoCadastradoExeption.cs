using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Exceptions
{
    public class JogoCadastradoExeption : Exception
    {
        public JogoCadastradoExeption() 
        {
            : base("Este jogo já esta cadastrado.");
        }
    }
}
