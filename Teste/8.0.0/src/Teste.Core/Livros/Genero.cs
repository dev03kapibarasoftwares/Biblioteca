using Abp.Domain.Entities.Auditing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Livros
{
    [Table("Biblioteca_Generos")]
    public class Genero : FullAuditedEntity
    {
        [Required]
        [MaxLength(30)]
        public string Nome_Genero { get; set; }
        [MaxLength(30)]
        public string SubGenero { get; set; }

        [ForeignKey("LivroId")]
        public Livro Livro { get; set; }
        public long LivroId { get; set; }
    }
}
