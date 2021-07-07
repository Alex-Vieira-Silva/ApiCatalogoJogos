using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Service;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using org.omg.PortableServer.CurrentPackage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IjogoService _jogoService;
        private int quantidade;
        private int idJogo;

        public JogosController(IjogoService jogoService) 
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5) { }

        [HttpGet("idJogo:guid")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);
            
             if(jogo == null) 
             {
                return NoContent();
                return Ok(jogo);
             }
         }

        [HttpPost]

        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel) 
        {
            try 
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);
                return Ok(jogo);
            }
            catch (JogoCadastradoExeption ex) 
            {
                return UnprocessableEntity("Já existe um jogo com este nome, para esse produto.");
            }
        }


        [HttpPut("idJogo:guid")]

        public async Task<ActionResult<JogoViewModel>> AtualizarJogo([FromRoute] Guid idjogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Atualizar(idJogo, jogoInputModel);
                return Ok(jogo);
            }
            catch (JogoNaoCadastradoExeption ex)
            {
                return NotFound("Não existe esse jogo.");
            }
        }

        [HttpPatch("(idjogo:guid)/preco/(preco:double)")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idjogo, [FromRoute] Guid preco) 
        {
            try
            {
                var jogo = await _jogoService.Atualizar(idJogo, preco);
                return Ok(jogo);
            }
            catch (JogoNaoCadastradoExeption ex)
            {
                return NotFound("Não existe esse jogo.");
            }
        }


        [HttpGet("idJogo:guid")]
        public async Task<ActionResult<JogoViewModel>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPut("idJogo:guid")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, JogoInputModel jogo) 
        {
            return Ok();
        }

        [HttpPatch("(idJogo:guid)/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco) 
        {
            return Ok();
        }

        [HttpDelete("(idJogo:guid)")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo) 
        {
            try
            {
                var jogo = await _jogoService.Remover(idJogo);
                return Ok();
            }
            catch (JogoNaoCadastradoExeption ex)
            {
                return NotFound("Não existe jogo.");
            }
        }
    }
}
