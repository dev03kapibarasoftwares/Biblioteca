using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Livros.Dto;

namespace Teste.Livros
{
    [AbpAuthorize]
    public class LivrosAppService : TesteAppServiceBase, ILivrosAppService
    {
        private readonly IRepository<Livro, long> _livroRepository;
        private readonly IRepository<Genero, int> _generoRepository;

        public LivrosAppService(IRepository<Livro, long> livroRepository, IRepository<Genero, int> generoRepository)
        {
            _livroRepository = livroRepository;
            _generoRepository = generoRepository;
        }

        private async Task TrataCadastroDeLivro (LivroDto inputLivro)
        {
            if (inputLivro.Nome_Livro.IsNullOrEmpty())
                throw new UserFriendlyException("Nome do Livro não informado!");
            if (inputLivro.Autor.IsNullOrEmpty())
                throw new UserFriendlyException("Nome do Autor não informado!");
            if (inputLivro.Nome_Genero.IsNullOrEmpty())
                throw new UserFriendlyException("Genero não informado!");         
        }

        public async Task CreateLivro(LivroDto input)
        {
            var livro = ObjectMapper.Map<Livro>(input);
            var genero = new Genero()
            {
                Nome_Genero = input.Nome_Genero,
                SubGenero = input.SubGenero
            };
            livro.Disponivel = false;
            livro.IsDeleted= false;

            await _livroRepository.InsertAsync(livro);
            await CurrentUnitOfWork.SaveChangesAsync();   
        }

        public async Task<List<Livro>> GetAll()
        {
            var livros = await _livroRepository.GetAllListAsync();
            return livros;
        }

        public async Task<List<Livro>> GetAllLivrosDisponiveis()
        {
            var livrosDisponiveis = await _livroRepository.GetAllListAsync(x => x.Disponivel == true);
            return livrosDisponiveis;
        }

        public async Task<List<Livro>> GetAllLivrosIndisponiveis()
        {
            var livrosIndisponiveis = await _livroRepository.GetAllListAsync(x => x.Disponivel == false);
            return livrosIndisponiveis;
        }

        public async Task<List<Genero>> GetAllGeneros()
        {
            var generos = await _generoRepository.GetAllListAsync();
            return generos;
        }

        public async Task UpdateLivro(LivroDto input)
        {
            var livroExists = await _livroRepository.GetAll()
                                              .AnyAsync(x => x.Id == input.Id);
            if (!livroExists)
                throw new UserFriendlyException("Livro não cadastrado no banco de dados!");

            var livro = await _livroRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            livro.Nome_Livro = input.Nome_Livro;
            livro.Autor = input.Autor;
            livro.Disponivel = input.Disponivel;

            var genero = await _generoRepository.FirstOrDefaultAsync(x => x.LivroId == livro.Id);
            genero.Nome_Genero = input.Nome_Genero;
            genero.SubGenero = input.SubGenero;
            
            await _livroRepository.UpdateAsync(livro);
            await _generoRepository.UpdateAsync(genero);
        }

        public async Task DeleteLivro(LivroDto input)
        {
            var livroExists = await _livroRepository.GetAll()
                                              .AnyAsync(x => x.Id == input.Id);
            if (!livroExists)
                throw new UserFriendlyException("Livro não cadastrado no banco de dados!");

            var livro = await _livroRepository.FirstOrDefaultAsync(x => x.Id == input.Id);

            livro.IsDeleted= true;
            _livroRepository.UpdateAsync(livro);
        }
    }
}
