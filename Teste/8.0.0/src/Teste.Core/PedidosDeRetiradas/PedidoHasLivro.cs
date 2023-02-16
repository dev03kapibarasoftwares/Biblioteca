using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using Teste.Livros;

namespace Teste.PedidosDeRetiradas
{
    [Table("Biblioteca_PedidosHasLivros")]
    public class PedidoHasLivro : FullAuditedEntity<long>
    {
        [ForeignKey("LivroId")]
        public Livro Livro{ get; set; }
        public long LivroId { get; set; }
    }
}
