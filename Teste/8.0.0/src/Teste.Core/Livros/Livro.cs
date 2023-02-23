using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Livros
{
    [Table("Biblioteca_Livros")]
    public class Livro : FullAuditedEntity<long>, ISoftDelete
    {
        [Required]
        [MaxLength(100)]
        public string Nome_Livro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Autor { get; set; }

        [Required]
        public bool Disponivel { get; set; }

        public List<Genero> Generos { get; set; }

    }
}
