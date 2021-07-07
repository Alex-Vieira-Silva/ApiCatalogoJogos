using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve contém no minimo entre 3 á 100 caracteres.")]
        public string nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve contém no minimo entre 3 á 100 caracteres.")]
        public string produtora { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "O preçco do jogo deve contém no minimo 1 real é no maximo 1000 reaid")]
        public double preco { get; set; }

    }
}
