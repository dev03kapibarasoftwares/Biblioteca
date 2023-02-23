using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teste.Authorization.Roles;
using Teste.Authorization.Users;
using Teste.Livros;
using Teste.MultiTenancy;
using Teste.PedidosDeRetiradas;

namespace Teste.EntityFrameworkCore
{
    public class TesteDbContext : AbpZeroDbContext<Tenant, Role, User, TesteDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<PedidoDeRetirada> PedidosDeRetiradas { get; set; }
        public DbSet<PedidoDeRetiradaItens> PedidoHasLivros { get; set; }
        
        public TesteDbContext(DbContextOptions<TesteDbContext> options)
            : base(options)
        {
        }
    }
}
