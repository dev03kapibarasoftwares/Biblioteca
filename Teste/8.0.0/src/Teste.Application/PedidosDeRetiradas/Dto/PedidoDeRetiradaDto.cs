using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Teste.Livros;

namespace Teste.PedidosDeRetiradas.Dto
{
    [AutoMap(typeof(PedidoDeRetirada))]
    public class PedidoDeRetiradaDto : FullAuditedEntity<long>
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public DateTime DataRetirada { get; set; }

        public List<PedidoDeRetiradaItens> Itens{ get; set; }

        [Required]
        public DateTime DataDevolucao { get; set; }

    }
}
