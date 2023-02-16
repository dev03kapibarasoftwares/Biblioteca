using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Livros
{
    public class LivrosAppService : TesteAppServiceBase, ILivrosAppService
    {
        private readonly IRepository<Livro, long> _livroRepository;
        private readonly IRepository<Genero, int> _generoRepository;

        public LivrosAppService(IRepository<Livro, long> livroRepository, IRepository<Genero, int> generoRepository)
        {
            _livroRepository = livroRepository;
            _generoRepository = generoRepository;
        }

        private async Task TrataCadastroDeLivro (Livro inputLivro, Genero inputGenero, LivroHasGenero livroHasGenero)
        {
            if (livroHasGenero == null)
                throw new UserFriendlyException("Genero do Livro não encontrado!");
            if (inputLivro.Nome.IsNullOrEmpty())
                throw new UserFriendlyException("Nome do Livro não informado!");
            if (inputLivro.Autor.IsNullOrEmpty())
                throw new UserFriendlyException("Nome do Autor não informado!");
            if (inputGenero.Nome.IsNullOrEmpty())
                throw new UserFriendlyException("Genero não informado!");


        }
    }
}
