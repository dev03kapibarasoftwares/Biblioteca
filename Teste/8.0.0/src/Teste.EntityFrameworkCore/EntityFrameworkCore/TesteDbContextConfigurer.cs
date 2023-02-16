using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Teste.EntityFrameworkCore
{
    public static class TesteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TesteDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TesteDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
