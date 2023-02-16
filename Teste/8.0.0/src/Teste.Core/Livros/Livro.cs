using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Livros
{
    [Table("Biblioteca_Livros")]
    public class Livro : FullAuditedEntity<long>
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Autor { get; set; }

        [Required]
        public bool Emprestado { get; set; }

        [Required]
        public long? CodInterno{ get; set; }

    }
}
