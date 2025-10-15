using DesafioLivraria.Entities;
using DesafioLivraria.Enums;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DesafioLivraria.Services
{
    public class LivroService
    {
        private static readonly Dictionary<Guid, Livro> _livro = new Dictionary<Guid, Livro>();

        public Guid CriarLivro(Livro livro)
        {
            var novolivro = new Livro
            {
                Id = Guid.NewGuid(),
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Genero = livro.Genero,
                Preco = livro.Preco,
                QuantidadeEstoque = livro.QuantidadeEstoque,
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            };

            ValidarLivro(novolivro);

            _livro[novolivro.Id] = novolivro;

            return novolivro.Id;
        }

        public IEnumerable<Livro> ConsultarLivros()
        {
                return _livro.Values;
        }

        public Livro? ConsultarLivroPorId(Guid idLivro)
        {
            return _livro.TryGetValue(idLivro, out Livro livroEncontrado) ? livroEncontrado : null;
           
        }

        public Livro AtualizarLivro(Livro livroAtualizado)
        {
            ValidarLivro(livroAtualizado);
            
            var livro = ConsultarLivroPorId(livroAtualizado.Id);

            if (livro == null)
            {
                return null;
            }

            livro.Titulo = livroAtualizado.Titulo;
            livro.Autor = livroAtualizado.Autor;
            livro.Genero = livroAtualizado.Genero;
            livro.Preco = livroAtualizado.Preco;
            livro.QuantidadeEstoque = livroAtualizado.QuantidadeEstoque;
            livro.AtualizadoEm = DateTime.Now;

            return livro;
        }

        public bool ExcluirLivro(Guid idLivro)
        {
            var livro = ConsultarLivroPorId(idLivro);

            if (livro == null) 
            {  
                return false; 
            }

            return _livro.Remove(idLivro);

        }

        public void ValidarLivro(Livro livro)
        {
            //Titulo
            if (_livro.Values.Any(l => l.Id != livro.Id && l.Titulo.Equals(livro.Titulo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Já existe um livro cadastrado com este título.");
            }

            //Autor
            if (_livro.Values.Any(l => l.Id != livro.Id && l.Autor.Equals(livro.Autor, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Já existe um livro cadastrado com este autor.");
            }

            if (livro.QuantidadeEstoque < 0)
            {
                throw new Exception("A quantidade em estoque não pode ser negativa.");
            }

            if (livro.Preco < 0)
            {
                throw new Exception("O preço do livro não pode ser negativo.");
            }

            if (!Enum.IsDefined(typeof(GeneroLivro), livro.Genero))
            {
                throw new Exception("Gênero inválido. Escolha um gênero válido.");
            }
        }
    }
}
