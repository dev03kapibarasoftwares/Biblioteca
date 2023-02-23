using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Teste.Livros;

namespace Teste.PedidosDeRetiradas
{
    [Table("Biblioteca_PedidosDeRetiradaItens")]
    public class PedidoDeRetiradaItens : FullAuditedEntity<long>, ISoftDelete
    {
        [ForeignKey("LivroId")]
        public Livro Livro{ get; set; }
        public long LivroId { get; set; }

        [ForeignKey("PedidoDeRetiradaId")]
        public PedidoDeRetirada PedidoDeRetirada { get; set; }
        public long PedidoDeRetiradaId { get; set; }

        public DateTime? DataDeDevolucao { get; set; }
    }
}
