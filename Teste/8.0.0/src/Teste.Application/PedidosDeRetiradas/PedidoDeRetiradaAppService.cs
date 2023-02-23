using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Teste.Authorization.Users;
using Teste.Livros;
using Teste.Livros.Dto;
using Teste.PedidoDeRetirada;
using Teste.PedidosDeRetiradas.Dto;
using System.Linq;
using Abp.Collections.Extensions;

namespace Teste.PedidosDeRetiradas
{
    [AbpAuthorize]
    public class PedidoDeRetiradaAppService : TesteAppServiceBase, IPedidoDeRetiradaAppService
    {
        private readonly IRepository<PedidoDeRetirada, long> _pedidoRepository;
        private readonly IRepository<PedidoDeRetiradaItens, long> _pedidoDeRetiradaItensRepository;
        private readonly IRepository<Livro, long> _livroRepository;
        private readonly IRepository<User, long> _userRepository;

        public PedidoDeRetiradaAppService(IRepository<PedidoDeRetirada, long> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task TrataCadastroDePedidoDeRetirada(PedidoDeRetiradaDto pedidoInput)
        {
            var livroExists = await _livroRepository.GetAll()
                                              .AnyAsync(x => x.Id == pedidoInput.Id);
            var userExists = await _userRepository.GetAll()
                                              .AnyAsync(x => x.Id == pedidoInput.UserId);

            if (!livroExists)
                throw new UserFriendlyException("Livro não encontrado!");

            if (!userExists)
                throw new UserFriendlyException("Usuário não encontrado!");
        }

        public async Task CreatePedidoDeRetirada(PedidoDeRetiradaDto pedidoInput)
        {
            await TrataCadastroDePedidoDeRetirada(pedidoInput);

            var Pedido = ObjectMapper.Map<PedidoDeRetirada>(pedidoInput);
            var livros = pedidoInput.Itens;

            if (livros.Count > 0)
                foreach (PedidoDeRetiradaItens livro in livros)
                    livro.Livro.Disponivel = false;
            else throw new UserFriendlyException("Não possuem Livros na requisição!");

            await _pedidoRepository.InsertAsync(Pedido);
        }

        public async Task<List<PedidoDeRetirada>> GetAllPedidosDeRetirada()
        {
            var pedidos = await _pedidoRepository.GetAllListAsync();
            return pedidos;
        }

        public async Task<List<PedidoDeRetirada>> GetAllPedidosEmAndamento()
        {
            var pedidos = await GetAllPedidosDeRetirada();
            List<PedidoDeRetiradaItens> ItensDoPedidoEmAndamento = new List<PedidoDeRetiradaItens>();
            List<PedidoDeRetirada> pedidosEmAndamento = new List<PedidoDeRetirada>();

            foreach(PedidoDeRetirada p in pedidos)
            {
                ItensDoPedidoEmAndamento = await _pedidoDeRetiradaItensRepository.GetAllListAsync(x => x.PedidoDeRetiradaId == p.Id && !x.Livro.Disponivel);
                if (!ItensDoPedidoEmAndamento.IsNullOrEmpty())
                    pedidosEmAndamento.Add(await GetPedidoById(p.Id));
            }

            return pedidosEmAndamento;
        }

        public async Task<PedidoDeRetirada> GetPedidoById(long input)
        {
            var pedido = await _pedidoRepository.FirstOrDefaultAsync(x => x.Id == input);
            return pedido;
        }

        public async Task UpdatePedido(PedidoDeRetiradaDto input)
        {
            var pedido = await GetPedidoById(input.Id);
            pedido.DataDeRetirada = input.DataRetirada;
            pedido.Id = input.Id;
            pedido.UserId = input.UserId;

            if (!pedido.Itens.IsNullOrEmpty())
            {

                foreach(PedidoDeRetiradaItens item in pedido.Itens)
                    await _pedidoDeRetiradaItensRepository.UpdateAsync(item);
            }                

            await _pedidoRepository.UpdateAsync(pedido);
        }

        public async Task DeletePedido(PedidoDeRetiradaDto input)
        {
            var delete = await GetPedidoById(input.Id);
            await _pedidoRepository.DeleteAsync(delete);
        }
    }
}
