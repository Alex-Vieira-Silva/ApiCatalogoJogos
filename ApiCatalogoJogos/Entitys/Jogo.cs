using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Entitys
{
    public class Jogo
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public string produto { get; set; }
        public double preco { get; set; }
    }
}
