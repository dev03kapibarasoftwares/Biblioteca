using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teste.Authorization.Users;

namespace Teste.PedidosDeRetiradas
{
    [Table("Bibliotecas_PedidosDeRetiradas")]
    public class PedidoDeRetirada : FullAuditedEntity<long>
    {
        [Required]
        public DateTime DataDeRetirada{ get; set; }
        
        [Required]
        public DateTime? DataDeDevolucao { get; set; }

        [ForeignKey("PedidoHasLivroId")]
        public PedidoHasLivro PedidoHasLivro { get; set; }
        public long? PedidoHasLivroId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public long? UserId { get; set; }
    }
}
