using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Livros
{
    [Table("Bilbioteca_LivroHasGenero")]
    public class LivroHasGenero : FullAuditedEntity<long>
    {
        [ForeignKey("LivroId")]
        public Livro Livro{ get; set; }
        public long? LivroId { get; set; }

        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }
        public int? GeneroId { get; set; }
    }
}
