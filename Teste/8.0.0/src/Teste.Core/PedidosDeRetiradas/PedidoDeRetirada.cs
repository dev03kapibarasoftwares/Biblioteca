using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teste.Authorization.Users;

namespace Teste.PedidosDeRetiradas
{
    [Table("Biblioteca_PedidosDeRetiradas")]
    public class PedidoDeRetirada : FullAuditedEntity<long>, ISoftDelete
    {
        [Required]
        public DateTime DataDeRetirada{ get; set; }
        public List<PedidoDeRetiradaItens> Itens { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }

        [Required]
        public StatusPedido StatusPedido { get; set; }
    }
}
