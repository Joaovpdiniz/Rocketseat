using DesafioLivraria.Entities;
using DesafioLivraria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private static LivroService livroService = new LivroService();

        [HttpPost]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status409Conflict)]
        public IActionResult PostLivro(Livro livro)
        {
            try
            {
                Guid idGerado = livroService.CriarLivro(livro);
                return CreatedAtAction(nameof(GetLivroPorId), new { idLivro = idGerado }, livro);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("título"))
                    return Conflict(new { Mensagem = ex.Message });
                if (ex.Message.Contains("autor"))
                    return Conflict(new { Mensagem = ex.Message });

                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
        public IActionResult GetAllLivro()
        {
            try
            {
                var livro = livroService.ConsultarLivros();

                if (livro is null)
                {
                    return Ok("Não Existem Livros Cadastrados.");
                }

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("{idLivro}")]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status400BadRequest)]
        public IActionResult GetLivroPorId(Guid? idLivro)
        {
            try
            {
                if (idLivro == null)
                {
                    return BadRequest("É necessario informar o ID do Livro!");
                }

                var livro = livroService.ConsultarLivroPorId(idLivro.Value);

                if (livro is null)
                {
                    return NotFound("Livro não encontrado.");
                }

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status404NotFound)]
        public IActionResult PutLivro(Livro livro)
        {
            try
            {
                var livroAtualizado = livroService.AtualizarLivro(livro);

                if (livroAtualizado == null)
                    return NotFound("Livro não encontrado para atualização.");

                return Ok(new
                {
                    Mensagem = "Livro Atualizado com Sucesso!",
                    Livro = livroAtualizado,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Livro), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteLivro(Guid idLivro)
        {
            try
            {
                if (idLivro == null)
                {
                    return BadRequest("ID do Livro é obrigatório");
                }

                var livroExcluido = livroService.ExcluirLivro(idLivro);

                if (!livroExcluido)
                {
                    return NotFound("Livro não encontrado para exclusão");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}
