using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teste.Livros.Dto
{
    [AutoMap(typeof(Livro))]
    public class LivroDto : FullAuditedEntityDto
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [DefaultValue(false)]
        public bool Emprestado { get; set; }
    }
}
