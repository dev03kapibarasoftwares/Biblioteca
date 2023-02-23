using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teste.Livros.Dto
{
    [AutoMap(typeof(Livro))]
    public class LivroDto : FullAuditedEntityDto<long>
    {
        [Required]
        [MaxLength(100)]
        public string Nome_Livro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Autor { get; set; }

        [DefaultValue(true)]
        public bool Disponivel { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome_Genero { get; set; }
        [MaxLength(30)]
        public string SubGenero { get; set; }
    }
}
